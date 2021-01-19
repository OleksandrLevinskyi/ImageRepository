using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OLImageRepository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ImageRepository.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private readonly ImageRepositoryContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AlbumController(ImageRepositoryContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
            var currUserId = _userManager.GetUserId(User);
            var album = await _context.Album.FirstOrDefaultAsync(a => a.OwnerId == currUserId && a.Name == "General");
            if (album == null)
            {
                await Create(new Album() { Name = "General", OwnerId = currUserId });
            }

            var albums = _context.Album.Where(a => a.OwnerId == currUserId);

            return View(await albums.ToListAsync());
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,OwnerId,Name")] Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    album.OwnerId = _userManager.GetUserId(User);

                    _context.Add(album);
                    await _context.SaveChangesAsync();

                    TempData["message"] = $"Album '{album.Name}' added successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = $"Error creating a record: {ex.GetBaseException().Message}";
            }

            return View(album);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,OwnerId,Name")] Album album)
        {
            if (id != album.AlbumId)
            {
                TempData["message"] = $"The record being updated is not the one requested";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();

                    TempData["message"] = $"Album '{album.Name}' updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        TempData["message"] = $"Album ID is not on file: {album.AlbumId}";
                    }
                    else
                    {
                        TempData["message"] = $"Concurrency exception: {ex.GetBaseException().Message}";
                    }
                }
                catch (Exception ex)
                {
                    TempData["message"] = $"Error updating a record: {ex.GetBaseException().Message}";
                }
            }

            return View(album);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var album = await _context.Album.FindAsync(id);
                _context.Album.Remove(album);
                await _context.SaveChangesAsync();

                TempData["message"] = $"Album '{album.Name}' deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = $"Error deleting a record: {ex.GetBaseException().Message}";
            }

            return RedirectToAction("Delete", new { ID = id });
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.AlbumId == id);
        }
    }
}
