namespace TpHeritage
{
    internal class Rectangle : Forme
    {

        public int Largeur { get; set; }
        public int Longueur { get; set; }


        protected override double Air()
        {
            return this.Largeur * this.Longueur;
        }

        protected override double Perimetre()
        {
            return (this.Largeur + this.Longueur)*2;
        }

        public override string ToString()
        {
            return $"Rectangle de longueur={Longueur} et largeur={Largeur} \n" + base.ToString();

        }
    }
}