namespace AtividadesGoo;

public class Poligono
{
    public List<Vertice> vertices;
    public int QuantidadeVertices => vertices.Count;
    public Poligono(List<Vertice> vertices)
    {
        if (vertices.Count < 3)
        {
            throw new Exception("O polígono deve ter pelo menos 3 vértices");
        }
        this.vertices = vertices;
    }
    public bool addVertice(Vertice v)
    {
        if (vertices.Contains(v))
        {
            return false;
        }
        vertices.Add(v);
        return true;
    }
    public void RemoverVertice(Vertice v)
    {
        if (vertices.Contains(v))
        {
            vertices.Remove(v);
        }
        else if (vertices.Count < 3)
        {
            throw new Exception("O polígono deve ter pelo menos 3 vértices");
        }
        else if (!vertices.Contains(v))
        {
            throw new Exception("O vértice não existe");
        }
    }
    public double Perimetro()
    {
        double perimetro = 0;
        int n = vertices.Count;
        for (int i = 0; i < n; i++)
        {
            int j = (i + 1) % n;
            perimetro += vertices[i].Distancia(vertices[j]);
        }
        return perimetro;
    }
}
