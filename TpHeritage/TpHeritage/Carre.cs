namespace TpHeritage
{
    internal class Carre : Forme
    {
        public int Longueur { get; set; }

        protected override double Air()
        {
            return this.Longueur * this.Longueur;
        }

        protected override double Perimetre()
        {
            return this.Longueur * 4;
        }

        public override string ToString()
        {
            return $"Carre de coté {Longueur}\n" + base.ToString();

        }
    }
}