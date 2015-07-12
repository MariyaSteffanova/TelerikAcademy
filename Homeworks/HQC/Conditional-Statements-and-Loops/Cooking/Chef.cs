namespace Cooking
{
    using System;
    using Cooking.Equipment;
    using Cooking.Ingredients;
    
    public class Chef
    {
        public Bowl Cook()
        {
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);

            Bowl bowl = this.GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);

            foreach (var veggie in bowl.Ingredients)
            {
                veggie.IsCooked = true;
            }

            return bowl;
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.Peel();
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.Cut();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }
    }
}
