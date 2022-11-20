using NAudio.CoreAudioApi;
using System.Diagnostics;

namespace Realtime_master_peak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            comboBox.Items.AddRange(devices.ToArray());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem != null)
            {
                var device = (MMDevice)comboBox.SelectedItem;
                progressBar.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
                // Debug.WriteLine(device.AudioMeterInformation.MasterPeakValue);
                Debug.WriteLine(progressBar.Value);
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}