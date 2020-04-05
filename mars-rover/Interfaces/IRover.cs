using mars_rover.Entities;
using mars_rover.Enums;


namespace mars_rover.Interfaces
{
    public interface IRover
    {
        bool IsOutOfBorder();
        Location GetLocation();
        Plateau GetPlateau();
        RotationEnum GetRotation();
        
        void SetLocation(Location location, RotationEnum rotation = RotationEnum.N);
        void SetLocation(int pointX, int pointY, RotationEnum rotation = RotationEnum.N);
        void SetPlateau(Plateau plateau);
        void SetRotation(RotationEnum rotation);
    }
}
