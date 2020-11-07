namespace MarsRover.Entity
{
    public class Plateau
    {
        public int Width;
        public int Height;

        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsValidXCoordinate(int x)
        {
            return x >= 0 && x <= Width;
        }

        public bool IsValidYCoordinate(int y)
        {
            return y >= 0 && y <= Height;
        }
    }
}