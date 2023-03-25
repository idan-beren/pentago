using static pentago.Configurations;
using System.Drawing;

namespace pentago
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
        
        // -------------------------------------------------------------------------------------------------------------
        
        private System.Windows.Forms.PictureBox[] subgrids; // array of the subgrids
        
        // Initialize the subgrids array and add them to the form
        private void InitializeSubgrids()
        {
            subgrids = new System.Windows.Forms.PictureBox[NumberOfSubgrids];
            for (int i = 0; i < NumberOfSubgrids; i++)
            {
                subgrids[i] = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(subgrids[i])).BeginInit();
                
                subgrids[i].Image = global::pentago.Properties.Resources.subgrid;
                subgrids[i].Location = new System.Drawing.Point(SubgridsPositions[i].X, SubgridsPositions[i].Y);
                subgrids[i].Name = "subgrid" + (i).ToString();
                subgrids[i].Size = new System.Drawing.Size(SubgridsSizes.Width, SubgridsSizes.Height);
                subgrids[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                subgrids[i].TabIndex = i;
                subgrids[i].TabStop = false;
                subgrids[i].BackColor = Color.Transparent;

                this.Controls.Add(subgrids[i]);
                ((System.ComponentModel.ISupportInitialize)(subgrids[i])).EndInit();
            }
        }

        private System.Windows.Forms.PictureBox[,] circles1; // matrix of the circles in the first subgrid
        private System.Windows.Forms.PictureBox[,] circles2; // matrix of the circles in the second subgrid
        private System.Windows.Forms.PictureBox[,] circles3; // matrix of the circles in the third subgrid
        private System.Windows.Forms.PictureBox[,] circles4; // matrix of the circles in the fourth subgrid
        private System.Windows.Forms.PictureBox[][,] circles; // array of the circles in the subgrids
        
        // Initialize the circles in the subgrids
        private void InitializeCircles()
        {
            circles1 = new System.Windows.Forms.PictureBox[SubgridSize, SubgridSize];
            circles2 = new System.Windows.Forms.PictureBox[SubgridSize, SubgridSize];
            circles3 = new System.Windows.Forms.PictureBox[SubgridSize, SubgridSize];
            circles4 = new System.Windows.Forms.PictureBox[SubgridSize, SubgridSize];
            circles = new System.Windows.Forms.PictureBox[NumberOfSubgrids][,];
            circles[0] = circles1;
            circles[1] = circles2;
            circles[2] = circles3;
            circles[3] = circles4;
            
            int index = 0;
            for (int i = 0; i < NumberOfSubgrids; i++)
            {
                for (int j = 0; j < SubgridSize; j++)
                {
                    for (int k = 0; k < SubgridSize; k++)
                    {
                        circles[i][j, k] = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(circles[i][j, k])).BeginInit();
                        
                        circles[i][j, k].Image = global::pentago.Properties.Resources.circle;
                        circles[i][j, k].Location = new System.Drawing.Point(CirclesPositions[i][j, k].X, CirclesPositions[i][j, k].Y);
                        circles[i][j, k].Name = "circle" + (i).ToString() + (j).ToString() + (k).ToString();
                        circles[i][j, k].Size = new System.Drawing.Size(CirclesSizes.Width, CirclesSizes.Height);
                        circles[i][j, k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        circles[i][j, k].TabIndex = CellIndexes[index];
                        index++;
                        circles[i][j, k].TabStop = false;
                        circles[i][j, k].BackColor = Color.FromArgb(139, 0, 0);;
                        circles[i][j, k].Click += new System.EventHandler(CircleClicked);
                        
                        this.Controls.Add(circles[i][j, k]);
                        ((System.ComponentModel.ISupportInitialize)(circles[i][j, k])).EndInit();
                    }
                }
            }
        }

        private System.Windows.Forms.PictureBox[] arrows; // array of the arrows
        
        // Initialize the arrows
        private void InitializeArrows()
        {
            arrows = new System.Windows.Forms.PictureBox[NumberOfArrows];
            for (int i = 0; i < NumberOfArrows; i++)
            {
                arrows[i] = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(arrows[i])).BeginInit();
                
                arrows[i].Image = global::pentago.Properties.Resources.arrow;
                arrows[i].Location = new System.Drawing.Point(ArrowsPositions[i].X, ArrowsPositions[i].Y);
                arrows[i].Name = "arrow" + (i).ToString();
                arrows[i].Size = new System.Drawing.Size(ArrowsSizes[i].Width, ArrowsSizes[i].Height);
                arrows[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                arrows[i].TabIndex = i;
                arrows[i].TabStop = false;
                arrows[i].BackColor = Color.Transparent;
                int flips = ArrowsRotations[i];
                arrows[i].Image.RotateFlip((RotateFlipType)flips);
                arrows[i].Click += new System.EventHandler(ArrowClicked);

                this.Controls.Add(arrows[i]);
                ((System.ComponentModel.ISupportInitialize)(arrows[i])).EndInit();
            }
        }

        // Initialize the form
        private void InitializeForm1()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(ScreenSizes.Width, ScreenSizes.Height);
            this.Name = "Form1";
            this.Text = "Pentago";
        }
        
        private System.Windows.Forms.Label headerLabel;  // header label
        // Initialize the labels
        private void InitializeLabels()
        {
            headerLabel = new System.Windows.Forms.Label();
            headerLabel.Location = new System.Drawing.Point(290, 50);
            headerLabel.Name = "label1";
            headerLabel.Size = new System.Drawing.Size(250, 100);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "𝖕𝖊𝖓𝖙𝖆𝖌𝖔";
            headerLabel.Font = new Font(headerLabel.Font.FontFamily, 34, FontStyle.Bold);
            this.Controls.Add(headerLabel);
        }

        // -------------------------------------------------------------------------------------------------------------
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Form1";
            this.ResumeLayout(false);
        }

        #endregion
    }
}