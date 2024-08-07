using System;
using catalogoprodutos.api.Domain;
using catalogoprodutos.api.Infra.Data;
using catalogoprodutos.api.InputModels;
using catalogoprodutos.api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catalogoprodutos.api.Controllers;

[Route("api/categoria")]
public class CategoriaController : ControllerBase
{
    private readonly CatalogoContext _context;

    public CategoriaController(CatalogoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodas()
    {
        var categorias = await _context.Categorias.ToListAsync();

        var categoriaViews = categorias.Select(CategoriaViewModel.Mapear);

        return Ok(categoriaViews);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(CategoriaInputModel model)
    {
        var nova = new Categoria(model.Descricao);

        _context.Categorias.Add(nova);

        if (await _context.SaveChangesAsync() > 0) return Ok("Nova categoria adicionada com sucesso!");

        return BadRequest("Não foi possível adicionar a categoria!!");
    }


    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Atualizar(Guid id, CategoriaInputModel model)
    {
        var categoriaEncontrada = await _context.Categorias.FindAsync(id);

        if (categoriaEncontrada is null) return NotFound();

        categoriaEncontrada.AtribuirDescricao(model.Descricao);

        if (await _context.SaveChangesAsync() > 0) return Ok("Categoria atualizada com sucesso!");

        return BadRequest("Não foi possível atualizar a categoria!");
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        var categoriaEncontrada = await _context.Categorias.FindAsync(id);

        if (categoriaEncontrada is null) return NotFound();

        _context.Categorias.Remove(categoriaEncontrada);

        if (await _context.SaveChangesAsync() > 0) return Ok("Categoria removida com sucesso!");

        return BadRequest("Não foi possível remover a categoria!");
    }
}