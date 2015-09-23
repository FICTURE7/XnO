using System;

namespace XnO.Model
{
    public class BitBoard
    {
        public const int Width = 3;
        public const int Height = 3;

        public BitBoard()
        {
            // Space
        }

        public BitBoard(ushort mark)
        {
            m_Markers = mark;
        }

        public bool this[int row, int column]
        {
            get { return IsMarked(row, column); }
            set { Mark(row, column, value); }
        }

        private ushort m_Markers = 0;

        private void Mark(int row, int column, bool set)
        {
            if (row > 2 || row < 0)
                throw new ArgumentException("row is not valid");
            if (column > 2 || column < 0)
                throw new ArgumentException("column is not valid");

            var val = (ushort)Math.Pow(2, (row * 4) + column);
            if (set)
                m_Markers |= val;
            else
                m_Markers &= (ushort)~val;
        }

        private bool IsMarked(int row, int column)
        {
            if (row > 2 || row < 0)
                throw new ArgumentException("row is not valid");
            if (column > 2 || column < 0)
                throw new ArgumentException("column is not valid");

            var val = (ushort)Math.Pow(2, (row * 4) + column);
            return (m_Markers & val) == val;
        }
    }
}
