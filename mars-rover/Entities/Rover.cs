using mars_rover.Enums;

namespace mars_rover.Entities
{
    public class Rover
    {

        public Plateau Plateau { get; set; }
        public Location Location { get; set; }
        public RotationEnum Rotation { get; set; }
    }
}
