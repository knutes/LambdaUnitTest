using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaCarTest
{
    public class Function
    {
        public enum Condition
        {
            EXCELLENT,
            GOOD,
            FAIR,
            BAD
        }
        public class Car 
        {
            private double _speed;
            public string Make { get; set; }
            public double Speed
            {
                get { return _speed; }
                set {
                    if(value >= 200)
                    {
                        _speed = 200;
                    }
                    else if(value <= -50)
                    {
                        _speed = -50;
                    }
                    else
                    {
                        _speed = value;
                    }
                }
            }
            public Condition Condition { get; set; }
            public Car(string make, Condition con)
            {
                Make = make;
                Condition = con;
            }

        }
        public string FunctionHandler(string input, ILambdaContext context)
        {
            //Car car = new Car("Chevy", Condition.BAD);
            //car.Condition;
            //car.Speed = 0;
            return input?.ToUpper();
        }
    }
}
