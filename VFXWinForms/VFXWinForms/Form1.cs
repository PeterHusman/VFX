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


        string fileLocation;

        Color min = Color.Transparent;
        Color max = Color.Transparent;
        public Form1()
        {
            InitializeComponent();

            displayThread = new Thread(ThreadMain);

            displayThread.IsBackground = true;
            displayThread.Start();
            
        }


        public void Mask(Mat input, Mat mask, Mat output)
        {
            mask.ConvertTo(mask,DepthType.Cv8U);
            CvInvoke.BitwiseXor(output, output, output);
            input.CopyTo(output, mask);
        }


        public void ThreadMain()
        {
            //MessageBox.Show("Hi from the thread!");

            VideoWriter writer = new VideoWriter("video.mp4", 60, new Size(1280, 720), true);

            int frame = 0;
            Capture cap = new Emgu.CV.Capture(@"C:\Users\Peter Husman\Downloads\Wildlife.wmv");
            Mat minions = new Capture(@"C:\Users\Peter Husman\Downloads\maxresdefault.jpg").QueryFrame();

            Mat data = new Mat();
            Mat chroma = new Mat();

            Mat threshold = new Mat();
            Mat bNot = new Mat();

            Mat minionsMask = new Mat();
            Mat vidMask = new Mat();



            var filter = new BackgroundSubtractorMOG();

            while (true)
            {
                try
                {
                    cap.Grab();
                    bool grabbed = cap.Retrieve(data);


                    CvInvoke.InRange(minions, new ScalarArray(new Emgu.CV.Structure.MCvScalar(0, 206, 0)), new ScalarArray(new Emgu.CV.Structure.MCvScalar(129, 255, 164)), threshold);
                    threshold.CopyTo(bNot);
                    CvInvoke.BitwiseNot(bNot,bNot);
                    Mask(minions,bNot,minionsMask);

                    Mask(data,threshold,vidMask);
                    
                    CvInvoke.BitwiseOr(minionsMask,vidMask,chroma);

                    //CvInvoke.CvtColor(data, hsv, ColorConversion.Bgr2Hsv);
                    //BackgroundSubtractorMOG
                    //data.Dispose();
                    //CvInvoke.InRange

                    //filter.Apply(data, hsv);
                    //ChromaKey(data, minions, chroma,min,max);
                    //CvInvoke.Imwrite($"{fileLocation}{frame.ToString()}.jpg", data);
                    //writer.Write(chroma);
                    CvInvoke.Imshow("Window", chroma);
                    CvInvoke.WaitKey(1);
                    frame++;
                    
                }
                catch (Exception ex)
                {

                }

            }
        }



       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonColorMin_Click(object sender, EventArgs e)
        {
            if (colorDialogMin.ShowDialog() == DialogResult.OK)
            {
                min = colorDialogMin.Color;
            }

        }

        private void buttonMax_Click(object sender, EventArgs e)
        {
            if(colorDialogMax.ShowDialog() == DialogResult.OK)
            {
                max = colorDialogMax.Color;
            }
        }

        private void strtProcess_Click(object sender, EventArgs e)
        {
            if(max != Color.Transparent && min != Color.Transparent)
            {
                saveFile.ShowDialog();
                displayThread.Start();
            }
        }

        private void saveFile_FileOk(object sender, CancelEventArgs e)
        {
            fileLocation = ((SaveFileDialog)sender).FileName.Replace("Save Location.txt","") ;
        }
    }
}
