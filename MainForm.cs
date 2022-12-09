
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Speech;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace SmartCortana
{
    public partial class mainform : Form
    {
       
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int countImages, NumLabels, t;
        string name, names, currentuser = null;
        SpeechSynthesizer speech = new SpeechSynthesizer();

        void LogAdd(string add,bool isCortana=true) {
            if(isCortana)
            rtbLog.AppendText("["+DateTime.Now.ToLongTimeString()+"] "+"Cortana"+": "+add+"\n");
            else
            rtbLog.AppendText("[" + DateTime.Now.ToLongTimeString() + "] " + currentuser+ ": " + add + "\n");
        }
        public mainform()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                //Load of previus faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/Faces/FacesLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                countImages = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/Faces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception e)
            {
                speech.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
                LogAdd("there is not face in data base");
                speech.SpeakAsync("there is not face in data base");
            }

        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            LogAdd(txtchat.Text, false);
        }

        void timertiming(object sender, EventArgs e)
        {
            DetectFaces();
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddPerson frm = new frmAddPerson();
            frm.ShowDialog();

        }


        private void button2_Click(object sender, System.EventArgs e)
        {
          
        }


    //    void FrameGrabber(object sender, EventArgs e)
     void DetectFaces()
        {
            label3.Text = "0";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    //Convert it to Grayscale
                    gray = currentFrame.Convert<Gray, Byte>();

                    //Face Detector
                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                  face,
                  1.2,
                  10,
                  Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                  new Size(20, 20));

                    //Action for each element detected
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        t = t + 1;
                        result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with cyan color                    
                //  currentFrame.Draw(f.rect, new Bgr(Color.Cyan), 1);


                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(countImages, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                      labels.ToArray(),
                      3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    //    //Draw the label for each face detected and recognized
                    //currentFrame.Draw(name, ref font, new Point(f.rect.X , f.rect.Y ), new Bgr(Color.Cyan));
                }
                     

                            NamePersons[t-1] = name;
                            NamePersons.Add("");
                            
                        //Set the number of faces detected on the scene
                       // label3.Text = facesDetected[0].Length.ToString();                  

                    }
                        t = 0;

            //Names concatenation of persons recognized

            //Show the faces procesed and recognized
            //imageBoxFrameGrabber.Image = currentFrame;
            //label4.Text = names;
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                if (nnn==1)
                    names = names + NamePersons[nnn] + " and ";
                else
                    names = names + NamePersons[nnn];
            }
           
            label4.Text = names;
            label3.Text = facesDetected[0].Length.ToString();

            if (names != "" && names != currentuser)
            {

                speech.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
                LogAdd(names + " welcome to cortana");
                speech.SpeakAsync(names + " welcome to cortana");
            }
            if(names!="")
            currentuser = names;
            names = "";
            // Task.Factory.StartNew(() =>
            // {
          
           // });
            NamePersons.Clear();
            
            //Clear the list(vector) of names
           
                     
                }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            speech.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
           
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
             Application.Idle += new EventHandler(timertiming);
            //timerCheckFace.Start();
        }


    }
}