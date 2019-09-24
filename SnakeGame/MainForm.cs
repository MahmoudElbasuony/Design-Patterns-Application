using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class MainForm : Form
    {
        SnakeGameManager _snakeGameManager;
        ArrowDirection _arrowDirection;
        public MainForm()
        {
            InitializeComponent();
            _snakeGameManager = SnakeGameManager.Instance(this.CreateGraphics(), Size);
            _snakeGameManager.SnakeColided += OnSnakeColided;
            refresh_timer.Start();
        }

        private void Refresh_timer_Tick(object sender, EventArgs e)
        {
            _snakeGameManager.UpdateBoard(_arrowDirection);
        }
        protected void OnSnakeColided()
        {
            refresh_timer.Stop();
            MessageBox.Show("You losed !");
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                _arrowDirection = ArrowDirection.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _arrowDirection = ArrowDirection.Down;
            }
            else if (e.KeyCode == Keys.Left)
            {
                _arrowDirection = ArrowDirection.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _arrowDirection = ArrowDirection.Right;
            }
        }
    }
}
