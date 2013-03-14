using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstoppableBall: Ball
    {
        // Exercise 8
        public new const string CollisionGroupString = "Uball";

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { '@' } }; 

        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "Ublock" 
                || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
           
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0 
                    && collisionData.hitObjectsCollisionGroupStrings.Contains("Ublock"))
                {
                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0
                     && collisionData.hitObjectsCollisionGroupStrings.Contains("Ublock"))
                {
                    this.Speed.Col *= -1;
                }

        }

    }
}
