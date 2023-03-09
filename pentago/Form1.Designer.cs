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
            for (int i = 0; i < 4; i++)
            {
                subgrids[i] = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(subgrids[i])).BeginInit();
                
                subgrids[i].Image = global::pentago.Properties.Resources.subgrid;
                subgrids[i].Location = new System.Drawing.Point(SubgridsPositions[i].X, SubgridsPositions[i].Y);
                subgrids[i].Name = "subgrid" + (i + 1).ToString();
                subgrids[i].Size = new System.Drawing.Size(SubgridsSizes.Width, SubgridsSizes.Height);
                subgrids[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                subgrids[i].TabIndex = i;
                subgrids[i].TabStop = false;
                subgrids[i].BackColor = Color.Transparent;

                this.Controls.Add(subgrids[i]);
                ((System.ComponentModel.ISupportInitialize)(subgrids[i])).EndInit();
            }
        }
        
        private System.Windows.Forms.PictureBox[] circles; // array of the circles
        // Initialize the circles
        private void InitializeCircles()
        {
            circles = new System.Windows.Forms.PictureBox[NumberOfCircles];
            for (int i = 0; i < 36; i++)
            {
                circles[i] = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(circles[i])).BeginInit();
                
                circles[i].Image = global::pentago.Properties.Resources.circle;
                circles[i].Location = new System.Drawing.Point(CirclesPositions[i].X, CirclesPositions[i].Y);
                circles[i].Name = "circle" + (i + 1).ToString();
                circles[i].Size = new System.Drawing.Size(CirclesSizes.Width, CirclesSizes.Height);
                circles[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                circles[i].TabIndex = i;
                circles[i].TabStop = false;
                circles[i].BackColor = Color.FromArgb(139, 0, 0);

                this.Controls.Add(circles[i]);
                ((System.ComponentModel.ISupportInitialize)(circles[i])).EndInit();
            }
        }
        
        private System.Windows.Forms.PictureBox[] arrows; // array of the arrows
        // Initialize the arrows
        private void InitializeArrows()
        {
            arrows = new System.Windows.Forms.PictureBox[NumberOfArrows];
            for (int i = 0; i < 8; i++)
            {
                arrows[i] = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(arrows[i])).BeginInit();
                
                arrows[i].Image = global::pentago.Properties.Resources.arrow;
                arrows[i].Location = new System.Drawing.Point(ArrowsPositions[i].X, ArrowsPositions[i].Y);
                arrows[i].Name = "arrow" + (i + 1).ToString();
                arrows[i].Size = new System.Drawing.Size(ArrowsSizes[i].Width, ArrowsSizes[i].Height);
                arrows[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                arrows[i].TabIndex = i;
                arrows[i].TabStop = false;
                arrows[i].BackColor = Color.Transparent;
                int flips = ArrowsRotations[i];
                arrows[i].Image.RotateFlip((RotateFlipType)flips);

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