using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using WinFormStringCnvClass;

using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;


namespace DeployONNX
{
    public partial class Form1 : Form
    {
        string thisExeDirPath;
        public Form1()
        {
            InitializeComponent();
            thisExeDirPath = Path.GetDirectoryName(Application.ExecutablePath);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TEXT|*.txt";
            if (false && ofd.ShowDialog() == DialogResult.OK)
            {
                WinFormStringCnv.setControlFromString(this, File.ReadAllText(ofd.FileName));
            }
            else
            {
                string paramFilename = Path.Combine(thisExeDirPath, "_param.txt");
                if (File.Exists(paramFilename))
                {
                    WinFormStringCnv.setControlFromString(this, File.ReadAllText(paramFilename));
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string FormContents = WinFormStringCnv.ToString(this);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TEXT|*.txt";

            if (false && sfd.ShowDialog() == DialogResult.OK)
            {

                File.WriteAllText(sfd.FileName, FormContents);
            }
            else
            {
                string paramFilename = Path.Combine(thisExeDirPath, "_param.txt");
                File.WriteAllText(paramFilename, FormContents);
            }

        }

        private void button_CreateTestImage_Run_Click(object sender, EventArgs e)
        {
            string topDirectoryPath = textBox_CreateTestImage_TargetDir.Text;
            if (!Directory.Exists(topDirectoryPath)) Directory.CreateDirectory(topDirectoryPath);
            if (!Directory.Exists(topDirectoryPath)) return;

            string imageSizeString = textBox_CreateTestImage_Size.Text;
            float defSize = 20.0f;

            //RedDot
            createTestImage_Dot(Path.Combine(topDirectoryPath, "01", "RedDot.png"), imageSizeString, defSize, 50, Brushes.Red);

            //BlueDot
            createTestImage_Dot(Path.Combine(topDirectoryPath, "02", "BlueDot.png"), imageSizeString, defSize, 50, Brushes.Blue);

            //BlackDot
            createTestImage_Dot(Path.Combine(topDirectoryPath, "03", "BlackDot.png"), imageSizeString, defSize, 50, Brushes.Black);

            defSize = 50.0f;
            //RedFlag
            createTestImage_Flagment(Path.Combine(topDirectoryPath, "04", "RedFlag.png"), imageSizeString, defSize, 50, Brushes.Red);

            //BlueFlag
            createTestImage_Flagment(Path.Combine(topDirectoryPath, "05", "BlueFlag.png"), imageSizeString, defSize, 50, Brushes.Blue);

            //BlackFlag
            createTestImage_Flagment(Path.Combine(topDirectoryPath, "06", "BlackFlag.png"), imageSizeString, defSize, 50, Brushes.Black);


        }




        private void createTestImage_Dot(string filename, string imageSize, float dotDiameter, int imgCount, Brush brush)
        {
            string topDirectoryPath = Path.GetDirectoryName(filename);
            if (!Directory.Exists(topDirectoryPath)) Directory.CreateDirectory(topDirectoryPath);

            string[] sizeArray = imageSize.Trim(',').Split(',');

            int imgWidth = int.Parse(sizeArray[0]);
            int imgHeight = int.Parse(sizeArray[1]);

            Random rnd = new Random();

            for (int imgIndex = 0; imgIndex < imgCount; imgIndex++)
            {
                using (Bitmap img = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb))
                {

                    float cx = (float)(imgWidth / 2.0 + (rnd.NextDouble() - 0.5) * imgWidth / 2.0);
                    float cy = (float)(imgHeight / 2.0 + (rnd.NextDouble() - 0.5) * imgHeight / 2.0);
                    float d = (float)(dotDiameter + dotDiameter * 0.5 * (rnd.NextDouble() * 2.0 - 1.0));

                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.FillRectangle(Brushes.White, 0, 0, imgWidth, imgHeight);
                        g.FillEllipse(brush, cx - d / 2.0f, cy - d / 2.0f, d / 2.0f, d / 2.0f);

                    }

                    string saveFilename = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename) + imgIndex.ToString("0000") + Path.GetExtension(filename));
                    img.Save(saveFilename);

                }

            }

        }

        private void createTestImage_Flagment(string filename, string imageSize, float dotDiameter, int imgCount, Brush brush)
        {
            string topDirectoryPath = Path.GetDirectoryName(filename);
            if (!Directory.Exists(topDirectoryPath)) Directory.CreateDirectory(topDirectoryPath);

            string[] sizeArray = imageSize.Trim(',').Split(',');

            int imgWidth = int.Parse(sizeArray[0]);
            int imgHeight = int.Parse(sizeArray[1]);

            Random rnd = new Random();

            for (int imgIndex = 0; imgIndex < imgCount; imgIndex++)
            {
                using (Bitmap img = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb))
                {

                    float cx = (float)(imgWidth / 2.0 + (rnd.NextDouble() - 0.5) * imgWidth / 2.0);
                    float cy = (float)(imgHeight / 2.0 + (rnd.NextDouble() - 0.5) * imgHeight / 2.0);

                    List<Point> points = new List<Point>();

                    for (int corIndex = 0; corIndex < 3; corIndex++)
                    {
                        float dx = (float)(dotDiameter + dotDiameter * 0.5 * (rnd.NextDouble() * 2.0 - 1.0));
                        float dy = (float)(dotDiameter + dotDiameter * 0.5 * (rnd.NextDouble() * 2.0 - 1.0));
                        points.Add(new Point((int)(cx - dx / 2.0f), (int)(cy - dy / 2.0f)));
                    }

                    double areaCount = CalculateTriangleArea(points);
                    if (areaCount <= dotDiameter * 1.5f)
                    {
                        imgIndex--;
                    }
                    else
                    {
                        using (Graphics g = Graphics.FromImage(img))
                        {
                            g.FillRectangle(Brushes.White, 0, 0, imgWidth, imgHeight);
                            g.FillPolygon(brush, points.ToArray());

                        }

                        string saveFilename = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename) + imgIndex.ToString("0000") + Path.GetExtension(filename));
                        img.Save(saveFilename);

                    }

                }

            }

        }

        double CalculateTriangleArea(List<Point> points)
        {
            if (points.Count != 3)
            {
                throw new ArgumentException("Exactly 3 points are required to calculate the area of a triangle.");
            }

            double area = Math.Abs((points[0].X * (points[1].Y - points[2].Y) +
                                    points[1].X * (points[2].Y - points[0].Y) +
                                    points[2].X * (points[0].Y - points[1].Y)) / 2.0);
            return area;
        }

        private void button_LoadOnnxFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ONNX|*.onnx";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string modelPath = ofd.FileName;
            textBox_LoadOnnxFilename.Text = modelPath;

            List<string> Lines = new List<string>();

            using (var session = new InferenceSession(modelPath))
            {
                Lines.Add($"ProducerName: {session.ModelMetadata.ProducerName}");
                Lines.Add($"Version: {session.ModelMetadata.Version.ToString()}");
                Lines.Add($"Description: {session.ModelMetadata.Description}");

                Lines.Add("//Input//");
                foreach (var input in session.InputMetadata)
                {
                    Lines.Add($" Key: {input.Key}, \r\n Value.ElementType: {input.Value.ElementType},\r\n Value.Dimensions: {string.Join(",", input.Value.Dimensions)}");
                    int[] Dimensions = input.Value.Dimensions.ToArray();

                    textBox_LoadOnnxFileInfo_Size.Text = Dimensions[2].ToString() + "," + Dimensions[3].ToString();
                }

                Lines.Add("//Output//");
                foreach (var output in session.OutputMetadata)
                {
                    Lines.Add($" Key: {output.Key},\r\n Value.ElementType: {output.Value.ElementType},\r\n Value.Dimensions: {string.Join(",", output.Value.Dimensions)}");
                }

            };

            textBox_LoadOnnxFileInfo.Text = string.Join("\r\n", Lines.ToArray());

        }
    }
}
