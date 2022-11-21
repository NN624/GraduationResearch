using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VolumeController
{
    public partial class Form1 : Form
    {

        private VolumeController vc = new VolumeController();
        public Form1()
        {
            InitializeComponent();
            // 現在の音量を取得して、初期値として設定
            label2.Text = System.Convert.ToString(vc.GetVolume());
            trackBar1.Value = vc.GetVolume();
            // デバイスの一覧を取得
            comboBox1.Items.AddRange(vc.GetDevices());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // パーの値を変更
                var device = (MMDevice)comboBox1.SelectedItem;
                progressBar1.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
                // Debug.WriteLine(device.AudioMeterInformation.MasterPeakValue);
                // Debug.WriteLine(progressBar1.Value);

                // 音量を取得
                var volume = vc.GetVolume();
                Debug.WriteLine(progressBar1.Value * volume);

                // 音量を制限
                if (progressBar1.Value * volume > 2000)
                {
                    label2.Text = System.Convert.ToString(vc.SetVolume(volume - 10));
                    trackBar1.Value = volume;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            vc.SetVolume(trackBar1.Value);
            label2.Text = System.Convert.ToString(vc.SetVolume(trackBar1.Value));
        }
    }

    // 音量調整をする
    class VolumeController
    {
        public MMDevice device;

        // VolumeControllerのコンストラクター
        public VolumeController()
        {
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }

        // メソッド:音量の変更
        public int SetVolume(int volume)
        {
            // 音量を変更（範囲：0.0～1.0）
            device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)volume / 100.0f);
            return GetVolume();
        }

        // メソッド：音量の取得
        public int GetVolume()
        {
            return (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        }

        // メソッド：デバイスの一覧を取得
        public object[] GetDevices()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            return devices.ToArray();
        }
    }
}