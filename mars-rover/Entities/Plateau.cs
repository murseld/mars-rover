namespace mars_rover.Entities
{
    public class Plateau
    {
        #region Constructor
        public Plateau(int width, int height, int minWidth = 0, int minHeight = 0)
        {
            MinWidth = minWidth;
            MinHeight = minHeight;
            Width = width;
            Height = height;
        }
        #endregion
        #region Properties
        public int MinWidth { get; set; }
        public int MinHeight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion
    }
}
