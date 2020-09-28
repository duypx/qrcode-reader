using System;
using System.Collections.Generic;
using System.Text;
using Inlite.ClearImageNet;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Main
{
    internal class ClearImageNetFnc
    {
        internal System.Windows.Forms.TextBox txtRslt = null;
        internal uint tbrCode;
        #region ClearImageNet API demonstration
        internal string readWithZones(string fileName, int page)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.Code128 = true; reader.Code39 = true;
                ImageIO io = new ImageIO();
                ImageInfo info = io.Info(fileName, page);
                string s = "======= Barcode in ZONE (upper half of the image) ===========" + Environment.NewLine;
                // Set zone to top half of the image
                reader.Zone = new Rectangle(0, 0, info.Width, info.Height / 2);
                Barcode[] barcodes = reader.Read(fileName, page);
                int cnt = 0;
                foreach (Barcode bc in barcodes)
                { cnt++; AddBarcode(ref s, cnt, bc); }
                if (cnt == 0) { s = s + "NO BARCODES"; }
                s = s + Environment.NewLine;
                s = s + "======= Barcode in IMAGE ===========" + Environment.NewLine;
                // Disable zone
                reader.Zone = new Rectangle();
                barcodes = reader.Read(fileName, page);
                cnt = 0;
                foreach (Barcode bc in barcodes)
                { cnt++; AddBarcode(ref s, cnt, bc); }
                if (cnt == 0) { s = s + "NO BARCODES"; }
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        private void _OnBarcodeFound(object sender, BarcodeFoundEventArgs e)
        {
            // e.cancel = (e.Count == 3);		// Cancel after 3 barcodes are found
            txtRslt.Text = txtRslt.Text + "_OnBarcodeFound -> ";
            string s = txtRslt.Text;
            AddBarcode(ref s, e.Count, e.Barcode);
            txtRslt.Text = s;
            System.Windows.Forms.Application.DoEvents();
        }

        internal string readWithEvents(string fileName)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.Code128 = true; reader.Code39 = true;
                // Configure events
                reader.BarcodeFoundEvent += new BarcodeReader.BarcodeFoundEventHandler(_OnBarcodeFound);
                // Read
                reader.Read(fileName);
                if ((txtRslt.Text == "")) { txtRslt.Text = "NO BARCODES"; }
                return "";  //  txtRslt.Text is already updated;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        long filesScanned = 0;
        static object _lockObject = new object();
        string[] filesToScan;
        private delegate void SetControlPropertyThreadSafeDelegate(System.Windows.Forms.Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(System.Windows.Forms.Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, System.Reflection.BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        private void _OnBarcodeFoundThread(object sender, BarcodeFoundEventArgs e)
        {
            lock (_lockObject)
            {
                string s = txtRslt.Text + "_OnBarcodeFound on Managed Thread " + System.Threading.Thread.CurrentThread.ManagedThreadId + " -> ";
                AddBarcode(ref s, e.Count, e.Barcode);
                SetControlPropertyThreadSafe(txtRslt, "Text", s);
                // txtRslt.Text = s;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void readFileOnThread()
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // configure directions
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.Code128 = true; reader.Code39 = true;
                // Configure events
                reader.BarcodeFoundEvent += new BarcodeReader.BarcodeFoundEventHandler(_OnBarcodeFoundThread);
                // Read
                while (true)
                {
                    string fileName;
                    // Obtain next file name
                    lock (_lockObject)
                    {
                        if (filesScanned >= filesToScan.Length)
                            break;
                        fileName = filesToScan[filesScanned];
                        filesScanned++;
                    }
                    //  Read images from file
                    try
                    {
#if false
                       reader.Read(fileName);     // Read all pages
#else
                        reader.Read(fileName, 1);  // Read only page 1
#endif
                    }
                    catch (Exception ex)
                    {
                        string s = txtRslt.Text + ">>>>>>>> ERROR processing '" + fileName + "'" +
                            Environment.NewLine + ex.Message + Environment.NewLine;
                        lock (_lockObject)
                        {
                            SetControlPropertyThreadSafe(txtRslt, "Text", s);
                            System.Windows.Forms.Application.DoEvents();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string s = txtRslt.Text + ">>>>>>>> ERROR processing '" + Environment.NewLine + ex.Message + Environment.NewLine;
                lock (_lockObject)
                {
                    SetControlPropertyThreadSafe(txtRslt, "Text", s);
                    System.Windows.Forms.Application.DoEvents();
                }
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string readDirectoryWithThreads(string directoryName)
        {
            filesToScan = Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly);
            filesScanned = 0;
            // Start 2 threads
            Thread workerThread1 = new Thread(new ThreadStart(readFileOnThread));
            workerThread1.Start();
            Thread workerThread2 = new Thread(new ThreadStart(readFileOnThread));
            workerThread2.Start();
            // wait for both threads to exit
            while (workerThread1.IsAlive || workerThread2.IsAlive)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            txtRslt.Text = txtRslt.Text + "DONE!!!";
            return "";  //  txtRslt.Text is already updated;
        }

        internal string readCode128andCode39(string fileName, int page)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.Code128 = true; reader.Code39 = true;
                Barcode[] barcodes = reader.Read(fileName, page);
                string s = ""; int cnt = 0;
                foreach (Barcode bc in barcodes)
                { cnt++; AddBarcode(ref s, cnt, bc); }
                if (cnt == 0) { s = s + "NO BARCODES"; }
                s = s + Environment.NewLine;
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string read1DautoType(string fileName, int page)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.Auto1D = true;
                Barcode[] barcodes = reader.Read(fileName, page);
                string s = ""; int cnt = 0;
                foreach (Barcode bc in barcodes)
                { cnt++; AddBarcode(ref s, cnt, bc); }
                if (cnt == 0) { s = s + "NO BARCODES"; }
                s = s + Environment.NewLine;
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string readMultiPageFile(string fileName)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.Code128 = true; reader.Code39 = true;
                Barcode[] barcodes = reader.Read(fileName);
                string s = ""; int cnt = 0;
                foreach (Barcode bc in barcodes)
                { cnt++; AddBarcode(ref s, cnt, bc); }
                if (cnt == 0) { s = s + "NO BARCODES"; }
                s = s + Environment.NewLine;
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string readFromStream(string fileName)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.Code128 = true; reader.Code39 = true;
                string s = "";
                using (MemoryStream ms = Utility.FileToStream(fileName))
                {
                    Barcode[] barcodes = reader.Read(ms);
                     int cnt = 0;
                    foreach (Barcode bc in barcodes)
                    { cnt++; AddBarcode(ref s, cnt, bc); }
                    if (cnt == 0) { s = s + "NO BARCODES"; }
                }
                s = s + Environment.NewLine;
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string readPDF417(string fileName, int page)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.Pdf417 = true;
                Barcode[] barcodes = reader.Read(fileName, page);
                string s = ""; int cnt = 0;
                foreach (Barcode bc in barcodes)
                { cnt++; AddBarcode(ref s, cnt, bc); }
                if (cnt == 0) { s = "NO BARCODES"; }
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string readDriverLicense(string fileName, int page)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.DrvLicID = true;
                Barcode[] barcodes = reader.Read(fileName, page);
                string s = ""; int cnt = 0;
                foreach (Barcode bc in barcodes)
                {
                    cnt++;
                    if (bc.Type == BarcodeType.Pdf417)
                    {
                        // Decode and display AAMVA data as XML
                        string aamva = bc.Decode(BarcodeDecoding.aamva);
                        if (aamva != "")
                            s = s + "Driver License / ID Data: " + Environment.NewLine + aamva + Environment.NewLine;
                    }
                    AddBarcode(ref s, cnt, bc);
                }
                if (cnt == 0) { s = "NO BARCODES"; }
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string readDataMatrix(string fileName, int page)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.DataMatrix = true;
                Barcode[] barcodes = reader.Read(fileName, page);
                string s = ""; int cnt = 0;
                foreach (Barcode bc in barcodes)
                { cnt++; AddBarcode(ref s, cnt, bc); }
                if (cnt == 0) { s = "NO BARCODES"; }
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string readQR(string fileName, int page)
        {
            BarcodeReader reader = null;
            try
            {
                reader = new BarcodeReader();
                if (tbrCode != 0) reader.TbrCode = tbrCode;// ClearImage V9 and later. Otherwise use:  reader.Read(tbrCode.ToString(), 456780);
                // for faster reading specify only required direction
                reader.Horizontal = true; reader.Vertical = true; reader.Diagonal = true;
                //configure types
                reader.QR = true;
                Barcode[] barcodes = reader.Read(fileName, page);
                string s = ""; int cnt = 0;
                foreach (Barcode bc in barcodes)
                { cnt++; AddBarcode(ref s, cnt, bc); }
                if (cnt == 0) { s = "NO BARCODES"; }
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string ShowInfo(ImageInfo info, int nPage)
        {
            string s = "";
            if (nPage == 1)
                s +=
                    "File = " + info.FileName + Environment.NewLine +
                            "  PageCnt = " + info.PageCount.ToString() + "   Format = " +
                            System.Enum.GetName(typeof(ImageFileFormat), info.FileFormat) + Environment.NewLine;
            if (info.Page > 0) s = s +
                "  Page=" + info.Page.ToString() + "  Format=" + System.Enum.GetName(typeof(PageCompression), info.Compression) +
                "  Size=" + info.Width.ToString() + "x" + info.Height.ToString() +
                "  Dpi=" + info.HorizontalDpi.ToString() + "x" + info.VerticalDpi.ToString() +
                "  Bpp=" + info.BitsPerPixel.ToString() + Environment.NewLine;
            else s = s +
                "  Page = " + nPage.ToString() + "   Format = " + System.Enum.GetName(typeof(PageCompression), info.Compression)
                    + Environment.NewLine;
            return s;
        }

        internal string Info(string fileName)
        {
            string s = "";
            ImageIO io1 = new ImageIO();
            int page = 1;
            ImageInfo oInfo;
            oInfo = io1.Info(fileName, page);
            int pages = oInfo.PageCount;
            txtRslt.Text = txtRslt.Text + ShowInfo(oInfo, page);
            for (page = 2; page <= Math.Min(pages, 20); page++)
            {
                oInfo = io1.Info(fileName, page);
                txtRslt.Text = txtRslt.Text + ShowInfo(oInfo, page);
                System.Windows.Forms.Application.DoEvents();
            }
            return txtRslt.Text;
        }



        internal string repairPage(string fileName, int page, string fileOut, ImageFileFormat format)
        {
            ImageEditor editor = null;
            try
            {
                editor = new ImageEditor();
                editor.Image.Open(fileName, page);
                string s = "File:" + fileName + "  Page:" + page.ToString() + Environment.NewLine;
                editor.AutoDeskew(); s = s + "AutoDeskew" + Environment.NewLine;
                editor.AutoCrop(50, 50, 50, 50); s = s + "AutoCrop (margins 50pix)" + Environment.NewLine;
                //  Save results
                if (fileOut != "")
                {
                    if (File.Exists(fileOut))
                    {
                        editor.Image.Append(fileOut, Inlite.ClearImage.EFileFormat.ciEXT);
                        s = s + "Append:" + fileOut;
                    }
                    else
                    {
                        editor.Image.SaveAs(fileOut, Inlite.ClearImage.EFileFormat.ciEXT);
                        s = s + "SaveAs:" + fileOut;
                    }
                }
                s = s + Environment.NewLine + "--------------" + Environment.NewLine;
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (editor != null) editor.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }


        private void _OnEditPage(object sender, EditPageEventArgs e)
        {
            // if (e.Editor.Image.PageNumber % 2 == 1) // skip odd pages
            //    { e.skipPage = true; return; }

            e.Editor.AutoDeskew();
            e.Editor.AutoCrop(50, 50, 50, 50);

            // if (e.Editor.Image.PageNumber % 4 == 0) // invert each 4th page
            //     { e.Editor.Image.Invert(); }

            // display progress
            string s = "_OnEditPage -> ";
            s = s + "File:" + e.Editor.Image.FileName + "  Page:" + e.Editor.Image.PageNumber + Environment.NewLine;
            s = s + "AutoDeskew" + Environment.NewLine;
            s = s + "AutoCrop (margins 50pix)" + Environment.NewLine;
            txtRslt.Text = txtRslt.Text + s;
            System.Windows.Forms.Application.DoEvents();
        }

        internal string repairFile(string fileName, string fileOut, ImageFileFormat format)
        {
            ImageEditor editor = null;
            try
            {
                editor = new ImageEditor();
                bool ret = editor.Edit(fileName, _OnEditPage, fileOut, format, true);
                return txtRslt.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (editor != null) editor.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string repairStream(string fileName, string fileOut, ImageFileFormat format)
        {
            ImageEditor editor = null;
            try
            {
                editor = new ImageEditor();

                MemoryStream ms = Utility.FileToStream(fileName);
                MemoryStream msOut = editor.Edit(ms, _OnEditPage, format);
                if (msOut != null)
                    Utility.StreamToFile(msOut, fileOut);
                return "";  //  txtRslt.Text is already updated;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (editor != null) editor.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string toolsPage(string fileName, int page)
        {
            ImageEditor editor = null;
            try
            {
                editor = new ImageEditor();
                string s = "";
                editor.Image.Open(fileName, page);
                double dSkew = editor.SkewAngle; s = s + string.Format("Skew {0:0.##} deg", dSkew) + Environment.NewLine;
                if (editor.BitsPerPixel == 1)
                {
                    ImageObject[] objects = editor.GetObjects();
                    s = s + string.Format("Object Count: {0}", objects.Length) + Environment.NewLine;
                }
                return s;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (editor != null) editor.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        internal string serverInfo()
        {
            txtRslt.Text = txtRslt.Text + "ClearImageNet Server " + Server.Major.ToString() + "." + Server.Minor.ToString() + "." + Server.Release.ToString() + "  " + Server.Edition;
            txtRslt.Text = txtRslt.Text + Environment.NewLine;
            string sFormat = "{0,-16} {1,-30} {2,-9} {3,-5}";
            string s1 = String.Format(sFormat, "MODULE", "PRODUCT", "LICENSED", "CALLS");
            txtRslt.Text = txtRslt.Text + s1 + Environment.NewLine;
            foreach (LicModule oModule in Server.Modules)
            {
                s1 = String.Format(sFormat, oModule.Name, oModule.Product,
                    (Server.Edition.StartsWith("Dev") ? "DevMode" : oModule.IsLicensed.ToString()),
                    oModule.Calls.ToString());
                txtRslt.Text = txtRslt.Text + s1 + Environment.NewLine;
            }
            return txtRslt.Text;
        }

        private void _OnObjectFound(object sender, ObjectFoundEventArgs e)
        {
            e.cancel = (e.Count == 20);		// Cancel after 20 objects 
            txtRslt.Text = txtRslt.Text + "_OnObjectFound -> ";
            string s = txtRslt.Text;
            AddObject(ref s, e.Count, e.ImageObject);
            txtRslt.Text = s;
            System.Windows.Forms.Application.DoEvents();
        }

        internal string toolsWithEvents(string fileName, int page, bool bSaveResults)
        {
            ImageEditor editor = null;
            try
            {
                editor = new ImageEditor();
                editor.Image.Open(fileName, page);
                // Configure events
                editor.ObjectFoundEvent += new ImageEditor.ObjectFoundEventHandler(_OnObjectFound);
                editor.GetObjects();
                return txtRslt.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (editor != null) editor.Dispose();  // ClearImage V9 and later.  Immediately free memory
            }
        }

        private void AddBarcode(ref string s, long i, Barcode Bc)
        {
            s = s + "Barcode#:" + i.ToString();
            if (Bc.File != "") s += "  File:" + Bc.File;
            s = s + " Page:" + Bc.Page.ToString() + Environment.NewLine;
            s = s + " Type:" + System.Enum.GetName(Bc.Type.GetType(), Bc.Type);
            s = s + " Lng:" + Bc.Length.ToString();
            // s = s + Environment.NewLine + "   "; 
            s = s + " Rect:" + Bc.Rectangle.Left.ToString() + ":" + Bc.Rectangle.Top.ToString() + "-" + Bc.Rectangle.Right.ToString() + ":" + Bc.Rectangle.Bottom.ToString();
            s = s + " Rotation:" + System.Enum.GetName(Bc.Rotation.GetType(), Bc.Rotation);
            // Try to decompress 2D Barcode data
            if (Bc.Type == BarcodeType.Pdf417 || Bc.Type == BarcodeType.DataMatrix || Bc.Type == BarcodeType.QR)
            {
                string decomp = Bc.Decode(BarcodeDecoding.compA);
                if (decomp != "")
                    s = s + Environment.NewLine + Environment.NewLine + "DECOMPRESSED BARCODE DATA (A):" + Environment.NewLine + decomp + Environment.NewLine;
                decomp = Bc.Decode(BarcodeDecoding.compI);
                if (decomp != "")
                    s = s + Environment.NewLine + Environment.NewLine + "DECOMPRESSED BARCODE DATA (I):" + Environment.NewLine + decomp + Environment.NewLine;
            }
            // Show raw  data
            s = s + Environment.NewLine + "RAW BARCODE DATA:" + Environment.NewLine + Bc.Text;
            s = s + Environment.NewLine + "--------------" + Environment.NewLine;
        }

        private void AddObject(ref string s, long cnt, ImageObject Obj)
        {
            s = s + "Object #" + cnt.ToString();
            s = s + " Pixels:" + Obj.Pixels.ToString() + " Intervals:" + Obj.Intervals.ToString();
            s = s + " Rect:" + Obj.Rectangle.Left.ToString() + ":" + Obj.Rectangle.Top.ToString() + "-" + Obj.Rectangle.Right.ToString() + ":" + Obj.Rectangle.Bottom.ToString();
            s = s + Environment.NewLine;
        }

        #endregion
    }
}
