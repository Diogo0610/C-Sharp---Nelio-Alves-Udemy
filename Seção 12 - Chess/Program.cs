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
                Board board = new Board(8, 8);

                board.PutPiece(new Tower(board, Color.Red), new Position(1, 4));
                board.PutPiece(new Tower(board, Color.Red), new Position(0, 7));
                board.PutPiece(new King(board, Color.Red), new Position(0, 0));
                board.PutPiece(new Tower(board, Color.Blue), new Position(7, 2));
                board.PutPiece(new King(board, Color.Blue), new Position(6, 0));

                Screen.ShowBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();
        }
    }
}