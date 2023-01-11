using System.Text.Json.Serialization;

namespace PesquisaItensAPI.Models
{
    public class Item
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public string Tipo { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        [JsonIgnore]
        public ICollection<ItemPesquisa> ItemPesquisas { get; private set; }

        public Item(string descricao, string tipo, string modelo, string marca)
        {
            Id = new Guid();
            Descricao = descricao;
            Tipo = tipo;
            Modelo = modelo;
            Marca = marca;
        }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void SetTipo(string tipo)
        {
            Tipo = tipo;
        }

        public void SetModelo(string modelo)
        {
            Modelo = modelo;
        }

        public void SetMarca(string marca)
        {
            Marca = marca;
        }
    }
}
