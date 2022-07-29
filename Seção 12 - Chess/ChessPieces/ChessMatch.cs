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

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            pieces = new HashSet<Piece>();
            catched = new HashSet<Piece>();
            PutPieces();
        }

        public void PieceMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncreaseNumMovements();
            Piece catchedPiece = board.RemovePiece(destination);
            board.PutPiece(p, destination);
            catched.Add(catchedPiece);
        }

        public void MakeMove(Position origin, Position destination)
        {
            PieceMovement(origin, destination);
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
