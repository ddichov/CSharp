using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingRacket: Racket
    {
        // Exercise 13
        public int shoots { get; private set; }
        public static bool produce { get; private set; }

        public ShootingRacket(MatrixCoords topLeft, int width) : base(topLeft, width)
        {
            this.shoots = 0;
        }
        public override string GetCollisionGroupString()
        {
            return Racket.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == Racket.CollisionGroupString || otherCollisionGroupString == "ball";
        }

        public override void Update()
        {

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (shoots > 0 && produce == true)
            {
                int row = this.TopLeft.Row;
                int col = this.TopLeft.Col;
                List<GameObject> bullets = new List<GameObject>();
                Bullet bullet = new Bullet(new MatrixCoords(row, col));
                bullets.Add(bullet);
                produce = false;    // ?

                return bullets;
            }
            return base.ProduceObjects();
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains(Gift.CollisionGroupString) )
            {
                this.shoots++;
            }
            else
            {
                base.RespondToCollision(collisionData);
            }
            
        }

        public static void Action()
        {
            produce = true;
                        
        }

    }
}
