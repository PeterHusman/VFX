using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using System.Threading;
using Emgu.CV.CvEnum;
using Emgu.CV.BgSegm;
using System.Drawing.Imaging;

namespace VFXWinForms
{
    public partial class Form1 : Form
    {
        Thread displayThread;

        public Form1()
        {
            InitializeComponent();

            displayThread = new Thread(ThreadMain);

            displayThread.IsBackground = true;
            displayThread.Start();
            
        }


        public void ThreadMain()
        {
            //MessageBox.Show("Hi from the thread!");

            Capture cap = new Emgu.CV.Capture(@"C:\Users\Peter Husman\Downloads\Wildlife.wmv");
            Mat minions = new Capture(@"C:\Users\Peter Husman\Downloads\maxresdefault.jpg").QueryFrame();

            Mat data = new Mat();
            Mat chroma = new Mat();

            var filter = new BackgroundSubtractorMOG();

            while (true)
            {
                try
                {
                    cap.Grab();
                    bool grabbed = cap.Retrieve(data);

                    //CvInvoke.CvtColor(data, hsv, ColorConversion.Bgr2Hsv);
                    //BackgroundSubtractorMOG
                    //data.Dispose();
                    //CvInvoke.InRange

                    //filter.Apply(data, hsv);
                    ChromaKey(data, minions, chroma);
                    

                    CvInvoke.Imshow("Window", chroma);
                    CvInvoke.WaitKey(1);

                }
                catch (Exception ex)
                {

                }

            }
        }



        public void ChromaKey(Mat under, Mat over, Mat dest)
        {
            dest.Create(under.Rows, under.Cols, DepthType.Cv8U, 3);
            Bitmap ubmp = under.Bitmap;
            Bitmap obmp = over.Bitmap;
            Bitmap dst = dest.Bitmap;

            BitmapData dataunder = ubmp.LockBits(new Rectangle(0, 0, ubmp.Width, ubmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataover = obmp.LockBits(new Rectangle(0, 0, obmp.Width, obmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData datadst = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte redLow = 0;
            byte redHigh = 255;

            byte greenLow = 200;
            byte greenHigh = 255;

            byte blueLow = 0;
            byte blueHigh = 255;

            unsafe
            {
                byte* ptrO = (byte*)dataover.Scan0;
                byte* ptrU = (byte*)dataunder.Scan0;
                byte* ptrD = (byte*)datadst.Scan0;



                for (int i = 0; i < under.Rows * under.Cols * 3; i+=3)
                {
                    if (ptrO[i] >= redLow && ptrO[i] <= redHigh && ptrO[i + 1] >= greenLow && ptrO[i+1] <= greenHigh && ptrO[i + 2] >= blueLow && ptrO[i + 2] <= blueHigh)
                    {
                        ptrD[i] = ptrU[i];
                        ptrD[i + 1] = ptrU[i + 1];
                        ptrD[i + 2] = ptrU[i + 2];
                    }
                    else
                    {

                        ptrD[i] = ptrO[i];
                        ptrD[i + 1] = ptrO[i + 1];
                        ptrD[i + 2] = ptrO[i + 2];
                    }
                }
            }

            ubmp.UnlockBits(dataunder);
            obmp.UnlockBits(dataover);
            dst.UnlockBits(datadst);

        }
    }
}
