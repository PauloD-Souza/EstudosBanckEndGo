namespace Consultorio.model;

using System;

public class Consulta
{
    public string CPF { get; private set; }
    public DateTime DataConsulta { get; private set; }
    public TimeSpan HoraInicial { get; private set; }
    public TimeSpan HoraFinal { get; private set; }

    public Consulta(string cpf, DateTime dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal)
    {
        CPF = cpf;
        DataConsulta = dataConsulta;
        HoraInicial = horaInicial;
        HoraFinal = horaFinal;
    }

}