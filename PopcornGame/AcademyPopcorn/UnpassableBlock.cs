using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlock: Block
    {
        // Exercise 8
        public new const string CollisionGroupString = "Ublock";

        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'U' } };
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball" || otherCollisionGroupString == "Uball";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = false;
        }
        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

    }
}
