using System;
using mars_rover.Entities;
using mars_rover.Enums;
using mars_rover.Interfaces;
using mars_rover.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace mars_rover
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRover, MarsRover>()
                .AddSingleton<IRoverManager, MarsRoverManager>()
                .BuildServiceProvider();

            var plateau = new Plateau(5, 5);
            var location = new Location(1, 2);

            var rover = serviceProvider.GetService<IRover>();
            rover.SetPlateau(plateau);
            rover.SetLocation(location, RotationEnum.N);

            var roverManager = serviceProvider.GetService<IRoverManager>();
            roverManager.ExecuteCommand("LMLMLMLMM");
            Console.WriteLine(roverManager.GetStatusText());

            rover.SetLocation(3, 3, RotationEnum.E);
            roverManager.ExecuteCommand("MMRMMRMRRMMMMMM");
            Console.WriteLine(roverManager.GetStatusText());
            Console.ReadKey();
        }
    }
}
