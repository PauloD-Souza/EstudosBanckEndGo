namespace Consultorio;

using System;
public class Program
{
    public static void Main(string[] args)
    {
        CadastroPacientes cadastro = new CadastroPacientes();

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
                    Console.WriteLine("Funcionalidade da agenda ainda não implementada.");
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
}
