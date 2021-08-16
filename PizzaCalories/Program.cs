using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Pizza (name)");
            Console.WriteLine("EXAMPLE: Pizza Bulgarian");
            Console.WriteLine("After that you can add dough(white or wholegrain) (crispy, chewy or homemade) and weight");
            Console.WriteLine("EXAMPLE: Dough white chewy 200 or Dough wholegrain homemade 250");
            Console.WriteLine("You also can add topping (meat, veggies, cheese and sauce) and weight");
            Console.WriteLine("EXAMPLE: Topping sauce 20 or Topping meat 50");
            Console.WriteLine("Type END for ending!!!");
            Console.WriteLine("HAVE FUN");
            Console.WriteLine("===============================================================");
            string[] input = Console.ReadLine().Split();
            try
            {
                CreatePizza(input);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static void CreatePizza(string[] input)
        {
            Pizza pizza = new Pizza(input[1]);
            input = Console.ReadLine().Split();
            Dough pizzaDough = new Dough(input[1], input[2], double.Parse(input[3]));
            pizza.Dought = pizzaDough;
            input = Console.ReadLine().Split();
            while (input[0] != "END")
            {
                Topping pizzaTopping = new Topping(input[1], double.Parse(input[2]));
                pizza.AddTopping(pizzaTopping);
                input = Console.ReadLine().Split();
            }
            if (pizza.Toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            Console.WriteLine(pizza);
        }
    }
}
