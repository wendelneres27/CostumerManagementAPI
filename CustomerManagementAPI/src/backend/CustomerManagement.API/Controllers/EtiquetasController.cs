using CustomerManagement.API.Data;
using CustomerManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class etiquetasController : ControllerBase
{
    private readonly AppDbContext _context;

    public etiquetasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        var etiquetas = _context.Etiquetas.ToList();

        return Ok(etiquetas);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarporId(int id)
    {
        var etiqueta = _context.Etiquetas.FirstOrDefault(etiqueta => etiqueta.Id == id);

        if (etiqueta == null)
        {
            return NotFound();
        }

        return Ok(etiqueta);
    }

    [HttpPost]
    public IActionResult Criar(Etiquetas etiqueta)
    {
        _context.Etiquetas.Add(etiqueta);

        _context.SaveChanges();

        return Ok(etiqueta);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Etiquetas dados)
    {
        var etiqueta = _context.Etiquetas.FirstOrDefault(etiqueta => etiqueta.Id == id);

        if (etiqueta == null)
        {
            return NotFound();
        }

        etiqueta.Nome = dados.Nome;
        etiqueta.Cor = dados.Cor;

        _context.SaveChanges();

        return Ok(etiqueta);

    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        var etiqueta = _context.Clientes.FirstOrDefault(e => e.Id == id);

        if (etiqueta == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(etiqueta);

        _context.SaveChanges();

        return NoContent();

    }
}