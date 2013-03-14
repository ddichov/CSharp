using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        //added. Exercise 5
        public int lifetime { get; set; }
        public TrailObject(MatrixCoords topLeft, char[,] body, int life=10)
            : base (topLeft, body) 
        {
            this.lifetime = life;
        }

        public override void Update()
        {
            if (this.lifetime==1)
            {
                this.IsDestroyed = true;
            }
            else
            {
                this.lifetime--;
            }
            
        }
    }
}
