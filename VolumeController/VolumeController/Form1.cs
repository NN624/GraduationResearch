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

namespace VolumeController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            VolumeController vc = new VolumeController();
            label2.Text = System.Convert.ToString(vc.GetVolume());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VolumeController vc = new VolumeController();
            label2.Text = System.Convert.ToString(vc.SetVolume(textBox1.Text));
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


        // ���ʂ̕ύX
        public int SetVolume(string value)
        {
            int volume = 0;
            // str����int�֕ϊ�
            try
            {
                volume = System.Convert.ToInt32(value);
            }
            catch (System.OverflowException)
            {
                Debug.WriteLine("Overflow in double to int conversion.");
            }
            // ���ʂ͈̔͂̔���
            if (0 <= volume && volume <= 100)
            {
                device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)volume / 100.0f);
                
            }
            else
            {
                Debug.WriteLine("Volume is over range.");
                volume = (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
            }
            return volume;
        }
        //���ʂ̎擾
        public int GetVolume()
        {
            return (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        }
    }
}