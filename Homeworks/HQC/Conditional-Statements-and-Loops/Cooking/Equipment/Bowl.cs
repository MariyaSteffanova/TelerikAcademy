namespace Cooking.Equipment
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Cooking.Ingredients;

    public class Bowl
    {
        public Bowl()
        {
            this.Ingredients = new List<Vegetable>();
        }

        public List<Vegetable> Ingredients { get; set; }

        public void Add(Vegetable vegetable)
        {
            this.Ingredients.Add(vegetable);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var veggie in this.Ingredients)
            {
                result.AppendLine(veggie.ToString());
            }

            return result.ToString();
        }
    }
}
