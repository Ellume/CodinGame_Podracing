using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    /**
     *
     **/
    static void Main(string[] args)
    {
        string[] inputs;

        // Number of laps.
        inputs = Console.ReadLine().Split(' ');


        // Number of checkpoints.
        inputs = Console.ReadLine().Split(' ');
        int numCheckpoints = int.Parse(inputs[0]);
        //Console.Error.WriteLine("Checkpoints #: "+numCheckpoints);


        // Coordinates for each checkpoint.
        double[][] coordinates = new double[numCheckpoints][];
        for (int i = 0; i < numCheckpoints; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            coordinates[i] = new double[2] { double.Parse(inputs[0]), double.Parse(inputs[1]) };
            //Console.Error.WriteLine("(x,y): "+double.Parse(inputs[0])+", "+double.Parse(inputs[1]));
        }

        // Initialize pods.
        Pod[] pods = new Pod[4];
        for (int i = 0; i < pods.Count(); i++)
        {
            pods[i] = new Pod();
        }


        // game loop
        while (true)
        {
            // Read in new parameters and update pods.
            for (int i = 0; i < 4; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                pods[i].Update(double.Parse(inputs[0]), double.Parse(inputs[1]), double.Parse(inputs[2]),
                                double.Parse(inputs[3]), double.Parse(inputs[4]), int.Parse(inputs[5]));
            }

            //GAME OUTPUT
            Console.WriteLine("0 0 0");
            Console.WriteLine("0 0 0");
        }
    }


    /**
     *  The Pod.. The point of the game. It races and has variables. And stuff.
     **/
    class Pod
    {

        public double currentX = 0;
        public double currentY = 0;
        public double currentVX = 0;
        public double currentVY = 0;
        public double currentAngle = 0;
        public int currentCheckpointID = 0;

        public double currentTargetX = 0;
        public double currentTargetY = 0;

        public double lastX = 0;
        public double lastY = 0;
        public double lastVX = 0;
        public double lastVY = 0;
        public double lastAngle = 0;
        public int lastCheckpointID = 0;

        public double lastTargetX = 0;
        public double lastTargetY = 0;


        // Init pod variables
        public void Init()
        {

            currentX = 0;
            currentY = 0;
            currentVX = 0;
            currentVY = 0;
            currentAngle = 0;
            currentCheckpointID = 1;

            currentTargetX = 0;
            currentTargetY = 0;

            lastX = 0;
            lastY = 0;
            lastVX = 0;
            lastVY = 0;
            lastAngle = 0;
            lastCheckpointID = 0;

            lastTargetX = 0;
            lastTargetY = 0;
        }

        // Read in new parameters and update turn data.
        public void Update(double newX, double newY, double newVX,
                            double newVY, double newAngle, int newCheckpointID)
        {
            lastX = currentX;
            lastY = currentY;
            lastVX = currentVX;
            lastVY = currentVY;
            lastAngle = currentAngle;
            lastCheckpointID = currentCheckpointID;

            //lastTargetX=currentTargetX;
            //lastTargetY=currentTargetY;

            currentX = newX;
            currentY = newY;
            currentVX = newVX;
            currentVY = newVY;
            currentAngle = newAngle;
            currentCheckpointID = newCheckpointID;

            //currentTargetX;
            //currentTargetY;

        }

        // Get pod variables. 
        public string Debug()
        {
            string output = "Test";
            return output;
        }
    }







}





/**
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        
        double boostAngle=20;
        
        double boost1 = 0;
        double x1=0;
        double y1=0;
        double lastX1=0;
        double lastY1=0;
        double vx1=0;
        double vy1=0;
        double lastVX1=0;
        double lastVY1=0;
        double nextCheckpointAngle1=0;
        double nextCheckPointID1=0;
        double nextCheckpointX1=0;
        double nextCheckpointY1=0;
        
        double boost2 = 0;
        double x2=0;
        double y2=0;
        double lastX2=0;
        double lastY2=0;
        double vx2=0;
        double vy2=0;
        double lastVX2=0;
        double lastVY2=0;
        double nextCheckpointAngle2=0;
        double nextCheckPointID2=0;
        double nextCheckpointX2=0;
        double nextCheckpointY2=0;
        
        double opponentX=0;
        double lastOpponentX=0;
        double opponentY=0;
        double lastOpponentY=0;
        double opponentAngle=0;
        double nextCheckpointDist=0;
        double lastCheckpointDist=0;
        double nextCheckpointAngle=0;
        double lastCheckpointAngle=0;
        double nextCheckpointAngleInc=0;
        double nextTargetX=0;
        double nextTargetY=0;
        double nextTargetDist=0;
        double nextTargetAngle=0;
        double nextTargetAngleInc=0;
        double VectorAngle=0;
        double VectorAngleInc=0;
        double thrust = 0;
        double thrustCalc=1;
        double thrustMinAngle=120;
        double thrustMaxAngle=45;
        double thrustDiff=thrustMinAngle-thrustMaxAngle;
        //Tuple<double,double>[] checkpoints = {Tuple.Create(0,0)};
        
        //Number of laps
        Console.Error.WriteLine("Laps");
        inputs = Console.ReadLine().Split(' ');
        
                    
        //Number of checkpoints
        inputs = Console.ReadLine().Split(' ');
        double numCheckpoints = double.Parse(inputs[0]);
        Console.Error.WriteLine("Checkpoints #: "+numCheckpoints);
        
            
        //Coordinates
        double[][] coordinates = new double[(int)numCheckpoints][];
        for (int i = 0; i < numCheckpoints; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            coordinates[i] = new double[2] {double.Parse(inputs[0]),double.Parse(inputs[1])};
            Console.Error.WriteLine("i = "+i);
        }

        // game loop
        while (true)
        {
            //Friendly Pod #1
            inputs = Console.ReadLine().Split(' ');
            
            lastX1 = x1;
            lastY1 = y1;
            lastVX1 = vx1;
            lastVY1 = vy1;
            
            x1 = double.Parse(inputs[0]);
            y1 = double.Parse(inputs[1]);
            vx1 = double.Parse(inputs[2]);
            vy1 = double.Parse(inputs[3]);
            nextCheckpointAngle1 = double.Parse(inputs[4]);
            nextCheckPointID1 = double.Parse(inputs[5]);
            
            //Friendly Pod #2
            inputs = Console.ReadLine().Split(' ');
            
            lastX2 = x2;
            lastY2 = y2;
            lastVX2 = vx2;
            lastVY2 = vy2;
            
            x2 = double.Parse(inputs[0]);
            y2 = double.Parse(inputs[1]);
            vx2 = double.Parse(inputs[2]);
            vy2 = double.Parse(inputs[3]);
            nextCheckpointAngle2 = double.Parse(inputs[4]);
            nextCheckPointID2 = double.Parse(inputs[5]);
            
            //Enemy Pod #1
            inputs = Console.ReadLine().Split(' ');
            
            //Enemy Pod #2
            inputs = Console.ReadLine().Split(' ');
            
            

            //lastX = x;
            //lastY = y;
            //x = double.Parse(inputs[0]);
            //y = double.Parse(inputs[1]);
            //double nextCheckpointX = double.Parse(inputs[2]);
            //double nextCheckpointY = double.Parse(inputs[3]);
            //lastCheckpointDist=nextCheckpointDist;
            //nextCheckpointDist = double.Parse(inputs[4]); // distance to the next checkpoint
            //lastCheckpointAngle=nextCheckpointAngle;
            //nextCheckpointAngle = double.Parse(inputs[5]); // angle between your pod orientation and the direction of the next checkpoint
            //inputs = Console.ReadLine().Split(' ');
            //lastOpponentX=opponentX;
            //lastOpponentY=opponentY;
            //opponentX = double.Parse(inputs[0]);
            //opponentY = double.Parse(inputs[1]);
        
            Console.Error.WriteLine("going");
            

            //CACHE CHECKPOINTS
            

            //THRUST CALCULATION
            // 0 = SET PARAMETERS
            // 1 = SIMPLE LINEAR
            // 2 = SIMPLE QUADRATIC
            if (nextCheckpointAngle > thrustMinAngle || nextCheckpointAngle < -thrustMinAngle)
            {
                thrust=0;
            }
            else if (nextCheckpointAngle > thrustMinAngle || nextCheckpointAngle < -thrustMinAngle)
            {
                if (thrustCalc==0)
                {
                    thrust = 25;
                }
                else if (thrustCalc==1)
                {
                    thrust=((-100.0/thrustDiff)*Math.Abs(nextCheckpointAngle)+(100.0*thrustMinAngle/thrustDiff));
                }
                else if (thrustCalc==2)
                {
                    thrust=(Math.Pow(100.0/thrustDiff,2)*Math.Pow(Math.Abs(nextCheckpointAngle)-thrustMinAngle,2));
                }
            }
            else
            {
                if (nextCheckpointDist >6000 && boost1==0 && (nextCheckpointAngle > -boostAngle && nextCheckpointAngle < boostAngle))
                {
                    boost1=1;
                }
                else
                {
                    if (nextCheckpointDist<1000)
                    {
                        //thrust=50;
                    }
                    else
                    {
                        thrust = 100;
                    }
                }
            }
            
            //TARGET CALCULATION
            //VectorAngleInc=Math.Atan((y-lastY)/(x-lastX));
            //nextCheckpointAngleInc=Math.Atan((nextCheckpointY-y)/(nextCheckpointX-x));
            //
            //nextTargetAngle=Math.Atan(500.0/nextCheckpointDist);
            //nextTargetDist=500.0/Math.Sin(nextTargetAngle);
            
            
            //if ((VectorAngleInc-nextCheckpointAngleInc>0) && (x-lastX)>0 && (nextCheckpointX-x)>0 ||
            //    (VectorAngleInc-nextCheckpointAngleInc>0) && (x-lastX)<0 && (nextCheckpointX-x)<0 ||
            //    (VectorAngleInc-nextCheckpointAngleInc<0) && (x-lastX)>0 && (nextCheckpointX-x)<0 ||
            //    (VectorAngleInc-nextCheckpointAngleInc<0) && (x-lastX)<0 && (nextCheckpointX-x)>0)
            //{
            //    Console.Error.WriteLine("FIRST CHECK");
            //    nextTargetAngle=-1.0*nextTargetAngle;
            //}

            //if (nextCheckpointAngle<0)
            //{
                //nextTargetAngle=-1.0*nextTargetAngle;
            //}
            //if (nextCheckpointX-x>=0)
            //{
            //    nextTargetX=x+nextTargetDist*Math.Cos(nextCheckpointAngleInc+nextTargetAngle);
            //    nextTargetY=y+nextTargetDist*Math.Sin(nextCheckpointAngleInc+nextTargetAngle);
            //}
            //else
            //{
            //    nextTargetX=x-nextTargetDist*Math.Cos(nextCheckpointAngleInc+nextTargetAngle);
            //    nextTargetY=y-nextTargetDist*Math.Sin(nextCheckpointAngleInc+nextTargetAngle);
            //}
  
            //Console.Error.WriteLine("Angle: "+nextTargetAngle);
            //Console.Error.WriteLine("AngleInc: "+nextTargetAngleInc);
            //Console.Error.WriteLine("TargetDist: "+nextTargetDist);
            //Console.Error.WriteLine("TargetX: "+nextTargetX);
            //Console.Error.WriteLine("TargetY: "+nextTargetY);
            
            //DEBUG INFO
            //Console.Error.WriteLine("CheckX: "+((x-lastX)/(nextCheckpointX-x)));
            //Console.Error.WriteLine("CheckY: "+((y-lastY)/(nextCheckpointY-y)));
            //Console.Error.WriteLine("CheckX/Y: "+(((x-lastX)/(nextCheckpointX-x))/((y-lastY)/(nextCheckpointY-y))));
            //Console.Error.WriteLine("VectorXDiff: "+(x-lastX));
            //Console.Error.WriteLine("VectorYDiff: "+(y-lastY));
            //Console.Error.WriteLine("VectorAngleInc: "+VectorAngleInc);
            
            
            //Console.Error.WriteLine("CheckXDiff: "+(nextCheckpointX-x));
            //Console.Error.WriteLine("CheckYDiff: "+(nextCheckpointY-y));
            //Console.Error.WriteLine("nextCheckpointAngleInc: "+nextCheckpointAngleInc);
            //Console.Error.WriteLine("AngleDiff: "+(VectorAngleInc-nextCheckpointAngleInc));
            //Console.Error.WriteLine("Target: ("+nextTargetX+","+nextTargetY+")");
            //Console.Error.WriteLine("Checkpoint: ("+nextCheckpointX+","+nextCheckpointY+")");
            //Console.Error.WriteLine("nextCheckpointDist: "+nextCheckpointDist);
            //Console.Error.WriteLine("nextCheckpointAngle: "+nextCheckpointAngle);
            //Console.Error.WriteLine("Speed: "+Math.Sqrt(Math.Pow(x-lastX,2)+Math.Pow(y-lastY,2)));
            //Console.Error.WriteLine("x: " + x);
            //Console.Error.WriteLine("Y: " + y);
            //Console.Error.WriteLine("opponentX: "+opponentX);
            //Console.Error.WriteLine("opponentY: "+opponentY);
            //Console.Error.WriteLine("trust: "+thrust);
            //Console.Error.WriteLine("boost: "+boost);
            
            
            //GAME OUTPUT
            if (boost1==1)
            {
                boost1=2;
                Console.WriteLine((int)nextCheckpointX1 + " " + (int)nextCheckpointY1 + " BOOST");
            }
            else
            {
                Console.WriteLine((int)nextCheckpointX1 + " " + (int)nextCheckpointY1 + " " + thrust);
            }
            
            if (boost2==1)
            {
                boost2=2;
                Console.WriteLine((int)nextCheckpointX2 + " " + (int)nextCheckpointY2 + " BOOST");
            }
            else
            {
                Console.WriteLine((int)nextCheckpointX2 + " " + (int)nextCheckpointY2 + " " + thrust);
            }
            
            //if (boost==1)
            //{
            //    boost=2;
            //    Console.WriteLine((int)nextCheckpointX + " " + (int)nextCheckpointY + " BOOST WAAAAGGGGGHHHH!!");
            //    Console.WriteLine((int)nextCheckpointX + " " + (int)nextCheckpointY + " BOOST WAAAAGGGGGHHHH!!");
            //}
            //else
            //{
            //    Console.WriteLine((int)nextTargetX + " " + (int)nextTargetY + " " + thrust);
            //    Console.WriteLine((int)nextTargetX + " " + (int)nextTargetY + " " + thrust);
            //}
        }
    }
}

*/
