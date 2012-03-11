using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace FitsDataImporter
{
    public partial class FitsImporter : Form
    {
        private ILog _log;

        public FitsImporter()
        {
            _log = Logging.Logging.GetLogger(typeof (FitsImporter));

            InitializeComponent();
        }

        private void btnBrowseFits_Click(object sender, EventArgs e)
        {
            _log.Info("Browse clicked");
            var dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
                tbFitsFile.Text = openFileDialog1.FileName;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            
            var imp = new FitsLogic.FitsImporter(tbMongoConnectionString.Text,tbFitsFile.Text);
            imp.ProgressMessage += new Action<string>(imp_ProgressMessage);
            imp.ProgressPercentage += new Action<int>(imp_ProgressParsing);
            Task.Factory.StartNew(imp.Parse);
        }

        void imp_ProgressParsing(int obj)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => imp_ProgressParsing(obj)));
                return;
            }

            progressBar1.Value = obj;
        }

        void imp_ProgressMessage(string obj)
        {
            if(InvokeRequired)
            {
               Invoke((MethodInvoker) (() => imp_ProgressMessage(obj)));
                return;
            }

            tbProgressReport.Text += obj;
            tbProgressReport.Text += Environment.NewLine;

            tbProgressReport.SelectionStart = tbProgressReport.Text.Length;
            tbProgressReport.ScrollToCaret();
            tbProgressReport.Refresh();

            if (tbProgressReport.Text.Length > 20000)
                tbProgressReport.Text = "";
        }
    }
}
