using System;
using BoardEntities;
using ChessPieces;

namespace Chess
{
    internal class Screen
    {
        public static void ShowBoard(Board board)
        {
            for(int i = 0; i < board.Lines; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ShowBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if(possibleMoves[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }

                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else 
            { 
                ConsoleColor aux = Console.ForegroundColor;
                switch (piece.Color)
                {
                    case Color.White:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(piece);
                        Console.ForegroundColor = aux;
                        break;
                    case Color.Black:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(piece);
                        Console.ForegroundColor = aux;
                        break;
                    case Color.Yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(piece);
                        Console.ForegroundColor = aux;
                        break;
                    case Color.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(piece);
                        Console.ForegroundColor = aux;
                        break;
                    case Color.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(piece);
                        Console.ForegroundColor = aux;
                        break;
                    case Color.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(piece);
                        Console.ForegroundColor = aux;
                        break;
                }
                Console.Write(" ");
            }
        }
    }
}
