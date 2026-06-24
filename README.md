<a name="start-building"></a>
<br>
<p align="center">
<img src="img/banner-build-26.png" alt="Microsoft Build 2026" width="1200"/>
</p>

# [Microsoft Build 2026](https://build.microsoft.com)

## 🔥 BRK206: 어디서나 내 에이전트 사용하기: GitHub Copilot SDK로 구현하는 멀티 클라이언트, 멀티 디바이스

> 이 저장소는 원본
> [microsoft/Build26-BRK206-your-agent-anywhere-multiclient-multidevice-with-github-copilot-sdk](https://github.com/microsoft/Build26-BRK206-your-agent-anywhere-multiclient-multidevice-with-github-copilot-sdk)를 remix한 버전입니다.
> 한국어 샘플 프롬프트, 대시보드 큐/상태 개선, 완료된 태스크 유지,
> 크기 조절 가능한 대시보드 패널, remix 저장소 QR 코드 등 데모에 필요한 기능을 추가했습니다.

영어 README: [README.en.md](README.en.md)

<img width='50%' alt="CopilotSDK" src="https://github.com/user-attachments/assets/0003609f-8ac5-43ed-bfea-4ab77498c57f" />

### 세션 설명

에이전트는 내 컴퓨터에서 강력하게 동작합니다. 하지만 다른 곳에서도 사용해야 한다면 어떻게 해야 할까요? 이 세션에서는 GitHub Copilot SDK를 사용해 에이전트를 만들고, 앱에 임베드하고, 여러 디바이스와 클라우드로 가져가는 방법을 보여줍니다. 로컬 에이전트를 휴대폰에서 접근할 수 있는 에이전트로 확장하고, 여러 머신과 여러 클라이언트 사이를 오가며 실행하는 흐름을 확인할 수 있습니다. 로컬에서 에이전트를 만들고 있었고 다음 단계가 궁금했다면, 이 세션이 바로 그 답입니다.

### 세션 슬라이드

*추후 추가 예정*

### 🧠 학습 목표

이 세션을 마치면 다음을 할 수 있습니다.

- GitHub Copilot 런타임을 앱에 안전하게 임베드하기
- 멀티 클라이언트, 멀티 디바이스 에이전트 배포 방식 이해하기
- GA 1.0 GitHub Copilot SDK의 새로운 기능 이해하기

### 💬 Copilot으로 계속 학습하기

이 세션의 주제를 더 탐색하려면 GitHub Copilot에서 아래 프롬프트를 사용해 보세요. VS Code에서 Copilot Chat을 열고(Windows/Linux: `Ctrl+Alt+I`, Mac: `Cmd+Shift+I`) 프롬프트를 붙여 넣어 학습할 수 있습니다. 최신 공식 문서를 참고하려면 [Microsoft Learn MCP Server](#-microsoft-learn-mcp-server)를 연결해 보세요.

아래 프롬프트를 시작점으로 사용하거나 직접 작성해 보세요.

- *GitHub Copilot SDK로 무엇을 만들 수 있나요?*
- *공개 프리뷰 이후 정식 출시된 Copilot SDK에는 무엇이 새로워졌나요?*
- *Copilot SDK는 어떤 언어를 지원하나요?*
- *인증은 어떻게 설정하나요?*

### 📚 리소스와 다음 단계

| 리소스 | 설명 |
|:------|:-----|
| [GitHub Copilot SDK Repo](https://github.com/github/copilot-sdk?utm_source=build-brk206-related-copilot-sdk-repo-cta&utm_medium=event&utm_campaign=msbuild-2026) | 6개 언어의 Copilot SDK를 확인할 수 있습니다 |
| [GitHub Copilot SDK Cookbooks](https://github.com/github/awesome-copilot?utm_source=build-brk206-related-awesome-copilot-cookbooks-cta&utm_medium=event&utm_campaign=msbuild-2026) | 커스텀 에이전트, instructions, skills, hooks, workflows, plugins 예제를 확인할 수 있습니다 |
| [GitHub Copilot SDK Getting Started Guide](https://github.com/github/copilot-sdk/blob/main/docs/getting-started.md?utm_source=build-brk206-related-sdk-getting-started-cta&utm_medium=event&utm_campaign=msbuild-2026) | 첫 Copilot 기반 앱을 만드는 가이드입니다 |

### 🚀 배포 참고 사항

이 데모는 SignalR/WebSockets, GitHub Copilot SDK, JSON 파일에서 seed되는 로컬 SQLite 데이터베이스를 사용하는 .NET Blazor Server 앱입니다. 정적 웹 앱이 아니므로 ASP.NET Core 서버 프로세스를 실행할 수 있는 서비스에 배포해야 합니다.

| 옵션 | 사용하는 인프라 | 예상 설정 시간 | 예상 비용 |
|:-----|:---------------|:---------------|:----------|
| Azure App Service(데모용 추천) | App Service Plan, Linux Web App, WebSockets 활성화, 애플리케이션 로그 | 30-60분 | Basic B1 기준 지역에 따라 약 $13-20 USD/월 |
| Azure Container Apps | Container Apps Environment, Container App, 이미지 레지스트리, HTTP ingress | 1-2시간 | 가벼운 사용량은 매우 낮을 수 있지만, 항상 켜두는 데모는 활성 vCPU/메모리 초에 따라 달라질 수 있습니다 |

배포 시 고려할 점:

- Azure App Service를 사용할 때는 Blazor Server/SignalR을 위해 WebSockets를 활성화하세요.
- SQLite 데이터베이스 경로는 앱 바이너리 디렉터리에서 App Service의 `/home/data/properties.db` 같은 persistent writable storage로 옮기는 것이 좋습니다.
- 자격 증명과 토큰은 저장소에 넣지 마세요. 환경 변수나 플랫폼 설정을 사용하세요.
- 짧은 컨퍼런스 데모에는 App Service가 가장 단순하고 예측 가능한 선택입니다. 이미 컨테이너 워크플로가 있다면 Container Apps도 좋은 대안입니다.

### 관련 랩

| Lab | 제목 | 저장소 |
|-----|------|--------|
| LAB500 | Terminal to Party: Live-Coding with GitHub Copilot CLI and Hydra | https://github.com/microsoft/Build26-LAB500-terminal-to-party-live-coding-with-github-copilot-cli-and-hydra |
| LAB502 | Make GitHub Copilot Work Your Way: Custom Tools, Context and Workflows | https://github.com/microsoft/Build26-LAB502-make-github-copilot-work-your-way-custom-tools-context-and-workflows |

### 🌟 Microsoft Learn MCP Server

Microsoft Learn MCP Server는 AI 에이전트가 Microsoft 공식 문서에 직접 접근할 수 있게 해 줍니다. 이 세션에서 다루는 제품과 서비스에 대해 최신 공식 문서에 기반한 답변을 받을 수 있습니다.

**VS Code** — 원클릭 설치:

[![Install in VS Code](https://img.shields.io/badge/VS_Code-Install_Microsoft_Learn_MCP-0098FF?style=flat-square&logo=visualstudiocode&logoColor=white)](https://vscode.dev/redirect/mcp/install?name=microsoft-learn&config=%7B%22type%22%3A%22http%22%2C%22url%22%3A%22https%3A%2F%2Flearn.microsoft.com%2Fapi%2Fmcp%22%7D)

**GitHub Copilot CLI** — Learn MCP Server를 플러그인으로 설치하려면 다음을 실행하세요.

```
/plugin install microsoftdocs/mcp
```

자세한 정보, 다른 클라이언트, 질문 등록은 [Learn MCP Server repo](https://aka.ms/learnmcp)를 참고하세요.

## 콘텐츠 오너

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

## 기여

이 프로젝트는 기여와 제안을 환영합니다. 대부분의 기여에는 Contributor License Agreement(CLA)에 동의해야 합니다. CLA는 여러분이 기여할 권리가 있으며, 실제로 해당 기여를 사용할 권리를 프로젝트에 부여한다는 내용을 확인합니다. 자세한 내용은 [Contributor License Agreements](https://cla.opensource.microsoft.com)를 참고하세요.

Pull request를 제출하면 CLA bot이 CLA 제출 필요 여부를 자동으로 판단하고 PR에 상태 확인이나 댓글을 추가합니다. bot이 안내하는 절차를 따르면 됩니다. Microsoft CLA를 사용하는 저장소 전체에서 이 절차는 한 번만 완료하면 됩니다.

이 프로젝트는 [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)를 따릅니다. 자세한 내용은 [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)를 참고하거나 [opencode@microsoft.com](mailto:opencode@microsoft.com)으로 문의하세요.

## 상표

이 프로젝트에는 프로젝트, 제품 또는 서비스의 상표나 로고가 포함될 수 있습니다. Microsoft 상표나 로고를 사용할 때는 [Microsoft Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)를 따라야 합니다. 수정된 버전에서 Microsoft 상표나 로고를 사용할 경우 혼동을 일으키거나 Microsoft의 후원을 암시해서는 안 됩니다. 타사 상표나 로고 사용에는 해당 타사의 정책이 적용됩니다.
