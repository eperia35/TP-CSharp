using System;

namespace TpHeritage
{
    internal class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        protected override double Air()
        {
            double p = this.Perimetre() / 2;
            return Math.Sqrt(p * (p - this.A) * (p - this.B) * (p - this.C));
        }

        protected override double Perimetre()
        {
            return this.A + this.B + this.C;
        }

        public override string ToString()
        {
            return $"Triangle de coté A= {this.A},B= {this.B},C= {this.C}\n" + base.ToString();

        }

    }
}