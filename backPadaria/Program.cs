using backPadaria.Model;
using backPadaria.Services;

namespace backPadaria
{
    internal class Program
    {
        private static int resultado;

        static void Main(string[] args)
        {

            //    //Console.WriteLine("Digite o nome do cliente: ");
            //    string nomeCliente = Console.ReadLine();

            //    Console.WriteLine("Digite o endereço do cliente: ");
            //    string enderecoCliente = Console.ReadLine();

            //    Console.WriteLine("Digite o cpf do cliente: ");
            //    string cpfCliente = Console.ReadLine();

            //    Console.WriteLine("Digite o telefone do cliente: ");
            //    string telefoneCliente = Console.ReadLine();

            //    Console.WriteLine("Digite a quantidade de pontos");
            //    int pontosCliente = int.Parse(Console.ReadLine());




            //    //REFATORAÇÃO ///
            //    Cliente cliente1 = new Cliente(
            //        nome: nomeCliente,
            //        cpf: cpfCliente,
            //        telefone: telefoneCliente,
            //        endereco: enderecoCliente,
            //        pontos: pontosCliente
            //     );


            //Cliente clienteParaDeletar = new Cliente(4);

            //if (Cliente.Deletar(clienteParaDeletar) >= 1)
            //{
            //    Console.WriteLine("Cliente excluído com sucesso. Graças a Deus");
            //}
            //else
            //{
            //    Console.WriteLine("Deu bom não. Cliente presente!");
            //}

            //List<Cliente> clientes = Cliente.ListarTodos();

            //foreach(Cliente cliente in clientes)
            //{
            //    Console.WriteLine("-------------------");

            //    Console.WriteLine($"ID {cliente.Id}");
            //    Console.WriteLine($"Nome {cliente.Nome}");
            //    Console.WriteLine($"CPF {cliente.Cpf}");
            //    Console.WriteLine($"Telefone {cliente.Telefone}");
            //    Console.WriteLine($"Endereco {cliente.Endereco}");
            //    Console.WriteLine($"Pontos {cliente.Pontos}");

            //    Console.WriteLine("-------------------");

            //}


            //Cliente cli01 = Cliente.listarPorId(4);

            //if (cli01 != null)
            //{
            //    Console.WriteLine("-------------------");


            //    Console.WriteLine($"ID {cli01.Id}");
            //    Console.WriteLine($"Nome {cli01.Nome}");
            //    Console.WriteLine($"CPF {cli01.Cpf}");
            //    Console.WriteLine($"Telefone {cli01.Telefone}");
            //    Console.WriteLine($"Endereco {cli01.Endereco}");
            //    Console.WriteLine($"Pontos {cli01.Pontos}");

            //    Console.WriteLine("-------------------");

            //}
            //else
            //{
            //    Console.WriteLine("O cliente não foi encontrado!!");
            //}



            //ClienteService.MenuCliente();



            //Cliente? meuCliente = Cliente.listarPorId(4);

            //if(meuCliente != null)
            //{
            //    meuCliente.Endereco = "Rua Barão de Alagoas, 171";
            //    meuCliente.Telefone = "1194320-1840";

            //    int resultado = Cliente.Atualizar(meuCliente);

            //    if (resultado > 0)
            //    {
            //        Console.WriteLine("Cliente atualizado com sucesso");
            //    }




            //// REFATORAÇÃO //
            //Funcionario funcionario = new Funcionario(
            //    nome: "Agatha",
            //    cpf: "847.293.615-70",
            //    cargo: "Gerente"
            //);

            //int resultadoFuncionario = Funcionario.Inserir(funcionario);

            //if (resultadoFuncionario > 0)
            //{
            //    Console.WriteLine("Funcionário cadastrado com sucesso!");
            //}

            //Console.WriteLine("-------------------");

            //// Listar Todos os Funcionários //
            //List<Funcionario> funcionarios = Funcionario.ListarTodos();

            //    foreach (Funcionario funcionarioLista in funcionarios)
            //    {
            //        Console.WriteLine("-------------------");

            //        Console.WriteLine($"ID: {funcionarioLista.Id}");
            //        Console.WriteLine($"Nome: {funcionarioLista.Nome}");
            //        Console.WriteLine($"CPF: {funcionarioLista.Cpf}");
            //        Console.WriteLine($"Cargo: {funcionarioLista.Cargo}");

            //        Console.WriteLine("-------------------");
            //    }

            //Console.WriteLine("-------------------");


            //// Buscar por ID //
            //Funcionario? func = Funcionario.ListarPorId(21);

            //    if (func != null)
            //    {
            //        Console.WriteLine($"ID: {func.Id}");
            //        Console.WriteLine($"Nome: {func.Nome}");
            //        Console.WriteLine($"CPF: {func.Cpf}");
            //        Console.WriteLine($"Cargo: {func.Cargo}");

            //    }
            //    else
            //    {
            //        Console.WriteLine("Funcionario não encontrado!");
            //    } 

            //Console.WriteLine("-------------------");


            //// Atualizar //
            //func = Funcionario.ListarPorId(1);

            //    if (func != null)
            //    {
            //        func.Cargo = "Supervisor";

            //        int resultadoAtualizacao = Funcionario.Atualizar(func);

            //        if (resultado > 0)
            //        {
            //            Console.WriteLine("Funcionario atualizado com sucesso!");
            //        }
            //    }

            //Console.WriteLine("-------------------");



            //// Deletar//
            //Funcionario funcionarioParaExcluir = new Funcionario(21);



            //    if (Funcionario.Deletar(funcionarioParaExcluir) > 0)
            //    {
            //        Console.WriteLine("Funcionario excluído com sucesso!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Funcionario não encontrado!");
            //    }


            //Console.WriteLine("-------------------");








            // // REFATORAÇÃO //
            //if (resultado > 0)
            //     {
            //         Console.WriteLine("Marca cadastrada com sucesso!");
            //     }

            // Console.WriteLine("-------------------");

            // // Listar Todas as Marcas //
            // List<Marca> marcas = Marca.ListarTodos();

            //     foreach (Marca marcaLista in marcas)
            //     {
            //         Console.WriteLine("-------------------");

            //         Console.WriteLine($"ID: {marcaLista.Id}");
            //         Console.WriteLine($"Nome: {marcaLista.Nome}");

            //         Console.WriteLine($"Telefone: {marcaLista.Telefone}");


            //         Console.WriteLine("-------------------");
            //     }

            // Console.WriteLine("-------------------");

            // // Buscar por ID //
            // Marca? marc = Marca.ListarPorId(10);

            //     if (marc != null)
            //     {
            //         Console.WriteLine($"ID: {marc.Id}");
            //         Console.WriteLine($"Nome: {marc.Nome}");
            //         Console.WriteLine($"Telefone: {marc.Telefone}");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Marca não encontrada!");
            //     }

            // Console.WriteLine("-------------------");

            // // Atualizar //
            // marc = Marca.ListarPorId(10);

            //     if (marc != null)
            //     {
            //         marc.Nome = "Nestle";

            //         int resultadoAtualizacao = Marca.Atualizar(marc);

            //     if (resultadoAtualizacao > 0)
            //     {
            //         Console.WriteLine("Marca atualizada com sucesso!");
            //     }
            //   }

            // Console.WriteLine("-------------------");

            // // Deletar//
            // Marca marcaParaExcluir = new Marca(10);

            // if (Marca.Deletar(marcaParaExcluir) > 0)
            // {
            //     Console.WriteLine("Marca excluída com sucesso!");
            // }
            // else
            // {
            //     Console.WriteLine("Marca não encontrada!");
            // }

            LoginFuncionario login = new LoginFuncionario(2, "jp_padoca@padariapaoecia.com.br", "deumaoito", "Diretor");

            LoginFuncionario.Inserir(login);

            LoginService.FazerLoginMenu();
        }
    }
 }