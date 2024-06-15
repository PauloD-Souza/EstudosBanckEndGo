using Consultorio.model;
using Consultorio.services;
using static Consultorio.ConsultorioUtils;

namespace Consultorio
{
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
    }
}
