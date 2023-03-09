using System.Windows.Forms;

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
    }
}