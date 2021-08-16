using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Dough
    {
        private string flour;
        private string bakingTechnique;
        private double weight;
        private double calories;

        public Dough(string flour, string bakingTechnique, double weight)
        {
            this.Flour = flour;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Calories
        {
            get { return this.CalculateCalories(); }
            set { this.calories = value; }
        }
        public string Flour
        {
            get { return this.flour; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flour = value;
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        private double CalculateCalories()
        {
            double sumCalories = this.weight * 2;
            switch (this.flour.ToLower())
            {
                case "white":
                    sumCalories *= 1.5;
                    break;
                case "wholegrain":
                    sumCalories *= 1;
                    break;
            }
            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    sumCalories *= 0.9;
                    break;
                case "chewy":
                    sumCalories *= 1.1;
                    break;
                case "homemade":
                    sumCalories *= 1;
                    break;
            }
            return sumCalories;
        }
    }
}
