using System;
using System.Windows.Forms;
using static pentago.Configurations;
using pentago.Board;

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
        
        // Click on the circle
        private void CircleClicked(object sender, EventArgs e)
        {
            PictureBox circle = (PictureBox)sender;
            circle.Enabled = false;
            circle.Image = Properties.Resources.white_circle;
        }
        
        // Click on the arrow
        private void ArrowClicked(object sender, EventArgs e)
        {
            PictureBox arrow = (PictureBox)sender;
            int rotationNumber = arrow.TabIndex;
            Rotation rotation = Rotations[rotationNumber];
            Rotate(rotation);
        }
        
        // Rotate the subgrid according to the given rotation
        private void Rotate(Rotation rotation)
        {
            Position[,] positionsMatrix = CreatPositionsMatrix(rotation.SubgridIndex);
            Position[,] rotatedPositionsMatrix;
            if (rotation.IsClockwise)
                rotatedPositionsMatrix = RotateClockwisePositionsMatrix(positionsMatrix);
            else
                rotatedPositionsMatrix = RotateCounterClockwisePositionsMatrix(positionsMatrix);
            UpdateCircles(rotatedPositionsMatrix, rotation.SubgridIndex);
        }

        // Creat a matrix of positions of the circles in the circles array
        private Position[,] CreatPositionsMatrix(int subgridIndex)
        {
            int x = StartRotation[subgridIndex];
            Position[,] positionsMatrix = new Position[Subgrid.SubgridSize, Subgrid.SubgridSize];
            for (int i = 0; i < Subgrid.SubgridSize; i++)
            {
                for (int j = 0; j < Subgrid.SubgridSize; j++)
                {
                    positionsMatrix[j, i] = new Position(circles[x].Location.X, circles[x].Location.Y);
                    x++;
                }
                x += Subgrid.SubgridSize;
            }
            return positionsMatrix;
        }
        
        // Rotate clockwise the positions matrix
        private Position[,] RotateClockwisePositionsMatrix(Position[,] positionsMatrix)
        {
            Position[,] rotatedPositionsMatrix = new Position[Subgrid.SubgridSize, Subgrid.SubgridSize];
            for (int i = 0; i < Subgrid.SubgridSize; i++)
                for (int j = 0; j < Subgrid.SubgridSize; j++)
                    rotatedPositionsMatrix[i, j] = positionsMatrix[Subgrid.SubgridSize - j - 1, i];
            return rotatedPositionsMatrix;
        }
        
        // Rotate counter clockwise the positions matrix
        private Position[,] RotateCounterClockwisePositionsMatrix(Position[,] positionsMatrix)
        {
            Position[,] rotatedPositionsMatrix = new Position[Subgrid.SubgridSize, Subgrid.SubgridSize];
            for (int i = 0; i < Subgrid.SubgridSize; i++)
                for (int j = 0; j < Subgrid.SubgridSize; j++)
                    rotatedPositionsMatrix[i, j] = positionsMatrix[j, Subgrid.SubgridSize - i - 1];
            return rotatedPositionsMatrix;
        }
        
        // Update the positions of the circles in the circles array according to the positions matrix
        private void UpdateCircles(Position[,] positionsMatrix, int subgridIndex)
        {
            int x = StartRotation[subgridIndex];
            for (int i = 0; i < Subgrid.SubgridSize; i++)
            {
                for (int j = 0; j < Subgrid.SubgridSize; j++)
                {
                    circles[x].Location = new System.Drawing.Point(positionsMatrix[j, i].X, positionsMatrix[j, i].Y);
                    x++;
                }
                x += Subgrid.SubgridSize;
            }
        }
    }
}