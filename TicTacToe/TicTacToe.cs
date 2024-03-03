using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class TicTacToe
    {
        string player1;
        string player2;

        string[] gameBoard;

        public TicTacToe(string player1, string player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.gameBoard = new string[9] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        }


        /// <summary>
        /// Tic Tac Toe Game Board
        /// </summary>
        void DrawBoard()
        {
            Console.WriteLine();
            Console.WriteLine($"{gameBoard[0]}  |  {gameBoard[1]}  | {gameBoard[2]} ");
            Console.WriteLine("_____________");
            Console.WriteLine($"{gameBoard[3]}  |  {gameBoard[4]}  | {gameBoard[5]} ");
            Console.WriteLine("_____________");
            Console.WriteLine($"{gameBoard[6]}  |  {gameBoard[7]}  | {gameBoard[8]} ");
            Console.WriteLine();
        }

        bool CheckWin()
        {

            if (this.gameBoard[0] == this.gameBoard[1] && this.gameBoard[1] == this.gameBoard[2])
            {
                return true;
            }
            else if (this.gameBoard[3] == this.gameBoard[4] && this.gameBoard[4] == this.gameBoard[5])
            {
                return true;
            }
            else if (this.gameBoard[6] == this.gameBoard[7] && this.gameBoard[7] == this.gameBoard[8])
            {
                return true;
            }

            else if (this.gameBoard[0] == this.gameBoard[3] && this.gameBoard[3] == this.gameBoard[6])
            {
                return true;
            }
            else if (this.gameBoard[1] == this.gameBoard[4] && this.gameBoard[4] == this.gameBoard[7])
            {
                return true;
            }
            else if (this.gameBoard[2] == this.gameBoard[5] && this.gameBoard[5] == this.gameBoard[8])
            {
                return true;
            }
            else if (this.gameBoard[0] == this.gameBoard[4] && this.gameBoard[4] == this.gameBoard[8])
            {
                return true;
            }
            else if (this.gameBoard[2] == this.gameBoard[4] && this.gameBoard[4] == this.gameBoard[6])
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        bool CheckDraw()
        {
            foreach (var val in this.gameBoard)
            {
                if (int.TryParse(val, out int x))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Starting the game
        /// </summary>
        public void StartGame()
        {
            bool isPlayer1Turn = true;

            while (true)
            {
                this.DrawBoard();
                if (isPlayer1Turn)
                {
                    Console.WriteLine($"{this.player1}, your turn. your symbol is ('X'), Enter a valid position: ");
                }
                else
                {
                    Console.WriteLine($"{this.player2}, your turn. your symbol is ('O'), Enter a valid postion: ");
                }

                int choice = int.Parse(Console.ReadLine());

                // Check valid postion or not
                if (choice < 0 || choice > 8)
                {
                    Console.WriteLine("Not a valid positioin. Try Again!");
                    continue;
                }

                // Check that positon is already filled or not
                if (this.gameBoard[choice] == "X" || this.gameBoard[choice] == "O")
                {
                    Console.WriteLine("Already filled, Try Again!");
                    continue;
                }


                // Entered position is valid, now assigned the symbol
                this.gameBoard[choice] = isPlayer1Turn ? "X" : "O";


                // Now Check if win
                if (CheckWin())
                {
                    string playerName = isPlayer1Turn ? this.player1 : this.player2;
                    Console.WriteLine($"{playerName} win the game.");
                    Environment.Exit(0);
                }


                // Check the Draw
                if(CheckDraw())
                {
                    Console.WriteLine("Game is draw.");
                    Environment.Exit(0);
                }


                // Change the turning
                isPlayer1Turn = !isPlayer1Turn;
            }
        }


    }
}
