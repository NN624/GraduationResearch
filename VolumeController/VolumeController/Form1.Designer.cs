namespace VolumeController
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.volume_trackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.max_volume = new System.Windows.Forms.Label();
            this.max_trackBar = new System.Windows.Forms.TrackBar();
            this.max_btn = new System.Windows.Forms.Button();
            this.media_btn = new System.Windows.Forms.Button();
            this.progres_value = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.min_volume = new System.Windows.Forms.Label();
            this.min_trackBar = new System.Windows.Forms.TrackBar();
            this.min_btn = new System.Windows.Forms.Button();
            this.sum_trackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.volume_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sum_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "現在の音量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 302);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(600, 73);
            this.progressBar1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(182, 255);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(430, 28);
            this.comboBox1.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // volume_trackBar
            // 
            this.volume_trackBar.Location = new System.Drawing.Point(170, 9);
            this.volume_trackBar.Maximum = 100;
            this.volume_trackBar.Name = "volume_trackBar";
            this.volume_trackBar.Size = new System.Drawing.Size(333, 56);
            this.volume_trackBar.TabIndex = 6;
            this.volume_trackBar.Scroll += new System.EventHandler(this.volume_trackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "最大の音量：";
            // 
            // max_volume
            // 
            this.max_volume.AutoSize = true;
            this.max_volume.Location = new System.Drawing.Point(114, 81);
            this.max_volume.Name = "max_volume";
            this.max_volume.Size = new System.Drawing.Size(33, 20);
            this.max_volume.TabIndex = 8;
            this.max_volume.Text = "100";
            // 
            // max_trackBar
            // 
            this.max_trackBar.Location = new System.Drawing.Point(170, 71);
            this.max_trackBar.Maximum = 100;
            this.max_trackBar.Name = "max_trackBar";
            this.max_trackBar.Size = new System.Drawing.Size(333, 56);
            this.max_trackBar.TabIndex = 9;
            this.max_trackBar.Value = 100;
            this.max_trackBar.Scroll += new System.EventHandler(this.max_trackBar_Scroll);
            // 
            // max_btn
            // 
            this.max_btn.Location = new System.Drawing.Point(14, 104);
            this.max_btn.Name = "max_btn";
            this.max_btn.Size = new System.Drawing.Size(136, 29);
            this.max_btn.TabIndex = 10;
            this.max_btn.Text = "最大の音量に設定";
            this.max_btn.UseVisualStyleBackColor = true;
            this.max_btn.Click += new System.EventHandler(this.max_btn_Click);
            // 
            // media_btn
            // 
            this.media_btn.Location = new System.Drawing.Point(509, 81);
            this.media_btn.Name = "media_btn";
            this.media_btn.Size = new System.Drawing.Size(94, 29);
            this.media_btn.TabIndex = 11;
            this.media_btn.Text = "play";
            this.media_btn.UseVisualStyleBackColor = true;
            this.media_btn.Click += new System.EventHandler(this.media_btn_Click);
            // 
            // progres_value
            // 
            this.progres_value.AutoSize = true;
            this.progres_value.Location = new System.Drawing.Point(130, 255);
            this.progres_value.Name = "progres_value";
            this.progres_value.Size = new System.Drawing.Size(17, 20);
            this.progres_value.TabIndex = 12;
            this.progres_value.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "再生中の音量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "最小の音量：";
            // 
            // min_volume
            // 
            this.min_volume.AutoSize = true;
            this.min_volume.Location = new System.Drawing.Point(114, 149);
            this.min_volume.Name = "min_volume";
            this.min_volume.Size = new System.Drawing.Size(17, 20);
            this.min_volume.TabIndex = 15;
            this.min_volume.Text = "0";
            // 
            // min_trackBar
            // 
            this.min_trackBar.Location = new System.Drawing.Point(170, 133);
            this.min_trackBar.Maximum = 100;
            this.min_trackBar.Name = "min_trackBar";
            this.min_trackBar.Size = new System.Drawing.Size(333, 56);
            this.min_trackBar.TabIndex = 16;
            this.min_trackBar.Scroll += new System.EventHandler(this.min_trackBar_Scroll);
            // 
            // min_btn
            // 
            this.min_btn.Location = new System.Drawing.Point(16, 176);
            this.min_btn.Name = "min_btn";
            this.min_btn.Size = new System.Drawing.Size(134, 29);
            this.min_btn.TabIndex = 17;
            this.min_btn.Text = "最小の音量に設定";
            this.min_btn.UseVisualStyleBackColor = true;
            this.min_btn.Click += new System.EventHandler(this.min_btn_Click);
            // 
            // sum_trackBar
            // 
            this.sum_trackBar.Location = new System.Drawing.Point(170, 195);
            this.sum_trackBar.Maximum = 100;
            this.sum_trackBar.Name = "sum_trackBar";
            this.sum_trackBar.Size = new System.Drawing.Size(333, 56);
            this.sum_trackBar.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 397);
            this.Controls.Add(this.sum_trackBar);
            this.Controls.Add(this.min_btn);
            this.Controls.Add(this.min_trackBar);
            this.Controls.Add(this.min_volume);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progres_value);
            this.Controls.Add(this.media_btn);
            this.Controls.Add(this.max_btn);
            this.Controls.Add(this.max_trackBar);
            this.Controls.Add(this.max_volume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.volume_trackBar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.volume_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sum_trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private ComboBox comboBox1;
        private System.Windows.Forms.Timer timer1;
        private TrackBar volume_trackBar;
        private Label label3;
        private Label max_volume;
        private TrackBar max_trackBar;
        private Button max_btn;
        private Button media_btn;
        private Label progres_value;
        private Label label5;
        private Label label6;
        private Label min_volume;
        private TrackBar min_trackBar;
        private Button min_btn;
        private TrackBar sum_trackBar;
    }
}