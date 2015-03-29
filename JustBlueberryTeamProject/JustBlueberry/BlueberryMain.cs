namespace JustBlueberry
{
    using System.Collections.Generic;
    using JustBlueberry.Interfaces;

    public class BlueberryMain
    {
        // Define constant dimensions for the game world.
        const int DEFAULT_WORLD_ROWS = 30;
        const int DEFAULT_WORLD_COLS = 80;

        public static void Main()
        {
            var renderer = new ConsoleRenderer(DEFAULT_WORLD_ROWS, DEFAULT_WORLD_COLS);

            var hadronOperator = new Operator();

            var physicalWorldObjects = new List<IMatter>()
            {
                BlueberryFactory.CreateDarkBlueberry(new Vector(2,2)),
                BlueberryFactory.CreateNervousBlueberry(new Vector(2, 40))
            };


            var engine = new Engine(renderer, hadronOperator, physicalWorldObjects, 100);

            engine.Run();
        }
    }
}
