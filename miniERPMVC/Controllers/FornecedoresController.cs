﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using miniERPMVC.Models;

namespace miniERPMVC.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly MiniErpmvc2Context _context;

        public FornecedoresController(MiniErpmvc2Context context)
        {
            _context = context;
        }

        // GET: Fornecedores
        public async Task<IActionResult> Index()
        {
            return _context.Fornecedores != null ?
                        View(await _context.Fornecedores.ToListAsync()) :
                        Problem("Entity set 'MiniErpmvc2Context.Fornecedores'  is null.");
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedore = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.IdFornecedor == id);
            if (fornecedore == null)
            {
                return NotFound();
            }

            return View(fornecedore);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFornecedor,NomeFornecedor,EnderecoFornecedor,TelefoneFornecedor")] Fornecedore fornecedore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedore);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedore = await _context.Fornecedores.FindAsync(id);
            if (fornecedore == null)
            {
                return NotFound();
            }
            return View(fornecedore);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFornecedor,NomeFornecedor,EnderecoFornecedor,TelefoneFornecedor")] Fornecedore fornecedore)
        {
            if (id != fornecedore.IdFornecedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedoreExists(fornecedore.IdFornecedor))
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
            return View(fornecedore);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedore = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.IdFornecedor == id);
            if (fornecedore == null)
            {
                return NotFound();
            }

            return View(fornecedore);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fornecedores == null)
            {
                return Problem("Entity set 'MiniErpmvc2Context.Fornecedores'  is null.");
            }
            var fornecedore = await _context.Fornecedores.FindAsync(id);
            if (fornecedore != null)
            {
                _context.Fornecedores.Remove(fornecedore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedoreExists(int id)
        {
            return (_context.Fornecedores?.Any(e => e.IdFornecedor == id)).GetValueOrDefault();
        }
    }
}
