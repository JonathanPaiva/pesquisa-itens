using Microsoft.EntityFrameworkCore;
using PesquisaItensAPI.Data;
using PesquisaItensAPI.DTO;
using PesquisaItensAPI.Interfaces;
using PesquisaItensAPI.Models;

namespace PesquisaItensAPI.Repositories
{
    public class ItemPesquisaRepository : IItemPesquisaRepository
    {
        private readonly ApplicationDbContext _context;
        private ItemRepository itemRepository;

        public ItemPesquisaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemPesquisa> Create(ItemPesquisaDTO itemPesquisaDTO)
        {
            itemRepository = new ItemRepository(_context);

            Item item = await itemRepository.Get(itemPesquisaDTO.ItemId);

            ItemPesquisa novoItemPesquisa = null;

            if (item == null)
            {
                return novoItemPesquisa;
            }

            novoItemPesquisa = new ItemPesquisa(
                    itemPesquisaDTO.ItemId,
                    itemPesquisaDTO.Local,
                    itemPesquisaDTO.Link,
                    itemPesquisaDTO.Preco,
                    itemPesquisaDTO.PrecoPrazo,
                    itemPesquisaDTO.PrecoFrete,
                    itemPesquisaDTO.DataPesquisa
                    );

            _context.ItemPesquisas.AddAsync(novoItemPesquisa);
            await _context.SaveChangesAsync();

            return novoItemPesquisa;
        }

        public async Task<IEnumerable<ItemPesquisa>> GetAll()
        {
            IEnumerable<ItemPesquisa> itemPesquisas = await _context.ItemPesquisas.Include(item => item.Item).ToListAsync();

            return itemPesquisas;
        }
        public async Task<ItemPesquisa> Get(Guid id)
        {
            ItemPesquisa itemPesquisa = await _context.ItemPesquisas
                                            .Include(item => item.Item)
                                            .Where(itemPesquisaDb => itemPesquisaDb.Id == id)
                                            .FirstOrDefaultAsync();

            return itemPesquisa;
        }

        public async Task<ItemPesquisa> Update(ItemPesquisaDTO itemPesquisaDTO, Guid id)
        {
            ItemPesquisa itemPesquisaDb = await Get(id);

            if (itemPesquisaDb == null)
            {
                return itemPesquisaDb;
            }

            itemPesquisaDb.SetLocal(itemPesquisaDTO.Local);
            itemPesquisaDb.SetLink(itemPesquisaDTO.Link);
            itemPesquisaDb.SetPreco(itemPesquisaDTO.Preco);
            itemPesquisaDb.SetPrecoPrazo(itemPesquisaDTO.PrecoPrazo);
            itemPesquisaDb.SetPrecoFrete(itemPesquisaDTO.PrecoFrete);
            itemPesquisaDb.SetDataPesquisa(itemPesquisaDTO.DataPesquisa);

            await _context.SaveChangesAsync();

            return itemPesquisaDb;
        }

        public async Task<bool> Delete(Guid id)
        {
            ItemPesquisa itemPesquisa = await Get(id);

            if (itemPesquisa == null)
            {
                return false;
            }

            _context.ItemPesquisas.Remove(itemPesquisa);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
