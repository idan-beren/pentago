using System;
using System.Windows.Forms;
using static pentago.Configurations;
using pentago.Utilities;
using pentago.Control;

namespace pentago.GUI
{
    // The sequence of the form
    public partial class Form1 : Form
    {
        private int _userCell; // user cell
        private int _userRotation; // user rotation
        private int _computerCell; // computer cell
        private int _computerRotation; // computer rotation
        private bool _isClicked; // is clicked - true if the user clicked on a circle, false otherwise
        private readonly Controller _controller = new Controller(); // controller
        private bool _isFinished; // is finished - true if the game is finished, false otherwise
        
        // Constructor
        public Form1()
        {
            InitializeForm1();
            InitializeStartButton();
            InitializeInstructionsButton();
            InitializeLogoPicture();
        }
        
        // ------------------------------------- MAIN FUNCTIONS --------------------------------------------------------
        
        // Identify a click on a circle, show it on the screen, notify the controller, get the response from the controller about the state of the game and show it if needed
        private void CircleClicked(object sender, EventArgs e)
        {
            if (!_isClicked && !_isFinished)
            {
                _isClicked = true;
                PictureBox circle = (PictureBox)sender;
                _userCell = circle.TabIndex;
                circle.Enabled = false;
                circle.Image = Properties.Resources.white_circle;
                
                GameStatus status = _controller.UserCellMove(_userCell);
                ShowGameStatus(status);
            }
        }
        
        // Identify a click on an arrow, show the rotation on the screen and notify the controller and gets a response with the status of the game and show it if needed
        private void ArrowClicked(object sender, EventArgs e)
        {
            if (_isClicked && !_isFinished)
            {
                _isClicked = false;
                PictureBox arrow = (PictureBox)sender;
                _userRotation = arrow.TabIndex;
                Rotation rotation = Rotations[_userRotation];
                Rotate(rotation);
                
                GameStatus status = _controller.UserRotationMove(_userRotation);
                ShowGameStatus(status);
                
                if (status == GameStatus.Nothing) ComputerMove();
            }
        }
        
        // Gets the move of the computer, show the move on the screen, gets the state of the game and show it if needed
        private void ComputerMove()
        {
            _controller.ComputerMove();
            
            GameStatus status = _controller.ComputerCellMove();
            _computerCell = _controller.Computer.Cell;
            PictureBox circle = SearchCircle(_computerCell);
            circle.Enabled = false;
            circle.Image = Properties.Resources.black_circle;
            ShowGameStatus(status);

            if (status == GameStatus.Nothing)
            {
                status = _controller.ComputerRotationMove();
                _computerRotation = _controller.Computer.Rotation;
                Rotate(Rotations[_computerRotation]);
                ShowGameStatus(status);
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
        
        // Clone a circle
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
        
        // Show the game status if needed on the screen
        private void ShowGameStatus(GameStatus status)
        {
            if (status == GameStatus.Nothing)
                return;
            MessageBox.Show(status.ToString());
            _isFinished = true;
        }
        
        // --------------------------------- SECONDARY FUNCTIONS -------------------------------------------------------
        
        // Identify a click on the restart button, reset the game and initialize the form
        private void RestartButtonClicked(object sender, EventArgs e)
        {
            _controller.ResetGame();
            Init();
        }

        // Identifies a click on the start button, starts the game
        private void StartButtonClicked(object sender, EventArgs e)
        {
            Controls.Clear();
            Init();
        }
        
        // Identifies a click on the instructions button, shows the instructions
        private void InstructionsButtonClicked(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeBackButton();
            InitializeInstructionsPicture();
        }
        
        // Identifies a click on the back button, goes back to the main menu
        private void BackButtonClicked(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeStartButton();
            InitializeInstructionsButton();
            InitializeLogoPicture();
        }
        
        // Initialize the form
        private void Init()
        {
            _isFinished = false;
            _isClicked = false;
            
            Controls.Clear();

            // Initializations
            InitializeForm1();
            InitializeLabels();
            InitializeCircles();
            InitializeSubgrids();
            InitializeArrows();
            InitializeRestartButton();
        }
    }
}