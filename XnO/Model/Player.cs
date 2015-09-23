namespace XnO.Model
{
    public abstract class Player
    {
        public Player()
        {
            Board = new BitBoard();
            Win = 0;
            Lost = 0;
            Draw = 0;
        }

        public BitBoard Board { get; set; }
        public int Win { get; set; }
        public int Lost { get; set; }
        public int Draw { get; set; }
    }
}
