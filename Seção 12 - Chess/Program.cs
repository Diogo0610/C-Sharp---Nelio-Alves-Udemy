using BoardEntities;
using ChessPieces;
using BoardExceptions;

namespace Chess
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.ShowBoard(match.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPosition().toPosition();

                    bool[,] possibleMoves = match.board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.ShowBoard(match.board, possibleMoves);


                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadPosition().toPosition();

                    match.PieceMovement(origin, destination);
                }

                Screen.ShowBoard(match.board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();
        }
    }
}