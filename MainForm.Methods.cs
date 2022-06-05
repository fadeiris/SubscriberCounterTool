using Microsoft.Playwright;
using SubscriberCounterTool.Common;
using SubscriberCounterTool.Common.Sets;
using SubscriberCounterTool.Extensions;
using System.Reflection;

namespace SubscriberCounterTool;

// 阻擋設計工具。
partial class DesignerBlocker { };

public partial class MainForm
{
    /// <summary>
    /// 自定義初始化
    /// </summary>
    private void CustomInit()
    {
        try
        {
            // 設定應用程式的圖示。
            Icon = Properties.Resources.app_icon;

            TBYTChannelID.InvokeIfRequired(() =>
            {
                // 設定焦點。
                TBYTChannelID.Focus();
            });

            // 載入設定值。
            CBUseTranslate.InvokeIfRequired(() =>
            {
                CBUseTranslate.Checked = Properties.Settings.Default.UseTranslate;
            });

            CBUseClip.InvokeIfRequired(() =>
            {
                CBUseClip.Checked = Properties.Settings.Default.UseClip;
            });

            CBAddTimestamp.InvokeIfRequired(() =>
            {
                CBAddTimestamp.Checked = Properties.Settings.Default.AddTimestamp;
            });

            CBBlurBackground.InvokeIfRequired(() =>
            {
                CBBlurBackground.Checked = Properties.Settings.Default.BlurBackground;
            });

            CBForceChromium.InvokeIfRequired(() =>
            {
                CBForceChromium.Checked = Properties.Settings.Default.ForceChromium;
            });

            CBIsDevelopmentMode.InvokeIfRequired(() =>
            {
                CBIsDevelopmentMode.Checked = Properties.Settings.Default.IsDevelopmentMode;
            });

            // 設定應用程式的版本號。
            LVersion.InvokeIfRequired(() =>
            {
                Version? version = Assembly.GetEntryAssembly()?.GetName().Version;

                if (version != null)
                {
                    LVersion.Text = $"版本：{version}";
                }
                else
                {
                    LVersion.Text = $"版本：無";
                }
            });

            // 設定控制項的 ToolTip。
            SharedTooltip.SetToolTip(
                TBYTChannelID,
                "支援從 YouTube 頻道網址或是 YouTube 頻道自訂網址取得 YouTube 頻道 ID");

            SharedTooltip.SetToolTip(
                CBUseTranslate,
                "僅會替換原本為英文的字串");

            SharedTooltip.SetToolTip(
                CBUseClip,
                "當「訂閱者數量」或「頻道名稱長度」超過一定值時，將不會裁切截圖");

            SharedTooltip.SetToolTip(
                CBAddTimestamp,
                "在截圖上加入日期戳記");

            SharedTooltip.SetToolTip(
                CBBlurBackground,
                "將背景模糊化");

            SharedTooltip.SetToolTip(
                 CBForceChromium,
                 "強制 Playwright 使用 Chromium");

            SharedTooltip.SetToolTip(
                 CBIsDevelopmentMode,
                 "啟用本應用程式的開發模式");

            SharedTooltip.SetToolTip(
                NUDCustomSubscriberAmount,
                "將此欄位的值保持為 -1，即表示使用網頁上的訂閱者數資料");

            SharedTooltip.SetToolTip(
                LLWebSite,
                $"點擊以開啟 {LWebSite.Text.Replace(":", string.Empty)} 網頁");

            SetControls(true);
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    /// <summary>
    /// 拍攝截圖
    /// </summary>
    /// <param name="channelId">字串，YouTube 頻道的 ID</param>
    /// <param name="inputSavedPath">字串，截圖的儲存路徑，預設值為空白</param>
    /// <param name="customSubscriberAmount">數值，自定義頻道訂閱者數量，預設值為 -1</param>
    /// <param name="useTranslate">布林值，套用中文翻譯，預設值為 false</param>
    /// <param name="useClip">布林值，將截圖裁切成正方形，預設值為 false</param>
    /// <param name="addTimestamp">布林值，加入日期戳記，預設值為 false</param>
    /// <param name="customTimestamp">字串，自定義的日期戳記，預設值為空白</param>
    /// <param name="blurBackground">布林值，模糊背景，預設值為 false</param>
    /// <param name="forceChromium">布林值，強制使用 Chromium，預設值為 false</param>
    /// <param name="isDevelopmentMode">布林值，開發模式，預設值為 false</param>
    /// <returns>Task</returns>
    private async Task TakeScreenshot(
        string channelId,
        string inputSavedPath = "",
        decimal customSubscriberAmount = -1,
        bool useTranslate = false,
        bool useClip = false,
        bool addTimestamp = false,
        string customTimestamp = "",
        bool blurBackground = false,
        bool forceChromium = false,
        bool isDevelopmentMode = false)
    {
        try
        {
            // 偵測 Playwright 使用的網頁瀏覽器。
            string browserChannel = await CustomFunction.DetectBrowser(TBLog, forceChromium);

            CustomFunction.WriteLog(TBLog, $"Playwright 使用的網頁瀏覽器頻道：{browserChannel}");

            using IPlaywright playwright = await Playwright.CreateAsync();

            await using IBrowser browser = await playwright.Chromium.LaunchAsync(new()
            {
                Channel = browserChannel,
                Headless = !isDevelopmentMode
            });

            IPage page = await browser.NewPageAsync();

            // 瀏覽 YouTube Subscriber Counter 網站。
            await page.GotoAsync($"https://subscribercounter.com/fullscreen/{channelId}");

            // 隱藏 Header 區塊。
            await page.EvalOnSelectorAsync(
                SelectorSet.HeaderBlock,
                ExpressionSet.HideElement);

            // 判斷是否要裁切截圖。
            if (useClip)
            {
                // 取頁面上的頻道名稱文字。
                string channelName = await page.InnerTextAsync(SelectorSet.ChannelNameBlock);

                channelName = channelName.TrimEnd();

                // 判斷是否需要截斷頻道名稱。
                if (channelName.Length > ValueSet.SplitLength)
                {
                    int[] intArray = CustomFunction.GetIntArray(channelName);

                    string[]? nameArray = channelName.Split(intArray);

                    if (nameArray != null)
                    {
                        if (nameArray.Length < ValueSet.ChannelNameRowLimit)
                        {
                            string newChannelName = string.Empty;

                            foreach (string str in nameArray)
                            {
                                newChannelName += $"<div>{str}</div>";
                            }

                            if (!string.IsNullOrEmpty(newChannelName))
                            {
                                // 替換文字。
                                await page.EvalOnSelectorAsync(
                                    SelectorSet.ChannelNameBlock,
                                    ExpressionSet.ChangeChannelNameBlock.Replace("{Value}", newChannelName));
                            }
                        }
                        else
                        {
                            // 當超出限制列數時，取消裁切截圖。
                            useClip = false;

                            CustomFunction.WriteLog(
                                TBLog,
                                $"因頻道名稱長度超過 {ValueSet.ChannelNameRowLimit} 列，故取消裁切截圖。");
                        }
                    }
                }
            }

            // 判斷是否要翻譯文字。
            if (useTranslate)
            {
                // 替換文字。
                await page.EvalOnSelectorAsync(
                    SelectorSet.PrefixText,
                    ExpressionSet.ChangePrefixText);

                // 替換文字。
                await page.EvalOnSelectorAsync(
                    SelectorSet.SuffixText,
                    ExpressionSet.ChangeSuffixText);
            }

            // 判斷是否要加入日期戳記
            if (addTimestamp)
            {
                // 當 customTimestamp 為空值時，使用今日。
                if (string.IsNullOrEmpty(customTimestamp))
                {
                    customTimestamp = DateTime.Now.ToShortDateString();
                }

                // 統一使用 "."。
                customTimestamp = customTimestamp
                    .Replace("/", ".")
                    .Replace("-", ".")
                    .Replace(" ", ".");

                // 替換文字。
                await page.EvalOnSelectorAsync(
                    useTranslate ? SelectorSet.TranslateSuffixText : SelectorSet.SuffixText,
                    ExpressionSet.ChangeSuffixText1Dot5.Replace("{Value}", customTimestamp));
            }

            // 點選對話視窗的按鈕。
            await page.ClickAsync(SelectorSet.AlertDialogButton);

            // 判斷是否要模糊背景。
            if (blurBackground)
            {
                // 點選設定按鈕。
                await page.EvalOnSelectorAsync(SelectorSet.SettingButton, ExpressionSet.ClickElement);

                // 點選模糊背景。
                await page.EvalOnSelectorAsync(SelectorSet.BlurBackgroundCheckbox, ExpressionSet.ClickElement);

                // 點選關閉按鈕。
                await page.EvalOnSelectorAsync(SelectorSet.CloseButton, ExpressionSet.ClickElement);
            }

            // 隱藏 Chart 區塊。
            await page.EvalOnSelectorAsync(
                SelectorSet.ChartBlock,
                ExpressionSet.HideElement);

            // 判斷是否有設定自定義訂閱數。
            if (customSubscriberAmount > 0)
            {
                string acutalNumber = string.Format("{0:N0}", customSubscriberAmount);

                string tempHtml = string.Empty;

                foreach (char c in acutalNumber.ToCharArray())
                {
                    tempHtml += $"{CustomFunction.SetHTML(c)}";
                }

                string expression = ExpressionSet.ChangeSubscribersBlock
                    .Replace("{Value}", tempHtml);

                // 設定自定義訂閱數。
                await page.EvalOnSelectorAsync(SelectorSet.SubscribersBlock, expression);
            }
            else
            {
                // 取頁面上的訂閱者數字。
                string subscriberAmount = await page.InnerTextAsync(SelectorSet.SubscribersBlock);

                // 將字串後處理。
                // 將字串後處理。
                subscriberAmount = subscriberAmount
                    .Replace("\r", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("\t", string.Empty)
                    .Replace(",", string.Empty);

                // 將處理過的字串轉換成 decimal。
                customSubscriberAmount = decimal.TryParse(subscriberAmount, out decimal parsedResult) ?
                    parsedResult : -1;
            }

            // 延後執行，讓對話視窗有時間關閉。
            Thread.Sleep(ValueSet.SleepMs);

            // 截圖的儲存路徑。
            string savedPath = string.IsNullOrEmpty(inputSavedPath) ?
                Path.Combine(
                    $@"C:\Users\{Environment.UserName}\Desktop",
                    $"Screenshot_{DateTime.Now:yyyyMMddHHmmss}.png") :
                inputSavedPath;

            // 當變數值相等時才判斷目的地的資料夾是否存在。
            if (savedPath == inputSavedPath)
            {
                string? folderPath = Path.GetDirectoryName(savedPath) ?? string.Empty;

                if (!string.IsNullOrEmpty(folderPath) &
                    !Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }

            // 取得副檔名。
            string extName = Path.GetExtension(savedPath);

            // 拍攝頁面的截圖。
            await page.ScreenshotAsync(new()
            {
                Path = savedPath,
                Timeout = ValueSet.ScreenshotTimeout,
                Clip = useClip ? CustomFunction.GetClip(TBLog, customSubscriberAmount) : null,
                Type = extName == ".png" ? ScreenshotType.Png : ScreenshotType.Jpeg
            });

            CustomFunction.WriteLog(TBLog, "已完成截圖的拍攝。");
            CustomFunction.WriteLog(TBLog, $"截圖檔案位於：{savedPath}");

            // 僅供測試使用。
            if (isDevelopmentMode)
            {
                Thread.Sleep(ValueSet.DevSleepMs);
            }
        }
        catch (Exception e)
        {
            CustomFunction.WriteLog(TBLog, e.Message);
        }
    }

    /// <summary>
    /// 設定控制項
    /// </summary>
    /// <param name="enabled">布林值，啟用，預設值為 true</param>
    private void SetControls(bool enabled = true)
    {
        try
        {
            TBYTChannelID.InvokeIfRequired(() =>
            {
                TBYTChannelID.Enabled = enabled;
            });

            NUDCustomSubscriberAmount.InvokeIfRequired(() =>
            {
                NUDCustomSubscriberAmount.Enabled = enabled;
            });

            DTPTimestamp.InvokeIfRequired(() =>
            {
                DTPTimestamp.Enabled = enabled;
            });

            CBUseTranslate.InvokeIfRequired(() =>
            {
                CBUseTranslate.Enabled = enabled;
            });

            CBUseClip.InvokeIfRequired(() =>
            {
                CBUseClip.Enabled = enabled;
            });

            CBAddTimestamp.InvokeIfRequired(() =>
            {
                CBAddTimestamp.Enabled = enabled;
            });

            CBBlurBackground.InvokeIfRequired(() =>
            {
                CBBlurBackground.Enabled = enabled;
            });

            CBForceChromium.InvokeIfRequired(() =>
            {
                CBForceChromium.Enabled = enabled;
            });

            CBIsDevelopmentMode.InvokeIfRequired(() =>
            {
                CBIsDevelopmentMode.Enabled = enabled;
            });

            BtnTakeScreensshot.InvokeIfRequired(() =>
            {
                BtnTakeScreensshot.Enabled = enabled;
            });

            BtnRest.InvokeIfRequired(() =>
            {
                BtnRest.Enabled = enabled;
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    /// <summary>
    /// 檢查應用程式的版本
    /// </summary>
    private async void CheckAppVersion()
    {
        // 取得 HttpClient。
        using HttpClient httpClient = _httpClientFactory.CreateClient();

        UpdateNotifier.CheckResult checkResult = await UpdateNotifier.CheckVersion(httpClient);

        if (!string.IsNullOrEmpty(checkResult.MessageText))
        {
            CustomFunction.WriteLog(TBLog, checkResult.MessageText);
        }

        if (checkResult.HasNewVersion &&
            !string.IsNullOrEmpty(checkResult.DownloadUrl))
        {
            DialogResult dialogResult = MessageBox.Show($"您是否要下載新版本 v{checkResult.VersionText}？",
                Text,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                CustomFunction.OpenUrl(checkResult.DownloadUrl);
            }
        }

        if (checkResult.NetVersionIsOdler &&
            !string.IsNullOrEmpty(checkResult.DownloadUrl))
        {
            DialogResult dialogResult = MessageBox.Show($"您是否要下載舊版本 v{checkResult.VersionText}？",
                Text,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                CustomFunction.OpenUrl(checkResult.DownloadUrl);
            }
        }
    }
}