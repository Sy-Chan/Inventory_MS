using Inventory_MS.Data;
using Inventory_MS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Inventory_MS.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly IMSContext _context;

        public InventoriesController(IMSContext context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inventory.ToListAsync());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("ID,Type, Items, ObjectID,DateIn,Status, Departments,Remarks")] Inventory inventory)
        {

            if (ModelState.IsValid)
            {
                int id = (from m in _context.Inventory where m.Type == inventory.Type select m.ID).Count();
                Code x = inventory.Type;

                int nid = id + 1;

                inventory.ObjectID = Convert.ToString(x) + nid.ToString();
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventories/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type, Items, ObjectID,DateIn,Status, Departments,Remarks")] Inventory inventory)
        {
            if (id != inventory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.ID))
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
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.ID == id);
        }
        public IActionResult Repair()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Repair([Bind("ID,Type, Items, ObjectID,DateIn,Status, Departments,Remarks")] Inventory inventory, [Bind("ID, ObjectID, Supplier, Payment, Remarks, DateSend, DateBack")] RepairRecord repair)
        {
            if (ModelState.IsValid)
            {
                var id = (from m in _context.Inventory where m.ObjectID == repair.ObjectID select m.ID).First();

                try
                {
                    inventory = await _context.Inventory.FindAsync(id);
                    inventory.Status = "Repair";
                    _context.Update(inventory);
                    _context.Update(repair);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.ID))
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
            return View(repair);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("ID, UserID, Password, Department, Position")] User user)
        {

            if (ModelState.IsValid)
            {
                
                string Password = (from m in _context.User where m.UserID == user.UserID select m.Password).First();
                int Id = (from m in _context.User where m.UserID == user.UserID select m.ID).First();
                var inventory = await _context.User.FindAsync(Id);
                if (Password == user.Password)
                {
                    ViewData["Message"] = "";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["Message"] = "Username or Password invalid";
                    return View();
                }

            }

            return RedirectToAction(nameof(Index));
        }


    }
}

