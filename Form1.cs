using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Diagnostics;

namespace CPT___Space_Inavders
{
    public partial class Form1 : Form
    {
        //spaceship directions
        enum spaceshipFunctions
        {
            Left,
            Right,
            None
        }

        //spaceship laser directions
        enum spaceshipLaserFunctions
        {
            Up,
            None
        }
        //enemy direction
        enum EnemyFunctions
        {
            Left,
            Right,
            None
        }
        //enemy laser directions
        enum EnemyLaserFunctions
        {
            Down,
            None
        }

        //global variables
        spaceshipFunctions spaceship = spaceshipFunctions.None;
        spaceshipLaserFunctions Laser = spaceshipLaserFunctions.None;
        EnemyFunctions enemies = EnemyFunctions.None;
        EnemyLaserFunctions enemyLaser = EnemyLaserFunctions.None;
        int SpaceshipBulletSpeed; //speed of spaceship bullet
        int EnemySpeed;//speed of enemy movement
        int EnemyLaserSpeed;//speed of enemy lasers
        Vector LaserPosition, EnemyLaserPosition, LaserSpeed, Speed;
        int Score = 0; //keeping track of the score
        int Timer; //tracking time for when enemy laser shoots
        public Form1()
        {
            InitializeComponent();
        }

        private void picSpaceShip_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Return)
            {
                //if the player hits the enter key, the game will start up and enable the timer.
                tmrGame.Enabled = true;
               
                //making every label invisible to clear the screen
                lblTitle.Visible = false;
                lblIkenna.Visible = false;
                lblControls.Visible = false;
                lblControlA.Visible = false;
                lblControlD.Visible = false;
                lblControlW.Visible = false;
                lblControlEsc.Visible = false;
                lblControlBackspace.Visible = false;
                lblBegin.Visible = false;

                //hiding pause menu when player resumes
                lblPause.Visible = false;
                lblHowToResume.Visible = false;

                //making spaceship visible
                picSpaceShip.Visible = true;

                //making the score visible
                lblScore.Visible = true;
                lblScoreNumber.Visible = true;


                //making orange enemies visible
                picOrangeEnemy1.Visible = true;
                picOrangeEnemy2.Visible = true;
                picOrangeEnemy3.Visible = true;
                picOrangeEnemy4.Visible = true;
                picOrangeEnemy5.Visible = true;
                picOrangeEnemy6.Visible = true;
                picOrangeEnemy7.Visible = true;
                picOrangeEnemy8.Visible = true;

                //making purple enemies visible
                picPurpleEnemy1.Visible = true;
                picPurpleEnemy2.Visible = true;
                picPurpleEnemy3.Visible = true;
                picPurpleEnemy4.Visible = true;
                picPurpleEnemy5.Visible = true;
                picPurpleEnemy6.Visible = true;
                picPurpleEnemy7.Visible = true;
                picPurpleEnemy8.Visible = true;

                //making green enemies visible
                picGreenEnemy1.Visible = true;
                picGreenEnemy2.Visible = true;
                picGreenEnemy3.Visible = true;
                picGreenEnemy4.Visible = true;
                picGreenEnemy5.Visible = true;
                picGreenEnemy6.Visible = true;
                picGreenEnemy7.Visible = true;
                picGreenEnemy8.Visible = true;

                //hide congratualations menu
                lblYouWin.Visible = false;
                lblYay.Visible = false;
                lblGoBack.Visible = false;
                lblRestart.Visible = false;

                //resetting score
                Score = 0;
                lblScoreNumber.Text = Score.ToString();
            }
            //if the player hits the escape key, the game will pause up and disable the timer.
            else if (e.KeyCode == Keys.Escape)
            {
                tmrGame.Enabled = false;
                lblPause.Visible = true;
                lblHowToResume.Visible = true;
            }
               //Go back to the menu
            if (e.KeyCode == Keys.Back)
            {
                /*if the player hits the backspace key, the game will go back 
                to the menu and disable the timer.*/
                tmrGame.Enabled = false;

                //making every label appear on the screen
                lblTitle.Visible = true;
                lblIkenna.Visible = true;
                lblControls.Visible = true;
                lblControlA.Visible = true;
                lblControlD.Visible = true;
                lblControlW.Visible = true;
                lblControlEsc.Visible = true;
                lblControlBackspace.Visible = true;
                lblBegin.Visible = true;
                lblPause.Visible = false;
                lblHowToResume.Visible = false;
                lblScore.Visible = false;
                lblScoreNumber.Visible = false;

                //making spaceship and its laser invisible
                picSpaceShip.Visible = false;
                picLaser.Visible = false;

                //making orange enemies invisible
                picOrangeEnemy1.Visible = false;
                picOrangeEnemy2.Visible = false;
                picOrangeEnemy3.Visible = false;
                picOrangeEnemy4.Visible = false;
                picOrangeEnemy5.Visible = false;
                picOrangeEnemy6.Visible = false;
                picOrangeEnemy7.Visible = false;
                picOrangeEnemy8.Visible = false;

                //making purple enemies visible
                picPurpleEnemy1.Visible = false;
                picPurpleEnemy2.Visible = false;
                picPurpleEnemy3.Visible = false;
                picPurpleEnemy4.Visible = false;
                picPurpleEnemy5.Visible = false;
                picPurpleEnemy6.Visible = false;
                picPurpleEnemy7.Visible = false;
                picPurpleEnemy8.Visible = false;

                //making green enemies visible
                picGreenEnemy1.Visible = false;
                picGreenEnemy2.Visible = false;
                picGreenEnemy3.Visible = false;
                picGreenEnemy4.Visible = false;
                picGreenEnemy5.Visible = false;
                picGreenEnemy6.Visible = false;
                picGreenEnemy7.Visible = false;
                picGreenEnemy8.Visible = false;

                //hide congratualations menu
                lblYouWin.Visible = false;
                lblYay.Visible = false;
                lblGoBack.Visible = false;
                lblRestart.Visible = false;
            }
            /*when a player presses 'A' on their keyboard, the spaceship moves to the left
              by 10 pixels*/
            if (e.KeyCode == Keys.A)
            {
                spaceship = spaceshipFunctions.Left;
            }
            /*when a player presses 'D' on their keyboard the spaceship moves to the right
             by 10 pixels.*/
            else if (e.KeyCode == Keys.D)
            {
                spaceship = spaceshipFunctions.Right;
            }

            if (e.KeyCode == Keys.Return)
            {
                moveEnemies();

                //enable timer to move laser
                tmrGame.Enabled = true;

            }
            if (e.KeyCode == Keys.Space)
            {
                ResetLaser();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            /*when a player presses 'A' on their keyboard, the spaceship moves to the left
              by 10 pixels*/
            if (e.KeyCode == Keys.A)
            {
                spaceship = spaceshipFunctions.None;
            }
            /*when a player presses 'D' on their keyboard the spaceship moves to the right
             by 10 pixels.*/
            else if (e.KeyCode == Keys.D)
            {
                spaceship = spaceshipFunctions.None;
            }
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            //move the laser
            if (Laser == spaceshipLaserFunctions.Up)
            {
                picLaser.Top -= SpaceshipBulletSpeed;
                

                /*when the laser hits the top of the screen stop the laser in
                its tracks.*/

                Console.WriteLine("shooting" + picLaser.Top);
                picLaser.Left = picSpaceShip.Left + 10;
            }

            //code to move spaceship
            if (spaceship == spaceshipFunctions.Left)
            {
                picSpaceShip.Left -= 9;
            }

            else if (spaceship == spaceshipFunctions.Right)
            {
                picSpaceShip.Left += 5;
            }
            //code to move enemies
            if (enemies == EnemyFunctions.Left)
            {
                movingEnemiesRight();
                /*variables to use as conditions for moving the enemies to the left
                when they hit the right end of the window*/
                int maximumMovementToTheRight = ClientRectangle.Right;

                int LastOrangeEnemyOnTheRight = picOrangeEnemy8.Right;
                int LastPurpleEnemyOnTheRight = picPurpleEnemy8.Right;
                int LastGreenEnemyOnTheRight = picGreenEnemy8.Right;

                /*variables to use as conditions for moving the enemies to the left
                when they hit the left end of the window*/
                int maximumMovementToTheLeft = ClientRectangle.Left;
                
                int LastOrangeEnemyOnTheLeft = picOrangeEnemy1.Left;


                /*if the right edge of each of the pictures in the far right column 
                 * touch the right edge of the client, the enemies should head into 
                 * the opposite direction.*/
                if ((LastOrangeEnemyOnTheRight >= maximumMovementToTheRight && LastPurpleEnemyOnTheRight >= maximumMovementToTheRight && LastGreenEnemyOnTheRight >= maximumMovementToTheRight))
                {
                    /*making the currently positive Speed.X a negative by multiplying Speed.X 
                     * by negative 1 so I can inverse the direction 
                     * it was currently travelling in.*/
                    Speed.X = -1 * (int)Speed.X;

                }

                /*if the left edge of the first orange enemy hits the left edge of the 
                client, the already negative Speed.X will become positive, meaning that the
                enemies will move to the right again.*/
                if (LastOrangeEnemyOnTheLeft < maximumMovementToTheLeft)
                {
                    /* Since 'Speed' is a global variable, the defined Speed.X in the previous
                     * if statement made Speed.X remain negative. However, by multiplying the 
                     * current negative Speed.X by negative 1, Speed.X will become positive
                     * since a negative multiplied by a negative is positive. */
                    Speed.X = -1 * (int)Speed.X;
                }

                
               
                
                
                //the orange enemies:

                /*if a bullet hits the first orange enemy, make the enemy disappear
                 * and reward points */
                if (picOrangeEnemy1.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picOrangeEnemy1.Visible = false;
                    picOrangeEnemy1.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picOrangeEnemy1.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the second orange enemy, make the enemy disappear
                 * and reward points */
                if (picOrangeEnemy2.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picOrangeEnemy2.Visible = false;
                    picOrangeEnemy2.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picOrangeEnemy2.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the third orange enemy, make the enemy disappear
                 * and reward points */
                if (picOrangeEnemy3.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picOrangeEnemy3.Visible = false;
                    picOrangeEnemy3.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picOrangeEnemy3.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the fourth orange enemy, make the enemy disappear
                 * and reward points */
                if (picOrangeEnemy4.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picOrangeEnemy4.Visible = false;
                    picOrangeEnemy4.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picOrangeEnemy4.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the fifth orange enemy, make the enemy disappear
                 * and reward points */
                if (picOrangeEnemy5.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picOrangeEnemy5.Visible = false;
                    picOrangeEnemy5.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picOrangeEnemy5.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the sixth orange enemy, make the enemy disappear
                 * and reward points */
                if (picOrangeEnemy6.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picOrangeEnemy6.Visible = false;
                    picOrangeEnemy6.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picOrangeEnemy6.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the seventh orange enemy, make the enemy disappear
                 * and reward points */
                if (picOrangeEnemy7.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picOrangeEnemy7.Visible = false;
                    picOrangeEnemy7.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picOrangeEnemy7.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the eighth orange enemy, make the enemy disappear
                 * and reward points */
                if (picOrangeEnemy8.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picOrangeEnemy8.Visible = false;
                    picOrangeEnemy8.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picOrangeEnemy8.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                //the purple enemies

                /*if a bullet hits the first purple enemy, make the enemy disappear
                 * and reward points */
                if (picPurpleEnemy1.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picPurpleEnemy1.Visible = false;
                    picPurpleEnemy1.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picPurpleEnemy1.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the second purple enemy, make the enemy disappear
                 * and reward points */
                if (picPurpleEnemy2.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picPurpleEnemy2.Visible = false;
                    picPurpleEnemy2.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picPurpleEnemy2.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the third purple enemy, make the enemy disappear
                 * and reward points */
                if (picPurpleEnemy3.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picPurpleEnemy3.Visible = false;
                    picPurpleEnemy3.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picPurpleEnemy3.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the fourth purple enemy, make the enemy disappear
                 * and reward points */
                if (picPurpleEnemy4.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picPurpleEnemy4.Visible = false;
                    picPurpleEnemy4.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picPurpleEnemy4.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the fifth purple enemy, make the enemy disappear
                 * and reward points */
                if (picPurpleEnemy5.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picPurpleEnemy5.Visible = false;
                    picPurpleEnemy5.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picPurpleEnemy5.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the sixth purple enemy, make the enemy disappear
                 * and reward points */
                if (picPurpleEnemy6.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picPurpleEnemy6.Visible = false;
                    picPurpleEnemy6.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picPurpleEnemy6.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the seventh purple enemy, make the enemy disappear
                 * and reward points */
                if (picPurpleEnemy7.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picPurpleEnemy7.Visible = false;
                    picPurpleEnemy7.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picPurpleEnemy7.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the eighth purple enemy, make the enemy disappear
                 * and reward points */
                if (picPurpleEnemy8.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picPurpleEnemy8.Visible = false;
                    picPurpleEnemy8.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;

                    //give user 10 points
                    if (picPurpleEnemy8.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                //the green enemies

                /*if a bullet hits the first green enemy, make the enemy disappear
                * and reward points */
                if (picGreenEnemy1.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picGreenEnemy1.Visible = false;
                    picGreenEnemy1.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;
                    picLaser.Visible = false;

                    //give user 10 points
                    if (picGreenEnemy1.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the second green enemy, make the enemy disappear
                 * and reward points */
                if (picGreenEnemy2.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picGreenEnemy2.Visible = false;
                    picGreenEnemy2.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;
                    picLaser.Visible = false;

                    //give user 10 points
                    if (picGreenEnemy2.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the third green enemy, make the enemy disappear
                 * and reward points */
                if (picGreenEnemy3.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picGreenEnemy3.Visible = false;
                    picGreenEnemy3.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;
                    picLaser.Visible = false;

                    //give user 10 points
                    if (picGreenEnemy3.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the fourth green enemy, make the enemy disappear
                 * and reward points */
                if (picGreenEnemy4.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picGreenEnemy4.Visible = false;
                    picGreenEnemy4.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;
                    picLaser.Visible = false;

                    //give user 10 points
                    if (picGreenEnemy4.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the fifth green enemy, make the enemy disappear
                 * and reward points */
                if (picGreenEnemy5.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picGreenEnemy5.Visible = false;
                    picGreenEnemy5.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;
                    picLaser.Visible = false;

                    //give user 10 points
                    if (picGreenEnemy5.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the sixth green enemy, make the enemy disappear
                 * and reward points */
                if (picGreenEnemy6.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picGreenEnemy6.Visible = false;
                    picGreenEnemy6.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;
                    picLaser.Visible = false;

                    //give user 10 points
                    if (picGreenEnemy6.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                if (enemyLaser == EnemyLaserFunctions.Down)
                {
                    enemyAttacks();
                    picEnemyLaser1.Top += EnemyLaserSpeed;
                }

                /*if a bullet hits the seventh green enemy, make the enemy disappear
                 * and reward points */
                if (picGreenEnemy7.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picGreenEnemy7.Visible = false;
                    picGreenEnemy7.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;
                    picLaser.Visible = false;

                    //give user 10 points
                    if (picGreenEnemy7.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }

                /*if a bullet hits the second green enemy, make the enemy disappear
                 * and reward points */
                if (picGreenEnemy8.Bounds.IntersectsWith(picLaser.Bounds))
                {
                    //make picture disappear and disable
                    picGreenEnemy8.Visible = false;
                    picGreenEnemy8.Enabled = false;

                    //make laser disappear
                    picLaser.Enabled = false;
                    picLaser.Visible = false;

                    //give user 10 points
                    if (picGreenEnemy8.Visible == false)
                    {
                        Score += 10;
                        lblScoreNumber.Text = Score.ToString();
                    }
                }


                //if all the enemies are wiped out you win the game.
                if (picOrangeEnemy1.Visible == false && picOrangeEnemy2.Visible == false && picOrangeEnemy3.Visible == false && picOrangeEnemy4.Visible == false && picOrangeEnemy5.Visible == false && picOrangeEnemy6.Visible == false && picOrangeEnemy7.Visible == false && picOrangeEnemy8.Visible == false && picPurpleEnemy1.Visible == false && picPurpleEnemy2.Visible == false && picPurpleEnemy3.Visible == false && picPurpleEnemy4.Visible == false && picPurpleEnemy5.Visible == false && picPurpleEnemy6.Visible == false && picPurpleEnemy7.Visible == false && picPurpleEnemy8.Visible == false && picGreenEnemy1.Visible == false && picGreenEnemy2.Visible == false &&picGreenEnemy3.Visible == false && picGreenEnemy4.Visible == false && picGreenEnemy5.Visible == false && picGreenEnemy6.Visible == false && picGreenEnemy7.Visible == false && picGreenEnemy8.Visible == false)
                {
                    //show congratualations menu
                    lblYouWin.Visible = true;
                    lblYay.Visible = true;
                    lblGoBack.Visible = true;
                    lblRestart.Visible = true;

                    //disable timer
                    tmrGame.Enabled = false;
                }






            }
        }

        public void ResetLaser()
        {
            //initialize spaceship laser speed
            SpaceshipBulletSpeed = 9;
            
            //making laser visible
            picLaser.Visible = true;

            
            //initializing new relocation of the laser to the ship
            LaserPosition = new Vector(picSpaceShip.Top / 2, 500);

            
                //relocate laser
                picLaser.Left = (int)LaserPosition.X;
                picLaser.Top = (int)LaserPosition.Y;
                Laser = spaceshipLaserFunctions.Up;
            
           
        }

        public void moveEnemies()
        {
            //initialize speed for enemies
            EnemySpeed = 2;

            Speed = new Vector(EnemySpeed, EnemySpeed);

            enemies = EnemyFunctions.Left;
        }

        public void movingEnemiesRight()
        {
            //making orange enemies move right
            picOrangeEnemy1.Left += (int)Speed.X;
            picOrangeEnemy2.Left += (int)Speed.X;
            picOrangeEnemy3.Left += (int)Speed.X;
            picOrangeEnemy4.Left += (int)Speed.X;
            picOrangeEnemy5.Left += (int)Speed.X;
            picOrangeEnemy6.Left += (int)Speed.X;
            picOrangeEnemy7.Left += (int)Speed.X;
            picOrangeEnemy8.Left += (int)Speed.X;

            //making purple enemies move right
            picPurpleEnemy1.Left += (int)Speed.X;
            picPurpleEnemy2.Left += (int)Speed.X;
            picPurpleEnemy3.Left += (int)Speed.X;
            picPurpleEnemy4.Left += (int)Speed.X;
            picPurpleEnemy5.Left += (int)Speed.X;
            picPurpleEnemy6.Left += (int)Speed.X;
            picPurpleEnemy7.Left += (int)Speed.X;
            picPurpleEnemy8.Left += (int)Speed.X;

            //making green enemies move right
            picGreenEnemy1.Left += (int)Speed.X;
            picGreenEnemy2.Left += (int)Speed.X;
            picGreenEnemy3.Left += (int)Speed.X;
            picGreenEnemy4.Left += (int)Speed.X;
            picGreenEnemy5.Left += (int)Speed.X;
            picGreenEnemy6.Left += (int)Speed.X;
            picGreenEnemy7.Left += (int)Speed.X;
            picGreenEnemy8.Left += (int)Speed.X;
        }

        public void movingEnemiesLeft()
        {
            //making orange enemies move right
            picOrangeEnemy1.Left -= (int)Speed.X;
            picOrangeEnemy2.Left -= (int)Speed.X;
            picOrangeEnemy3.Left -= (int)Speed.X;
            picOrangeEnemy4.Left -= (int)Speed.X;
            picOrangeEnemy5.Left -= (int)Speed.X;
            picOrangeEnemy6.Left -= (int)Speed.X;
            picOrangeEnemy7.Left -= (int)Speed.X;
            picOrangeEnemy8.Left -= (int)Speed.X;

            //making purple enemies move right
            picPurpleEnemy1.Left -= (int)Speed.X;
            picPurpleEnemy2.Left -= (int)Speed.X;
            picPurpleEnemy3.Left -= (int)Speed.X;
            picPurpleEnemy4.Left -= (int)Speed.X;
            picPurpleEnemy5.Left -= (int)Speed.X;
            picPurpleEnemy6.Left -= (int)Speed.X;
            picPurpleEnemy7.Left -= (int)Speed.X;
            picPurpleEnemy8.Left -= (int)Speed.X;

            //making green enemies move right
            picGreenEnemy1.Left -= (int)Speed.X;
            picGreenEnemy2.Left -= (int)Speed.X;
            picGreenEnemy3.Left -= (int)Speed.X;
            picGreenEnemy4.Left -= (int)Speed.X;
            picGreenEnemy5.Left -= (int)Speed.X;
            picGreenEnemy6.Left -= (int)Speed.X;
            picGreenEnemy7.Left -= (int)Speed.X;
            picGreenEnemy8.Left -= (int)Speed.X;
        }

        //method to choose random enemy to attack
        public void enemyAttacks()
        {
            //initializing timer to set a specific amount of time
            int Timer = 0;
            //looping through the number of ticks
            while (tmrGame.Enabled == true)
            {
                //keep track of time and increment by 1
                Timer++;

                int EnemyRole = 0;

                //if the Timer reaches 15  choose a random enemy to shoot laser
                if (Timer == 2000) 
                {
                    //random number generator
                    Random randomEnemy = new Random();

                    //storing random number generator method into an integer
                    //the numbers are 1 to 24 because that is how many enemies there are
                    EnemyRole = randomEnemy.Next(1, 24);

                    /*the next section is if statements to make the laser shoot from
                    the enemy if their random number was selected.*/

                    //the first orange Enemy is represented as number 1
                    if (EnemyRole == 1)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the first orange enemy
                        EnemyLaserPosition = new Vector(picOrangeEnemy1.Top/2, 150);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }


                    //the second orange Enemy is represented as number 2
                    if (EnemyRole == 2)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the second orange enemy
                        EnemyLaserPosition = new Vector(picOrangeEnemy2.Top / 2, 150);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;


                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }


                    //the third orange Enemy is represented as number 3
                    if (EnemyRole == 3)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the third orange enemy
                        EnemyLaserPosition = new Vector(picOrangeEnemy3.Top / 2, 150);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }


                    //the fourth orange Enemy is represented as number 4
                    if (EnemyRole == 4)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the fourth orange enemy
                        EnemyLaserPosition = new Vector(picOrangeEnemy4.Top / 2, 150);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }


                    //the fifth orange Enemy is represented as number 5
                    if (EnemyRole == 5)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the fifth orange enemy
                        EnemyLaserPosition = new Vector(picOrangeEnemy5.Top / 2, 150);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the sixth orange Enemy is represented as number 6
                    if (EnemyRole == 6)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the sixth orange enemy
                        EnemyLaserPosition = new Vector(picOrangeEnemy6.Top / 2, 150);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the seventh orange Enemy is represented as number 7
                    if (EnemyRole == 7)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the seventh orange enemy
                        EnemyLaserPosition = new Vector(picOrangeEnemy7.Top / 2, 150);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the eighth orange Enemy is represented as number 8
                    if (EnemyRole == 8)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the eighth orange enemy
                        EnemyLaserPosition = new Vector(picOrangeEnemy8.Top / 2, 150);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the first purple Enemy is represented as number 9
                    if (EnemyRole == 9)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the first purple enemy
                        EnemyLaserPosition = new Vector(picPurpleEnemy1.Top / 2, 225);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the second purple Enemy is represented as number 10
                    if (EnemyRole == 10)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the second purple enemy
                        EnemyLaserPosition = new Vector(picPurpleEnemy2.Top / 2, 225);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the third purple Enemy is represented as number 11
                    if (EnemyRole == 11)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the third purple enemy
                        EnemyLaserPosition = new Vector(picPurpleEnemy3.Top / 2, 225);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the fourth purple Enemy is represented as number 12
                    if (EnemyRole == 12)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the fourth purple enemy
                        EnemyLaserPosition = new Vector(picPurpleEnemy4.Top / 2, 225);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the fifth purple Enemy is represented as number 13
                    if (EnemyRole == 13)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the fifth purple enemy
                        EnemyLaserPosition = new Vector(picPurpleEnemy5.Top / 2, 225);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the sixth purple Enemy is represented as number 14
                    if (EnemyRole == 14)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the fourth purple enemy
                        EnemyLaserPosition = new Vector(picPurpleEnemy6.Top / 2, 225);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the seventh purple Enemy is represented as number 15
                    if (EnemyRole == 15)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the seventh purple enemy
                        EnemyLaserPosition = new Vector(picPurpleEnemy7.Top / 2, 225);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }
                    //the eighth purple Enemy is represented as number 16
                    if (EnemyRole == 16)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the eighth purple enemy
                        EnemyLaserPosition = new Vector(picPurpleEnemy8.Top / 2, 225);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the first green Enemy is represented as number 17
                    if (EnemyRole == 17)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the first green enemy
                        EnemyLaserPosition = new Vector(picGreenEnemy1.Top / 2, 300);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the second green Enemy is represented as number 18
                    if (EnemyRole == 18)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the second green enemy
                        EnemyLaserPosition = new Vector(picGreenEnemy2.Top / 2, 300);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the third green Enemy is represented as number 19
                    if (EnemyRole == 19)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the third green enemy
                        EnemyLaserPosition = new Vector(picGreenEnemy3.Top / 2, 300);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the fourth green Enemy is represented as number 20
                    if (EnemyRole == 20)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the fourth green enemy
                        EnemyLaserPosition = new Vector(picGreenEnemy4.Top / 2, 300);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the fifth green Enemy is represented as number 21
                    if (EnemyRole == 21)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the fifth green enemy
                        EnemyLaserPosition = new Vector(picGreenEnemy5.Top / 2, 300);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the sixth green Enemy is represented as number 22
                    if (EnemyRole == 22)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the sixth green enemy
                        EnemyLaserPosition = new Vector(picGreenEnemy6.Top / 2, 300);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                    //the seventh green Enemy is represented as number 23
                    if (EnemyRole == 23)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the seventh green enemy
                        EnemyLaserPosition = new Vector(picGreenEnemy7.Top / 2, 300);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;

                    }

                    //the eighth green Enemy is represented as number 24
                    if (EnemyRole == 24)
                    {
                        //the speed of the laser
                        EnemyLaserSpeed = 4;

                        //positioning the laser to shoot from the eighth green enemy
                        EnemyLaserPosition = new Vector(picGreenEnemy8.Top / 2, 300);

                        //where laser shoots from
                        picEnemyLaser1.Left = (int)EnemyLaserPosition.X;
                        picEnemyLaser1.Top = (int)EnemyLaserPosition.Y;

                        //making laser visible
                        picEnemyLaser1.Visible = true;

                        //enabling the timer so the laser can move
                        tmrGame.Enabled = true;

                        enemyLaser = EnemyLaserFunctions.Down;
                    }

                   
                }
            }

            
         }

        private void lblYouWIn_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar ==' ') {
              
                    ResetLaser();
                //enable timer to move laser
                tmrGame.Enabled = true;


            }
            //MessageBox.Show("Key '" +
            //e.KeyChar.ToString() + "' pressed.");*/
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
