using System;
using System.Windows.Forms;
using static pentago.Configurations;

namespace pentago
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SuspendLayout();
            
            // Initializations
            InitializeForm1();
            InitializeLabels();
            InitializeCircles();
            InitializeSubgrids();
            InitializeArrows();

            ResumeLayout(false);
            PerformLayout();
        }
        
        private void CircleClicked(object sender, EventArgs e)
        {
            PictureBox circle = (PictureBox)sender;
            circle.Enabled = false;
            circle.Image = Properties.Resources.white_circle;
        }
        
        private void ArrowClicked(object sender, EventArgs e)
        {
            PictureBox arrow = (PictureBox)sender;
            int rotationNumber = arrow.TabIndex;
            Rotation rotation = Rotations[rotationNumber];
            Rotate(rotation);
        }
        
        private void Rotate(Rotation rotation)
        {
            if (rotation.IsClockwise)
                RotateClockwise(rotation.SubgridIndex);
            else
                RotateCounterClockwise(rotation.SubgridIndex);
        }
        
        private void RotateClockwise(int subgridIndex)
        {
            return;
        }

        private void RotateCounterClockwise(int subgridIndex)
        {
            return;
        }
    }
}