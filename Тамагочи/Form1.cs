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
        }
        private void init_scale(Label lbl_cur, Label lbl_max, Scale scale)
        {
            lbl_cur.Text = scale.current_value.ToString();
            lbl_max.Text = scale.max_value.ToString();
        }
        private void init_game()
        {
            new Settings();
            init_scale(lblEatCur,   lblEatMax,   Settings.eat);
            init_scale(lblSleepCur, lblSleepMax, Settings.sleep);
            init_scale(lblClearCur, lblClearMax, Settings.clear);
            init_scale(lblHPCur,    lblHPMax,    Settings.HP);
            init_scale(lblHappyCur, lblHappyMax, Settings.happy);

            lblGameOver.Visible = false;
        }
        private Scale add_value(int add_value, Scale cur_scale)
        {
            cur_scale.current_value += add_value;
            if(cur_scale.current_value > cur_scale.max_value)
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
                
            if(Settings.HP.current_value == 0
            || Settings.eat.current_value == 0
            || Settings.sleep.current_value == 0
            || Settings.happy.current_value == 0
            || Settings.clear.current_value == 0)
            {
                return true;
            }
            return false;
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

        }
    }
}
