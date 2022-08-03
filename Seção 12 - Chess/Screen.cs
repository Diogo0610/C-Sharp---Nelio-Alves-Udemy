using System;
using System.Collections.Generic;
using BoardEntities;
using ChessPieces;

namespace Chess
{
    internal class Screen
    {

        public static void PrintBoard(ChessMatch match)
        {
            CreateBoard(match.board);
            Console.WriteLine();
            PrintCatchedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);

            if (!match.Finished)
            {
                Console.WriteLine("Waiting for play: " + match.currentPlayer);
                if (match.check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + match.currentPlayer);
            }
        }

        public static void PrintCatchedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            PrintGroup(match.CatchedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintGroup(match.CatchedPieces(Color.Black));
            Console.ForegroundColor = temp;
            Console.WriteLine();
        }

        public static void PrintGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach (Piece x in group)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void CreateBoard(Board board)
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

        public static void CreateBoard(Board board, bool[,] possibleMoves)
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
                        Console.ForegroundColor = ConsoleColor.Yellow;
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
