using System;

namespace islands
{
    class Program
    {
        static void Main(string[] args)
        {

            var logic = new Logic();

            //ფერების გამო ჰარდკოდადაა 5X5 მატრიცა
            logic.FillMatrix(5,5);

            Console.ReadKey();
        }
    }
}
