namespace SubscriberCounterTool;

// 阻擋設計工具。
partial class DesignerBlocker { };

public partial class MainForm
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ToolTip SharedTooltip = new();
}