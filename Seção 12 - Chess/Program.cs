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
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPosition().toPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possibleMoves = match.board.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.ShowBoard(match.board, possibleMoves);


                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadPosition().toPosition();
                        match.ValidateDestinationPosition(origin, destination);

                        match.MakeMove(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.Write(e.Message);
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.Write("Error");
                    }

                }
                Console.Clear();
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