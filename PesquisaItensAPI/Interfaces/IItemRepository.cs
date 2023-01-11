using Microsoft.AspNetCore.Mvc;
using PesquisaItensAPI.DTO;
using PesquisaItensAPI.Models;

namespace PesquisaItensAPI.Interfaces
{
    public interface IItemRepository
    {
        public Task<Item> Create(ItemDTO itemDTO);

        public Task<IEnumerable<Item>> Get();

        public Task<Item> Get(Guid id);

        public Task<Item> Update([FromBody] ItemDTO itemDTO, Guid id);

        public Task<bool> Delete(Guid id);

    }
}
