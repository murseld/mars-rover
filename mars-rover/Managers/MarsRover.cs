
using mars_rover.Entities;
using mars_rover.Enums;
using mars_rover.Interfaces;

namespace mars_rover.Managers
{
    public class MarsRover : Rover, IRover
    {
        //public MarsRover(Plateau plateau,Location location)
        //{
        //    Plateau = plateau;
        //    Location = location;
        //}

        #region Public Methods

        public bool IsOutOfBorder()
        {
            return
                Plateau.MinWidth <= Location.PointX &&
                Location.PointX <= Plateau.Width &&
                Plateau.MinHeight <= Location.PointY &&
                Location.PointY <= Plateau.Height;
        }
        public Location GetLocation()
        {
            return Location;
        }
        public RotationEnum GetRotation()
        {
            return Rotation;
        }
        public Plateau GetPlateau()
        {
            return Plateau;
        }
        public void SetLocation(Location location, RotationEnum rotation = RotationEnum.N)
        {
            if (Location != null)
            {
                Location.PointX = location.PointX;
                Location.PointY = location.PointY;
            }
            else
            {
                Location = new Location(location.PointX, location.PointY);
            }
            Rotation = rotation;
        }
        public void SetLocation(int pointX, int pointY, RotationEnum rotation = RotationEnum.N)
        {
            if (Location != null)
            {
                Location.PointX = pointX;
                Location.PointY = pointY;
            }
            else
            {
                Location = new Location(pointX, pointY);
            }
            Rotation = rotation;
        }
        public void SetPlateau(Plateau plateau)
        {
            Plateau = plateau;
        }
        public void SetRotation(RotationEnum rotation)
        {
            Rotation = rotation;
        }

        #endregion
    }
}
