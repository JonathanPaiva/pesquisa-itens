using PesquisaItensAPI.DTO;
using PesquisaItensAPI.Models;

namespace PesquisaItensAPI.Interfaces
{
    public interface IItemPesquisaRepository
    {
        public Task<ItemPesquisa> Create(ItemPesquisaDTO itemPesquisaDTO);

        public Task<IEnumerable<ItemPesquisa>> GetAll();

        public Task<ItemPesquisa> Get(Guid id);

        public Task<ItemPesquisa> Update(ItemPesquisaDTO itemPesquisaDTO, Guid id);

        public Task<bool> Delete(Guid id);
    }
}
