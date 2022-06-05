namespace SubscriberCounterTool.Common.Sets;

/// <summary>
/// 選擇器組
/// </summary>
public static class SelectorSet
{
    /// <summary>
    /// 標頭區塊
    /// </summary>
    public static readonly string HeaderBlock = "#app > div > div:nth-child(2) > header";

    /// <summary>
    /// 對話視窗的我瞭解按鈕
    /// </summary>
    public static readonly string AlertDialogButton = "text=I understand";

    /// <summary>
    /// 圖表區塊
    /// </summary>
    public static readonly string ChartBlock = "#app > div > div.index__content--3Rn7r > div.index__fullscreenContainer--1wQ3Q > div > div.index__chartContainer--Q2DDx";

    /// <summary>
    /// 頻道名稱區塊
    /// </summary>
    public static readonly string ChannelNameBlock = "#app > div > div.index__content--3Rn7r > div.index__fullscreenContainer--1wQ3Q > div > span.index__channelName--8wD56";

    /// <summary>
    /// 前綴文字
    /// </summary>
    public static readonly string PrefixText = "text=CURRENTLY HAS";

    /// <summary>
    /// 後綴文字
    /// </summary>
    public static readonly string SuffixText = "text=YOUTUBE SUBSCRIBERS";

    /// <summary>
    /// 套用中文翻譯的後綴文字
    /// </summary>
    public static readonly string TranslateSuffixText = "text=位 YouTube 訂閱者";

    /// <summary>
    /// 訂閱者數字區塊
    /// </summary>
    public static readonly string SubscribersBlock = "#app > div > div.index__content--3Rn7r > div.index__fullscreenContainer--1wQ3Q > div > div.index__subscriberCountAmount--xCo5w > div > div > div";

    /// <summary>
    /// 設定按鈕
    /// </summary>
    public static readonly string SettingButton = "#app > div > div:nth-child(2) > header > div.index__headerIcons--16OLo > img.index__headerIconSettings--39iKs";

    /// <summary>
    /// 模糊背景勾選框
    /// </summary>
    public static readonly string BlurBackgroundCheckbox = "#app > div > div:nth-child(2) > div:nth-child(4) > div.index__modalContent--1xqbZ > div.index__modal--2Lv_s > div:nth-child(3) > label > div > span.index__checkboxBefore--2zVxP";

    /// <summary>
    /// 關閉按鈕
    /// </summary>
    public static readonly string CloseButton = "#app > div > div:nth-child(2) > div:nth-child(4) > div.index__modalContent--1xqbZ > span > img";
}