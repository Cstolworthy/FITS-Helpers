using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitsTest1
{
    public partial class Form1 : Form
    {
        private FitsReader.FitsReader _reader;
        private Timer _timer;

        public Form1()
        {
            InitializeComponent();
            _reader = new FitsReader.FitsReader();
            _reader.ImageReady += new Action(_reader_ImageReady);

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
        }

        void _reader_ImageReady()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker) _reader_ImageReady);
                return;
            }
            
            _timer.Stop();
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            pictureBox1.Visible = true;
            pictureBox1.Image = _reader.Image;
            mnuSaveImage.Enabled = true;
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            
            pictureBox1.Visible = false;
            progressBar1.Visible = true;
            _timer.Start();
            Task.Factory.StartNew(delegate
                                      {
                                          _reader.Bias = Convert.ToInt32(numericUpDown1.Value);
                                          _reader.Parse(openFileDialog1.FileName);
                                      });
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
                btnBegin.Enabled = true;
        }

        private void mnuSaveImage_Click(object sender, EventArgs e)
        {
            var dr = saveFileDialog1.ShowDialog();

            if(dr == DialogResult.OK)
                _reader.Image.Save(saveFileDialog1.FileName);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
