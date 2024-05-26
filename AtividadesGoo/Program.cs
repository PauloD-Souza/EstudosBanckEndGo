using System;
namespace AtividadesGoo;
public class Program
{
    public static void Main(string[] args)
    {
        // Exercicio 1
        /*try
        {
            Console.Write("Digite o valor de N: ");
            int n = int.Parse(Console.ReadLine());
            Piramide piramide = new Piramide(n);
            piramide.Desenha();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }*/
        // Exercicio 2

        /*try
            {
                Vertice v1 = new Vertice(1.0, 2.0);
                Vertice v2 = new Vertice(4.0, 6.0);

                double distancia = v1.Distancia(v2);
                Console.WriteLine($"Distância entre v1 e v2: {distancia}");

                v1.Move(3.0, 4.0);
                Console.WriteLine($"Novo v1: ({v1.X}, {v1.Y})");

                Vertice v3 = new Vertice(3.0, 4.0);
                bool saoIguais = v1.Equals(v3);
                Console.WriteLine($"v1 é igual a v3? {saoIguais}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        //Exercicio 3
        /*
        try
        {
            Vertice v1 = new Vertice(0.0, 0.0);
            Vertice v2 = new Vertice(3.0, 0.0);
            Vertice v3 = new Vertice(0.0, 4.0);

            Triangulo t1 = new Triangulo(v1, v2, v3);

            Console.WriteLine($"Perímetro do triângulo: {t1.Perimetro}");
            Console.WriteLine($"Área do triângulo: {t1.Area}");
            Console.WriteLine($"Tipo do triângulo: {t1.Tipo}");

            Vertice v4 = new Vertice(0.0, 0.0);
            Vertice v5 = new Vertice(3.0, 0.0);
            Vertice v6 = new Vertice(0.0, 4.0);

            Triangulo t2 = new Triangulo(v4, v5, v6);

            bool saoIguais = t1.Equals(t2);
            Console.WriteLine($"t1 é igual a t2? {saoIguais}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }*/
        try
        {
            List<Vertice> vertices = new List<Vertice>
                {
                    new Vertice(0.0, 0.0),
                    new Vertice(3.0, 0.0),
                    new Vertice(0.0, 4.0)
                };

            Poligono poligono = new Poligono(vertices);

            Console.WriteLine($"Quantidade de vértices: {poligono.QuantidadeVertices}");
            Console.WriteLine($"Perímetro do polígono: {poligono.Perimetro()}");

            Vertice novoVertice = new Vertice(3.0, 4.0);
            bool adicionado = poligono.addVertice(novoVertice);
            Console.WriteLine($"Novo vértice adicionado? {adicionado}");

            Console.WriteLine($"Quantidade de vértices: {poligono.QuantidadeVertices}");
            Console.WriteLine($"Perímetro do polígono: {poligono.Perimetro()}");

            poligono.RemoverVertice(novoVertice);

            Console.WriteLine($"Quantidade de vértices após remoção: {poligono.QuantidadeVertices}");
            Console.WriteLine($"Perímetro do polígono após remoção: {poligono.Perimetro()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}




