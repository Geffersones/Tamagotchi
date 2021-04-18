using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тамагочи
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            init_game();

            gameTimer.Interval = 1000 / Settings.speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            
        }
        private void init_scale(Label lbl_cur, Label lbl_max, Scale scale)
        {
            lbl_cur.Text = scale.current_value.ToString();
            lbl_max.Text = scale.max_value.ToString();
        }
        private void init_game()
        {
            new Settings();
            init_scale(lblEatCur, lblEatMax, Settings.eat);
            init_scale(lblSleepCur, lblSleepMax, Settings.sleep);
            init_scale(lblClearCur, lblClearMax, Settings.clear);
            init_scale(lblHPCur, lblHPMax, Settings.HP);
            init_scale(lblHappyCur, lblHappyMax, Settings.happy);

            lblGameOver.Visible = false;
        }
        private Scale add_value(int add_value, Scale cur_scale)
        {
            cur_scale.current_value += add_value;
            if (cur_scale.current_value > cur_scale.max_value)
            {
                cur_scale.current_value = cur_scale.max_value;
            }
            return cur_scale;
        }
        private Scale dif_value(int dif_value, Scale cur_scale)
        {
            cur_scale.current_value -= dif_value;
            if (cur_scale.current_value < 0)
            {
                cur_scale.current_value = 0;
            }
            return cur_scale;
        }
        private bool is_die()
        {
            int cur_life = (Settings.eat.current_value +
                Settings.sleep.current_value +
                Settings.happy.current_value +
                Settings.clear.current_value) / 4;

            Settings.HP.current_value = cur_life;

            if (Settings.HP.current_value == 0
            || Settings.eat.current_value == 0
            || Settings.sleep.current_value == 0
            || Settings.happy.current_value == 0
            || Settings.clear.current_value == 0)
            {
                return true;
            }
            return false;
        }
        private void set_scales()
        {
            lblEatCur.Text = Settings.eat.current_value.ToString();
            lblSleepCur.Text = Settings.sleep.current_value.ToString();
            lblHappyCur.Text = Settings.happy.current_value.ToString();
            lblClearCur.Text = Settings.clear.current_value.ToString();
            lblHPCur.Text = Settings.HP.current_value.ToString();
        }
        private void eating()
        {
            add_value(Settings.add, Settings.eat);
            dif_value(Settings.dif, Settings.clear);
        }
        private void clearing()
        {
            add_value(Settings.add, Settings.clear);
            dif_value(Settings.dif, Settings.happy);
        }
        private void sleeping()
        {
            add_value(Settings.add, Settings.sleep);
            dif_value(Settings.dif, Settings.eat);
        }
        private void happy()
        {
            add_value(Settings.add, Settings.happy);
            dif_value(Settings.dif, Settings.sleep);
            dif_value(Settings.dif, Settings.eat);
        }
        private void game_over_actions()
        {
            lblGameOver.Visible = true;
            pbImage.Image = Properties.Resources.Смерть;
            btnClean.Enabled = false;
            btnEat.Enabled = false;
            btnSleep.Enabled = false;
            btnHappy.Enabled = false;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            eating();
            set_scales();
            Settings.is_gameover = is_die();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            sleeping();
            set_scales();
            Settings.is_gameover = is_die();
        }

        private void btnHappy_Click(object sender, EventArgs e)
        {
            happy();
            set_scales();
            Settings.is_gameover = is_die();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            clearing();
            set_scales();
            Settings.is_gameover = is_die();
        }
        public void dec_eat()
        {
            Settings.eat = dif_value(Settings.default_dif, Settings.eat);
             set_scales();
            Settings.is_gameover = is_die();    
        }
        public void dec_happy()
        {
            Settings.happy = dif_value(Settings.default_dif, Settings.happy);
            set_scales();
            Settings.is_gameover = is_die();
        }
        public void dec_sleep()
        {
            Settings.sleep = dif_value(Settings.default_dif, Settings.sleep);
            set_scales();
            Settings.is_gameover = is_die();
        }
        public void dec_clear()
        {
            Settings.clear = dif_value(Settings.default_dif, Settings.clear);
            set_scales();
            Settings.is_gameover = is_die();
        }
        public void UpdateScreen(object sender, EventArgs E)
        {
            if(Settings.is_gameover)
            {
                game_over_actions();
            }
            else
            {
                Random random = new Random();
                int is_action = random.Next(0, 2);
                if(is_action == 1)
                {
                    generate_action(random);
                }
            }
        }
        private void generate_action(Random random)
        {
            List<Action> action = new List<Action> { dec_clear,dec_eat,dec_happy,dec_sleep};
            int index = random.Next(0, action.Count);
            action[index]();
            int[] arr = new int[10];
        }

    }
}