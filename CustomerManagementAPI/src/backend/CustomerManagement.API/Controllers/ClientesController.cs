using Microsoft.AspNetCore.Mvc;
using CustomerManagement.API.Models;

namespace CustomerManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class clientesController : ControllerBase
{
    private static List<Cliente> clientes = new List<Cliente>();

    [HttpGet] //GET: api/clientes
    public IActionResult List()
    {
        return Ok(clientes);
    }

    [HttpGet("{id}")] //GET : api/clientes/{id}
    public IActionResult BuscarPorId(int id)
    {
        var cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);

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