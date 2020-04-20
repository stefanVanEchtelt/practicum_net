using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using practicum_1_opdracht_2;

namespace practicum_1_opdracht_1
{
    public partial class Form1 : Form
    {
        private TicTacToeEngine ticTacToeEngine = new TicTacToeEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setStatus();
        }

        private void setBoard()
        {
            int index = 1;
            foreach (String value in ticTacToeEngine.Board().Replace("-", "").Replace(" ", "").Replace("\n", "").Replace("||", "|").Trim('|').Split('|'))
            {
                var control = Controls.Find("button" + index, true);
                if (control != null)
                {
                    Button button = control.First() as Button;
                    button.Text = value;
                }

                index++;
            }
            setStatus();
        }

        private void setStatus()
        {
            if (ticTacToeEngine.Status == GameStatus.PlayerOWins || ticTacToeEngine.Status == GameStatus.PlayerXWins)
            {
                System.Windows.Forms.MessageBox.Show("Gefeliciteerd! Speler " + (ticTacToeEngine.Status == GameStatus.PlayerXWins ? "X" : "O") + " wint.");
            } else if (ticTacToeEngine.Status == GameStatus.Equal)
            {
                System.Windows.Forms.MessageBox.Show("Het is gelijkspel");
            }

            this.label1.Text = "Status: " + ticTacToeEngine.Status.ToString();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                bool correctChoice = ticTacToeEngine.ChooseCell(button.TabIndex + 1);

                if (correctChoice)
                {
                    setBoard();
                    return;
                }
            }

            System.Windows.Forms.MessageBox.Show("Invalid choice");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ticTacToeEngine.Reset();
            setBoard();
        }
    }
}
