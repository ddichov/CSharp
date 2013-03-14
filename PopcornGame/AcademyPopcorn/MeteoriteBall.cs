using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall: Ball
    {
        // Exercise 6
        public MeteoriteBall (MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { 'O' } }; //

        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List < GameObject >  l1= new List<GameObject>();
            TrailObject trObj = new TrailObject(this.topLeft, new char[,] { { 'M' } }, 3);
            l1.Add(trObj);
            return l1;
        }
        public override void Update()
        {
            ProduceObjects();
            
            base.Update();
           
        }
    }
}
