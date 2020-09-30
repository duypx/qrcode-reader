using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Timers;
using System.Windows.Forms;

using Inlite.ClearImageNet;

namespace Main
{
    public class Form1 : System.Windows.Forms.Form
    {
        public System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private PictureBox pictureBox2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label5;
        private Button button2;
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
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(12, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(616, 399);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 61;
            this.button1.Text = "Choose Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(523, 20);
            this.textBox1.TabIndex = 62;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(641, 68);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(184, 372);
            this.textBox2.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(638, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Results:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(641, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 65;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(837, 451);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "QR Code Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            //Microsoft.Win32.RegistryKey key = GetRegKey();
            //if (key.ValueCount > 0) txtFileIn_.Text = key.GetValue(txtFileIn_.Name).ToString();
            //cmbOutFormat.SelectedIndex = 0;
            //cmbTbrCode.SelectedIndex = 0;
            //ciNetProc.txtRslt = txtRslt;
            //ciProc.txtRslt = txtRslt;
            //txtFileIn_.SelectionLength = 0;
            //DisplayImage(txtFileIn_.Text);
            //txtRslt.Text = AboutText();

            CreateTimer();

            if (File.Exists(inputFileName))
            {
                imagePath = File.ReadAllText(inputFileName);
                textBox1.Text = imagePath;
                if (imagePath != "")
                {
                    string img = getFileInDir(imagePath);
                    if (img != "")
                    {
                        getBarCode(img);
                    }
                }
            }
        }

        private void readWithZones_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readWithZones(txtFileIn_.Text, (int)numPage.Value);
            //    else
            //        s = ciProc.readWithZones(txtFileIn_.Text, (int)numPage.Value);
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void readPDF417_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readPDF417(txtFileIn_.Text, (int)numPage.Value);
            //    else
            //        s = ciProc.readPDF417(txtFileIn_.Text, (int)numPage.Value);

            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void readDataMatrix_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readDataMatrix(txtFileIn_.Text, (int)numPage.Value);
            //    else
            //        s = ciProc.readDataMatrix(txtFileIn_.Text, (int)numPage.Value);
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void readQR_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readQR(txtFileIn_.Text, (int)numPage.Value);
            //    else
            //        s = ciProc.readQR(txtFileIn_.Text, (int)numPage.Value);
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}

        }

        private void readWithEvents_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readWithEvents(txtFileIn_.Text);
            //    else
            //        s = "ClearImage namespace does not implement events";
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}

        }

        private void repairFile_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    ImageFileFormat format = ImageFileFormat.inputFileFormat;
            //    Inlite.ClearImage.EFileFormat ciFormat = Inlite.ClearImage.EFileFormat.ciEXT;
            //    string fileOut = getRepairOutputFileName(txtFileIn_.Text, ref format, ref ciFormat, true);
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.repairFile(txtFileIn_.Text, fileOut, format);
            //    else
            //        s = ciProc.repairFile(txtFileIn_.Text, fileOut, ciFormat);
            //    // Display results
            //    OpDone(s);
            //    if (s != "")
            //        DisplayImage(fileOut);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void toolsPage_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.toolsPage(txtFileIn_.Text, (int)numPage.Value);
            //    else
            //        s = ciProc.toolsPage(txtFileIn_.Text, (int)numPage.Value);
            //    // Display results
            //    OpDone(s);
            //    // Display modified image
            //    long n = s.LastIndexOf("SaveAs:");
            //    if (n >= 0)
            //    {
            //        string a = s.Substring((Int32)(n + 7));
            //        DisplayImage(a);
            //        System.IO.File.Delete(a);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void toolsWithEvents_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.toolsWithEvents(txtFileIn_.Text, (int)numPage.Value, true);
            //    else
            //        s = "ClearImage namespace does not implement events";
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void about_Click(object sender, System.EventArgs e)
        {
            //txtRslt.Text = AboutText();
        }

        private void imageInfo_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.Info(txtFileIn_.Text);
            //    else
            //        s = ciProc.Info(txtFileIn_.Text);
            //    // Display results
            //    OpDone("");
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void browseFile_Click(object sender, System.EventArgs e)
        {
            //OpenFileDialog1.FileName = txtFileIn_.Text;
            //OpenFileDialog1.Filter = "Image Files files (tif, jpg, bmp, pdf)|*.tif;*.tiff;*.jpg;*.jpeg;*.bmp;*.pdf|All files (*.*)|*.*";
            //OpenFileDialog1.FilterIndex = 1;
            //OpenFileDialog1.RestoreDirectory = true;
            //OpenFileDialog1.CheckFileExists = true;
            //OpenFileDialog1.Multiselect = false;
            //if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    txtRslt.Text = "";
            //    txtFileIn_.Text = OpenFileDialog1.FileName;
            //    Microsoft.Win32.RegistryKey key = GetRegKey();
            //    key.SetValue(txtFileIn_.Name, txtFileIn_.Text);
            //    DisplayImage(txtFileIn_.Text);
            //    Application.DoEvents();
            //    imageInfo_Click(null, null);
            //}
        }

        private void serverInfo_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.serverInfo();
            //    else
            //        s = ciProc.serverInfo();
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void readFromStream_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readFromStream(txtFileIn_.Text);
            //    else
            //        s = ciProc.readFromStream(txtFileIn_.Text);
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}

        }

        private void readCode128andCode39_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readCode128andCode39(txtFileIn_.Text, (int)numPage.Value);
            //    else
            //        s = ciProc.readCode128andCode39(txtFileIn_.Text, (int)numPage.Value);
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void read1DautoType_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.read1DautoType(txtFileIn_.Text, (int)numPage.Value);
            //    else
            //        s = ciProc.read1DautoType(txtFileIn_.Text, (int)numPage.Value);
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void readMultiPageFile_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readMultiPageFile(txtFileIn_.Text);
            //    else
            //        s = ciProc.readMultiPageFile(txtFileIn_.Text);
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void readWithThreads_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readDirectoryWithThreads(System.IO.Path.GetDirectoryName(txtFileIn_.Text));
            //    else
            //        s = ciProc.readDirectoryWithThreads(System.IO.Path.GetDirectoryName(txtFileIn_.Text));
            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void repairPage_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //
            //    ImageFileFormat format = ImageFileFormat.inputFileFormat;
            //    Inlite.ClearImage.EFileFormat ciFormat = Inlite.ClearImage.EFileFormat.ciEXT;
            //    string fileOut = getRepairOutputFileName(txtFileIn_.Text, ref format, ref ciFormat, true);
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.repairPage(txtFileIn_.Text, (int)numPage.Value, fileOut, format);
            //    else
            //        s = ciProc.repairPage(txtFileIn_.Text, (int)numPage.Value, fileOut, ciFormat);
            //    // Display results
            //    OpDone(s);
            //    if (s != "")
            //        DisplayImage(fileOut);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void repairStream_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //
            //    ImageFileFormat format = ImageFileFormat.inputFileFormat;
            //    Inlite.ClearImage.EFileFormat ciFormat = Inlite.ClearImage.EFileFormat.ciEXT;
            //    string fileOut = getRepairOutputFileName(txtFileIn_.Text, ref format, ref ciFormat, true);
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.repairStream(txtFileIn_.Text, fileOut, format);
            //    else
            //        s = ciProc.repairStream(txtFileIn_.Text, fileOut, ciFormat);
            //    // Display results
            //    OpDone(s);
            //    if (s != "")
            //        DisplayImage(fileOut);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }

        private void readDriverLicense_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!OpStart(sender)) return;
            //    //    Do processing
            //    string s = "";
            //    if (optClearImageNet.Checked)
            //        s = ciNetProc.readDriverLicense(txtFileIn_.Text, (int)numPage.Value);
            //    else
            //        s = "ClearImage namespace does not implement Driver License Reading";

            //    // Display results
            //    OpDone(s);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex);
            //}
        }
        #endregion

        #region Utility Functions

        private string getRepairOutputFileName(string inpFile, ref ImageFileFormat format,
             ref Inlite.ClearImage.EFileFormat ciFormat, bool delete)
        {
            //string ext = "";
            //switch (cmbOutFormat.SelectedIndex)
            //{
            //    case 0:
            //        ext = System.IO.Path.GetExtension(inpFile);
            //        format = ImageFileFormat.inputFileFormat;
            //        ciFormat = Inlite.ClearImage.EFileFormat.ciEXT;
            //        break;
            //    case 1:
            //        ext = ".pdf";
            //        format = ImageFileFormat.pdf;
            //        ciFormat = Inlite.ClearImage.EFileFormat.cifPDF;
            //        break;
            //    case 2:
            //        ext = ".tif";
            //        format = ImageFileFormat.tiff;
            //        ciFormat = Inlite.ClearImage.EFileFormat.ciTIFF;
            //        break;
            //    case 3:
            //        ext = ".jpg";
            //        format = ImageFileFormat.jpeg;
            //        ciFormat = Inlite.ClearImage.EFileFormat.ciJPG;
            //        break;
            //}
            //string fileOut = System.IO.Path.GetTempPath() + @"CiRepair" + ext;
            //if (delete)
            //    System.IO.File.Delete(fileOut);
            //txtRslt.Text = txtRslt.Text + "Output in: " + fileOut + Environment.NewLine;
            //txtRslt.Text = txtRslt.Text + "------------------------" + Environment.NewLine;
            //return fileOut;
            return "";
        }

        private bool OpStart(object sender)
        {
            //string text = "";
            //txtRslt.Text = "";
            //uint tbrCode = 0;  uint.TryParse(cmbTbrCode.Text, out tbrCode);
            //ciNetProc.tbrCode = tbrCode;
            //ciProc.tbrCode = tbrCode;
            //if (sender != null && sender.GetType().Name == "Button")
            //{
            //    Button btn = (Button)sender;
            //    if (btn.Tag != null) text = btn.Tag.ToString();
            //}
            //if (sender != null && sender.GetType().Name == "String")
            //{
            //    text = (string)sender;
            //}
            //if (text != "")
            //    txtRslt.Text = "### " + text + Environment.NewLine + "#######################" + Environment.NewLine;
            //if ((txtFileIn_.Text == "")) { MessageBox.Show("No File specified"); return false; }
            //Application.DoEvents();
            return true;
        }

        private void OpDone(string sRslt)
        {
            //if (sRslt.StartsWith("### "))
            //    txtRslt.Text = sRslt;
            //else
            //    txtRslt.Text = txtRslt.Text + sRslt;
        }

        private bool GetThumbnailImageAbort()
        {
            return false;
        }

        private void DisplayImage(string fileName)
        {
            //try
            //{
            //    PictureBox1.Image = null;
            //    if (!System.IO.File.Exists(fileName)) return;
            //    ImageIO io = new ImageIO();
            //    Bitmap newImage = io.Open(fileName);
            //    double scaleX = (double)PictureBox1.Width / (double)newImage.Width;
            //    double scaleY = (double)PictureBox1.Height / (double)newImage.Height;
            //    double Scale = Math.Min(scaleX, scaleY);
            //    int w = (int)(newImage.Width * Scale);
            //    int h = (int)(newImage.Height * Scale);
            //    PictureBox1.Image = newImage.GetThumbnailImage(w, h, new System.Drawing.Image.GetThumbnailImageAbort(GetThumbnailImageAbort), IntPtr.Zero);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Image is not displayed because:" + Environment.NewLine + ex.Message);
            //}
        }

        private void ShowError(Exception ex)
        {
            //txtRslt.Text += "ERROR: " + ex.Message.ToString();
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

        string inputFileName = "input_image.txt";
        string outputFileName = "output_barcode.txt";

        Bitmap bitmapImage;
        delegate void SetTextCallback(string text);

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    imagePath = fbd.SelectedPath;
                    File.WriteAllText(inputFileName, imagePath);
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

        private void CreateTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            timer.Interval = 5000;
            timer.Enabled = true;
        }

        private void PerformClickBtn()
        {
            try
            {
                if (button2.InvokeRequired)
                {
                    button2.Invoke(new Action(button2.PerformClick));
                    return;
                }
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            button2.PerformClick();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            PerformClickBtn();
        }

        private void clearView()
        {

        }

        private void getBarCode(string path)
        {
            string s = ciNetProc.readQR(path, 1);
            //textBox2.Text = s;
            File.WriteAllText(outputFileName, s);
            SetText(s);

            Bitmap barcodeBitmap;

            using (var bmpTemp = new Bitmap(path))
            {
                //Bitmap bmp1 = ToGrayScale(bmpTemp);
                barcodeBitmap = AdjustBrightness(bmpTemp, 1f);
            }

            int cnt = 0;
            foreach (Barcode bc in ciNetProc.mBarcodes)
            {
                cnt++;
                string txt = cnt.ToString();
                DrawNumBarcode(barcodeBitmap, bc.Rectangle.Left, bc.Rectangle.Top, txt);
            }

            pictureBox2.Image = bitmapImage;

            DeleteFile();
        }

        private void DeleteFile()
        {
            DirectoryInfo di = new DirectoryInfo(imagePath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        private Bitmap ToGrayScale(Bitmap bmp)
        {
            return bmp;
        }

        private Bitmap AdjustBrightness(Image image, float brightness)
        {
            // Make the ColorMatrix.
            float b = brightness;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
            new float[] {b, 0, 0, 0, 0},
            new float[] {0, b, 0, 0, 0},
            new float[] {0, 0, b, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1},
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying
            // the new ColorMatrix.
            Point[] points = {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }
            Bitmap bmp = ToGrayScale(bm);

            // Return the result.
            return bmp;
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }

        private void DrawNumBarcode(Bitmap bmp, float x, float y, string text)
        {
            Font font = new Font("Tahoma", 88);
            Graphics drawing = Graphics.FromImage(bmp);

            //create a brush for the text
            Brush textBrush = new SolidBrush(Color.Red);

            drawing.DrawString(text, font, textBrush, x, y);

            //drawing.DrawString(DateTime.Now.ToString(), new Font("Tahoma", 48), new SolidBrush(Color.Blue), x - 150, y + 150);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            //pictureBox1.Image = bmp;
            bitmapImage = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = getFileInDir(imagePath);
            if (path != "")
            {
                showImageFromPath(path);
                getBarCode(path);
            }
        }
    }
}
