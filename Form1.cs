using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;


namespace pacman_2
{
    public partial class F_pacman : Form
    {
        bool goup, godown, goleft, goright, IsGameOver;

        int score, playerSpeed, redGhostspeed, yellowGhostspeed, pinkGhostX, pinkGhostY;

        private void pictureBox31_Click(object sender, EventArgs e)
        {

        }

        private void F_pacman_Load(object sender, EventArgs e)
        {

        }

        public F_pacman()
        {
            InitializeComponent();

            resetGame();
        }        

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            lb_score.Text = "Score: " + score;

            if(goleft == true)
            {
                pb_pacman.Left -= playerSpeed;
                pb_pacman.Image = Properties.Resources.left;

            }
            if(goright == true)
            {
                pb_pacman.Left += playerSpeed;
                pb_pacman.Image = Properties.Resources.right;
            }
            if(godown == true)
            {
                pb_pacman.Top += playerSpeed;
                pb_pacman.Image = Properties.Resources.down;
            }
            if(goup == true)
            {
                pb_pacman.Top -= playerSpeed;
                pb_pacman.Image = Properties.Resources.Up;
            }

            if(pb_pacman.Left < 199)
            {
                pb_pacman.Left = 598;
            }
            if(pb_pacman.Left > 598)
            {
                pb_pacman.Left = 199;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if ((string)x.Tag == "coin")
                    {
                        if (pb_pacman.Bounds.IntersectsWith(x.Bounds));
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }
                }
            }

        }
         /// <summary>
         ///  Inicio del juego. 
         /// </summary>
        private void resetGame()
        {
            lb_score.Text = "Score: 0";    // el puntaje es cero.
            score = 0;

            redGhostspeed = 5;  // velocidad del primer fantasma rojo.
            yellowGhostspeed = 5;  // velocidad del fantasma naranja.
            pinkGhostX = 5;
            pinkGhostY = 5;
            playerSpeed = 8;

            IsGameOver = false;

            pb_pacman.Left = 188;   // posicion de pacman incio en x
            pb_pacman.Top = 410;    // posicion de pacman inicio en y. 

            pb_red.Left = 362;       // posicion del fantasma rojo en x
            pb_red.Top = 196;        // posicion del fanstama rojo en y
            pb_orange.Left = 341;    // posicion del fanstasma naranja en x
            pb_orange.Top = 196;    // posicion del fantasma naranja en y
            pb_pink.Left = 383;      // posicion del fantasma rosa en x
            pb_pink.Top = 196;      // posicion del fantasma rosa en y



            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            gametmr.Start();
        }

        private void gameOver(string message)
        {

        }
    }
}
