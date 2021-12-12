using FirstWeblog.Models;
using FirstWeblog.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWeblog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        readonly WeblogContext _context;
        public PagesController(WeblogContext context)
        {
            _context = context;
        }
        // GET: Admin/PagesController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Logs.ToListAsync());
        }

        // GET: Admin/PagesController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var log = await _context.Logs
                .FirstOrDefaultAsync(l => l.LogID == id);
            if (log == null) return RedirectToAction("Index");
            return View(log);
        }

        // GET: Admin/PagesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int id,string name,string content)
        {
            LogViewModel vm = new LogViewModel();

            if (ModelState.IsValid)
            {
                vm.LogID = id;
                vm.Name = name;
                vm.Content = content;
                _context.Add(vm);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/PagesController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var log = await _context.Logs.FindAsync(id);
            if (log == null) return NotFound();
            return View(log);
        }

        // POST: Admin/PagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string name, string content)
        {
            LogViewModel vm = new LogViewModel();
            if (id != vm.LogID) return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                if (vm.LogID == id)
                {
                    vm.Name = name;
                    vm.Content = content;
                    _context.Update(vm);
                    await _context.SaveChangesAsync();
                }
                else return NotFound();
            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/PagesController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var log = await _context.Logs
                .FirstOrDefaultAsync(l => l.LogID == id);

            if(log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Admin/PagesController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
