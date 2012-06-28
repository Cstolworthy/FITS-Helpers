using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using DataAccess;
using Mappers;
using Objects.DTO;

namespace TestHarness
{
    public partial class Form1 : Form
    {
        public string MongoConnection = "mongodb://127.0.0.1:27017";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestImport_Click(object sender, EventArgs e)
        {
            var dataAccess = new FitsImporterRepository();
            
            var fm = new FitsMapper(dataAccess);

            fm.CreateNewFileImportRequest(new FileInfo("c:\\temp\\myfile.fits"));
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            var dataAccess = new FitsImporterRepository();
            var imports = dataAccess.FindAllFileImportRequest();

            foreach (var fileImportRequest in imports)
            {
                SerializeAndShow(fileImportRequest);
                textBox1.Text += "******************************************";
                textBox1.Text += Environment.NewLine;
            }
        }

        private void SerializeAndShow(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var serializedString = serializer.Serialize(obj);

            textBox1.Text += serializedString;
            textBox1.Text += Environment.NewLine;
        }
    }
}
