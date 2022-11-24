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
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VolumeController
{
    public partial class Form1 : Form
    {

        //private VolumeController vc = new VolumeController();

        MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
        public MMDevice device;


        // サンプル再生用の準備
        WaveOutEvent waveOut = new WaveOutEvent();
        AudioFileReader afr = new AudioFileReader("C:\\Users\\s192034.TSITCL\\OneDrive - Cyber University\\School\\卒業研究\\GraduationResearch\\VolumeController\\VolumeController\\400hz-6db-20sec.wav");

        public Form1()
        {
            InitializeComponent();

            device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // 現在の音量を取得して、初期値として設定
            label2.Text = System.Convert.ToString(GetVolume());
            volume_trackBar.Value = GetVolume();
            // デバイスの一覧を取得
            comboBox1.Items.AddRange(GetDevices());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                
                var device = (MMDevice)comboBox1.SelectedItem;
                // progressBar1の値を変更
                progressBar1.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
                progres_value.Text = System.Convert.ToString(progressBar1.Value);

                // 音量を取得
                var volume = GetVolume();
                // Debug.WriteLine(progressBar1.Value * volume);
                Debug.WriteLine(progressBar1.Value + volume);

                // 最大の音量を制限
                if ((progressBar1.Value * volume) > (max_trackBar.Value * 100))
                {
                    // volumeの大きさによって下げる音量の幅を変更する
                    SetVolume(volume - (int)Math.Ceiling((double)volume / 10.0d));
                    volume_trackBar.Value = volume;
                }

                // 最小の音量を制限
                if ((progressBar1.Value * volume) < (min_trackBar.Value * volume))
                {
                    // volumeの大きさによって下げる音量の幅を変更する
                    SetVolume(volume + (int)Math.Ceiling((double)volume / 10.0d));
                    volume_trackBar.Value = volume;
                }

                // サンプル音源のループ
                afr.Position = 0;
                /*
                 ループが出来ているかを20秒の音源でテストする！！！！！
                これが出来たら完成かな～
                音の最大値をへんこう
                 */
            }
        }

        private void volume_trackBar_Scroll(object sender, EventArgs e)
        {
            SetVolume(volume_trackBar.Value);
        }

        private void max_trackBar_Scroll(object sender, EventArgs e)
        {
            max_volume.Text = System.Convert.ToString(max_trackBar.Value);
        }

        private void min_trackBar_Scroll(object sender, EventArgs e)
        {
            min_volume.Text = System.Convert.ToString(min_trackBar.Value);
        }

        private void media_btn_Click(object sender, EventArgs e)
        {
            if (waveOut.PlaybackState == PlaybackState.Stopped)
            {
                waveOut.Init(afr);
                waveOut.Play();
                media_btn.Text = "stop";
            }
            else if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Stop();
                media_btn.Text = "play";
            }
        }

        private void max_btn_Click(object sender, EventArgs e)
        {
            //max_trackBar.Value = (int)Math.Floor((double)(GetVolume() * (progressBar1.Value / 100)) * 100.0d);
            max_trackBar.Value = (int)(GetVolume() * (progressBar1.Value / 100.0d)) * 100;
            max_volume.Text = System.Convert.ToString(max_trackBar.Value) + "%";
        }

        private void min_btn_Click(object sender, EventArgs e)
        {
            //min_trackBar.Value = (int)Math.Floor((double)(GetVolume() * progressBar1.Value) / 100.0d);
            min_trackBar.Value = (int)(GetVolume() * (progressBar1.Value / 100.0d)) * 100;
            min_volume.Text = System.Convert.ToString(min_trackBar.Value * 100) + "%";
        }

        /*
        public void update()
        {

        }
        */


        // メソッド:音量の変更
        public int SetVolume(int volume)
        {
            // 音量を変更（範囲：0.0～1.0）
            volume = volume < 0 ? 0 : volume;
            device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)volume / 100.0f);
            volume_trackBar.Value = volume;
            label2.Text = System.Convert.ToString(volume);


            return GetVolume();
        }

        // メソッド：音量の取得 return：0.00～1.00 
        public int GetVolume()
        {
            return (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar);
        }

        // メソッド：デバイスの一覧を取得
        public object[] GetDevices()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            return devices.ToArray();
        }

    }

    /*
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
            volume = volume < 0 ? 0 : volume;
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
    */
}