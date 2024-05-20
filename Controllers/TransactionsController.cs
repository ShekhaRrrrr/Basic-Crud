using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using basiccrud.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace basiccrud.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionDbContext _context;

        public TransactionsController(TransactionDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }
        
        //// GET: Transactions/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.Transactions
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transaction);
        //}

        // GET: Transactions/AddorEdit
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new Transaction());
            else
                return View(_context.Transactions.Find(id));
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("Id,AccountNumber,BeneficaryName,BankName,SWIFTCODE,Amount,Date")] Transaction transaction)

        {
            if (ModelState.IsValid)
            {
                var transactionId = transaction.Id;
                if (transactionId == 0)
                {
                    _context.Add(transaction);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}


