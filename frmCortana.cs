using SmartCortana.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCortana
{
    public partial class frmCortana : Form
    {

        SpeechSynthesizer speech = new SpeechSynthesizer();
        public frmCortana()
        {
            InitializeComponent();
        }

        private void frmCortana_Load(object sender, EventArgs e)
        {
            picCortana.Image = Resources.Start;
            tm1.Start();
            speech.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            speech.SpeakAsync("Loading Data");
        }

        private void tm1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 10)
            {
                mainform frm = new mainform();
                frm.Show();
                tm1.Stop();
                this.Hide();
            }else
            {
                progressBar1.Value++;
            }
        }
    }
}
