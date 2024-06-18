namespace Consultorio.services;
using Consultorio.model;
using System.Collections.Generic;
using System.Linq;

public class AgendaConsultas
{
	private readonly List<Consulta> consultas = new List<Consulta>();
	private CadastroPacientes cadastro;

	public AgendaConsultas(CadastroPacientes cadastro)
	{
		this.cadastro = cadastro;
	}
    public void AgendarConsulta(Consulta consulta)
    {
        ValidarConsulta(consulta);

        if (!cadastro.ObterPacientesOrdenadosPorCPF().Any(p => p.CPF == consulta.CPF))
            throw new ArgumentException("CPF n�o encontrado no cadastro de pacientes.");

        if (consultas.Any(c => c.CPF == consulta.CPF && c.DataConsulta >= DateTime.Now))
            throw new ArgumentException("O paciente j� possui um agendamento futuro.");

        consultas.Add(consulta);
    }

    public void ExcluirConsulta(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
    {
        var consulta = consultas.FirstOrDefault(c => c.CPF == cpf && c.DataConsulta == dataConsulta && c.HoraInicial == horaInicial);

        if (consulta == null)
            throw new ArgumentException("Consulta n�o encontrada.");

        if (dataConsulta < DateTime.Now.Date || (dataConsulta == DateTime.Now.Date && horaInicial <= DateTime.Now.TimeOfDay))
            throw new ArgumentException("O cancelamento s� pode ser realizado para agendamentos futuros.");

        consultas.Remove(consulta);
    }


    public List<Consulta> ListarConsultasFuturas(string cpf)
	{
		return consultas.Where(c => c.CPF == cpf && c.DataConsulta > DateTime.Now).ToList();
	}

    private void ValidarConsulta(Consulta consulta)
    {
        if (consulta.DataConsulta == default)
            throw new ArgumentException("Data da consulta inv�lida.");

        if (consulta.HoraInicial == default || consulta.HoraFinal == default)
            throw new ArgumentException("Horas de consulta inv�lidas.");

        if (consulta.HoraInicial.Minutes % 15 != 0 || consulta.HoraFinal.Minutes % 15 != 0)
            throw new ArgumentException("As horas inicial e final devem ser m�ltiplos de 15 minutos.");

        if (consulta.HoraFinal <= consulta.HoraInicial)
            throw new ArgumentException("Hora final deve ser maior que a hora inicial.");

        TimeSpan horaAbertura = new TimeSpan(8, 0, 0);
        TimeSpan horaFechamento = new TimeSpan(19, 0, 0);

        if (consulta.HoraInicial < horaAbertura || consulta.HoraInicial >= horaFechamento)
            throw new ArgumentException("A hora inicial da consulta deve estar dentro do hor�rio de funcionamento (8:00h �s 19:00h).");

        if (consulta.HoraFinal <= horaAbertura || consulta.HoraFinal > horaFechamento)
            throw new ArgumentException("A hora final da consulta deve estar dentro do hor�rio de funcionamento (8:00h �s 19:00h).");

        DateTime dataHoraConsulta = consulta.DataConsulta.Date + consulta.HoraInicial;

        if (dataHoraConsulta <= DateTime.Now)
            throw new ArgumentException("A consulta deve ser marcada para um per�odo futuro.");
    }
}