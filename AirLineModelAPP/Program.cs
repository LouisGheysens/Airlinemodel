using System;
using AirLineModelClassLibrary;

namespace AirLineModelAPP {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            AirLineContext ax = new AirLineContext();

            ax.Database.EnsureDeleted();
            ax.Database.EnsureCreated();
        }
    }
}
