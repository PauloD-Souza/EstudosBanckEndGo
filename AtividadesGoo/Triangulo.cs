namespace AtividadesGoo;

public class Triangulo
{
    public Vertice V1 { get; private set; }
    public Vertice V2 { get; private set; }
    public Vertice V3 { get; private set; }

    public Triangulo(Vertice v1, Vertice v2, Vertice v3)
    {
        this.V1 = v1;
        this.V2 = v2;
        this.V3 = v3;
        if (!formaTriangulo())
        {
            throw new Exception("Não é um triângulo");
        }
    }
    private bool formaTriangulo()
    {
        double a = V1.Distancia(V2);
        double b = V2.Distancia(V3);
        double c = V3.Distancia(V1);

        return a + b > c && a + c > b && b + c > a;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Triangulo outro = (Triangulo)obj;

        return (V1.Equals(outro.V1) || V1.Equals(outro.V2) || V1.Equals(outro.V3)) &&
               (V2.Equals(outro.V1) || V2.Equals(outro.V2) || V2.Equals(outro.V3)) &&
               (V3.Equals(outro.V1) || V3.Equals(outro.V2) || V3.Equals(outro.V3));
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(V1, V2, V3);
    }

    public double Perimetro {
        get
        {
            double a = V1.Distancia(V2);
            double b = V2.Distancia(V3);
            double c = V3.Distancia(V1);
            return a + b + c;
        }
    }
    public tipoTriangulo Tipo
        {
            get
            {
                double a = V1.Distancia(V2);
                double b = V2.Distancia(V3);
                double c = V3.Distancia(V1);

                if (a == b && b == c)
                {
                    return tipoTriangulo.Equilatero;
                }
                else if (a == b || b == c || a == c)
                {
                    return tipoTriangulo.Isosceles;
                }
                else
                {
                    return tipoTriangulo.Escaleno;
                }
            }
        }

        public double Area
        {
            get
            {
                double a = V1.Distancia(V2);
                double b = V2.Distancia(V3);
                double c = V3.Distancia(V1);
                double s = Perimetro / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }
}
