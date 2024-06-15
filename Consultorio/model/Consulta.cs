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
        if (horaIni.Minutes % 15 != 0 || horaFim.Minutes % 15 != 0)
            throw new ArgumentException("As horas inicial e final devem ser múltiplos de 15 minutos.");
        if (horaFim <= horaIni)
            throw new ArgumentException("Hora final deve ser maior que a hora inicial.");
        TimeSpan horaAbertura = new TimeSpan(8, 0, 0);
        TimeSpan horaFechamento = new TimeSpan(19, 0, 0);
        if (horaIni < horaAbertura || horaIni >= horaFechamento)
            throw new ArgumentException("A hora inicial da consulta deve estar dentro do horário de funcionamento (8:00h às 19:00h).");
        if (horaFim <= horaAbertura || horaFim > horaFechamento)
            throw new ArgumentException("A hora final da consulta deve estar dentro do horário de funcionamento (8:00h às 19:00h).");
        DateTime dataHoraConsulta = data.Date + horaIni;
        if (dataHoraConsulta <= DateTime.Now)
            throw new ArgumentException("A consulta deve ser marcada para um período futuro.");
        CPF = cpf;
        DataConsulta = data;
        HoraInicial = horaIni;
        HoraFinal = horaFim;
    }

}