using SubscriberCounterTool.Common;
using SubscriberCounterTool.Common.Sets;
using SubscriberCounterTool.Extensions;

namespace SubscriberCounterTool;

public partial class MainForm : Form
{
    public MainForm(IHttpClientFactory httpClientFactory)
    {
        InitializeComponent();

        _httpClientFactory = httpClientFactory;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        CustomInit();
        CheckAppVersion();
    }

    private void TBYTChannelID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TBYTChannelID.InvokeIfRequired(() =>
            {
                string channelID = TBYTChannelID.Text;

                if (!string.IsNullOrEmpty(channelID))
                {
                    if (channelID.Contains(ValueSet.YTCustomChannelUrl))
                    {
                        string retrivedChannelID = CustomFunction.GetYTChannelID(channelID);

                        if (!string.IsNullOrEmpty(retrivedChannelID))
                        {
                            channelID = retrivedChannelID;
                        }
                        else
                        {
                            channelID = channelID.Replace(
                                ValueSet.YTCustomChannelUrl,
                                string.Empty);
                        }

                        TBYTChannelID.Text = channelID;
                    }
                    else if (channelID.Contains(ValueSet.YTChannelUrl))
                    {
                        channelID = channelID.Replace(
                            ValueSet.YTChannelUrl,
                            string.Empty);

                        TBYTChannelID.Text = channelID;
                    }
                }
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    private void CBUseTranslate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CBUseTranslate.InvokeIfRequired(() =>
            {
                bool value = CBUseTranslate.Checked;

                if (value != Properties.Settings.Default.UseTranslate)
                {
                    Properties.Settings.Default.UseTranslate = value;
                    Properties.Settings.Default.Save();
                }
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    private void CBUseClip_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CBUseClip.InvokeIfRequired(() =>
            {
                bool value = CBUseClip.Checked;

                if (value != Properties.Settings.Default.UseClip)
                {
                    Properties.Settings.Default.UseClip = value;
                    Properties.Settings.Default.Save();
                }
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    private void CBAddTimestamp_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CBAddTimestamp.InvokeIfRequired(() =>
            {
                bool value = CBAddTimestamp.Checked;

                if (value != Properties.Settings.Default.AddTimestamp)
                {
                    Properties.Settings.Default.AddTimestamp = value;
                    Properties.Settings.Default.Save();
                }
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    private void CBBlurBackground_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CBBlurBackground.InvokeIfRequired(() =>
            {
                bool value = CBBlurBackground.Checked;

                if (value != Properties.Settings.Default.BlurBackground)
                {
                    Properties.Settings.Default.BlurBackground = value;
                    Properties.Settings.Default.Save();
                }
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    private void CBForceChromium_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CBForceChromium.InvokeIfRequired(() =>
            {
                bool value = CBForceChromium.Checked;

                if (value != Properties.Settings.Default.ForceChromium)
                {
                    Properties.Settings.Default.ForceChromium = value;
                    Properties.Settings.Default.Save();
                }
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    private void CBIsDevelopmentMode_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CBIsDevelopmentMode.InvokeIfRequired(() =>
            {
                bool value = CBIsDevelopmentMode.Checked;

                if (value != Properties.Settings.Default.IsDevelopmentMode)
                {
                    Properties.Settings.Default.IsDevelopmentMode = value;
                    Properties.Settings.Default.Save();
                }
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    private async void BtnTakeScreensshot_Click(object sender, EventArgs e)
    {
        try
        {
            SetControls(false);

            TBLog.InvokeIfRequired(() =>
            {
                TBLog.Clear();
            });

            bool useTranslate = false,
                useClip = false,
                addTimestamp = false,
                blurBackground = false,
                forceChromium = false,
                isDevelopmentMode = false;

            CBUseTranslate.InvokeIfRequired(() =>
            {
                useTranslate = CBUseTranslate.Checked;
            });

            CBUseClip.InvokeIfRequired(() =>
            {
                useClip = CBUseClip.Checked;
            });

            CBAddTimestamp.InvokeIfRequired(() =>
            {
                addTimestamp = CBAddTimestamp.Checked;
            });

            CBBlurBackground.InvokeIfRequired(() =>
            {
                blurBackground = CBBlurBackground.Checked;
            });

            CBForceChromium.InvokeIfRequired(() =>
            {
                forceChromium = CBForceChromium.Checked;
            });

            CBIsDevelopmentMode.InvokeIfRequired(() =>
            {
                isDevelopmentMode = CBIsDevelopmentMode.Checked;
            });

            string channelID = string.Empty;

            TBYTChannelID.InvokeIfRequired(() =>
            {
                channelID = TBYTChannelID.Text;
            });

            if (string.IsNullOrEmpty(channelID))
            {
                MessageBox.Show(
                    "請輸入 YouTube 頻道 ID。",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal customSubscriberAmount = 0;

            NUDCustomSubscriberAmount.InvokeIfRequired(() =>
            {
                customSubscriberAmount = NUDCustomSubscriberAmount.Value;
            });

            string customTimestamp = string.Empty;

            DTPTimestamp.InvokeIfRequired(() =>
            {
                customTimestamp = DTPTimestamp.Value.ToShortDateString();
            });

            SaveFileDialog saveFileDialog = new()
            {
                AddExtension = true,
                DefaultExt = ".png",
                FileName = $"Screenshot_{DateTime.Now:yyyyMMddHHmmss}",
                Filter = "PNG 圖片 (*.png)|*.png|JPEG 圖片 (*.jpg)|*.jpg",
                FilterIndex = 0
            };

            DialogResult dialogResult = saveFileDialog.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    await TakeScreenshot(channelID,
                        saveFileDialog.FileName,
                        customSubscriberAmount,
                        useTranslate,
                        useClip,
                        addTimestamp,
                        customTimestamp,
                        blurBackground,
                        forceChromium,
                        isDevelopmentMode);
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
        finally
        {
            SetControls(true);
        }
    }

    private void BtnRest_Click(object sender, EventArgs e)
    {
        try
        {
            TBYTChannelID.InvokeIfRequired(() =>
            {
                TBYTChannelID.Text = string.Empty;
            });

            NUDCustomSubscriberAmount.InvokeIfRequired(() =>
            {
                NUDCustomSubscriberAmount.Value = -1;
            });

            DTPTimestamp.InvokeIfRequired(() =>
            {
                DTPTimestamp.Value = DateTime.Now;
            });

            TBLog.InvokeIfRequired(() =>
            {
                TBLog.Clear();
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }

    private void LLWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            LLWebSite.InvokeIfRequired(() =>
            {
                if (!string.IsNullOrEmpty(TBYTChannelID.Text))
                {
                    CustomFunction.OpenUrl($"{LLWebSite.Text}channel/{TBYTChannelID.Text}");
                }
                else
                {
                    CustomFunction.OpenUrl(LLWebSite.Text);
                }
            });
        }
        catch (Exception ex)
        {
            CustomFunction.WriteLog(TBLog, ex.Message);
        }
    }
}