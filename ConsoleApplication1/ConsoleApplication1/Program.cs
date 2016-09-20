using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Max Speed Equation: maxSpeed=6.855707829*thrust-8.083308758
 * 
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        double boost = 0;
        double boostAngle = 20;
        double x = 0;
        double y = 0;
        double lastX = 0;
        double lastY = 0;
        double opponentX = 0;
        double lastOpponentX = 0;
        double opponentY = 0;
        double lastOpponentY = 0;
        double opponentAngle = 0;
        double nextCheckpointDist = 0;
        double lastCheckpointDist = 0;
        double nextCheckpointAngle = 0;
        double lastCheckpointAngle = 0;
        double nextCheckpointAngleInc = 0;
        double nextTargetX = 0;
        double nextTargetY = 0;
        double nextTargetDist = 0;
        double nextTargetAngle = 0;
        double nextTargetAngleInc = 0;
        double VectorAngle = 0;
        double VectorAngleInc = 0;
        double thrust = 0;
        double thrustCalc = 1;
        double thrustMinAngle = 120;
        double thrustMaxAngle = 45;
        double thrustDiff = thrustMinAngle - thrustMaxAngle;
        //Tuple<double,double>[] checkpoints = {Tuple.Create(0,0)};

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            inputs = Console.ReadLine().Split(' ');
            inputs = Console.ReadLine().Split(' ');
            lastX = x;
            lastY = y;
            x = double.Parse(inputs[0]);
            y = double.Parse(inputs[1]);
            double nextCheckpointX = double.Parse(inputs[2]); // x position of the next check point
            double nextCheckpointY = double.Parse(inputs[3]); // y position of the next check point
            lastCheckpointDist = nextCheckpointDist;
            nextCheckpointDist = double.Parse(inputs[4]); // distance to the next checkpoint
            lastCheckpointAngle = nextCheckpointAngle;
            nextCheckpointAngle = double.Parse(inputs[5]); // angle between your pod orientation and the direction of the next checkpoint
            inputs = Console.ReadLine().Split(' ');
            lastOpponentX = opponentX;
            lastOpponentY = opponentY;
            opponentX = double.Parse(inputs[0]);
            opponentY = double.Parse(inputs[1]);




            //CACHE CHECKPOINTS


            //THRUST CALCULATION
            // 0 = SET PARAMETERS
            // 1 = SIMPLE LINEAR
            // 2 = SIMPLE QUADRATIC
            if (nextCheckpointAngle > thrustMinAngle || nextCheckpointAngle < -thrustMinAngle)
            {
                thrust = 0;
            }
            else if (nextCheckpointAngle > thrustMinAngle || nextCheckpointAngle < -thrustMinAngle)
            {
                if (thrustCalc == 0)
                {
                    thrust = 25;
                }
                else if (thrustCalc == 1)
                {
                    thrust = ((-100.0 / thrustDiff) * Math.Abs(nextCheckpointAngle) + (100.0 * thrustMinAngle / thrustDiff));
                }
                else if (thrustCalc == 2)
                {
                    thrust = (Math.Pow(100.0 / thrustDiff, 2) * Math.Pow(Math.Abs(nextCheckpointAngle) - thrustMinAngle, 2));
                }
            }
            else
            {
                if (nextCheckpointDist > 6000 && boost == 0 && (nextCheckpointAngle > -boostAngle && nextCheckpointAngle < boostAngle))
                {
                    boost = 1;
                }
                else
                {
                    if (nextCheckpointDist < 1000)
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
            VectorAngleInc = Math.Atan((y - lastY) / (x - lastX));
            nextCheckpointAngleInc = Math.Atan((nextCheckpointY - y) / (nextCheckpointX - x));

            nextTargetAngle = Math.Atan(500.0 / nextCheckpointDist);
            nextTargetDist = 500.0 / Math.Sin(nextTargetAngle);


            if ((VectorAngleInc - nextCheckpointAngleInc > 0) && (x - lastX) > 0 && (nextCheckpointX - x) > 0 ||
                (VectorAngleInc - nextCheckpointAngleInc > 0) && (x - lastX) < 0 && (nextCheckpointX - x) < 0 ||
                (VectorAngleInc - nextCheckpointAngleInc < 0) && (x - lastX) > 0 && (nextCheckpointX - x) < 0 ||
                (VectorAngleInc - nextCheckpointAngleInc < 0) && (x - lastX) < 0 && (nextCheckpointX - x) > 0)
            {
                Console.Error.WriteLine("FIRST CHECK");
                nextTargetAngle = -1.0 * nextTargetAngle;
            }

            if (nextCheckpointAngle < 0)
            {
                //nextTargetAngle=-1.0*nextTargetAngle;
            }
            if (nextCheckpointX - x >= 0)
            {
                nextTargetX = x + nextTargetDist * Math.Cos(nextCheckpointAngleInc + nextTargetAngle);
                nextTargetY = y + nextTargetDist * Math.Sin(nextCheckpointAngleInc + nextTargetAngle);
            }
            else
            {
                nextTargetX = x - nextTargetDist * Math.Cos(nextCheckpointAngleInc + nextTargetAngle);
                nextTargetY = y - nextTargetDist * Math.Sin(nextCheckpointAngleInc + nextTargetAngle);
            }

            //Console.Error.WriteLine("Angle: "+nextTargetAngle);
            //Console.Error.WriteLine("AngleInc: "+nextTargetAngleInc);
            //Console.Error.WriteLine("TargetDist: "+nextTargetDist);
            //Console.Error.WriteLine("TargetX: "+nextTargetX);
            //Console.Error.WriteLine("TargetY: "+nextTargetY);

            //DEBUG INFO
            Console.Error.WriteLine("CheckX: " + ((x - lastX) / (nextCheckpointX - x)));
            Console.Error.WriteLine("CheckY: " + ((y - lastY) / (nextCheckpointY - y)));
            Console.Error.WriteLine("CheckX/Y: " + (((x - lastX) / (nextCheckpointX - x)) / ((y - lastY) / (nextCheckpointY - y))));
            Console.Error.WriteLine("VectorXDiff: " + (x - lastX));
            Console.Error.WriteLine("VectorYDiff: " + (y - lastY));
            Console.Error.WriteLine("VectorAngleInc: " + VectorAngleInc);


            Console.Error.WriteLine("CheckXDiff: " + (nextCheckpointX - x));
            Console.Error.WriteLine("CheckYDiff: " + (nextCheckpointY - y));
            Console.Error.WriteLine("nextCheckpointAngleInc: " + nextCheckpointAngleInc);
            Console.Error.WriteLine("AngleDiff: " + (VectorAngleInc - nextCheckpointAngleInc));
            Console.Error.WriteLine("Target: (" + nextTargetX + "," + nextTargetY + ")");
            Console.Error.WriteLine("Checkpoint: (" + nextCheckpointX + "," + nextCheckpointY + ")");
            Console.Error.WriteLine("nextCheckpointDist: " + nextCheckpointDist);
            Console.Error.WriteLine("nextCheckpointAngle: " + nextCheckpointAngle);
            Console.Error.WriteLine("Speed: " + Math.Sqrt(Math.Pow(x - lastX, 2) + Math.Pow(y - lastY, 2)));
            //Console.Error.WriteLine("x: " + x);
            //Console.Error.WriteLine("Y: " + y);
            //Console.Error.WriteLine("opponentX: "+opponentX);
            //Console.Error.WriteLine("opponentY: "+opponentY);
            Console.Error.WriteLine("trust: " + thrust);
            Console.Error.WriteLine("boost: " + boost);


            //GAME OUTPUT
            if (boost == 1)
            {
                boost = 2;
                Console.WriteLine((int)nextCheckpointX + " " + (int)nextCheckpointY + " BOOST WAAAAGGGGGHHHH!!");
                Console.WriteLine((int)nextCheckpointX + " " + (int)nextCheckpointY + " BOOST WAAAAGGGGGHHHH!!");
            }
            //else if (((x-lastX)/(nextCheckpointX-x))<0 &&
            //        ((y-lastY)/(nextCheckpointY-y))>0)
            //{
            //    Console.WriteLine((int)nextTargetX + " " + (int)nextTargetY + " " + thrust + " NEGATIVE!");
            //}
            else
            {
                Console.WriteLine((int)nextTargetX + " " + (int)nextTargetY + " " + thrust);
                Console.WriteLine((int)nextTargetX + " " + (int)nextTargetY + " " + thrust);
            }
        }
    }
}