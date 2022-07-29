using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardEntities
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece()
        {
        }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumMovements = 0;
        }

        public void IncreaseNumMovements()
        {
            NumMovements++;
        }
    }
}
