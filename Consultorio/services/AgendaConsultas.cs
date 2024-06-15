namespace Consultorio.services;
using Consultorio.model;
using System.Collections.Generic;
using System.Linq;

public class AgendaConsultas
{
	private List<Consulta> consultas = new List<Consulta>();
	private CadastroPacientes cadastro;

	public AgendaConsultas(CadastroPacientes cadastro)
	{
		this.cadastro = cadastro;
	}
    public void AgendarConsulta(Consulta consulta)
    {
        if (!cadastro.ObterPacientesOrdenadosPorCPF().Any(p => p.CPF == consulta.CPF))
            throw new ArgumentException("CPF não encontrado no cadastro de pacientes.");

        if (consultas.Any(c => c.CPF == consulta.CPF && c.DataConsulta >= DateTime.Now))
            throw new ArgumentException("O paciente já possui um agendamento futuro.");

        consultas.Add(consulta);
    }

    public void ExcluirConsulta(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
    {
        var consulta = consultas.FirstOrDefault(c => c.CPF == cpf && c.DataConsulta == dataConsulta && c.HoraInicial == horaInicial);

        if (consulta == null)
            throw new ArgumentException("Consulta não encontrada.");

        if (dataConsulta < DateTime.Now.Date || (dataConsulta == DateTime.Now.Date && horaInicial <= DateTime.Now.TimeOfDay))
            throw new ArgumentException("O cancelamento só pode ser realizado para agendamentos futuros.");

        consultas.Remove(consulta);
    }


    public List<Consulta> ListarConsultasFuturas(string cpf)
	{
		return consultas.Where(c => c.CPF == cpf && c.DataConsulta > DateTime.Now).ToList();
	}
}