using Controller;
using System;

namespace UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string output;

            PrintUsage();

            while (true)
            {
                string[] inputArgs = Console.ReadLine().TrimStart().Split(' ');
                if (inputArgs[0].ToLower().Equals("quit"))
                {
                    return;
                }

                try
                {
                    double[] shapeParameters = ConvertStringToNumber(inputArgs);
                    
                    if(shapeParameters.Length == 0)
                    {
                        Console.WriteLine("Please type paramaters after shape name");
                    }
                    else
                    {
                        IShapeService shapeService = StartupConfig.GetShapeService();
                        output = shapeService.GetShapeConcreteTypeName(inputArgs[0], shapeParameters);
                        Console.WriteLine(output);
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);        // Inform users that parameters are not number
                }
            }         
        }

        // UI layer basic validation to ensure parameters are legit number
        private static double[] ConvertStringToNumber(string[] inputArgs)
        {
            double[] shapeParameters = new double[inputArgs.Length - 1];

            var isEmptyParameter = true;
            for(int i=1; i< inputArgs.Length; i++)
            {
                if (!string.IsNullOrEmpty(inputArgs[i]))
                {
                    isEmptyParameter = false;
                    break;
                }                
            }
            if (isEmptyParameter)
            {
                return shapeParameters;
            }
            
            try
            {
                for (int i = 1; i < inputArgs.Length; i++)
                {
                    shapeParameters[i - 1] = double.Parse(inputArgs[i]);
                }
            }
            catch (Exception)
            {
                throw new Exception("Input parameters are not legit number" );
            }
            return shapeParameters;
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Please input shape with correct parameters, for example => Triangle 2 3 4");
            Console.WriteLine("Type quit to exit program");
            Console.WriteLine();
        }
    }

}
