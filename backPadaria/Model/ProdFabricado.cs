using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class ProdFabricado : Produto
    {
        private int produtoId;
        private string descricaoProducao;
        
        public ProdFabricado(int produtoId,string nome,decimal preco, string categoria,bool fabricado,int marcaId, string descricaoProducao) : base (nome, preco, categoria, fabricado, marcaId) 
        {
            this.produtoId = produtoId;
            this.descricaoProducao = descricaoProducao;
        }

        public int ProdutoId
        {
            get => produtoId;
            set => produtoId = value;
        }

        public string DescricaoProducao
        {
            get => descricaoProducao;
            set => descricaoProducao = value;
        }
     }
 }


