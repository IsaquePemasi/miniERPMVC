using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using miniERPMVC.Models;

namespace miniERPMVC.Controllers
{
    public class NotasFiscaisController : Controller
    {
        private readonly MiniErpmvc2Context _context;

        public NotasFiscaisController(MiniErpmvc2Context context)
        {
            _context = context;
        }

        // GET: NotasFiscais
        public async Task<IActionResult> Index()
        {
            var miniErpmvc2Context = _context.NotasFiscais.Include(n => n.IdClienteNavigation).Include(n => n.IdProdutoNavigation);
            return View(await miniErpmvc2Context.ToListAsync());
        }

        // GET: NotasFiscais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NotasFiscais == null)
            {
                return NotFound();
            }

            var notasFiscai = await _context.NotasFiscais
                .Include(n => n.IdClienteNavigation)
                .Include(n => n.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notasFiscai == null)
            {
                return NotFound();
            }

            return View(notasFiscai);
        }

        // GET: NotasFiscais/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto");
            return View();
        }

        // POST: NotasFiscais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNota,DataEmissao,IdCliente,IdProduto")] NotasFiscai notasFiscai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notasFiscai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", notasFiscai.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", notasFiscai.IdProduto);
            return View(notasFiscai);
        }

        // GET: NotasFiscais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NotasFiscais == null)
            {
                return NotFound();
            }

            var notasFiscai = await _context.NotasFiscais.FindAsync(id);
            if (notasFiscai == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", notasFiscai.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", notasFiscai.IdProduto);
            return View(notasFiscai);
        }

        // POST: NotasFiscais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNota,DataEmissao,IdCliente,IdProduto")] NotasFiscai notasFiscai)
        {
            if (id != notasFiscai.IdNota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notasFiscai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasFiscaiExists(notasFiscai.IdNota))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", notasFiscai.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", notasFiscai.IdProduto);
            return View(notasFiscai);
        }

        // GET: NotasFiscais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NotasFiscais == null)
            {
                return NotFound();
            }

            var notasFiscai = await _context.NotasFiscais
                .Include(n => n.IdClienteNavigation)
                .Include(n => n.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notasFiscai == null)
            {
                return NotFound();
            }

            return View(notasFiscai);
        }

        // POST: NotasFiscais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NotasFiscais == null)
            {
                return Problem("Entity set 'MiniErpmvc2Context.NotasFiscais'  is null.");
            }
            var notasFiscai = await _context.NotasFiscais.FindAsync(id);
            if (notasFiscai != null)
            {
                _context.NotasFiscais.Remove(notasFiscai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasFiscaiExists(int id)
        {
            return (_context.NotasFiscais?.Any(e => e.IdNota == id)).GetValueOrDefault();
        }
    }
}
