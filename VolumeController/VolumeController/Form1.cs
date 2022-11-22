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
            // ���݂̉��ʂ��擾���āA�����l�Ƃ��Đݒ�
            label2.Text = System.Convert.ToString(vc.GetVolume());
            trackBar1.Value = vc.GetVolume();
            // �f�o�C�X�̈ꗗ���擾
            comboBox1.Items.AddRange(vc.GetDevices());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // �p�[�̒l��ύX
                var device = (MMDevice)comboBox1.SelectedItem;
                progressBar1.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));

                // ���ʂ��擾
                var volume = vc.GetVolume();
                Debug.WriteLine(progressBar1.Value * volume);

                // ���ʂ𐧌�
                if ((progressBar1.Value * volume) > (trackBar2.Value * 100))
                {
                    // volume�̑傫���ɂ���ĉ����鉹�ʂ̕���ύX����
                    label2.Text = System.Convert.ToString(vc.SetVolume(volume - (int)Math.Ceiling((double)volume / 10.0d)));
                    trackBar1.Value = volume;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            vc.SetVolume(trackBar1.Value);
            label2.Text = System.Convert.ToString(vc.SetVolume(trackBar1.Value));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = System.Convert.ToString(trackBar2.Value);
        }
    }

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
            /*
            if (volume < 0)
            {
                volume = 0;
            }
            */
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
}