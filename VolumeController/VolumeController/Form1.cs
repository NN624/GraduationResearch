using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace VolumeController
{

    // âπó í≤êÆÇÇ∑ÇÈ
    class VolumeController
    {
        public void SetVolume(int value)
        {
            // via http://moguriblogg.blogspot.jp/2017/01/c25.html
            //âπó ÇïœçX
            MMDevice device;
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)value / 100.0f);
        }
    }


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VolumeController vc = new VolumeController();
            vc.SetVolume(20);
        }
    }
}