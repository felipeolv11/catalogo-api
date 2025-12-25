using Catalogo_API.Context;
using Catalogo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo_API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly CatalogoDbContext _context;

    public CategoriasController(CatalogoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        return _context.Categorias.ToList();
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

        if (categoria is null)
        {
            return NotFound();
        }

        return categoria;
    }
}
