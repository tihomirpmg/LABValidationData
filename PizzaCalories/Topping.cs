using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Topping
    {
        private string type;
        private double weight;
        private double calories;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public double Calories
        {
            get { return this.CalculateCalories(); }
            set { this.calories = value; }
        }
        public string Type
        {
            get { return this.type; }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        private double CalculateCalories()
        {
            double sumCalories = this.weight * 2;
            switch (this.type.ToLower())
            {
                case "meat":
                    sumCalories *= 1.2;
                    break;
                case "veggies":
                    sumCalories *= 0.8;
                    break;
                case "cheese":
                    sumCalories *= 1.1;
                    break;
                case "sauce":
                    sumCalories *= 0.9;
                    break;
            }
            return sumCalories;
        }
    }
}
