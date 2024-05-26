namespace AtividadesGoo;

public class Vertice
{
    public double X {get; private set;}
    public double Y {get; private set;}

    public Vertice (double x, double y){
        this.X = x;
        this.Y = y;
    }
    public double Distancia (Vertice outro){
        double dx = X - outro.X;
        double dy = Y - outro.Y;
        return Math.Sqrt(dx*dx + dy*dy);
    }

    public void Move(double novoX, double novoY){
        this.X = novoX;
        this.Y = novoY;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Vertice outro = (Vertice)obj;
        return X == outro.X && Y == outro.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
