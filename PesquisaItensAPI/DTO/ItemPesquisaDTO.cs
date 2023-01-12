namespace PesquisaItensAPI.DTO
{
    public class ItemPesquisaDTO
    {
        public string Local { get; set; }
        public DateTime DataPesquisa { get; set; }
        public string Link { get; set; }
        public double Preco { get; set; }
        public double PrecoPrazo { get; set; }
        public double PrecoFrete { get; set; }
        public Guid ItemId { get; set; }
    }
}
