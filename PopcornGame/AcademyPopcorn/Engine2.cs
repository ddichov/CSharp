using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Engine2 : Engine
    {
        // added. Exercise 4
      
        public Engine2(IRenderer renderer, IUserInterface userInterface, int sleepTime = 500)
            : base(renderer, userInterface, sleepTime)
        {
        }

        

        public void ShootPlayerRacket( )
        {
            ShootingRacket.Action(); // Exercise 13
        }
    }
}
