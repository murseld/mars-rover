using System;
using System.Linq;
using mars_rover.Enums;
using mars_rover.Exceptions;
using mars_rover.Interfaces;

namespace mars_rover.Managers
{
    public class MarsRoverManager : IRoverManager
    {
        private readonly IRover _rover;

        #region Constructor

        public MarsRoverManager(IRover rover)
        {
            _rover = rover;
        }

        #endregion

        #region Public Methods
        public void ExecuteCommand(string rotationCommand)
        {
            rotationCommand.ToList().ForEach(cmd =>
            {
                switch (cmd)
                {
                    case (char)CommandEnum.M:
                        {
                            if (!Move())
                            {
                               throw new OutOfBorderException();
                            }
                            break;
                        }
                    case (char)CommandEnum.L:
                        TurnLeft();
                        break;
                    case (char)CommandEnum.R:
                        TurnRight();
                        break;
                    default:
                        throw new InvalidCommandException();
                }
            });
        }
        public string GetStatusText()
        {
            return $"{_rover.GetLocation().PointX} {_rover.GetLocation().PointY} {_rover.GetRotation()}";
        }

        #endregion

        #region Private Methods

        private void TurnLeft()
        {
            _rover?.SetRotation(_rover.GetRotation() - 1 < RotationEnum.N
                ? RotationEnum.W
                : _rover.GetRotation() - 1);
        }
        private void TurnRight()
        {
            _rover?.SetRotation(_rover.GetRotation() + 1 > RotationEnum.W
                ? RotationEnum.N
                : _rover.GetRotation() + 1);
        }
        private bool Move()
        {
            if (!_rover.IsOutOfBorder())
                return false;

            switch (_rover.GetRotation())
            {
                case RotationEnum.N:
                    _rover.GetLocation().PointY += 1;
                    break;
                case RotationEnum.E:
                    _rover.GetLocation().PointX += 1;
                    break;
                case RotationEnum.S:
                    _rover.GetLocation().PointY -= 1;
                    break;
                case RotationEnum.W:
                    _rover.GetLocation().PointX -= 1;
                    break;
            }
            return true;
        }

        #endregion
    }
}
