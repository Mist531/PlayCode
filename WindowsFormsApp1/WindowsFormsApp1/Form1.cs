using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        GameLogic game;
        int hodi = 0;
        public Form1()
        {
            InitializeComponent();
            game = new GameLogic(4);
        }
        private void button10_Click(object sender, EventArgs e)
        {
           int position = Convert.ToInt16(((Button)sender).TabIndex);
           game.smena(position);
           fresh();
            hodi++;
            if (game.Proverka())
            {
                MessageBox.Show("Победа! Количество ходов = "+hodi,"Итог");
                game.start();
                hodi = 0;
            }

        }
        private Button button(int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hodi = 0;
            game.start();
            for(int i = 0; i < 400; i++)
            {
                game.random();
            }
            fresh();
        }
        private void fresh()
        {
            for(int position = 0; position<16; position++)
            {
                button(position).Text = game.get(position).ToString();
                button(position).Visible = (game.get(position) > 0);
            }
        }

        private void menu_sozdat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создатель: Лукин Никита Алексеевич 1095гр", "Создатель");
        }

        private void menu_kontakt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://vk.com/mrrobote", "Ссылка");
        }
    }
}
