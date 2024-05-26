using System;
namespace AtividadesGoo;

public class Piramide
{
    private int _n;
    public int N
    {
        get { return _n; }
        set
        {
            if (value < 1)
                throw new ArgumentException("N deve ser maior ou igual a 1.");
            _n = value;
        }
    }
    public Piramide(int n)
    {
        if (n < 1)
            throw new ArgumentException("N deve ser maior ou igual a 1.");
        N = n;
    }

    public void Desenha()
    {
        for (int i = 1; i <= N; i++)
        {
            for (int j = 0; j < N - i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 1; k <= i; k++)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
        }
    }
}
