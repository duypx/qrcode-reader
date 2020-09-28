using System;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;

using Inlite.ClearImageNet;

namespace Main
{
    public class Form1 : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.TextBox txtRslt;
        internal System.Windows.Forms.TextBox txtFileIn_;
        public System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button cmdBrowseFileIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPage;
        private GroupBox groupBox1;
        private RadioButton optClearImage;
        private RadioButton optClearImageNet;
        internal Label label3;
        private ComboBox cmbOutFormat;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem readFeatures;
        private ToolStripMenuItem readOnFilePageToolStripMenuItem;
        private ToolStripMenuItem readWithThreads;
        private ToolStripMenuItem readWithEvents;
        private ToolStripMenuItem readFromStream;
        private ToolStripMenuItem readWithZones;
        private ToolStripMenuItem readBarcodes;
        private ToolStripMenuItem read1DAuto;
        private ToolStripMenuItem readCode128AndCode39;
        private ToolStripMenuItem readPDF417;
        private ToolStripMenuItem readDataMarix;
        private ToolStripMenuItem readQR;
        private ToolStripMenuItem readDriveLicense;
        private ToolStripMenuItem imageProcessing;
        private ToolStripMenuItem onePageToolStripMenuItem;
        private ToolStripMenuItem repairAllPages;
        private ToolStripMenuItem reapirFromToStream;
        private ToolStripMenuItem toolOnePage;
        private ToolStripMenuItem toolsWithEvents;
        private ComboBox cmbTbrCode;
        private Label label4;
        private ToolStripMenuItem serverInfo;
        private ToolStripMenuItem imageInfo;
        private PictureBox pictureBox2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label5;
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtRslt = new System.Windows.Forms.TextBox();
            this.txtFileIn_ = new System.Windows.Forms.TextBox();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdBrowseFileIn = new System.Windows.Forms.Button();
            this.numPage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optClearImage = new System.Windows.Forms.RadioButton();
            this.optClearImageNet = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOutFormat = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.readBarcodes = new System.Windows.Forms.ToolStripMenuItem();
            this.read1DAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.readCode128AndCode39 = new System.Windows.Forms.ToolStripMenuItem();
            this.readPDF417 = new System.Windows.Forms.ToolStripMenuItem();
            this.readDataMarix = new System.Windows.Forms.ToolStripMenuItem();
            this.readQR = new System.Windows.Forms.ToolStripMenuItem();
            this.readDriveLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.readFeatures = new System.Windows.Forms.ToolStripMenuItem();
            this.readOnFilePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readWithThreads = new System.Windows.Forms.ToolStripMenuItem();
            this.readWithEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.readFromStream = new System.Windows.Forms.ToolStripMenuItem();
            this.readWithZones = new System.Windows.Forms.ToolStripMenuItem();
            this.imageProcessing = new System.Windows.Forms.ToolStripMenuItem();
            this.onePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repairAllPages = new System.Windows.Forms.ToolStripMenuItem();
            this.reapirFromToStream = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOnePage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsWithEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.serverInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.imageInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbTbrCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(641, 35);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(184, 240);
            this.PictureBox1.TabIndex = 13;
            this.PictureBox1.TabStop = false;
            // 
            // txtRslt
            // 
            this.txtRslt.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRslt.Location = new System.Drawing.Point(12, 125);
            this.txtRslt.Multiline = true;
            this.txtRslt.Name = "txtRslt";
            this.txtRslt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRslt.Size = new System.Drawing.Size(619, 180);
            this.txtRslt.TabIndex = 12;
            // 
            // txtFileIn_
            // 
            this.txtFileIn_.Location = new System.Drawing.Point(68, 34);
            this.txtFileIn_.Name = "txtFileIn_";
            this.txtFileIn_.Size = new System.Drawing.Size(417, 20);
            this.txtFileIn_.TabIndex = 9;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 34);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 24);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Image File";
            // 
            // cmdBrowseFileIn
            // 
            this.cmdBrowseFileIn.Location = new System.Drawing.Point(491, 34);
            this.cmdBrowseFileIn.Name = "cmdBrowseFileIn";
            this.cmdBrowseFileIn.Size = new System.Drawing.Size(24, 20);
            this.cmdBrowseFileIn.TabIndex = 10;
            this.cmdBrowseFileIn.Text = "...";
            this.cmdBrowseFileIn.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // numPage
            // 
            this.numPage.Location = new System.Drawing.Point(556, 35);
            this.numPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPage.Name = "numPage";
            this.numPage.Size = new System.Drawing.Size(40, 20);
            this.numPage.TabIndex = 41;
            this.numPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(524, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "Page";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optClearImage);
            this.groupBox1.Controls.Add(this.optClearImageNet);
            this.groupBox1.Location = new System.Drawing.Point(18, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 57);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Use namespace";
            // 
            // optClearImage
            // 
            this.optClearImage.AutoSize = true;
            this.optClearImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optClearImage.Location = new System.Drawing.Point(6, 34);
            this.optClearImage.Name = "optClearImage";
            this.optClearImage.Size = new System.Drawing.Size(78, 17);
            this.optClearImage.TabIndex = 1;
            this.optClearImage.Text = "ClearImage";
            this.optClearImage.UseVisualStyleBackColor = true;
            // 
            // optClearImageNet
            // 
            this.optClearImageNet.AutoSize = true;
            this.optClearImageNet.Checked = true;
            this.optClearImageNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optClearImageNet.Location = new System.Drawing.Point(6, 16);
            this.optClearImageNet.Name = "optClearImageNet";
            this.optClearImageNet.Size = new System.Drawing.Size(95, 17);
            this.optClearImageNet.TabIndex = 0;
            this.optClearImageNet.TabStop = true;
            this.optClearImageNet.Text = "ClearImageNet";
            this.optClearImageNet.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Repair output format:";
            // 
            // cmbOutFormat
            // 
            this.cmbOutFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutFormat.FormattingEnabled = true;
            this.cmbOutFormat.Items.AddRange(new object[] {
            "Input Format",
            "PDF",
            "TIFF",
            "JPEG"});
            this.cmbOutFormat.Location = new System.Drawing.Point(253, 94);
            this.cmbOutFormat.Name = "cmbOutFormat";
            this.cmbOutFormat.Size = new System.Drawing.Size(131, 21);
            this.cmbOutFormat.TabIndex = 50;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readBarcodes,
            this.readFeatures,
            this.imageProcessing,
            this.serverInfo,
            this.imageInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 57;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // readBarcodes
            // 
            this.readBarcodes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.read1DAuto,
            this.readCode128AndCode39,
            this.readPDF417,
            this.readDataMarix,
            this.readQR,
            this.readDriveLicense});
            this.readBarcodes.Name = "readBarcodes";
            this.readBarcodes.Size = new System.Drawing.Size(123, 20);
            this.readBarcodes.Text = "Read Barcodes Type";
            // 
            // read1DAuto
            // 
            this.read1DAuto.Name = "read1DAuto";
            this.read1DAuto.Size = new System.Drawing.Size(246, 22);
            this.read1DAuto.Text = "Read 1D - Auto Types";
            this.read1DAuto.Click += new System.EventHandler(this.read1DautoType_Click);
            // 
            // readCode128AndCode39
            // 
            this.readCode128AndCode39.Name = "readCode128AndCode39";
            this.readCode128AndCode39.Size = new System.Drawing.Size(246, 22);
            this.readCode128AndCode39.Text = "Read 1D - Code 128 and Code 39";
            this.readCode128AndCode39.Click += new System.EventHandler(this.readCode128andCode39_Click);
            // 
            // readPDF417
            // 
            this.readPDF417.Name = "readPDF417";
            this.readPDF417.Size = new System.Drawing.Size(246, 22);
            this.readPDF417.Text = "Read PDF417";
            this.readPDF417.Click += new System.EventHandler(this.readPDF417_Click);
            // 
            // readDataMarix
            // 
            this.readDataMarix.Name = "readDataMarix";
            this.readDataMarix.Size = new System.Drawing.Size(246, 22);
            this.readDataMarix.Text = "Read DataMarix";
            this.readDataMarix.Click += new System.EventHandler(this.readDataMatrix_Click);
            // 
            // readQR
            // 
            this.readQR.Name = "readQR";
            this.readQR.Size = new System.Drawing.Size(246, 22);
            this.readQR.Text = "Read QR";
            this.readQR.Click += new System.EventHandler(this.readQR_Click);
            // 
            // readDriveLicense
            // 
            this.readDriveLicense.Name = "readDriveLicense";
            this.readDriveLicense.Size = new System.Drawing.Size(246, 22);
            this.readDriveLicense.Text = "Read Driver License";
            this.readDriveLicense.Click += new System.EventHandler(this.readDriverLicense_Click);
            // 
            // readFeatures
            // 
            this.readFeatures.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readOnFilePageToolStripMenuItem,
            this.readWithThreads,
            this.readWithEvents,
            this.readFromStream,
            this.readWithZones});
            this.readFeatures.Name = "readFeatures";
            this.readFeatures.Size = new System.Drawing.Size(138, 20);
            this.readFeatures.Text = "Read Barcode Features";
            // 
            // readOnFilePageToolStripMenuItem
            // 
            this.readOnFilePageToolStripMenuItem.Name = "readOnFilePageToolStripMenuItem";
            this.readOnFilePageToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.readOnFilePageToolStripMenuItem.Text = "Multi-page file";
            this.readOnFilePageToolStripMenuItem.Click += new System.EventHandler(this.readMultiPageFile_Click);
            // 
            // readWithThreads
            // 
            this.readWithThreads.Name = "readWithThreads";
            this.readWithThreads.Size = new System.Drawing.Size(156, 22);
            this.readWithThreads.Text = "Multi-Threaded";
            this.readWithThreads.Click += new System.EventHandler(this.readWithThreads_Click);
            // 
            // readWithEvents
            // 
            this.readWithEvents.Name = "readWithEvents";
            this.readWithEvents.Size = new System.Drawing.Size(156, 22);
            this.readWithEvents.Text = "With Events";
            this.readWithEvents.Click += new System.EventHandler(this.readWithEvents_Click);
            // 
            // readFromStream
            // 
            this.readFromStream.Name = "readFromStream";
            this.readFromStream.Size = new System.Drawing.Size(156, 22);
            this.readFromStream.Text = "From Stream";
            this.readFromStream.Click += new System.EventHandler(this.readFromStream_Click);
            // 
            // readWithZones
            // 
            this.readWithZones.Name = "readWithZones";
            this.readWithZones.Size = new System.Drawing.Size(156, 22);
            this.readWithZones.Text = "With Zones";
            this.readWithZones.Click += new System.EventHandler(this.readWithZones_Click);
            // 
            // imageProcessing
            // 
            this.imageProcessing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onePageToolStripMenuItem,
            this.repairAllPages,
            this.reapirFromToStream,
            this.toolOnePage,
            this.toolsWithEvents});
            this.imageProcessing.Name = "imageProcessing";
            this.imageProcessing.Size = new System.Drawing.Size(112, 20);
            this.imageProcessing.Text = "Image Processing";
            // 
            // onePageToolStripMenuItem
            // 
            this.onePageToolStripMenuItem.Name = "onePageToolStripMenuItem";
            this.onePageToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.onePageToolStripMenuItem.Text = "Repair- One Page";
            this.onePageToolStripMenuItem.Click += new System.EventHandler(this.repairPage_Click);
            // 
            // repairAllPages
            // 
            this.repairAllPages.Name = "repairAllPages";
            this.repairAllPages.Size = new System.Drawing.Size(203, 22);
            this.repairAllPages.Text = "Repair - All Pages";
            this.repairAllPages.Click += new System.EventHandler(this.repairFile_Click);
            // 
            // reapirFromToStream
            // 
            this.reapirFromToStream.Name = "reapirFromToStream";
            this.reapirFromToStream.Size = new System.Drawing.Size(203, 22);
            this.reapirFromToStream.Text = "Repair - From/To Stream";
            this.reapirFromToStream.Click += new System.EventHandler(this.repairStream_Click);
            // 
            // toolOnePage
            // 
            this.toolOnePage.Name = "toolOnePage";
            this.toolOnePage.Size = new System.Drawing.Size(203, 22);
            this.toolOnePage.Text = "Tools - One page";
            this.toolOnePage.Click += new System.EventHandler(this.toolsPage_Click);
            // 
            // toolsWithEvents
            // 
            this.toolsWithEvents.Name = "toolsWithEvents";
            this.toolsWithEvents.Size = new System.Drawing.Size(203, 22);
            this.toolsWithEvents.Text = "Tools - with Events";
            this.toolsWithEvents.Click += new System.EventHandler(this.toolsWithEvents_Click);
            // 
            // serverInfo
            // 
            this.serverInfo.Name = "serverInfo";
            this.serverInfo.Size = new System.Drawing.Size(75, 20);
            this.serverInfo.Text = "Server Info";
            this.serverInfo.Click += new System.EventHandler(this.serverInfo_Click);
            // 
            // imageInfo
            // 
            this.imageInfo.Name = "imageInfo";
            this.imageInfo.Size = new System.Drawing.Size(76, 20);
            this.imageInfo.Text = "Image Info";
            this.imageInfo.Click += new System.EventHandler(this.imageInfo_Click);
            // 
            // cmbTbrCode
            // 
            this.cmbTbrCode.AutoCompleteCustomSource.AddRange(new string[] {
            "none",
            "101",
            "102",
            "103",
            "104",
            "106",
            "107",
            "108",
            "109",
            "112",
            "113",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "123",
            "124",
            "125",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "137",
            ""});
            this.cmbTbrCode.FormattingEnabled = true;
            this.cmbTbrCode.Items.AddRange(new object[] {
            "none",
            "100",
            "101",
            "102",
            "103",
            "107",
            "112",
            "113",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "123",
            "124",
            "125",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "137"});
            this.cmbTbrCode.Location = new System.Drawing.Point(276, 65);
            this.cmbTbrCode.Name = "cmbTbrCode";
            this.cmbTbrCode.Size = new System.Drawing.Size(95, 21);
            this.cmbTbrCode.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Barcode Reader TbrCode:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(15, 365);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(616, 258);
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 61;
            this.button1.Text = "Choose Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 335);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(523, 20);
            this.textBox1.TabIndex = 62;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(641, 365);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 258);
            this.textBox2.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(638, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Results:";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(837, 706);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbOutFormat);
            this.Controls.Add(this.cmbTbrCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPage);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.txtRslt);
            this.Controls.Add(this.txtFileIn_);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmdBrowseFileIn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ClearImage Example (C#)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        #region Commands processing
        ClearImageNetFnc ciNetProc = new ClearImageNetFnc();
        ClearImageFnc ciProc = new ClearImageFnc();
        private void Form1_Load(object sender, System.EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = GetRegKey();
            if (key.ValueCount > 0) txtFileIn_.Text = key.GetValue(txtFileIn_.Name).ToString();
            cmbOutFormat.SelectedIndex = 0;
            cmbTbrCode.SelectedIndex = 0;
            ciNetProc.txtRslt = txtRslt;
            ciProc.txtRslt = txtRslt;
            txtFileIn_.SelectionLength = 0;
            DisplayImage(txtFileIn_.Text);
            txtRslt.Text = AboutText();
        }

        private void readWithZones_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readWithZones(txtFileIn_.Text, (int)numPage.Value);
                else
                    s = ciProc.readWithZones(txtFileIn_.Text, (int)numPage.Value);
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void readPDF417_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readPDF417(txtFileIn_.Text, (int)numPage.Value);
                else
                    s = ciProc.readPDF417(txtFileIn_.Text, (int)numPage.Value);

                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void readDataMatrix_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readDataMatrix(txtFileIn_.Text, (int)numPage.Value);
                else
                    s = ciProc.readDataMatrix(txtFileIn_.Text, (int)numPage.Value);
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void readQR_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readQR(txtFileIn_.Text, (int)numPage.Value);
                else
                    s = ciProc.readQR(txtFileIn_.Text, (int)numPage.Value);
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }

        private void readWithEvents_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readWithEvents(txtFileIn_.Text);
                else
                    s = "ClearImage namespace does not implement events";
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }

        private void repairFile_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                ImageFileFormat format = ImageFileFormat.inputFileFormat;
                Inlite.ClearImage.EFileFormat ciFormat = Inlite.ClearImage.EFileFormat.ciEXT;
                string fileOut = getRepairOutputFileName(txtFileIn_.Text, ref format, ref ciFormat, true);
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.repairFile(txtFileIn_.Text, fileOut, format);
                else
                    s = ciProc.repairFile(txtFileIn_.Text, fileOut, ciFormat);
                // Display results
                OpDone(s);
                if (s != "")
                    DisplayImage(fileOut);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void toolsPage_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.toolsPage(txtFileIn_.Text, (int)numPage.Value);
                else
                    s = ciProc.toolsPage(txtFileIn_.Text, (int)numPage.Value);
                // Display results
                OpDone(s);
                // Display modified image
                long n = s.LastIndexOf("SaveAs:");
                if (n >= 0)
                {
                    string a = s.Substring((Int32)(n + 7));
                    DisplayImage(a);
                    System.IO.File.Delete(a);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void toolsWithEvents_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.toolsWithEvents(txtFileIn_.Text, (int)numPage.Value, true);
                else
                    s = "ClearImage namespace does not implement events";
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void about_Click(object sender, System.EventArgs e)
        {
            txtRslt.Text = AboutText();
        }

        private void imageInfo_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.Info(txtFileIn_.Text);
                else
                    s = ciProc.Info(txtFileIn_.Text);
                // Display results
                OpDone("");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void browseFile_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog1.FileName = txtFileIn_.Text;
            OpenFileDialog1.Filter = "Image Files files (tif, jpg, bmp, pdf)|*.tif;*.tiff;*.jpg;*.jpeg;*.bmp;*.pdf|All files (*.*)|*.*";
            OpenFileDialog1.FilterIndex = 1;
            OpenFileDialog1.RestoreDirectory = true;
            OpenFileDialog1.CheckFileExists = true;
            OpenFileDialog1.Multiselect = false;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRslt.Text = "";
                txtFileIn_.Text = OpenFileDialog1.FileName;
                Microsoft.Win32.RegistryKey key = GetRegKey();
                key.SetValue(txtFileIn_.Name, txtFileIn_.Text);
                DisplayImage(txtFileIn_.Text);
                Application.DoEvents();
                imageInfo_Click(null, null);
            }
        }

        private void serverInfo_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.serverInfo();
                else
                    s = ciProc.serverInfo();
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }



        private void readFromStream_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readFromStream(txtFileIn_.Text);
                else
                    s = ciProc.readFromStream(txtFileIn_.Text);
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }

        private void readCode128andCode39_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readCode128andCode39(txtFileIn_.Text, (int)numPage.Value);
                else
                    s = ciProc.readCode128andCode39(txtFileIn_.Text, (int)numPage.Value);
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void read1DautoType_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.read1DautoType(txtFileIn_.Text, (int)numPage.Value);
                else
                    s = ciProc.read1DautoType(txtFileIn_.Text, (int)numPage.Value);
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void readMultiPageFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readMultiPageFile(txtFileIn_.Text);
                else
                    s = ciProc.readMultiPageFile(txtFileIn_.Text);
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void readWithThreads_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readDirectoryWithThreads(System.IO.Path.GetDirectoryName(txtFileIn_.Text));
                else
                    s = ciProc.readDirectoryWithThreads(System.IO.Path.GetDirectoryName(txtFileIn_.Text));
                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void repairPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //
                ImageFileFormat format = ImageFileFormat.inputFileFormat;
                Inlite.ClearImage.EFileFormat ciFormat = Inlite.ClearImage.EFileFormat.ciEXT;
                string fileOut = getRepairOutputFileName(txtFileIn_.Text, ref format, ref ciFormat, true);
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.repairPage(txtFileIn_.Text, (int)numPage.Value, fileOut, format);
                else
                    s = ciProc.repairPage(txtFileIn_.Text, (int)numPage.Value, fileOut, ciFormat);
                // Display results
                OpDone(s);
                if (s != "")
                    DisplayImage(fileOut);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void repairStream_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //
                ImageFileFormat format = ImageFileFormat.inputFileFormat;
                Inlite.ClearImage.EFileFormat ciFormat = Inlite.ClearImage.EFileFormat.ciEXT;
                string fileOut = getRepairOutputFileName(txtFileIn_.Text, ref format, ref ciFormat, true);
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.repairStream(txtFileIn_.Text, fileOut, format);
                else
                    s = ciProc.repairStream(txtFileIn_.Text, fileOut, ciFormat);
                // Display results
                OpDone(s);
                if (s != "")
                    DisplayImage(fileOut);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void readDriverLicense_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OpStart(sender)) return;
                //    Do processing
                string s = "";
                if (optClearImageNet.Checked)
                    s = ciNetProc.readDriverLicense(txtFileIn_.Text, (int)numPage.Value);
                else
                    s = "ClearImage namespace does not implement Driver License Reading";

                // Display results
                OpDone(s);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
        #endregion

        #region Utility Functions

        private string getRepairOutputFileName(string inpFile, ref ImageFileFormat format,
             ref Inlite.ClearImage.EFileFormat ciFormat, bool delete)
        {
            string ext = "";
            switch (cmbOutFormat.SelectedIndex)
            {
                case 0:
                    ext = System.IO.Path.GetExtension(inpFile);
                    format = ImageFileFormat.inputFileFormat;
                    ciFormat = Inlite.ClearImage.EFileFormat.ciEXT;
                    break;
                case 1:
                    ext = ".pdf";
                    format = ImageFileFormat.pdf;
                    ciFormat = Inlite.ClearImage.EFileFormat.cifPDF;
                    break;
                case 2:
                    ext = ".tif";
                    format = ImageFileFormat.tiff;
                    ciFormat = Inlite.ClearImage.EFileFormat.ciTIFF;
                    break;
                case 3:
                    ext = ".jpg";
                    format = ImageFileFormat.jpeg;
                    ciFormat = Inlite.ClearImage.EFileFormat.ciJPG;
                    break;
            }
            string fileOut = System.IO.Path.GetTempPath() + @"CiRepair" + ext;
            if (delete)
                System.IO.File.Delete(fileOut);
            txtRslt.Text = txtRslt.Text + "Output in: " + fileOut + Environment.NewLine;
            txtRslt.Text = txtRslt.Text + "------------------------" + Environment.NewLine;
            return fileOut;
        }

        private bool OpStart(object sender)
        {
            string text = "";
            txtRslt.Text = "";
            uint tbrCode = 0;  uint.TryParse(cmbTbrCode.Text, out tbrCode);
            ciNetProc.tbrCode = tbrCode;
            ciProc.tbrCode = tbrCode;
            if (sender != null && sender.GetType().Name == "Button")
            {
                Button btn = (Button)sender;
                if (btn.Tag != null) text = btn.Tag.ToString();
            }
            if (sender != null && sender.GetType().Name == "String")
            {
                text = (string)sender;
            }
            if (text != "")
                txtRslt.Text = "### " + text + Environment.NewLine + "#######################" + Environment.NewLine;
            if ((txtFileIn_.Text == "")) { MessageBox.Show("No File specified"); return false; }
            Application.DoEvents();
            return true;
        }


        private void OpDone(string sRslt)
        {
            if (sRslt.StartsWith("### "))
                txtRslt.Text = sRslt;
            else
                txtRslt.Text = txtRslt.Text + sRslt;
        }

        private bool GetThumbnailImageAbort()
        {
            return false;
        }

        private void DisplayImage(string fileName)
        {
            try
            {
                PictureBox1.Image = null;
                if (!System.IO.File.Exists(fileName)) return;
                ImageIO io = new ImageIO();
                Bitmap newImage = io.Open(fileName);
                double scaleX = (double)PictureBox1.Width / (double)newImage.Width;
                double scaleY = (double)PictureBox1.Height / (double)newImage.Height;
                double Scale = Math.Min(scaleX, scaleY);
                int w = (int)(newImage.Width * Scale);
                int h = (int)(newImage.Height * Scale);
                PictureBox1.Image = newImage.GetThumbnailImage(w, h, new System.Drawing.Image.GetThumbnailImageAbort(GetThumbnailImageAbort), IntPtr.Zero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image is not displayed because:" + Environment.NewLine + ex.Message);
            }
        }

        private void ShowError(Exception ex)
        {
            txtRslt.Text += "ERROR: " + ex.Message.ToString();
        }

        private string AboutText()
        {
            string s = "";
            s = "ClearImageNet Server " + Server.Major.ToString() + "." + Server.Minor.ToString() + "." + Server.Release.ToString() + " " + Server.Edition;
            s = s + Environment.NewLine;
            s = s + Environment.NewLine + "This program demonstrates basic use of ClearImageNet assembly C#";
            s = s + Environment.NewLine + "   Full assembly reference is in ClearImageNet API Help.";
            s = s + Environment.NewLine + "Use ClearImage Demo to evaluate functionality without writing code";
            s = s + Environment.NewLine + "";
            s = s + Environment.NewLine + "For additional support, send your images and code";
            s = s + Environment.NewLine + "    snippets to 'support@inliteresearch.com'";
            return s;
        }

        private Microsoft.Win32.RegistryKey GetRegKey()
        {
            // Create key in HKLM without Release
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Inlite\\" + Application.ProductName);
            return key;
        }
        #endregion


        // TODO:

        string imagePath = "";
        private static System.Timers.Timer timer;

        string inputFilename = "input_image.txt";
        string outputFilename = "output_barcode.txt";

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    imagePath = fbd.SelectedPath;
                    File.WriteAllText(inputFilename, imagePath);
                    textBox1.Text = imagePath;

                    string path = getFileInDir(imagePath);
                    if (path != "")
                    {
                        showImageFromPath(path);
                        getBarCode(path);
                    }

                }
            }
        }

        private void showImageFromPath(string fileName)
        {
            try
            {
                pictureBox2.Image = null;
                if (!System.IO.File.Exists(fileName)) return;
                ImageIO io = new ImageIO();
                Bitmap newImage = io.Open(fileName);
                double scaleX = (double)pictureBox2.Width / (double)newImage.Width;
                double scaleY = (double)pictureBox2.Height / (double)newImage.Height;
                double Scale = Math.Min(scaleX, scaleY);
                int w = (int)(newImage.Width * Scale);
                int h = (int)(newImage.Height * Scale);
                pictureBox2.Image = newImage.GetThumbnailImage(w, h, new System.Drawing.Image.GetThumbnailImageAbort(GetThumbnailImageAbort), IntPtr.Zero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image is not displayed because:" + Environment.NewLine + ex.Message);
            }
        }

        private string getFileInDir(string dirPath)
        {
            if (dirPath == "") return "";
            if (!Directory.Exists(dirPath)) return "";

            string[] files = Directory.GetFiles(dirPath);
            if (files.Length > 0)
            {
                Console.WriteLine(files[0]);
                return files[0];
            }
            return "";
        }

        private void createTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            timer.Interval = 5000;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string path = getFileInDir(imagePath);
            if (path != "")
            {
                getBarCode(path);
            }
            else
            {
                clearView();
            }
        }

        private void clearView()
        {

        }

        private void getBarCode(string path)
        {
            string s = "";
            s = ciNetProc.readQR(path, 1);
            textBox2.Text = s;
        }
    }
}
