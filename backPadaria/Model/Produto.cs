using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Produto
    {
        private int id;
        private string nome;
        private decimal preco;
        private string categoria;
        private bool fabricado;
        private int marcaId;


        public Produto(string nome, decimal preco, string categoria, bool fabricado, int marcaId)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome do produto não pode ser vazio");

            this.nome = nome;
            this.preco = preco;
            this.categoria = categoria;
            this.fabricado = fabricado;
            this.marcaId = marcaId;
        }

        public Produto(int id, string nome, decimal preco, string categoria, bool fabricado, int marcaId)
        {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
            this.categoria = categoria;
            this.fabricado = fabricado;
            this.marcaId = marcaId;
        }


        // Gambiarra para testar

        public Produto(int id)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public decimal Preco { get => preco; set => preco = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public bool Fabricado { get => fabricado; set => fabricado = value; }
        public int MarcaId { get => marcaId; set => marcaId = value; }


        public static int Inserir(Produto produto)
        {
            //Instrução SQL: Define o comando de inserção (INSERT).
            // O uso de marcações com '@' (ex: @Nome) é uma prática de segurança crucial chamada de "Parametricação".
            // Ela impede ataques de SQL Injection , pois o banco entende o que é comando e o que é apenas texto do usuário.
            string sql = "INSERT INTO `Produto` (Nome, Preco, Categoria, Fabricado, MarcaId) VALUES (@Nome, @Preco, @Categoria, @Fabricado, @MarcaId)";


            // Gerenciamento de recursos: Cria o objeto de comando já passando a instrução SQL.
            // O 'using' garante que os recursos de memória ocupados pelo comando sejam liberados ao final do bloco.
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                cmd.Parameters.AddWithValue("@Categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@Fabricado", produto.Fabricado);
                cmd.Parameters.AddWithValue("@MarcaId", produto.MarcaId);
         

                // Execução: Como o comando de INSERT não retorna tabelas (apenas executa uma ação),
                // ele envia o comando configurado para o método genérico 'executarComando' da classe 'Banco'.
                // O método retorna 1 (se o usuário for inserido com sucesso) ou -1 (se houver erro no banco).

                return Banco.executarComando(cmd);
            }
        }

        public static int Deletar(Produto produto)
        {
            string sql = "DELETE FROM `Produto` WHERE `Id` = @id";

            using (var cmd = new MySqlCommand(sql)) 
            {
                cmd.Parameters.AddWithValue("@id", produto.id);

                return Banco.executarComando(cmd);
            }
        }

        public static List<Produto> ListarTodos()
        {
            string sql = "SELECT * FROM `Produto`";

            List<Produto> listaProduto = new();

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
                        decimal preco = reader.GetDecimal("Preco");
                        string categoria = validarCampo(reader["Categoria"]);
                        bool fabricado = reader.GetBoolean("Fabricado");
                        int marcaId = reader.GetInt32("MarcaId");


                        // Criar o objeto Produto com os dados extraídos
                        Produto produto = new Produto(id, nome, preco, categoria, fabricado, marcaId);

                        // Adiciona este produto á nossa lista
                        listaProduto.Add(produto);
                    }
                }
                // Retorna a lista completa (se a tabela estiver vazia, retorna uma lista com 0 itens)
                return listaProduto;
            }
        }

        public static Produto? ListarPorId(int id)
        {
            string sql = "SELECT * from `Produto` WHERE `id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);

                Produto? produto = null;

                while (reader.Read())
                {
                    // Extrair os dados da linha atual
                    int idBanco = reader.GetInt32("Id");
                    string nome = validarCampo(reader["Nome"]);
                    decimal preco = reader.GetDecimal("Preco");
                    string categoria = validarCampo(reader["Categoria"]);
                    bool fabricado = reader.GetBoolean("Fabricado");
                    int marcaId = reader.GetInt32("MarcaId");

                    // Criar o objeto Cliente com os dados extraídos
                    produto = new Produto(idBanco, nome, preco, categoria, fabricado, marcaId);
                }
                return produto;
            }
        }

        public static int Atualizar(Produto produto)
        {
            string sql = @"UPDATE Produto SET Nome = @Nome, Preco = @Preco, Categoria = @Categoria, Fabricado = @Fabricado, MarcaId = @MarcaId WHERE Id = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                //Vinculação de parâmetros; Protege contra SQL Injection e organiza os dados
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                cmd.Parameters.AddWithValue("@Categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@Fabricado", produto.Fabricado);
                cmd.Parameters.AddWithValue("@MarcaId", produto.MarcaId);

                //A chave de busca: Quem será atualizado?
                cmd.Parameters.AddWithValue("@Id", produto.Id);

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

