using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock: Block
    {
        // Exercise 10
        public new const string CollisionGroupString = "Eblock";

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'E' } };
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
            return ExplodingBlock.CollisionGroupString;
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
                List<GameObject> boom = new List<GameObject>();
                ProduceTempBall(row - 1, col + 1, ref boom);
                ProduceTempBall(row - 1, col - 1, ref boom);
                ProduceTempBall(row - 1, col, ref boom);
                ProduceTempBall(row + 1, col + 1, ref boom);
                ProduceTempBall(row + 1, col - 1, ref boom);
                ProduceTempBall(row + 1, col, ref boom);
                ProduceTempBall(row, col + 1, ref boom);
                ProduceTempBall(row, col - 1, ref boom);
                
                return boom;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
            private void ProduceTempBall(int row, int col,ref List<GameObject> boom)
            {
                TemporaryBall tempBall = new TemporaryBall(new MatrixCoords(row, col), 1);
                boom.Add(tempBall);

            }
            
        }
    }

