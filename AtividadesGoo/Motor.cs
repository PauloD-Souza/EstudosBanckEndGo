namespace AtividadesGoo;

public class Motor
{
    public double Cilindrada { get; private set; }
    public bool Instalado { get; private set; }

    public Motor(double cilindrada)
    {
        if (cilindrada <= 0)
        {
            throw new ArgumentException("A cilindrada deve ser positiva.");
        }
        Cilindrada = cilindrada;
        Instalado = false;
    }

    public void Instalar()
    {
        if (Instalado)
        {
            throw new InvalidOperationException("O motor já está instalado em um carro.");
        }
        Instalado = true;
    }

    public void Desinstalar()
    {
        if (!Instalado)
        {
            throw new InvalidOperationException("O motor não está instalado em nenhum carro.");
        }
        Instalado = false;
    }
}
