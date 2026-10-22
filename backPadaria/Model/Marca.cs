using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Marca
    {
        private int id;
        private string nome;
        private string telefone;

        public Marca(string nome, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome da marca não pode ser vazio");

            this.nome = nome;
            this.telefone = telefone;
        }

        public Marca(int id, string nome, string telefone)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
        }

        // Gambiarra para testar

        public Marca(int id)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }


        public static int Inserir(Marca marca)
        {
            //Instrução SQL: Define o comando de inserção (INSERT).
            // O uso de marcações com '@' (ex: @Nome) é uma prática de segurança crucial chamada de "Parametricação".
            // Ela impede ataques de SQL Injection , pois o banco entende o que é comando e o que é apenas texto do usuário.
            string sql = "INSERT INTO `Marca` (Nome, Telefone) VALUES (@Nome, @Telefone)";

            // Gerenciamento de recursos: Cria o objeto de comando já passando a instrução SQL.
            // O 'using' garante que os recursos de memória ocupados pelo comando sejam liberados ao final do bloco.
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                cmd.Parameters.AddWithValue("@Telefone", marca.Telefone);
               


                // Execução: Como o comando de INSERT não retorna tabelas (apenas executa uma ação),
                // ele envia o comando configurado para o método genérico 'executarComando' da classe 'Banco'.
                // O método retorna 1 (se o usuário for inserido com sucesso) ou -1 (se houver erro no banco).

                return Banco.executarComando(cmd);
            }
        }

        public static int Deletar(Marca marca)
        {
            string sql = "DELETE FROM `Marca` WHERE `Id` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", marca.id);

                return Banco.executarComando(cmd);
            }
        }

        public static List<Marca> ListarTodos()

        {
            string sql = "SELECT * FROM `Marca`";

            List<Marca> listaMarca = new();

            using (var cmd = new MySqlCommand(sql))
            {
                // Executa a leitura. O bloco 'using' aqui é FUNDAMENTAL para garantir que o 
                // reader seja fechado no final, o que por sua vez fecha a conexão com o bloco.
                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                {
                    // O while vai rodar uma vez para CADA linha que existir na tabela Cliente
                    while (reader.Read())
                    {

                        // Extrair os dados da linha atual
                        int id = reader.GetInt32("Id");
                        string nome = validarCampo(reader["Nome"]);
                        string telefone = validarCampo(reader["Telefone"]);
                       


                        // Criar o objeto Marca com os dados extraídos
                        Marca marca = new Marca(id, nome, telefone);


                        // Adiciona este cliente á nossa lista
                        listaMarca.Add(marca);
                    }
                }
                // Retorna a lista completa (se a tabela estiver vazia, retorna uma lista com 0 itens)
                return listaMarca;
            }
        }

        public static Marca? ListarPorId(int id)

        {
            string sql = "SELECT * FROM `Marca` WHERE `id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);

                Marca? marca = null;

                while (reader.Read())
                {
                    // Extrair os dados da linha atual
                    int idBanco = reader.GetInt32("Id");
                    string nome = validarCampo(reader["Nome"]);
                    string telefone = validarCampo(reader["Telefone"]);

                    // Criar o objeto Cliente com os dados extraídos
                    marca = new Marca (idBanco, nome, telefone);
                }

                return marca;
            }
        }

        public static int Atualizar(Marca marca)
        {
            string sql = @"UPDATE Marca SET Nome = @Nome, Telefone = @Telefone, WHERE Id = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                //Vinculação de parâmetros; Protege contra SQL Injection e organiza os dados
                cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                cmd.Parameters.AddWithValue("@Telefone", marca.Telefone);


                //A chave de busca: Quem será atualizado?
                cmd.Parameters.AddWithValue("@Id", marca.id);

                //Execução: O UPDATE também é uma instrução de ação (como INSERT e DELETE).
                //Ele vai retornar 1 (se encontrou o ID e atualizou com sucesso) ou 0 (se o ID não existia).
                return Banco.executarComando(cmd);
            }
        }

        private static string validarCampo(object campo)
        {
            if (campo == DBNull.Value || campo == null)
            {
                return "";
            }
            else
            {
                return campo.ToString();
            }
        }
    }
}
        











    

