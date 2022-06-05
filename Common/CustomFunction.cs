using HtmlAgilityPack;
using Microsoft.Playwright;
using Microsoft.Win32;
using SubscriberCounterTool.Common.Sets;
using SubscriberCounterTool.Extensions;
using System.Diagnostics;

namespace SubscriberCounterTool.Common;

public static class CustomFunction
{
    /// <summary>
    /// 設定 HTML 碼
    /// </summary>
    /// <param name="value">字串，值</param>
    /// <returns>字串</returns>
    public static string SetHTML(char value)
    {
        string output;

        if (value == ',')
        {
            output = "<span class=\\\"odometer-formatting-mark\\\">,</span>";
        }
        else
        {
            output = "<span class=\\\"odometer-digit\\\">" +
                "<span class=\\\"odometer-digit-spacer\\\">8</span>" +
                "<span class=\\\"odometer-digit-inner\\\">" +
                "<span class=\\\"odometer-ribbon\\\">" +
                "<span class=\\\"odometer-ribbon-inner\\\"" +
                $"<span class=\\\"odometer-channelName\\\">{value}</span>" +
                "</span>" +
                "</span>" +
                "</span>" +
                "</span>";
        }

        return output;
    }

    /// <summary>
    /// 取得 Clip
    /// </summary>
    /// <param name="control">TextBox</param>
    /// <param name="subscriberAmount">數值，訂閱者的數量</param>
    /// <returns>Clip</returns>
    public static Clip? GetClip(TextBox control, decimal subscriberAmount)
    {
        Clip? clip;

        if (subscriberAmount == -1)
        {
            clip = null;
        }
        else if (subscriberAmount <= 9999999)
        {
            clip = new()
            {
                X = 390,
                Y = 135,
                Width = 500,
                Height = 500
            };
        }
        else if (subscriberAmount <= 99999999)
        {
            clip = new()
            {
                X = 340,
                Y = 115,
                Width = 600,
                Height = 600
            };
        }
        else if (subscriberAmount <= 999999999)
        {
            clip = new()
            {
                X = 290,
                Y = 15,
                Width = 700,
                Height = 700
            };
        }
        else
        {
            clip = null;

            WriteLog(control, "訂閱者數字已超過可以顯示的範圍，故不將截圖裁切成正方形。");
        }

        return clip;
    }

    /// <summary>
    /// 取得 int[]
    /// </summary>
    /// <param name="channelName">字串，頻道名稱</param>
    /// <returns>數值陣列</returns>
    public static int[] GetIntArray(string channelName)
    {
        int step = channelName.Length / ValueSet.SplitLength;
        int leftNum = channelName.Length % ValueSet.SplitLength;

        if (leftNum != 0)
        {
            step++;
        }

        int[] output = new int[step];

        for (int i = 0; i < step; i++)
        {
            if (leftNum == 0)
            {
                output[i] = ValueSet.SplitLength;
            }
            else
            {
                if (i != step - 1)
                {
                    output[i] = ValueSet.SplitLength;
                }
                else
                {
                    output[i] = leftNum;
                }
            }
        }

        return output;
    }

    /// <summary>
    /// 偵測網頁瀏覽器
    /// </summary>
    /// <param name="control">TextBox</param>
    /// <param name="forceChromium">布林值，是否強制使用 Chromium，預設值為 false</param>
    /// <returns>Task&lt;string&gt;</returns>
    public static async Task<string> DetectBrowser(TextBox control, bool forceChromium = false)
    {
        string browser = "chromuim";

        if (IsBrowserInstalled("chrome"))
        {
            browser = "chrome";
        }
        else if (IsBrowserInstalled("edge"))
        {
            browser = "msedge";
        }
        else
        {
            await InstallPlaywrightBrowser(control);
        }

        if (forceChromium)
        {
            browser = "chromium";

            await InstallPlaywrightBrowser(control);
        }

        return browser;
    }

    /// <summary>
    /// 安裝 Playwright 的網頁瀏覽器
    /// </summary>
    /// <param name="control">TextBox</param>
    /// <returns>Task</returns>
    public static async Task InstallPlaywrightBrowser(TextBox control)
    {
        await Task.Run(() =>
        {
            try
            {
                // 安裝 Playwright 的瀏覽器。
                int exitCode = Microsoft.Playwright.Program.Main(new[] { "install", "chromium" });

                if (exitCode != 0)
                {
                    throw new Exception($"Playwright 已結束，離開碼：{exitCode}");
                }

                WriteLog(control, "Playwright 瀏覽器的路徑：");
                WriteLog(control, $@"C:\Users\{Environment.UserName}\AppData\Local\ms-playwright");
            }
            catch (Exception e)
            {
                WriteLog(control, e.Message);
            }
        });
    }

    /// <summary>
    /// 檢查網頁瀏覽器是否已安裝
    /// <para>來源： https://quomodo-info.com/csharp-check-if-webbrowser-is-installed/</para>
    /// </summary>
    /// <param name="browserName">字串，網頁瀏覽器的名稱</param>
    /// <returns>布林值</returns>
    public static bool IsBrowserInstalled(string browserName)
    {
        bool isInstalled = false;

        RegistryKey? browsersNode = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

        if (browsersNode != null)
        {
            foreach (string browser in browsersNode.GetSubKeyNames())
            {
                if (browser.ToLower().Contains(browserName.ToLower()))
                {
                    isInstalled = true;

                    break;
                }
            }
        }

        return isInstalled;
    }


    /// <summary>
    /// 寫紀錄
    /// </summary>
    /// <param name="control">TextBox，TBLog</param>
    /// <param name="message">字串，訊息</param>
    /// <param name="enableDebug">布林值，輸出 Debug，預設值為 false</param>
    /// <param name="enableAutoClear">布林值，自動執行 TextBox.Clear()，預設值為 true</param>
    public static void WriteLog(TextBox control,
        string message,
        bool enableDebug = false,
        bool enableAutoClear = true)
    {
        try
        {
            // 當 message 不為空白或空值時才輸出。
            if (!string.IsNullOrEmpty(message))
            {
                control.InvokeIfRequired(() =>
                {
                    string outputMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

                    if (enableDebug)
                    {
                        Debug.WriteLine(outputMessage);
                    }

                    outputMessage += Environment.NewLine;

                    if (enableAutoClear)
                    {
                        // 預測文字字串長度。
                        int predictTextLength = control.Text.Length + outputMessage.Length;

                        // 當 predictTextLength 大於或等於 TextBox 的上限值時。
                        if (predictTextLength >= control.MaxLength)
                        {
                            // 清除 TextBox。
                            control.Clear();

                            if (enableDebug)
                            {
                                Debug.WriteLine("已執行 TextBox.Clear()。");
                            }
                        }
                    }

                    control.AppendText(outputMessage);
                });
            }
            else
            {
                Debug.WriteLine("變數 message 為空白或是空值。");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"輸入的訊息：{message}");
            Debug.WriteLine(ex);
        }
    }

    /// <summary>
    /// 開啟網址
    /// </summary>
    /// <param name="url">字串，網址</param>
    /// <returns>Process</returns>
    public static Process? OpenUrl(string url)
    {
        return Process.Start(new ProcessStartInfo()
        {
            FileName = url,
            UseShellExecute = true
        });
    }

    /// <summary>
    /// 取得 YouTube 頻道的 ID
    /// </summary>
    /// <param name="url">字串，YouTube 頻道的網址</param>
    /// <returns>字串</returns>
    public static string GetYTChannelID(string url)
    {
        string channelID = string.Empty;

        HtmlWeb htmlWeb = new();
        HtmlAgilityPack.HtmlDocument htmlDocument = htmlWeb.Load(url);

        HtmlNodeCollection metaTags = htmlDocument.DocumentNode.SelectNodes("//meta");

        if (metaTags != null)
        {
            HtmlNode? ogUrl = metaTags.FirstOrDefault(n => n.Attributes["property"] != null &&
                n.Attributes["content"] != null &&
                n.Attributes["property"].Value == "og:url");

            if (ogUrl != null)
            {
                channelID = ogUrl.Attributes["content"].Value;
            }
        }

        return channelID;
    }
}