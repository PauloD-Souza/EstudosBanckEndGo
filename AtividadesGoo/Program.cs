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
        //Exercicio 4
        /*
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
        }*/
        /* Exercicio 5
         try
        {
            Intervalo intervalo1 = new Intervalo(new DateTime(2024, 5, 28, 9, 0, 0), new DateTime(2024, 5, 28, 17, 0, 0));
            Intervalo intervalo2 = new Intervalo(new DateTime(2024, 5, 28, 13, 0, 0), new DateTime(2024, 5, 28, 18, 0, 0));

            Console.WriteLine($"Intervalo 1: {intervalo1.dataHoraInicial} - {intervalo1.dataHoraFinal}");
            Console.WriteLine($"Intervalo 2: {intervalo2.dataHoraInicial} - {intervalo2.dataHoraFinal}");

            Console.WriteLine($"Os intervalos têm interseção? {intervalo1.TemIntersecao(intervalo2)}");
            Console.WriteLine($"A duração do intervalo 1 é: {intervalo1.Duracao}");

            Intervalo intervalo3 = new Intervalo(new DateTime(2024, 5, 28, 9, 0, 0), new DateTime(2024, 5, 28, 17, 0, 0));
            Console.WriteLine($"O intervalo 1 é igual ao intervalo 3? {intervalo1.Equals(intervalo3)}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }*/
        /* Exercicio 6
        Intervalo intervalo1 = new Intervalo(new DateTime(2024, 6, 1, 9, 0, 0), new DateTime(2024, 6, 1, 10, 0, 0));
        Intervalo intervalo2 = new Intervalo(new DateTime(2024, 6, 1, 10, 30, 0), new DateTime(2024, 6, 1, 11, 30, 0));
        Intervalo intervalo3 = new Intervalo(new DateTime(2024, 6, 1, 12, 0, 0), new DateTime(2024, 6, 1, 13, 0, 0));

        ListaIntervalo listaIntervalos = new ListaIntervalo();
        listaIntervalos.Add(intervalo1);
        listaIntervalos.Add(intervalo2);
        listaIntervalos.Add(intervalo3);

        foreach (var intervalo in listaIntervalos.Intervalos)
        {
            Console.WriteLine(intervalo);
        }

        Intervalo intervaloSobreposto = new Intervalo(new DateTime(2024, 6, 1, 10, 0, 0), new DateTime(2024, 6, 1, 11, 0, 0));
        try
        {
            listaIntervalos.Add(intervaloSobreposto);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }*/
        /* Exercicio 7*/     
          for (int i = 1; i <= 10000; i++)
            {
                if (i.IsArmstrong())
                {
                    Console.WriteLine(i);
                }
            }
    }
}




