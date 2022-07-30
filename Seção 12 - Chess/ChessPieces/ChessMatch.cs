using BoardEntities;
using BoardExceptions;

namespace ChessPieces
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> catched;
        public bool check { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            pieces = new HashSet<Piece>();
            catched = new HashSet<Piece>();
            check = false;
            PutPieces();
        }

        public Piece PieceMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncreaseNumMovements();
            Piece catchedPiece = board.RemovePiece(destination);
            board.PutPiece(p, destination);
            
            if(catchedPiece != null)
            {
                catched.Add(catchedPiece);
            }

            return catchedPiece;
        }

        public void ReturnMove(Position oringin, Position destination, Piece catchedPiece)
        {
            Piece p = board.RemovePiece(destination);
            p.DecreaseNumMovements();
            if(catchedPiece != null)
            {
                board.PutPiece(catchedPiece, destination);
                catched.Remove(catchedPiece);
            }
            board.PutPiece(p, oringin);
        }

        public void MakeMove(Position origin, Position destination)
        {
            Piece catchedPiece = PieceMovement(origin, destination);

            if (Check(currentPlayer))
            {
                ReturnMove(origin, destination, catchedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (Check(Enemy(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            turn++;
            ChangePlayer();
        }
        
        public void ValidateOriginPosition(Position pos)
        {
            if(board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece in this position!");
            }
            if (currentPlayer != board.Piece(pos).Color)
            {
                throw new BoardException("This is not your piece!");
            }
            if (!board.Piece(pos).HasPossibleMoves())
            {
                throw new BoardException("There is no possible move for this piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!board.Piece(origin).CanMoveFor(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        private void ChangePlayer()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> CatchedPieces(Color color)
        {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach(Piece x in catched)
            {
                if(x.Color == color)
                {
                    temp.Add(x);
                }
            }
            return temp;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    temp.Add(x);
                }
            }
            temp.ExceptWith(CatchedPieces(color));
            return temp;
        }

        private Color Enemy(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach(Piece x in PiecesInGame(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool Check(Color color)
        {
            Piece king = King(color);

            foreach (Piece x in PiecesInGame(Enemy(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(board, Color.White));
            PutNewPiece('c', 2, new Tower(board, Color.White));
            PutNewPiece('d', 2, new Tower(board, Color.White));
            PutNewPiece('e', 2, new Tower(board, Color.White));
            PutNewPiece('e', 1, new Tower(board, Color.White));
            PutNewPiece('d', 1, new King(board, Color.White));

            PutNewPiece('c', 7, new Tower(board, Color.Black));
            PutNewPiece('c', 8, new Tower(board, Color.Black));
            PutNewPiece('d', 7, new Tower(board, Color.Black));
            PutNewPiece('e', 7, new Tower(board, Color.Black));
            PutNewPiece('e', 8, new Tower(board, Color.Black));
            PutNewPiece('d', 8, new King(board, Color.Black));

        }
    }
}
