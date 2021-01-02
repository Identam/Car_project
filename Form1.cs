using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_cars
{
    public partial class NFS : Form
    {
        
        public NFS()
        {
            InitializeComponent();

            Bitmap DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);            
            pictureBox1.Image = DrawArea;
            Engine.Picture = pictureBox1;
            Engine.Graph = Graphics.FromImage(DrawArea); 
            
            Engine.Initialization();
            Engine.RenderMap();
        }

        private void button5_Click(object sender, EventArgs e) //Start
        {
            Engine.Start();
        }

        private void button6_Click(object sender, EventArgs e) //Pause
        {
            Engine.Pause();
        }

        private void button1_Click(object sender, EventArgs e) //GorizontalLeft
        {
            Gen_crazy.GorizontalLeftC();
        }

        private void button2_Click(object sender, EventArgs e) //VerticalUp
        {
            Gen_crazy.VerticalUpC();
        }

        private void button3_Click(object sender, EventArgs e) //GorizontalRight
        {
            Gen_crazy.GorizontalRightC();
        }

        private void button4_Click(object sender, EventArgs e) //VerticalDown
        {
            Gen_crazy.VerticalDownC();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Generate.GorizontalRight();
            Generate.GorizontalLeft();
            Generate.VerticalUp();
            Generate.VerticalDown();
        }

    }

}
