using GitHub.Copilot;
using System.Collections.Concurrent;
using System.Threading;

namespace AgentOrchestrator;

public class AppState(PropertyDatabase propertyDatabase, IWebHostEnvironment environment)
{
    private int totalCompleted;
    private int totalRejected;
    private readonly ConcurrentDictionary<string, byte> countedOutcomes = new();

    private readonly CopilotClient copilotClient = CreateCopilotClient(environment);

    public ConcurrentDictionary<string, Agent> Agents { get; } = new();
    public int TotalCompleted => totalCompleted;
    public int TotalRejected => totalRejected;
    public event Action? UpdateUi;

    public async Task RunAgentAsync(string enquiry)
    {
        var agentId = Guid.NewGuid().ToString("N")[..8];
        var agent = new Agent(agentId, enquiry, propertyDatabase, OnAgentChanged);
        Agents[agentId] = agent;
        NotifyChanged();
        Console.WriteLine($"Created agent {agentId}");

        try
        {
            await agent.RunAsync(copilotClient);
            CountOutcomeIfFinished(agent);
            NotifyChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error running agent {agentId}: {ex}");
            CountRejected(agentId);
            NotifyChanged();
        }
    }

    public void NotifyChanged()
        => UpdateUi?.Invoke();

    private static CopilotClient CreateCopilotClient(IWebHostEnvironment environment)
    {
        var directory = environment.IsDevelopment()
            ? AppContext.BaseDirectory
            : Path.Combine(Environment.GetEnvironmentVariable("HOME") ?? AppContext.BaseDirectory, "data");
        Directory.CreateDirectory(directory);
        return new(new()
        {
            Mode = CopilotClientMode.Empty,
            BaseDirectory = Path.Combine(directory, ".copilot"),
        });
    }

    private void OnAgentChanged(Agent agent)
    {
        CountOutcomeIfFinished(agent);
        NotifyChanged();
    }

    private void CountOutcomeIfFinished(Agent agent)
    {
        if (!PipelineConfig.Nodes[agent.Phase].IsFinished || !countedOutcomes.TryAdd(agent.Id, 0))
        {
            return;
        }

        agent.FinishedAt ??= DateTime.UtcNow;
        if (agent.Phase == Phase.Done)
        {
            Interlocked.Increment(ref totalCompleted);
        }
        else
        {
            Interlocked.Increment(ref totalRejected);
        }
    }

    private void CountRejected(string agentId)
    {
        if (countedOutcomes.TryAdd(agentId, 0))
        {
            Interlocked.Increment(ref totalRejected);
        }
    }
}
