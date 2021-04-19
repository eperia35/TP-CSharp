namespace TpHeritage
{
    internal abstract class Forme
    {
        protected abstract double Air();
        protected abstract double Perimetre();


        public override string ToString()
        {
            return $"Air = {this.Air()} \nPérimètre = {this.Perimetre()} \n\n";
                    
        }
    }
}