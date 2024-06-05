namespace AtividadesGoo;

public class DesafioCliente
{
    public string Nome { get; private set; }
    public string CPF { get; private set; }

    public DesafioCliente(string nome, string cpf)
    {
        Nome = nome;
        CPF = cpf;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        DesafioCliente outro = (DesafioCliente)obj;
        return CPF == outro.CPF;
    }

    public override int GetHashCode()
    {
        return CPF.GetHashCode();
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, CPF: {CPF}";
    }
}
