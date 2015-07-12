namespace Cooking.Ingredients
{
    using System;
    using System.Text;

    public abstract class Vegetable
    {
        public Vegetable()
        {
            this.IsRotten = false;
            this.IsPeeled = false;
            this.IsCut = false;
            this.IsCooked = false;
        }

        public bool IsRotten { get; set; }

        public bool IsPeeled { get; set; }

        public bool IsCut { get; set; }

        public bool IsCooked { get; set; }

        public void Peel()
        {
            this.IsPeeled = true;
        }

        public void Cut()
        {
            this.IsCut = true;
        }

        public void Cook()
        {
            this.IsCooked = true;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("{0}", this.GetType().Name).AppendLine();
            result.AppendFormat("{0},", this.IsPeeled ? "peeled" : "not peeled");
            result.AppendFormat("{0},", this.IsCut ? "cut" : "not cut");
            result.AppendFormat("{0}", this.IsCooked ? "cooked" : "not cooked");
            result.AppendLine();
            return result.ToString();
        }
    }
}
