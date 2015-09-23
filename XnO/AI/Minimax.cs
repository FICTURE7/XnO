using XnO.Model;

namespace XnO.AI
{
    public class Minimax
    {
        public Minimax(XnOGame game)
        {
            Game = game;
        }

        public XnOGame Game { get; set; }
    }
}
