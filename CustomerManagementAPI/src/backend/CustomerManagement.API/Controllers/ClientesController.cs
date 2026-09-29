using Microsoft.AspNetCore.Mvc;
using CustomerManagement.API.Models;
using CustomerManagement.API.Data;

namespace CustomerManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class clientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public clientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet] //GET: api/clientes
    public IActionResult Listar()
    {
        var clientes = _context.Clientes.ToList();

        return Ok(clientes);
    }

    [HttpGet("{id}")] //GET : api/clientes/{id}
    public IActionResult BuscarPorId(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    [HttpPost] //POST: api/clientes
    public IActionResult Criar(Cliente cliente)
    {
        cliente.Id = clientes.Count + 1;

        cliente.DataCadastro = DateTime.Now;

        clientes.Add(cliente);

        return Ok(cliente);
    }

    [HttpPut("{id}")] //PUT : api/clientes 
    public IActionResult Atualizar(int id, Cliente dados)
    {
        var cliente = clientes.FirstOrDefault(clientes => clientes.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        cliente.Nome = dados.Nome;
        cliente.Email = dados.Email;
        cliente.Telefone = dados.Telefone;

        return Ok(cliente);

    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        clientes.Remove(cliente);

        return NoContent();
    }
}