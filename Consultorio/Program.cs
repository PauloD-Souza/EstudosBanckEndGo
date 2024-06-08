namespace Consultorio;

using System;
public class Program
{
    public static void Main(string[] args)
    {
        CadastroPacientes cadastro = new CadastroPacientes();
        AgendaConsultas agenda = new AgendaConsultas(cadastro);

        while (true)
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1 - Cadastro de pacientes");
            Console.WriteLine("2 - Agenda");
            Console.WriteLine("3 - Fim");
            Console.Write("Escolha uma opção: ");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    MostrarMenuCadastroPaciente(cadastro);
                    break;
                case "2":
                    GerenciarAgenda(agenda, cadastro);
                    break;
                case "3":
                    Console.WriteLine("Fim do programa.");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void MostrarMenuCadastroPaciente(CadastroPacientes cadastro)
    {
        while (true)
        {
            Console.WriteLine("Menu do Cadastro de Pacientes");
            Console.WriteLine("1 - Cadastrar novo paciente");
            Console.WriteLine("2 - Excluir paciente");
            Console.WriteLine("3 - Listar pacientes (ordenado por CPF)");
            Console.WriteLine("4 - Listar pacientes (ordenado por nome)");
            Console.WriteLine("5 - Voltar para o menu principal");
            Console.Write("Escolha uma opção: ");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    CadastrarPaciente(cadastro);
                    break;
                case "2":
                    ExcluirPaciente(cadastro);
                    break;
                case "3":
                    ListarPacientesPorCPF(cadastro);
                    break;
                case "4":
                    ListarPacientesPorNome(cadastro);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
    private static void CadastrarPaciente(CadastroPacientes cadastro)
    {
        while (true)
        {
            try
            {
                Console.Write("Digite o CPF do paciente: ");
                string cpf = Console.ReadLine();

                Console.Write("Digite o nome do paciente: ");
                string nome = Console.ReadLine();

                Console.Write("Digite a data de nascimento do paciente (DDMMAAAA): ");
                string dataNascimento = Console.ReadLine();

                Paciente paciente = new Paciente(cpf, nome, dataNascimento);
                cadastro.AdicionarPaciente(paciente);

                Console.Write("Deseja cadastrar outro paciente? (s/n): ");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() != "s")
                {
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }

    private static void ExcluirPaciente(CadastroPacientes cadastro)
    {
        Console.Write("Digite o CPF do paciente a ser excluído: ");
        string cpf = Console.ReadLine();

        try
        {
            cadastro.ExcluirPaciente(cpf);
            Console.WriteLine("Paciente excluído com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    private static void ListarPacientesPorCPF(CadastroPacientes cadastro)
    {
        List<Paciente> pacientes = cadastro.ObterPacientesOrdenadosPorCPF();
        Console.WriteLine("Pacientes ordenados por CPF:");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine(paciente.ToString());
        }
    }

    private static void ListarPacientesPorNome(CadastroPacientes cadastro)
    {
        List<Paciente> pacientes = cadastro.ObterPacientesOrdenadosPorNome();
        Console.WriteLine("Pacientes ordenados por nome:");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine(paciente.ToString());
        }
    }
    private static void GerenciarAgenda(AgendaConsultas agenda, CadastroPacientes cadastro)
    {
        while (true)
        {
            Console.WriteLine("Menu da Agenda");
            Console.WriteLine("1 - Agendar nova consulta");
            Console.WriteLine("2 - Cancelar consulta");
            Console.WriteLine("3 - Listar consultas futuras");
            Console.WriteLine("4 - Voltar ao menu principal");
            Console.Write("Escolha uma opção: ");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    AgendarConsulta(agenda, cadastro);
                    break;
                case "2":
                    CancelarConsulta(agenda);
                    break;
                case "3":
                    ListarConsultasFuturas(agenda);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void AgendarConsulta(AgendaConsultas agenda, CadastroPacientes cadastro)
    {
        try
        {
            Console.Write("Digite o CPF do paciente: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite a data da consulta (DDMMAAAA): ");
            string dataConsulta = Console.ReadLine();

            Console.Write("Digite a hora inicial da consulta (HHMM): ");
            string horaInicial = Console.ReadLine();

            Console.Write("Digite a hora final da consulta (HHMM): ");
            string horaFinal = Console.ReadLine();

            Consulta consulta = new Consulta(cpf, dataConsulta, horaInicial, horaFinal);
            agenda.AgendarConsulta(consulta);

            Console.WriteLine("Consulta agendada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    private static void CancelarConsulta(AgendaConsultas agenda)
    {
        try
        {
            Console.Write("Digite o CPF do paciente: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite a data da consulta (DDMMAAAA): ");
            string dataConsulta = Console.ReadLine();

            if (DateTime.TryParseExact(dataConsulta, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out var data))
            {
                agenda.ExcluirConsulta(cpf, data);
                Console.WriteLine("Consulta cancelada com sucesso!");
            }
            else
            {
                Console.WriteLine("Data da consulta inválida.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    private static void ListarConsultasFuturas(AgendaConsultas agenda)
    {
        Console.Write("Digite o CPF do paciente: ");
        string cpf = Console.ReadLine();

        var consultas = agenda.ListarConsultasFuturas(cpf);
        if (consultas.Any())
        {
            Console.WriteLine("Consultas futuras:");
            foreach (var consulta in consultas)
            {
                Console.WriteLine($"Data: {consulta.DataConsulta:dd/MM/yyyy}, Hora Inicial: {consulta.HoraInicial}, Hora Final: {consulta.HoraFinal}");
            }
        }
        else
        {
            Console.WriteLine("Nenhuma consulta futura encontrada.");
        }
    }
}
