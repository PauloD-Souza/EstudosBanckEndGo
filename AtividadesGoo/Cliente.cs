namespace AtividadesGoo;
using System;
using System.Globalization;


public class Cliente
{
    public string Nome { get; private set; }
    public long CPF { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public float RendaMensal { get; private set; }
    public char EstadoCivil { get; private set; }
    public int Dependentes { get; private set; }

    public Cliente()
    {
        Nome = ObterNome();
        CPF = ObterCPF();
        DataNascimento = ObterDataNascimento();
        RendaMensal = ObterRendaMensal();
        EstadoCivil = ObterEstadoCivil();
        Dependentes = ObterDependentes();
    }

    private string ObterNome()
    {
        string nome;
        do
        {
            Console.Write("Digite o nome (pelo menos 5 caracteres): ");
            nome = Console.ReadLine();
        } while (nome.Length < 5);

        return nome;
    }

    private long ObterCPF()
    {
        long cpf;
        bool cpfValido;
        do
        {
            Console.Write("Digite o CPF (11 dígitos): ");
            string cpfInput = Console.ReadLine();
            cpfValido = long.TryParse(cpfInput, out cpf) && cpfInput.Length == 11 && ValidarCPF(cpfInput);
            if (!cpfValido)
            {
                Console.WriteLine("CPF inválido. Deve conter exatamente 11 dígitos e ser válido de acordo com as regras.");
            }
        } while (!cpfValido);

        return cpf;
    }

    private bool ValidarCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }

    private DateTime ObterDataNascimento()
    {
        DateTime dataNascimento;
        bool dataValida;
        do
        {
            Console.Write("Digite a data de nascimento (DD/MM/AAAA): ");
            string dataInput = Console.ReadLine();
            dataValida = DateTime.TryParseExact(dataInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento);
            if (dataValida && CalcularIdade(dataNascimento) < 18)
            {
                dataValida = false;
                Console.WriteLine("Cliente deve ter pelo menos 18 anos.");
            }
            if (!dataValida)
            {
                Console.WriteLine("Data de nascimento inválida.");
            }
        } while (!dataValida);

        return dataNascimento;
    }

    private int CalcularIdade(DateTime dataNascimento)
    {
        int idade = DateTime.Now.Year - dataNascimento.Year;
        if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
        {
            idade--;
        }
        return idade;
    }

    private float ObterRendaMensal()
    {
        float rendaMensal;
        bool rendaValida;
        do
        {
            Console.Write("Digite a renda mensal (valor ≥ 0, com duas casas decimais e vírgula decimal): ");
            string rendaInput = Console.ReadLine();
            rendaValida = float.TryParse(rendaInput, NumberStyles.Float, CultureInfo.GetCultureInfo("pt-BR"), out rendaMensal) && rendaMensal >= 0;
            if (!rendaValida)
            {
                Console.WriteLine("Renda mensal inválida.");
            }
        } while (!rendaValida);

        return rendaMensal;
    }

    private char ObterEstadoCivil()
    {
        char estadoCivil;
        bool estadoCivilValido;
        do
        {
            Console.Write("Digite o estado civil (C, S, V, D): ");
            estadoCivil = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            estadoCivilValido = "CSVD".Contains(estadoCivil);
            if (!estadoCivilValido)
            {
                Console.WriteLine("Estado civil inválido.");
            }
        } while (!estadoCivilValido);

        return estadoCivil;
    }

    private int ObterDependentes()
    {
        int dependentes;
        bool dependentesValidos;
        do
        {
            Console.Write("Digite o número de dependentes (0 a 10): ");
            string dependentesInput = Console.ReadLine();
            dependentesValidos = int.TryParse(dependentesInput, out dependentes) && dependentes >= 0 && dependentes <= 10;
            if (!dependentesValidos)
            {
                Console.WriteLine("Número de dependentes inválido.");
            }
        } while (!dependentesValidos);

        return dependentes;
    }

    public void ImprimirDados()
    {
        Console.WriteLine("\nDados do Cliente:");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"CPF: {CPF}");
        Console.WriteLine($"Data de Nascimento: {DataNascimento.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Renda Mensal: {RendaMensal.ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Estado Civil: {EstadoCivil}");
        Console.WriteLine($"Dependentes: {Dependentes}");
    }
}
