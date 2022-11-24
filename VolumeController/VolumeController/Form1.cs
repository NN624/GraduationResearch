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


        // �T���v���Đ��p�̏���
        WaveOutEvent waveOut = new WaveOutEvent();
        AudioFileReader afr = new AudioFileReader("C:\\Users\\s192034.TSITCL\\OneDrive - Cyber University\\School\\���ƌ���\\GraduationResearch\\VolumeController\\VolumeController\\400hz-6db-20sec.wav");

        public Form1()
        {
            InitializeComponent();

            device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // ���݂̉��ʂ��擾���āA�����l�Ƃ��Đݒ�
            label2.Text = System.Convert.ToString(GetVolume());
            volume_trackBar.Value = GetVolume();
            // �f�o�C�X�̈ꗗ���擾
            comboBox1.Items.AddRange(GetDevices());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                
                var device = (MMDevice)comboBox1.SelectedItem;
                // progressBar1�̒l��ύX
                progressBar1.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
                progres_value.Text = System.Convert.ToString(progressBar1.Value);

                // ���ʂ��擾
                var volume = GetVolume();
                // Debug.WriteLine(progressBar1.Value * volume);
                Debug.WriteLine(progressBar1.Value + volume);

                // �ő�̉��ʂ𐧌�
                if ((progressBar1.Value * volume) > (max_trackBar.Value * 100))
                {
                    // volume�̑傫���ɂ���ĉ����鉹�ʂ̕���ύX����
                    SetVolume(volume - (int)Math.Ceiling((double)volume / 10.0d));
                    volume_trackBar.Value = volume;
                }

                // �ŏ��̉��ʂ𐧌�
                if ((progressBar1.Value * volume) < (min_trackBar.Value * volume))
                {
                    // volume�̑傫���ɂ���ĉ����鉹�ʂ̕���ύX����
                    SetVolume(volume + (int)Math.Ceiling((double)volume / 10.0d));
                    volume_trackBar.Value = volume;
                }

                // �T���v�������̃��[�v
                afr.Position = 0;
                /*
                 ���[�v���o���Ă��邩��20�b�̉����Ńe�X�g����I�I�I�I�I
                ���ꂪ�o�����犮�����ȁ`
                ���̍ő�l���ւ񂱂�
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


        // ���\�b�h:���ʂ̕ύX
        public int SetVolume(int volume)
        {
            // ���ʂ�ύX�i�͈́F0.0�`1.0�j
            volume = volume < 0 ? 0 : volume;
            device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)volume / 100.0f);
            volume_trackBar.Value = volume;
            label2.Text = System.Convert.ToString(volume);


            return GetVolume();
        }

        // ���\�b�h�F���ʂ̎擾 return�F0.00�`1.00 
        public int GetVolume()
        {
            return (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar);
        }

        // ���\�b�h�F�f�o�C�X�̈ꗗ���擾
        public object[] GetDevices()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            return devices.ToArray();
        }

    }

    /*
    // ���ʒ���������
    class VolumeController
    {
        public MMDevice device;

        // VolumeController�̃R���X�g���N�^�[
        public VolumeController()
        {
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }

        // ���\�b�h:���ʂ̕ύX
        public int SetVolume(int volume)
        {
            // ���ʂ�ύX�i�͈́F0.0�`1.0�j
            volume = volume < 0 ? 0 : volume;
            device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)volume / 100.0f);

            return GetVolume();
        }

        // ���\�b�h�F���ʂ̎擾
        public int GetVolume()
        {
            return (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        }

        // ���\�b�h�F�f�o�C�X�̈ꗗ���擾
        public object[] GetDevices()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            return devices.ToArray();
        }
    }
    */
}