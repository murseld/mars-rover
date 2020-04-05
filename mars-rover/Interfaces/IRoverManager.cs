namespace mars_rover.Interfaces
{
    public interface IRoverManager
    {
        void ExecuteCommand(string rotationCommand);
        string GetStatusText();

    }
}
