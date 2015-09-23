using System;
using System.Text;

namespace XnO.Model
{
    public class XnOGame
    {
        public XnOGame()
        {
            OPlayer = new OPlayer();
            XPlayer = new XPlayer();
        }

        public OPlayer OPlayer { get; set; }
        public XPlayer XPlayer { get; set; }
        public Player Winner
        {
            get
            {
                var xPlayerMarks = XPlayer.Board;
                var oPlayerMarks = OPlayer.Board;

                // check rows
                for (int row = 0; row < BitBoard.Height; row++)
                {
                    if ((xPlayerMarks[row, 0] & xPlayerMarks[row, 1] & xPlayerMarks[row, 2]))
                        return XPlayer;
                    if ((oPlayerMarks[row, 0] & oPlayerMarks[row, 1] & oPlayerMarks[row, 2]))
                        return OPlayer;
                }

                // check columns
                for (int column = 0; column < BitBoard.Width; column++)
                {
                    if ((xPlayerMarks[0, column] & xPlayerMarks[1, column] & xPlayerMarks[2, column]))
                        return XPlayer;
                    if ((oPlayerMarks[0, column] & oPlayerMarks[1, column] & oPlayerMarks[2, column]))
                        return OPlayer;
                }

                // check diagonal
                if ((xPlayerMarks[0, 0] & xPlayerMarks[1, 1] & xPlayerMarks[2, 2]))
                    return XPlayer;
                if ((oPlayerMarks[0, 0] & oPlayerMarks[1, 1] & oPlayerMarks[2, 2]))
                    return OPlayer;

                // check diagonal alternate
                if ((xPlayerMarks[0, 2] & xPlayerMarks[1, 1] & xPlayerMarks[2, 0]))
                    return XPlayer;
                if ((oPlayerMarks[0, 2] & oPlayerMarks[1, 1] & oPlayerMarks[2, 0]))
                    return OPlayer;

                return null;
            }
        }

        public void PrintBoard()
        {
            var xPlayerMarks = XPlayer.Board;
            var oPlayerMarks = OPlayer.Board;
            var sb = new StringBuilder();
            for (int row = 0; row < BitBoard.Height; row++)
            {
                sb.Append(" ");
                for (int column = 0; column < BitBoard.Width; column++)
                {
                    var mark = " ";
                    if (xPlayerMarks[row, column])
                        mark = "X";
                    if (oPlayerMarks[row, column])
                        mark = "O";

                    sb.Append(" " + mark + " ");
                    if (column != BitBoard.Width - 1)
                        sb.Append("|");
                }
                if (row != BitBoard.Height - 1)
                    sb.AppendLine("\r\n ---+---+---");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
