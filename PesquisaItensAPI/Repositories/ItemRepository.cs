using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesquisaItensAPI.Data;
using PesquisaItensAPI.DTO;
using PesquisaItensAPI.Interfaces;
using PesquisaItensAPI.Models;

namespace PesquisaItensAPI.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<Item> Create(ItemDTO itemDTO)
        {
            Item itemNovo = new Item(
                itemDTO.Descricao,
                itemDTO.Tipo,
                itemDTO.Modelo,
                itemDTO.Marca
                );

            _context.Itens.AddAsync(itemNovo);
            await _context.SaveChangesAsync();

            return itemNovo;
        }

        public async Task<IEnumerable<Item>> Get()
        {
            IList<Item> itens = await _context.Itens.ToListAsync();

            return itens;   
        }

        public async Task<Item> Get(Guid id)
        {
            Item item = await _context.Itens.FirstOrDefaultAsync(i => i.Id == id);

            return item;
        }

        public async Task<Item> Update([FromBody] ItemDTO itemDTO, Guid id)
        {
            Item itemDb = await Get(id);

            if (itemDb == null)
            {
                return itemDb;
            }

            itemDb.SetDescricao(itemDTO.Descricao);
            itemDb.SetTipo(itemDTO.Tipo);
            itemDb.SetModelo(itemDTO.Modelo);
            itemDb.SetMarca(itemDTO.Marca);

            await _context.SaveChangesAsync();

            return itemDb;
        }

        public async Task<bool> Delete(Guid id)
        {
            Item item = await Get(id);

            if (item == null)
            {
                return false;
            }

            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
