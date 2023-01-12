using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesquisaItensAPI.DTO;
using PesquisaItensAPI.Interfaces;
using PesquisaItensAPI.Models;
using PesquisaItensAPI.Repositories;

namespace PesquisaItensAPI.Controllers
{
    [Route("itempesquisas")]
    [ApiController]
    public class ItemPesquisaController : ControllerBase
    {
        private readonly IItemPesquisaRepository _itemPesquisaRepository;

        public ItemPesquisaController(IItemPesquisaRepository itemPesquisaRepository)
        {
            _itemPesquisaRepository = itemPesquisaRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ItemPesquisa>> Create([FromBody] ItemPesquisaDTO itemPesquisaDTO)
        {
            ItemPesquisa itemPesqusiaNovo = await _itemPesquisaRepository.Create(itemPesquisaDTO);
            
            if (itemPesqusiaNovo == null)
            {
                return BadRequest();
            }

            return new CreatedResult($"itempesquisas/{itemPesqusiaNovo.Id}", itemPesquisaDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPesquisa>>> Get()
        {
            IEnumerable<ItemPesquisa> itemPesquisas = await _itemPesquisaRepository.GetAll();

            if (itemPesquisas == null)
            {
                return NoContent();
            }

            return Ok(itemPesquisas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPesquisa>> Get(Guid id)
        {
            ItemPesquisa itemPesquisa = await _itemPesquisaRepository.Get(id);

            if (itemPesquisa == null)
            {
                return NoContent();
            }

            return Ok(itemPesquisa);
        }

        [HttpPut]
        public async Task<ActionResult<ItemPesquisa>> Update([FromBody] ItemPesquisaDTO itemPesquisaDTO, Guid id)
        {
            ItemPesquisa itemPesquisaDb = await _itemPesquisaRepository.Update(itemPesquisaDTO, id);

            if (itemPesquisaDb == null)
            {
                return NotFound();
            }

            return Ok(itemPesquisaDb);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool deletado;

            try
            {
                deletado = await _itemPesquisaRepository.Delete(id);
            }
            catch (DbUpdateException ex)
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
