using Cadastro_com_Banco.models;
using Cadastro_com_Banco.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_com_Banco.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  ActionResult<List<ProdutoModel>> Produto() {
            return _context.ProdutoItems.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel?>> ProdutoById(long id) {
            return await _context.ProdutoItems.Where(i => i.ProdutoID.Equals(id)).FirstAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> ItemTodo(ProdutoModel produtoItem) {
            _context.Add(produtoItem);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("Produto", produtoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> ItemTodo(long id, ProdutoModel produtoItem) {
            if (id != produtoItem.ProdutoID) {
                return BadRequest();
            }

            _context.Entry(produtoItem).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> ProdutoDelete(long id) {
            var produtoItem =await ProdutoById(id);
            _context.Remove(produtoItem.Value!);
            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}