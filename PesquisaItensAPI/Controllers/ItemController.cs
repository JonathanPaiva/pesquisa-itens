using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesquisaItensAPI.DTO;
using PesquisaItensAPI.Interfaces;
using PesquisaItensAPI.Models;
using System.Diagnostics;

namespace PesquisaItensAPI.Controllers
{
    [Route("itens")]
    [ApiController]
    public class ItemController: ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Item>> Create([FromBody] ItemDTO itemDTO)
        {
            Item itemNovo = await _itemRepository.Create(itemDTO);

            if (itemNovo == null)
            {
                return BadRequest();
            }

            return new CreatedResult($"itens/{itemNovo.Id}", itemNovo);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            IEnumerable<Item> itens = await _itemRepository.Get();

            if (itens == null)
            {
                return NoContent();
            }

            return Ok(itens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(Guid id)
        {
            Item item = await _itemRepository.Get(id);

            if (item == null)
            {
                return NoContent();
            }

            return Ok(item);
        }

        [HttpPut]
        public async Task<ActionResult<Item>> Update([FromBody] ItemDTO itemDTO, Guid id)
        {
            Item itemDb = await _itemRepository.Update(itemDTO, id);

            if (itemDb == null)
            {
                return NotFound();
            }

            return Ok(itemDb);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool deletado;

            try
            {
                deletado = await _itemRepository.Delete(id);
            }
            catch(DbUpdateException ex)
            {
                return Unauthorized();
            }

            if (deletado)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
