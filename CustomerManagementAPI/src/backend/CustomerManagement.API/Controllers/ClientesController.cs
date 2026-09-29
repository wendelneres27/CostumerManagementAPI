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

    [HttpPost] //POST: api/clientes
    public IActionResult Criar(Cliente cliente)
    {
        cliente.Id = clientes.Count + 1;

        cliente.DataCadastro = DateTime.Now;

        clientes.Add(cliente);

        return Ok(cliente);
    }
}