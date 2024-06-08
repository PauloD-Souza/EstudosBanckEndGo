namespace Consultorio;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Paciente
{
    public string ? CPF { get; private set; }
    public string ? Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }

    public Paciente(string cpf, string nome, string dataNascimento)
    {
        SetCPF(cpf);
        SetNome(nome);
        SetDataNascimento(dataNascimento);
    }

    private void SetCPF(string cpf)
    {
        if (IsValidCPF(cpf))
        {
            CPF = cpf;
        }
        else
        {
            throw new ArgumentException("CPF inválido.");
        }
    }

    private void SetNome(string nome)
    {
        if (nome.Length >= 5)
        {
            Nome = nome;
        }
        else
        {
            throw new ArgumentException("Nome deve ter pelo menos 5 caracteres.");
        }
    }

    private void SetDataNascimento(string dataNascimento)
    {
        if (DateTime.TryParseExact(dataNascimento, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
        {
            if (CalcularIdade(data) >= 13)
            {
                DataNascimento = data;
            }
            else
            {
                throw new ArgumentException("Paciente deve ter 13 anos ou mais.");
            }
        }
        else
        {
            throw new ArgumentException("Data de nascimento inválida.");
        }
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

    private bool IsValidCPF(string? cpf)
    {
        cpf = Regex.Replace(cpf, @"[^\d]", "");

        if (cpf.Length != 11)
        {
            return false;
        }

        for (int j = 0; j < 10; j++)
        {
            if (cpf == new string((char)('0' + j), 11))
            {
                return false;
            }
        }

        int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];
        }

        int resto = soma % 11;
        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        string digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];
        }

        resto = soma % 11;
        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }
    public override string ToString()
    {
        return $"CPF: {CPF}, Nome: {Nome}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}";
    }
}