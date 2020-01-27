using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebScraping.Data;
using WebScraping.Models;

namespace WebScraping.Controllers
{
    public class TaxaSelicController : Controller
    {
        private readonly WebScrapingContext _context;

        public TaxaSelicController(WebScrapingContext context)
        {
            _context = context;
        }

        // GET: TaxaSelic
        public async Task<IActionResult> Index()
        {
            string url = "http://receita.economia.gov.br/orientacao/tributaria/pagamentos-e-parcelamentos/taxa-de-juros-selic";
            var webClient = new WebClient();
            string pagina = webClient.DownloadString(url);

            Console.Write(pagina);
            return View(await _context.TaxaSelic.ToListAsync());
        }

        // GET: TaxaSelic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxaSelic = await _context.TaxaSelic
                .FirstOrDefaultAsync(m => m.ID == id);
            if (taxaSelic == null)
            {
                return NotFound();
            }

            return View(taxaSelic);
        }

        // GET: TaxaSelic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxaSelic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Data,Vigencia,Valor")] TaxaSelic taxaSelic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxaSelic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxaSelic);
        }

        // GET: TaxaSelic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxaSelic = await _context.TaxaSelic.FindAsync(id);
            if (taxaSelic == null)
            {
                return NotFound();
            }
            return View(taxaSelic);
        }

        // POST: TaxaSelic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Data,Vigencia,Valor")] TaxaSelic taxaSelic)
        {
            if (id != taxaSelic.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxaSelic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxaSelicExists(taxaSelic.ID))
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
            return View(taxaSelic);
        }

        // GET: TaxaSelic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxaSelic = await _context.TaxaSelic
                .FirstOrDefaultAsync(m => m.ID == id);
            if (taxaSelic == null)
            {
                return NotFound();
            }

            return View(taxaSelic);
        }

        // POST: TaxaSelic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxaSelic = await _context.TaxaSelic.FindAsync(id);
            _context.TaxaSelic.Remove(taxaSelic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxaSelicExists(int id)
        {
            return _context.TaxaSelic.Any(e => e.ID == id);
        }
    }
}
