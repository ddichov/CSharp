using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
     public class TemporaryBall: Ball
    {
         public int Life { get; private set; }
         public TemporaryBall(MatrixCoords topLeft, int life)
            : base(topLeft, new MatrixCoords(0,0))
  
        {
            this.body = new char[,] { { '*' } };
            this.Life = life;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }
        public override void Update()
        {
            if (this.Life == 1)
            {
                this.IsDestroyed = true;
            }
            else
            {
                this.Life--;
            };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
            //{
            //    this.Speed.Row *= -1;
            //}
            //if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
            //{
            //    this.Speed.Col *= -1;
            //}
        }
    }
}
