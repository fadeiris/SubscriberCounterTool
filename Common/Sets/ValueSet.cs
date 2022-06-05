namespace SubscriberCounterTool.Common.Sets;

/// <summary>
/// 值組 
/// </summary>
public static class ValueSet
{
    /// <summary>
    /// 截圖的 Timeout
    /// </summary>
    public static readonly int ScreenshotTimeout = Properties.Settings.Default.ScreenshotTimeout;

    /// <summary>
    /// 暫停執行毫秒
    /// </summary>
    public static readonly int SleepMs = Properties.Settings.Default.SleepMs;

    /// <summary>
    /// 開發模式的暫停執行毫秒
    /// </summary>
    public static readonly int DevSleepMs = Properties.Settings.Default.DevSleepMs;

    /// <summary>
    /// 頻道名稱字串分割長度
    /// </summary>
    public static readonly int SplitLength = Properties.Settings.Default.SplitLength;

    /// <summary>
    /// 分割後的頻道名稱列數限制
    /// </summary>
    public static readonly int ChannelNameRowLimit = Properties.Settings.Default.ChannelNameRowLimit;

    /// <summary>
    /// YouTube 頻道網址
    /// </summary>
    public static readonly string YTChannelUrl = "https://www.youtube.com/channel/";

    /// <summary>
    /// YouTube 自定義頻道網址
    /// </summary>
    public static readonly string YTCustomChannelUrl = "https://www.youtube.com/c/";
}