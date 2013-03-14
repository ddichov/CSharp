using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow + 2, i));
                GiftBlock currBlock2 = new GiftBlock(new MatrixCoords(startRow + 4, i));
                engine.AddObject(currBlock);
                engine.AddObject(currBlock2);

                if (i < endCol / 4)   // Exercise 9, 10
                {
                    UnpassableBlock currUBlock = new UnpassableBlock(new MatrixCoords(startRow + 0, i));// Exercise 9 
                    engine.AddObject(currUBlock);
                    if (i % 3 == 0)// Exercise 10
                    {
                        ExplodingBlock currEBlock = new ExplodingBlock(new MatrixCoords(startRow + 3, i));// Exercise 10
                        engine.AddObject(currEBlock);
                    }
                }  
            }

            for (int i = 0; i < WorldCols; i++) // added. Exercise 1
            {
                IndestructibleBlock currBlock1=new IndestructibleBlock(new MatrixCoords(0,i));
                engine.AddObject(currBlock1);
            }

            for (int i = 1; i < WorldRows; i++) // added. Exercise 1
            {
                IndestructibleBlock currBlock1 = new IndestructibleBlock(new MatrixCoords(i, 0));
                IndestructibleBlock currBlock2 = new IndestructibleBlock(new MatrixCoords(i, WorldCols-1));
                engine.AddObject(currBlock1);
                engine.AddObject(currBlock2);
            }
             // added. Exercise 5
            TrailObject trObj1 = new TrailObject(new MatrixCoords(20, 36), new char[,] {{ 'f' }}, 10);
            engine.AddObject(trObj1);
            TrailObject trObj2 = new TrailObject(new MatrixCoords(15, 27), new char[,] { { 'R' } }, 15);
            engine.AddObject(trObj2);

            // // replaced with MeteoriteBall
            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            // //Exercise 7; replaced with UnstoppableBall
            //MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            // Exercise 9 
            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            //Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            ShootingRacket theRacket = new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength); //Exercise 13

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

           // Engine gameEngine = new Engine(renderer, keyboard); // changed to Engin2
            Engine2 gameEngine = new Engine2(renderer, keyboard); // Exercise 13

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            // added Exercise 13
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
