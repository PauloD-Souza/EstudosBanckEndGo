namespace Consultorio.model;

using System;

public class Consulta
{
    public string CPF { get; private set; }
    public DateTime DataConsulta { get; private set; }
    public TimeSpan HoraInicial { get; private set; }
    public TimeSpan HoraFinal { get; private set; }

    public Consulta(string cpf, string dataConsulta, string horaInicial, string horaFinal)
    {
        if (!DateTime.TryParseExact(dataConsulta, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out var data))
            throw new ArgumentException("Data da consulta inválida. Use o formato DDMMAAAA.");
        if (!TimeSpan.TryParseExact(horaInicial, "hhmm", null, out var horaIni))
            throw new ArgumentException("Hora inicial inválida. Use o formato HHMM.");
        if (!TimeSpan.TryParseExact(horaFinal, "hhmm", null, out var horaFim))
            throw new ArgumentException("Hora final inválida. Use o formato HHMM.");
        if (data < DateTime.Now.Date || (data == DateTime.Now.Date && horaIni <= DateTime.Now.TimeOfDay))
            throw new ArgumentException("A consulta deve ser para um período futuro.");
        if (horaFim <= horaIni)
            throw new ArgumentException("Hora final deve ser maior que a hora inicial.");

        CPF = cpf;
        DataConsulta = data;
        HoraInicial = horaIni;
        HoraFinal = horaFim;
    }

}