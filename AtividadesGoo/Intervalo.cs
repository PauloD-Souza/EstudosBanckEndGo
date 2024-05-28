namespace AtividadesGoo;

public class Intervalo
{
    public DateTime dataHoraInicial {get;}
    public DateTime dataHoraFinal {get;}

    public Intervalo (DateTime dataHoraInicial, DateTime dataHoraFinal){
        if (dataHoraInicial > dataHoraFinal){
            throw new Exception("Data inicial não pode ser maior que a data final");
        }
        this.dataHoraInicial = dataHoraInicial;
        this.dataHoraFinal = dataHoraFinal;
    }
     public bool TemIntersecao(Intervalo outro)
    {
        return dataHoraInicial < outro.dataHoraFinal && dataHoraFinal > outro.dataHoraInicial;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Intervalo outro = (Intervalo)obj;
        return dataHoraInicial == outro.dataHoraInicial && dataHoraFinal == outro.dataHoraFinal;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(dataHoraInicial, dataHoraFinal);
    }

    public TimeSpan Duracao
    {
        get
        {
            return dataHoraFinal - dataHoraInicial;
        }
    }
}
