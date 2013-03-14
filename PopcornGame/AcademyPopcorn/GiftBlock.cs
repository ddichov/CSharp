using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class GiftBlock: Block
    {
        // Exercise 12
        public new const string CollisionGroupString = "Gblock";

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'G' } };
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball" || otherCollisionGroupString == "Uball";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return GiftBlock.CollisionGroupString; 
        }

        public override void Update()
        {

        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {


                int row = this.TopLeft.Row;
                int col = this.TopLeft.Col;
                List<GameObject> gifts = new List<GameObject>();
                Gift gift1 = new Gift(new MatrixCoords(row, col));
                gifts.Add(gift1);
                return gifts;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
           
    }
}
