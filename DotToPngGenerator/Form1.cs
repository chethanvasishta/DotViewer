using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;

namespace DotToPngGenerator
{
    public partial class MainForm : Form
    {
        private delegate void CreatePNG(String s);
        private CreatePNG m_createPNG;
        private const float MAX_RATIO = 2.0f;
        private const float MIN_RATIO = 0.25f;
        //string exePath = "C:\\Program Files\\Graphviz2.24\\bin\\dot.exe";

        public MainForm()
        {
            InitializeComponent();
            m_createPNG = new CreatePNG(this.CreatePNGMethod);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (a != null)
                {
                    for (int i = 0; i < a.Length; ++i)
                    {
                        String s = a.GetValue(i).ToString();
                        //var parameterizedThreadStart = new System.Threading.ParameterizedThreadStart(CreatePNGMethod);
                        //ThreadStart t = new ThreadStart(CreatePNGMethod);
                        //var thread = new System.Threading.Thread(t);
                        this.BeginInvoke(m_createPNG, s);
                        this.Activate();
                    }
                }
               
            }
            catch
            {
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;            
        }

        private void CreatePNGMethod(String dotPath)
        {
            try
            {
                //if (!dotPath.EndsWith(".dot"))
                //{
                //    throw new ArgumentException();
                //}
                //string pngPath = dotPath + ".SVG";
                //string arguments = "-Tsvg -o ";
                string pngPath = dotPath + ".png";
                string arguments = "-Tpng -o ";
                arguments += pngPath + " ";
                arguments += dotPath + " ";
                Process p = new Process();
                p.StartInfo.FileName = GlobalSettings.GetInstance().DotToPNGConverterPath;
                p.StartInfo.Arguments = arguments;
                p.StartInfo.CreateNoWindow = true;
                //p.StartInfo.RedirectStandardError = true;
                //p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.RedirectStandardInput = true;
                p.Start();
                p.WaitForExit();
                string fileName = pngPath.Substring(pngPath.LastIndexOf('\\')+1);
                
                //check for settings
                if (GlobalSettings.GetInstance().ShowInExternalViewer)//make it true to open the image in new window
                {
                    TabPage t = new TabPage(fileName);
                    mainTabControl.TabPages.Add(t);
                    PictureBox pBox = new PictureBox();
                    t.Controls.Add(pBox);
                    t.Tag = pngPath;
                    pBox.Dock = DockStyle.None;    
                    t.MouseClick += new MouseEventHandler(TabPage_MouseClick);
                    t.AutoScroll = true;
                    t.Scroll += new ScrollEventHandler(t_Scroll);                    
                    //t.ToolTipText = pngPath;
                    
                    pBox.ImageLocation = pngPath;
                    pBox.Refresh();                    
                    pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    pBox.LoadCompleted += new AsyncCompletedEventHandler(pBox_LoadCompleted);
                    pBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBox.MouseDown += new MouseEventHandler(pBox_MouseDown);
                    pBox.MouseUp += new MouseEventHandler(pBox_MouseUp);
                    
                    //pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    //pBox.AutoScrollOffset = t.AutoScrollOffset;
                    //t.Scroll += new ScrollEventHandler(TabScroll);
                    //t.HorizontalScroll.Visible = true;
                    //t.VerticalScroll.Visible = true;                    
                    //t.Focus();
                }
                else
                {
                    Process p1 = new Process();
                    p1.StartInfo.FileName = pngPath;
                    p1.Start();
                }

            }
            catch (ArgumentException arg)
            {
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error occured while performing your request: " + ex.Message);
            }

            
        }

        void t_Scroll(object sender, ScrollEventArgs e)
        {
            
            ((TabPage)sender).Refresh();
        }

        void pBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox p = (PictureBox)sender;
                p.Tag = new Point(e.X, e.Y);
                p.Cursor = Cursors.SizeAll ;
            }
            
        }

        void pBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //move by delta
                //Move((PictureBox)sender, new Point(e.X - mouseDown.X, e.Y - mouseDown.Y));
                //reset the mousedown
                PictureBox p = (PictureBox)sender;
                Point mouseDown = (Point)p.Tag;
                Point offset = new Point(e.X - mouseDown.X, e.Y - mouseDown.Y);
                
                TabPage t = (TabPage)p.Parent;//see if we can catch an exception                
                int value = t.VerticalScroll.Value - offset.Y;
                PictureBox pBox = (PictureBox)t.Controls[0];//This is the only control we have till now in the tabpage
                if (value < 0)
                    value = 0;
                if (value > pBox.Height)
                    value = pBox.Height;
                t.VerticalScroll.Value = value;
                value = t.HorizontalScroll.Value - offset.X;
                if (value < 0)
                    value = 0;
                if (value > pBox.Width)
                    value = pBox.Width;
                t.HorizontalScroll.Value = value;
                p.Cursor = Cursors.Default;
            }
            
        }

       
        void TabPage_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Middle)
            //{
            //    mainTabControl.Controls.Remove((TabPage)sender);
            //}
        }

        void pBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //we set the size mode to stretch
            PictureBox p = (PictureBox)sender;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.SetBounds(0, 0, p.Image.Width, p.Image.Height);
            p.MaximumSize = new Size((int)(p.Image.Width * MAX_RATIO),(int) (p.Image.Height * MAX_RATIO));
            p.MinimumSize = new Size((int)(p.Image.Width * MIN_RATIO), (int)(p.Image.Height * MIN_RATIO));
        }

        void mainTabControl_MouseWheel(object sender, MouseEventArgs e)
        {
            //we get the mouse wheel in focus.. this is per scroll
            if (mainTabControl.TabCount == 0)
                return;
            TabPage t = mainTabControl.SelectedTab;
            PictureBox p = (PictureBox)t.Controls[0];
            Zoom(p, e);
        }

        private void Zoom(PictureBox p, MouseEventArgs e)
        {
            //p.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //p.Update();
            //
            
            //g.DrawImageUnscaled(p.Image, p.Left, p.Top);
            bool isUpwardsScroll = e.Delta < 0;
            //Graphics g = p.CreateGraphics();
            //Image picImage = p.Image;
            //Bitmap tempBitmap = new Bitmap(picImage.Width, picImage.Height,
            //                       PixelFormat.Format24bppRgb);
            //tempBitmap.SetResolution(picImage.HorizontalResolution,
            //                 picImage.VerticalResolution);
            //Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            ////bmGraphics.Clear(_BackColor);

            //// Set the interpolationmode since we are resizing an image here

            //bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //// Draw the original image on the temporary bitmap, resizing it using

            //// the calculated values of targetWidth and targetHeight.

            //bmGraphics.DrawImage(picImage,
            //                     new Rectangle(0, 0, picImage.Width*5/4, picImage.Height*5/4),
            //                     new Rectangle(0, 0, picImage.Width, picImage.Height),
            //                     GraphicsUnit.Pixel);

            //// Dispose of the bmGraphics object

            //bmGraphics.Dispose();

            //// Set the image of the picImage picturebox to the temporary bitmap

            //p.Image = tempBitmap;
            int width = p.Width;
            int height = p.Height;              
            if (isUpwardsScroll)
            {
                p.Width = p.Width * 4 / 5;
                p.Height = p.Height * 4 / 5;
                //g.DrawImage(p.Image, e.X * 5 / 4, e.Y * 5 / 4);
            }
            else
            {

                p.Width = p.Width * 5 / 4;
                p.Height = p.Height * 5 / 4;
                //g.DrawImage(p.Image, e.X * 4 / 5, e.Y * 4 / 5);
            }
            try
            {
                if (p.Width >= p.MaximumSize.Width || p.Height >= p.MaximumSize.Height || p.Width <= p.MinimumSize.Width || p.Height <= p.MinimumSize.Height)
                {
                    //do it with min too
                    p.Width = width;
                    p.Height = height;
                }
                p.Refresh();
            }
            catch(System.ComponentModel.Win32Exception ex)
            {
                //p.Width = width;
                //p.Height = height;
                //p.Refresh();
                Console.WriteLine(ex.Message);
            }
            
        }  

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }        

        private void mainTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (mainTabControl.TabCount != 0)
            {
                if (e.Button == MouseButtons.Middle)
                    mainTabControl.Controls.Remove(mainTabControl.SelectedTab);
            }
        }

        private void closeFileMenuItem_Click(object sender, EventArgs e)
        {
            if (mainTabControl.TabCount != 0)
                mainTabControl.Controls.Remove(mainTabControl.SelectedTab);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
