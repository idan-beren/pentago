using System;
using System.Windows.Forms;
using static pentago.Configurations;

namespace pentago
{
    public partial class Form1 : Form
    {
        private int _userCell; // user cell
        private int _userRotation; // user rotation
        private int _computerCell; // computer cell
        private int _computerRotation; // computer rotation
        private bool _isClicked; // is clicked - true if the user clicked on a circle, false otherwise
        
        // Constructor
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
        
        // Click on the circle
        private void CircleClicked(object sender, EventArgs e)
        {
            _isClicked = true;
            PictureBox circle = (PictureBox)sender;
            _userCell = circle.TabIndex;
            circle.Enabled = false;
            circle.Image = Properties.Resources.white_circle;
        }
        
        // Click on the arrow
        private void ArrowClicked(object sender, EventArgs e)
        {
            if (_isClicked)
            {
                _isClicked = false;
                PictureBox arrow = (PictureBox)sender;
                _userRotation = arrow.TabIndex;
                Rotation rotation = Rotations[_userRotation];
                Rotate(rotation);
            }
        }
        
        // Rotate the subgrid according to the given rotation
        private void Rotate(Rotation rotation)
        {
            if (rotation.IsClockwise)
                RotateClockwise(rotation.SubgridIndex);
            else
                RotateCounterClockwise(rotation.SubgridIndex);
        }
        
        // Rotate clockwise the subgrid
        private void RotateClockwise(int subgridIndex)
        {
            PictureBox[,] temp = new PictureBox[SubgridSize, SubgridSize];
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    temp[i, j] = CloneCircle(circles[subgridIndex][i, j]);
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    SwapCircles(circles[subgridIndex][i, j], temp[SubgridSize - j - 1, i]);
        }
        
        // Rotate counter-clockwise the subgrid
        private void RotateCounterClockwise(int subgridIndex)
        {
            PictureBox[,] temp = new PictureBox[SubgridSize, SubgridSize];
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    temp[i, j] = CloneCircle(circles[subgridIndex][i, j]);
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    SwapCircles(circles[subgridIndex][i, j],  temp[j, SubgridSize - i - 1]);
        }
        
        // Swap the circles by image and enabled
        private static void SwapCircles(PictureBox circle1, PictureBox circle2)
        {
            System.Drawing.Image tempImage = circle1.Image;
            bool tempEnabled = circle1.Enabled;
            circle1.Image = circle2.Image;
            circle1.Enabled = circle2.Enabled;
            circle2.Image = tempImage;
            circle2.Enabled = tempEnabled;
        }
        
        // Clone the circles
        private static PictureBox CloneCircle(PictureBox circle)
        {
            PictureBox clone = new PictureBox();
            clone.Image = circle.Image;
            clone.Enabled = circle.Enabled;
            return clone;
        }
        
        // Search a circle by its tab index
        private PictureBox SearchCircle(int tabIndex)
        {
            for (int i = 0; i < NumberOfSubgrids; i++)
                for (int j = 0; j < SubgridSize; j++)
                    for (int k = 0; k < SubgridSize; k++)
                        if (circles[i][j, k].TabIndex == tabIndex)
                            return circles[i][j, k];
            return null;
        }
    }
}