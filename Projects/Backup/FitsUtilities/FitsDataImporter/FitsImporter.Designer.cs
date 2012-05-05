namespace FitsDataImporter
{
    partial class FitsImporter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMongo = new System.Windows.Forms.Label();
            this.tbMongoConnectionString = new System.Windows.Forms.TextBox();
            this.btnBrowseFits = new System.Windows.Forms.Button();
            this.tbFitsFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbProgressReport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCollectionName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMongo
            // 
            this.lblMongo.AutoSize = true;
            this.lblMongo.Location = new System.Drawing.Point(9, 15);
            this.lblMongo.Name = "lblMongo";
            this.lblMongo.Size = new System.Drawing.Size(130, 13);
            this.lblMongo.TabIndex = 0;
            this.lblMongo.Text = "Mongo Connection String:";
            // 
            // tbMongoConnectionString
            // 
            this.tbMongoConnectionString.Location = new System.Drawing.Point(145, 12);
            this.tbMongoConnectionString.Name = "tbMongoConnectionString";
            this.tbMongoConnectionString.Size = new System.Drawing.Size(236, 20);
            this.tbMongoConnectionString.TabIndex = 1;
            this.tbMongoConnectionString.Text = "mongodb://127.0.0.1:27017";
            // 
            // btnBrowseFits
            // 
            this.btnBrowseFits.Location = new System.Drawing.Point(211, 55);
            this.btnBrowseFits.Name = "btnBrowseFits";
            this.btnBrowseFits.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFits.TabIndex = 2;
            this.btnBrowseFits.Text = "Browse";
            this.btnBrowseFits.UseVisualStyleBackColor = true;
            this.btnBrowseFits.Click += new System.EventHandler(this.btnBrowseFits_Click);
            // 
            // tbFitsFile
            // 
            this.tbFitsFile.Location = new System.Drawing.Point(105, 58);
            this.tbFitsFile.Name = "tbFitsFile";
            this.tbFitsFile.Size = new System.Drawing.Size(100, 20);
            this.tbFitsFile.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fits File:";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(306, 227);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 196);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(366, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 6;
            // 
            // tbProgressReport
            // 
            this.tbProgressReport.Location = new System.Drawing.Point(15, 116);
            this.tbProgressReport.Multiline = true;
            this.tbProgressReport.Name = "tbProgressReport";
            this.tbProgressReport.Size = new System.Drawing.Size(366, 74);
            this.tbProgressReport.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Collection Name:";
            // 
            // tbCollectionName
            // 
            this.tbCollectionName.Location = new System.Drawing.Point(105, 84);
            this.tbCollectionName.Name = "tbCollectionName";
            this.tbCollectionName.Size = new System.Drawing.Size(100, 20);
            this.tbCollectionName.TabIndex = 8;
            // 
            // FitsImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCollectionName);
            this.Controls.Add(this.tbProgressReport);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFitsFile);
            this.Controls.Add(this.btnBrowseFits);
            this.Controls.Add(this.tbMongoConnectionString);
            this.Controls.Add(this.lblMongo);
            this.Name = "FitsImporter";
            this.Text = "FitsImporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMongo;
        private System.Windows.Forms.TextBox tbMongoConnectionString;
        private System.Windows.Forms.Button btnBrowseFits;
        private System.Windows.Forms.TextBox tbFitsFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tbProgressReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCollectionName;
    }
}

