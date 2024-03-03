namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Player1 and Player 2 name: ");
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine();
            TicTacToe ticTacToe = new(player1, player2);
            ticTacToe.StartGame();
        }
    }
}
