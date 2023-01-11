using System.Text.Json.Serialization;

namespace PesquisaItensAPI.Models
{
    public class ItemPesquisa
    {
        public Guid Id { get; private set; }
        public string Local { get; private set; }
        public DateTime DataPesquisa { get; private set; }
        public string Link { get; private set; }
        public double Preco { get; private set; }
        public double PrecoPrazo { get; private set; }
        public double PrecoFrete { get; private set; }
        public Item Item { get; private set; }
        [JsonIgnore]
        public Guid ItemId { get; private set; }

        public ItemPesquisa(Guid itemId, string local, string link, double preco, double precoPrazo, double precoFrete, DateTime dataPesquisa)
        {
            Id = new Guid();
            ItemId = itemId;
            Local = local;
            Link = link;
            Preco = preco;
            PrecoPrazo = precoPrazo;
            PrecoFrete = precoFrete;
            DataPesquisa = dataPesquisa;
        }

        public ItemPesquisa(Guid itemId, string local, string link, double preco, double precoPrazo, double precoFrete)
        {
            Id = new Guid();
            ItemId = itemId;
            Local = local;
            Link = link;
            Preco = preco;
            PrecoPrazo = precoPrazo;
            PrecoFrete = precoFrete;
            DataPesquisa = DateTime.Now;
        }

        public void SetLocal(string local)
        {
            Local = local;
        }

        public void SetLink(string link)
        {
            Link = link;
        }

        public void SetPreco(double preco)
        {
            Preco = preco;
        }

        public void SetPrecoPrazo(double precoPrazo)
        {
            PrecoPrazo = precoPrazo;
        }

        public void SetPrecoFrete(double precoFrete)
        {
            PrecoFrete = precoFrete;
        }

        public void SetDataPesquisa(DateTime dataPesquisa)
        {
            DataPesquisa = DataPesquisa;
        }
    }
}
