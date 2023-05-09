using static pentago.Configurations;
using System.Drawing;

namespace pentago.GUI
{
    // The designer of the main form
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
        
        // -------------------------------------  MAIN FORM  -----------------------------------------------------------
        
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
        
        // Initialize the circles in the subgrids and add them to the form
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
                for (int j = 0; j < SubgridSize; j++)
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

        private System.Windows.Forms.PictureBox[] arrows; // array of the arrows
        
        // Initialize the arrows and add them to the form
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

        private System.Windows.Forms.Label headerLabel;  // header label
        
        // Initialize the labels and add them to the form
        private void InitializeLabels()
        {
            headerLabel = new System.Windows.Forms.Label();
            headerLabel.Location = new System.Drawing.Point(HeaderPosition.X, HeaderPosition.Y);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new System.Drawing.Size(HeaderSize.Width, HeaderSize.Height);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "𝖕𝖊𝖓𝖙𝖆𝖌𝖔";
            headerLabel.Font = new Font(headerLabel.Font.FontFamily, 34, FontStyle.Bold);
            this.Controls.Add(headerLabel);
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
        
        // ------------------------------------- SECONDARY FUNCTIONS ---------------------------------------------------
        
        private System.Windows.Forms.Button restartButton; // restart button
        
        // Initialize the restart button and add it to the form
        private void InitializeRestartButton()
        {
            restartButton = new System.Windows.Forms.Button();
            restartButton.Location = new System.Drawing.Point(RestartButtonPosition.X, RestartButtonPosition.Y);
            restartButton.Name = "restartButton";
            restartButton.Size = new System.Drawing.Size(ButtonsSize.Width, ButtonsSize.Height);
            restartButton.TabIndex = 0;
            restartButton.Text = "Restart";
            restartButton.Font = new Font(restartButton.Font.FontFamily, 12, FontStyle.Bold);
            restartButton.Click += new System.EventHandler(RestartButtonClicked);
            this.Controls.Add(restartButton);
        }

        private System.Windows.Forms.Button startButton; // start button
        
        // Initialize the start button and add it to the form
        private void InitializeStartButton()
        {
            startButton = new System.Windows.Forms.Button();
            startButton.Location = new System.Drawing.Point(StartButtonPosition.X, StartButtonPosition.Y);
            startButton.Name = "startButton";
            startButton.Size = new System.Drawing.Size(ButtonsSize.Width, ButtonsSize.Height);
            startButton.TabIndex = 0;
            startButton.Text = "Start Game";
            startButton.Font = new Font(startButton.Font.FontFamily, 12, FontStyle.Bold);
            startButton.Click += new System.EventHandler(StartButtonClicked);
            this.Controls.Add(startButton);
        }
        
        private System.Windows.Forms.Button instructionsButton; // instructions button
        
        // Initialize the instructions button and add it to the form
        private void InitializeInstructionsButton()
        {
            instructionsButton = new System.Windows.Forms.Button();
            instructionsButton.Location = new System.Drawing.Point(InstructionsButtonPosition.X, InstructionsButtonPosition.Y);
            instructionsButton.Name = "istructionsButton";
            instructionsButton.Size = new System.Drawing.Size(ButtonsSize.Width, ButtonsSize.Height);
            instructionsButton.TabIndex = 0;
            instructionsButton.Text = "Instructions";
            instructionsButton.Font = new Font(instructionsButton.Font.FontFamily, 12, FontStyle.Bold);
            instructionsButton.Click += new System.EventHandler(InstructionsButtonClicked);
            this.Controls.Add(instructionsButton);
        }
        
        private System.Windows.Forms.Button backButton; // back button
        
        // Initialize the back button and add it to the form
        private void InitializeBackButton()
        {
            backButton = new System.Windows.Forms.Button();
            backButton.Location = new System.Drawing.Point(BackButtonPosition.X, BackButtonPosition.Y);
            backButton.Name = "backButton";
            backButton.Size = new System.Drawing.Size(ButtonsSize.Width, ButtonsSize.Height);
            backButton.TabIndex = 0;
            backButton.Text = "Back";
            backButton.Font = new Font(backButton.Font.FontFamily, 12, FontStyle.Bold);
            backButton.Click += new System.EventHandler(BackButtonClicked);
            this.Controls.Add(backButton);
        }

        private System.Windows.Forms.PictureBox logoPicture;  // logo picture
        
        // Initialize the logo picture and add it to the form
        private void InitializeLogoPicture()
        {
            logoPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(logoPicture)).BeginInit();
            
            logoPicture.Image = global::pentago.Properties.Resources.logo;
            logoPicture.Location = new System.Drawing.Point(0, 0);
            logoPicture.Name = "logoPicture";
            logoPicture.Size = new System.Drawing.Size(LogoSize.Width, LogoSize.Height);
            logoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            logoPicture.TabIndex = 0;
            logoPicture.TabStop = false;
            logoPicture.BackColor = Color.Transparent;
            
            this.Controls.Add(logoPicture);
            ((System.ComponentModel.ISupportInitialize)(logoPicture)).EndInit();
        }
        
        private System.Windows.Forms.PictureBox instructionsPicture;  // instructions picure
        
        // Initialize the instructions picure and add it to the form
        private void InitializeInstructionsPicture()
        {
            instructionsPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(instructionsPicture)).BeginInit();
            
            instructionsPicture.Image = global::pentago.Properties.Resources.instructions;
            instructionsPicture.Location = new System.Drawing.Point(0, 0);
            instructionsPicture.Name = "instructionsPicture";
            instructionsPicture.Size = new System.Drawing.Size(InstructionsSize.Width, InstructionsSize.Height);
            instructionsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            instructionsPicture.TabIndex = 0;
            instructionsPicture.TabStop = false;
            instructionsPicture.BackColor = Color.Transparent;
            
            this.Controls.Add(instructionsPicture);
            ((System.ComponentModel.ISupportInitialize)(instructionsPicture)).EndInit();
        }
        
        // ------------------------------------------ GENERATED CODE ---------------------------------------------------
        
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