namespace IndividualTask
{
    public class Player
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public char Cursor { get; set; }

        public Player(int positionX, int positionY, char cursor)
        {
            PositionX=positionX;
            PositionY=positionY;
            Cursor=cursor;
        }

        public Player()
        {
            PositionX = 0;
            PositionY = 0;
            Cursor = '@';
        }

        public override string ToString()
        {
            return $"{Cursor} {PositionX} {PositionY}";
        }
    }
}
