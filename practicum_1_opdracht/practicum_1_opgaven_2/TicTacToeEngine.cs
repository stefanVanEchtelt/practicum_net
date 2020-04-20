using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicum_1_opdracht_2
{
    public enum GameStatus { PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins }

    public class TicTacToeEngine
    {
        private string[] values = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public GameStatus Status { get; private set; }

        public TicTacToeEngine()
        {
            this.Status = GameStatus.PlayerOPlays;
        }

        public string Board()
        {
            return  "------------- \n" +
                    "| " + this.values[0] + " | " + this.values[1] + " | " + this.values[2] + " | \n" +
                    "------------- \n" +
                    "| " + this.values[3] + " | " + this.values[4] + " | " + this.values[5] + " | \n" +
                    "------------- \n" +
                    "| " + this.values[6] + " | " + this.values[7] + " | " + this.values[8] + " | \n" +
                    "-------------";
        }

        private Boolean checkIfSame(int v1, int v2, int v3)
        {
            if ((
                    this.values[v1 - 1].Equals("X") ||
                    this.values[v1 - 1].Equals("O")
                ) &&
                this.values[v1 - 1].Equals(this.values[v2 - 1]) && 
                this.values[v2 - 1].Equals(this.values[v3 - 1]))
                return true;

            return false;
        }

        private Boolean checkIfWon()
        {
            if (checkIfSame(1, 2, 3) ||
                checkIfSame(4, 5, 6) ||
                checkIfSame(7, 8, 9) ||
                checkIfSame(1, 5, 9) ||
                checkIfSame(3, 5, 7) ||
                checkIfSame(1, 4, 7) ||
                checkIfSame(2, 5, 8) ||
                checkIfSame(3, 6, 9))
                return true;

            return false;
        }

        public Boolean ChooseCell(int cellNumber)
        {
            if (
                cellNumber > 0 && cellNumber <= 9 && 
                this.values[cellNumber - 1] != "X" && this.values[cellNumber - 1] != "O" &&
                (this.Status == GameStatus.PlayerOPlays || this.Status == GameStatus.PlayerXPlays)
            )
            {
                if (this.Status == GameStatus.PlayerOPlays)
                {
                    this.values[cellNumber - 1] = "O";
                    
                    if (this.checkIfWon())
                        this.Status = GameStatus.PlayerOWins;
                    else
                        this.Status = GameStatus.PlayerXPlays;
                } else
                {
                    this.values[cellNumber - 1] = "X";

                    if (this.checkIfWon())
                        this.Status = GameStatus.PlayerXWins;
                    else
                        this.Status = GameStatus.PlayerOPlays;
                }

                if (this.values.GroupBy(value => value).Count() == 2)
                    this.Status = GameStatus.Equal;

                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.values = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            this.Status = GameStatus.PlayerOPlays;
        }
    }
}
