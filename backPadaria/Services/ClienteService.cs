using backPadaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Services
{
    public static class ClienteService
    {
        public static void MenuCliente()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("===== GESTÃO DE CLIENTES =====");

                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar Todos os Clientes");
                Console.WriteLine("3 - Buscar Cliente por ID");
                Console.WriteLine("4 - Atualizar Cliente");
                Console.WriteLine("5 - Excluir Cliente");
                Console.WriteLine("6 - Visualizar pontuação");
                Console.WriteLine("0 - Sair do Programa");

                Console.WriteLine("==================");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();

                Console.Clear();


                try
                {
                    switch (opcao)
                    {
                        case "1": // Cadastrar Cliente
                       

                            Console.WriteLine("------ CADASTRAR CLIENTES ------");

                            Console.WriteLine("Digite o nome do cliente: ");
                            string nomeCliente = Console.ReadLine();

                            Console.WriteLine("Digite o endereço do cliente: ");
                            string enderecoCliente = Console.ReadLine();

                            Console.WriteLine("Digite o cpf do cliente: ");
                            string cpfCliente = Console.ReadLine();

                            Console.WriteLine("Digite o telefone do cliente: ");
                            string telefoneCliente = Console.ReadLine();

                            Console.WriteLine("Digite a quantidade de pontos");
                            int pontosCliente = int.Parse(Console.ReadLine());


                            Cliente NovoCliente = new Cliente(
                                nome: nomeCliente,
                                cpf: cpfCliente,
                                telefone: telefoneCliente,
                                endereco: enderecoCliente,
                                pontos: pontosCliente
                            );

                            int resultadoInsert = Cliente.Inserir(NovoCliente);

                            Console.Clear();

                            if (resultadoInsert > 0) Console.WriteLine("Cliente cadastrado com sucesso!!");

                            break;



                        case "2": // Listar Todos os Clientes

                            List<Cliente> lista = Cliente.ListarTodos();

                            if (lista.Count == 0)
                            {
                                Console.WriteLine("Nenhum cliente cadastrado.");
                            }
                            else
                            {
                                foreach (Cliente cliente in lista)
                                {
                                    Console.WriteLine(
                                        $"ID: {cliente.Id} | Nome: {cliente.Nome} | CPF: {cliente.Cpf} | Pontos: {cliente.Pontos}"
                                    );
                                }
                            }
                            break;



                        case "3": // Buscar Cliente por ID
                            Console.WriteLine("Digite o ID: ");
                            int idBuscar = int.Parse(Console.ReadLine());

                            Cliente clienteBuscar = Cliente.listarPorId(idBuscar);

                           

                            if (clienteBuscar != null)
                            {
                                Console.WriteLine($"Nome: {clienteBuscar.Nome}");
                                Console.WriteLine($"CPF: {clienteBuscar.Cpf}");
                                Console.WriteLine($"Telefone: {clienteBuscar.Telefone}");
                                Console.WriteLine($"Endereço: {clienteBuscar.Endereco}");
                                Console.WriteLine($"Pontos: {clienteBuscar.Pontos}");
                            }
                            else
                            {
                                Console.WriteLine("Cliente não encontrado.");
                            }
                            break;



                        case "4": // Atualizar Cliente
                            Console.Write("Digite o ID do cliente: ");
                            int idAtualizar = int.Parse(Console.ReadLine());

                            Console.Write("Novo nome: ");
                            string novoNome = Console.ReadLine();

                            Console.Write("Novo endereço: ");
                            string novoEndereco = Console.ReadLine();

                            Console.Write("Novo telefone: ");
                            string novoTelefone = Console.ReadLine();

                            Cliente clienteAtualizado = new Cliente(
                                id: idAtualizar,
                                nome: novoNome,
                                cpf: "",
                                telefone: novoTelefone,
                                endereco: novoEndereco,
                                pontos: 0
                            );

                            Cliente.Atualizar(clienteAtualizado);

                            Console.WriteLine("Cliente atualizado com sucesso.");
                            break;



                        case "5": // Excluir Cliente
                            Console.Write("Digite o ID do cliente que deseja excluir: ");
                            int idExcluir = int.Parse(Console.ReadLine());

                            Cliente clienteExcluir = Cliente.BuscaPorId(idExcluir);

                            if (clienteExcluir != null)
                            {
                                int resultadoDelete = Cliente.Excluir(idExcluir);

                                if (resultadoDelete > 0)
                                {
                                    Console.WriteLine("Cliente excluído com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível excluir o cliente.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cliente não encontrado.");
                            }

                            break;


                        case "6": // Visualizar Pontuação
                            Console.Write("Digite o ID do cliente: ");
                            int idPontuacao = int.Parse(Console.ReadLine());

                            Cliente clientePontos = Cliente.BuscaPorId(idPontuacao);

                            if (clientePontos != null)
                            {
                                Console.WriteLine($"Cliente: {clientePontos.Nome}");
                                Console.WriteLine($"Pontuação: {clientePontos.Pontos}");
                            }
                            else
                            {
                                Console.WriteLine("Cliente não encontrado.");
                            }
                            break;



                        case "0":
                            sair = true;
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                } 
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");


                }
            }
        }
    }
}