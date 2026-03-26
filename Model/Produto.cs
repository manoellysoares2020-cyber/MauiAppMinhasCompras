using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiAppMinhasCompras.Model // classe de modelo, representa a estrutura do produto no banco de dados SQLite
{
    public class Produto 
    {
        string _descricao; // campo privado para a descrição do produto

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // identificador do produto
        public string Categoria { get; set; } // categoria do produto
        public string Descricao { get; set;
           /* get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                }
            }*/
        } 
        public double Quantidade { get; set; } // quantidade do produto
        public double Preco { get; set; } // preço do produto
        public double Total { get => Quantidade * Preco;  } // total do produto, calculado a partir da quantidade e do preço
    }
}
