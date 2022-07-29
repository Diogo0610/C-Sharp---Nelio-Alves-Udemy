using BoardEntities;

namespace ChessPieces
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void PieceMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncreaseNumMovements();
            Piece catchedPiece = board.RemovePiece(destination);
            board.PutPiece(p, destination);
        }

        private void PutPieces()
        {
            board.PutPiece(new King(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('d', 3).toPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('h', 7).toPosition());
            board.PutPiece(new King(board, Color.Red), new ChessPosition('a', 8).toPosition());
            board.PutPiece(new Tower(board, Color.Red), new ChessPosition('f', 4).toPosition());
            board.PutPiece(new Tower(board, Color.Red), new ChessPosition('b', 5).toPosition());
        }
    }
}
