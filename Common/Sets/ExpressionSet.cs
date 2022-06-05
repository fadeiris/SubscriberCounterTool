namespace SubscriberCounterTool.Common.Sets;

/// <summary>
/// 表達式組
/// </summary>
public static class ExpressionSet
{
    /// <summary>
    /// 隱藏元素
    /// </summary>
    public static readonly string HideElement = "(element) => { element.style.display = \"none\"; }";

    /// <summary>
    /// 變更前綴文字
    /// </summary>
    public static readonly string ChangePrefixText = "(element) => { element.innerHTML = \"目前已有\"; }";

    /// <summary>
    /// 變更後綴文字
    /// </summary>
    public static readonly string ChangeSuffixText = "(element) => { element.innerHTML = \"位 YouTube 訂閱者\"; }";

    /// <summary>
    /// 變更後綴文字 1.5
    /// </summary>
    public static readonly string ChangeSuffixText1Dot5 = "(element) => { element.style.textAlign = \"center\"; element.innerHTML += \"<div style=\\\"font-size: 3rem;\\\">{Value}</div>\"; }";

    /// <summary>
    /// 變更訂閱者數字區塊
    /// </summary>
    public static readonly string ChangeSubscribersBlock = "(element) => { element.innerHTML = \"{Value}\"; }";

    /// <summary>
    /// 變更頻道名稱區塊
    /// </summary>
    public static readonly string ChangeChannelNameBlock = "(element) => { element.innerHTML = \"{Value}\"; }";

    /// <summary>
    /// 點選元素
    /// </summary>
    public static readonly string ClickElement = "(element) => { element.click(); }";
}