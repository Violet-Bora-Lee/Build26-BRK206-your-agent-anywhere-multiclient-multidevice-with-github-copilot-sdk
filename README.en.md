<a name="start-building"></a>
<br>
<p align="center">
<img src="img/banner-build-26.png" alt="Microsoft Build 2026" width="1200"/>
</p>

# [Microsoft Build 2026](https://build.microsoft.com)

## 🔥 BRK206: Your agent, anywhere: MultiClient, MultiDevice with GitHub Copilot SDK

> This repository is a remix of the original
> [microsoft/Build26-BRK206-your-agent-anywhere-multiclient-multidevice-with-github-copilot-sdk](https://github.com/microsoft/Build26-BRK206-your-agent-anywhere-multiclient-multidevice-with-github-copilot-sdk).
> It adds demo-focused updates including Korean sample prompts, dashboard queue/status improvements,
> persistent completed tasks, a resizable dashboard panel, and an on-screen QR code for the remixed repo.

Korean README: [README.md](README.md)

Live demo: [https://brk206-violet-06241731.azurewebsites.net/](https://brk206-violet-06241731.azurewebsites.net/)

<img width='50%' alt="CopilotSDK" src="https://github.com/user-attachments/assets/0003609f-8ac5-43ed-bfea-4ab77498c57f" />

### Session Description

Agents are powerful on your machine, but what happens when you need them everywhere else? In this session, we'll show how GitHub Copilot SDK lets you build an agent, embed it in an app, and take it with you across devices and into the cloud. You'll see how to go from a local agent to one you can access on your phone, move between machines, and run across multiple clients. If you've been working with agents locally and wondering what the next step looks like, this is it.

### Session Slides
*Will be added soon*

### 🧠 Learning Outcomes

By the end of this session, you will be able to:

- Embed GitHub Copilot's runtime into any app securely
- Understand multi-client, multi-device agent deployment
- Know what is new in the new GA 1.0 GitHub Copilot SDK

### 💬 Keep Learning with Copilot

Try these prompts with GitHub Copilot to explore the topics from this session. Open Copilot Chat in VS Code (`Ctrl+Alt+I` on Windows/Linux, `Cmd+Shift+I` on Mac), paste a prompt, and see what you learn. Try connecting the [Microsoft Learn MCP Server](#-microsoft-learn-mcp-server) for the latest official documentation.

Use these as a starting point — or write your own!

- *What can I make with the GitHub Copilot SDK*
- *What's new in the generally available Copilot SDK since public preview?*
- *What languages is the Copilot SDK available in?*
- *How do I set up authentication?*

### 📚 Resources and Next Steps

| Resource | Description |
|:---------|:------------|
| [GitHub Copilot SDK Repo](https://github.com/github/copilot-sdk?utm_source=build-brk206-related-copilot-sdk-repo-cta&utm_medium=event&utm_campaign=msbuild-2026) | Access all Copilot SDK in all 6 languages |
| [GitHub Copilot SDK Cookbooks](https://github.com/github/awesome-copilot?utm_source=build-brk206-related-awesome-copilot-cookbooks-cta&utm_medium=event&utm_campaign=msbuild-2026) | Custom agents, instructions, skills, hooks, workflows, and plugins |
| [GitHub Copilot SDK Getting Started Guide](https://github.com/github/copilot-sdk/blob/main/docs/getting-started.md?utm_source=build-brk206-related-sdk-getting-started-cta&utm_medium=event&utm_campaign=msbuild-2026) | Build your first Copilot-powered app |

### 🚀 Deployment Notes

This demo is a .NET Blazor Server app that uses SignalR/WebSockets, the GitHub Copilot SDK,
and a local SQLite database seeded from JSON files. It is not a static web app, so deploy it
to a service that can run an ASP.NET Core server process.

| Option | What it uses | Estimated setup time | Estimated cost |
|:-------|:-------------|:---------------------|:---------------|
| Azure App Service (recommended for demos) | App Service Plan, Linux Web App, WebSockets enabled, application logs | 30-60 minutes | Basic B1 is roughly $13-20 USD/month depending on region |
| Azure Container Apps | Container Apps Environment, Container App, image registry, HTTP ingress | 1-2 hours | Consumption can be very low for light usage, but always-on demos may vary by active vCPU/memory seconds |

Deployment considerations:

- Enable WebSockets for Blazor Server/SignalR when using Azure App Service.
- Move the SQLite database path from the app binary directory to persistent writable storage
  such as `/home/data/properties.db` on App Service.
- Keep credentials and tokens out of the repository. Use environment variables or platform
  configuration for any deployment-time secrets.
- For a short-lived conference demo, App Service is the simplest and most predictable option.
  Container Apps is a good alternative if you already have a container workflow.

### Related Labs

| Lab | Title | Repo |
|-----|-------|------|
| LAB500 | Terminal to Party: Live-Coding with GitHub Copilot CLI and Hydra | https://github.com/microsoft/Build26-LAB500-terminal-to-party-live-coding-with-github-copilot-cli-and-hydra |
| LAB502 | Make GitHub Copilot Work Your Way: Custom Tools, Context and Workflows | https://github.com/microsoft/Build26-LAB502-make-github-copilot-work-your-way-custom-tools-context-and-workflows |

### 🌟 Microsoft Learn MCP Server

The Microsoft Learn MCP Server gives your AI agent direct access to Microsoft's official documentation — grounded, up-to-date answers about the products and services covered in this session.

**VS Code** — One click installation:

[![Install in VS Code](https://img.shields.io/badge/VS_Code-Install_Microsoft_Learn_MCP-0098FF?style=flat-square&logo=visualstudiocode&logoColor=white)](https://vscode.dev/redirect/mcp/install?name=microsoft-learn&config=%7B%22type%22%3A%22http%22%2C%22url%22%3A%22https%3A%2F%2Flearn.microsoft.com%2Fapi%2Fmcp%22%7D)

**GitHub Copilot CLI** — Run this to install the Learn MCP Server as a plugin:

```
/plugin install microsoftdocs/mcp
```

For more info, other clients, and to post questions, visit the [Learn MCP Server repo](https://aka.ms/learnmcp).

## Content Owners

<table>
<tr>
    <td align="center"><a href="http://github.com/patniko">
        <img src="https://github.com/patniko.png" width="100px;" alt="Patrick Nikoletich"/><br />
        <sub><b>Patrick Nikoletich</b></sub></a><br />
            <a href="https://github.com/patniko" title="Distinguished Product Manager">📢</a>
    </td>
     <td align="center"><a href="http://github.com/stevesandersonms">
        <img src="https://github.com/stevesandersonms.png" width="100px;" alt="Steve Sanderson"/><br />
        <sub><b>Steve Sanderson</b></sub></a><br />
            <a href="https://github.com/patniko" title="Principal Software Engineer">📢</a>
    </td>
</tr></table>

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit [Contributor License Agreements](https://cla.opensource.microsoft.com).

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft
trademarks or logos is subject to and must follow
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
