using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Digite o valor de N: ");
            int n = int.Parse(Console.ReadLine());
            Piramide piramide = new Piramide(n);
            piramide.Desenha();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
