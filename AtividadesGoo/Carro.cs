namespace AtividadesGoo;

public class Carro
{
    public string Placa { get; private set; }
    public string Modelo { get; private set; }
    public Motor Motor { get; private set; }

    public Carro(string placa, string modelo, Motor motor)
    {
        if (string.IsNullOrWhiteSpace(placa))
        {
            throw new ArgumentException("A placa é obrigatória.");
        }
        if (string.IsNullOrWhiteSpace(modelo))
        {
            throw new ArgumentException("O modelo é obrigatório.");
        }
        if (motor == null)
        {
            throw new ArgumentNullException(nameof(motor), "O motor é obrigatório.");
        }
        if (motor.Instalado)
        {
            throw new InvalidOperationException("O motor já está instalado em outro carro.");
        }

        Placa = placa;
        Modelo = modelo;
        Motor = motor;
        motor.Instalar();
    }

    public void TrocarMotor(Motor novoMotor)
    {
        if (novoMotor == null)
        {
            throw new ArgumentNullException(nameof(novoMotor), "O novo motor é obrigatório.");
        }
        if (novoMotor.Instalado)
        {
            throw new InvalidOperationException("O novo motor já está instalado em outro carro.");
        }

        Motor.Desinstalar();
        Motor = novoMotor;
        Motor.Instalar();
    }

    public int CalcularVelocidadeMaxima()
    {
        if (Motor.Cilindrada <= 1.0)
        {
            return 140;
        }
        else if (Motor.Cilindrada <= 1.6)
        {
            return 160;
        }
        else if (Motor.Cilindrada <= 2.0)
        {
            return 180;
        }
        else
        {
            return 220;
        }
    }

    public void ImprimirDados()
    {
        Console.WriteLine($"Placa: {Placa}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Cilindrada do Motor: {Motor.Cilindrada}");
        Console.WriteLine($"Velocidade Máxima: {CalcularVelocidadeMaxima()} km/h");
    }
}
