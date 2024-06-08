namespace Consultorio;

using System;
using System.Collections.Generic;

public class CadastroPacientes
{
    private List<Paciente> pacientes = new List<Paciente>();

    public void AdicionarPaciente(Paciente paciente)
    {
        if (!PacienteExiste(paciente.CPF))
        {
            pacientes.Add(paciente);
            Console.WriteLine("Paciente cadastrado com sucesso!");
        }
        else
        {
            throw new ArgumentException("Já existe um paciente com este CPF.");
        }
    }

    private bool PacienteExiste(string cpf)
    {
        foreach (var paciente in pacientes)
        {
            if (paciente.CPF == cpf)
            {
                return true;
            }
        }
        return false;
    }
    public void ExcluirPaciente(string cpf)
    {
        Paciente paciente = pacientes.FirstOrDefault(p => p.CPF == cpf);
        if (paciente != null)
        {
            pacientes.Remove(paciente);
        }
        else
        {
            throw new ArgumentException("Paciente não encontrado.");
        }
    }

    public List<Paciente> ObterPacientesOrdenadosPorCPF()
    {
        return pacientes.OrderBy(p => p.CPF).ToList();
    }

    public List<Paciente> ObterPacientesOrdenadosPorNome()
    {
        return pacientes.OrderBy(p => p.Nome).ToList();
    }
}