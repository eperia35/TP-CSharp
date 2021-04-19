namespace TpHeritage
{
    internal class Cercle : Forme
    {
        public int Rayon { get; set; }
        protected override double Air()
        {
            return this.Rayon * this.Rayon * 3.14;
        }

        protected override double Perimetre()
        {
            return 2 * this.Rayon * 3.14;
        }

        public override string ToString()
        {
            return $"Cercle de rayon {this.Rayon}\n" + base.ToString();

        }

        
    }
}