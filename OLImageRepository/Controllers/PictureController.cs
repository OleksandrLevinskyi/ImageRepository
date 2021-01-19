using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OLImageRepository.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using ImageRepositoryClassLibrary;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ImageRepository.Controllers
{
    [Authorize]
    public class PictureController : Controller
    {
        private readonly ImageRepositoryContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PictureController(ImageRepositoryContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Picture
        [AllowAnonymous]
        public async Task<IActionResult> BrowsePublicImages()
        {
            var pictureContext = _context.Picture;
            IEnumerable<Picture> pictures;

            pictures = await pictureContext.Where(i => i.IsPublic == true).ToListAsync();

            HttpContext.Session.SetString("isPrivateMode", "false");

            return View("Index", pictures.OrderByDescending(i => i.DateAdded));
        }

        // GET: Picture
        public async Task<IActionResult> BrowsePrivateImages()
        {
            var pictureContext = _context.Picture;
            IEnumerable<Picture> pictures;

            pictures = await pictureContext.Where(i => i.OwnerId == _userManager.GetUserId(User)).ToListAsync();

            HttpContext.Session.SetString("isPrivateMode", "true");
            HttpContext.Session.SetString("albumId", "");

            return View("Index", pictures.OrderByDescending(i => i.DateAdded));
        }

        /// <summary>
        /// finds images for the specific album
        /// </summary>
        /// <param name="albumId">album ID to examine</param>
        /// <returns>view with a collection of album pictures</returns>
        public async Task<IActionResult> BrowseAlbumImages(int? albumId = null)
        {
            IEnumerable<Picture> pictures;

            if (albumId != null)
            {
                HttpContext.Session.SetString(nameof(albumId), albumId.ToString());
                SetAlbumNameInSession((int)albumId);
            }
            else if (!String.IsNullOrEmpty(HttpContext.Session.GetString(nameof(albumId))))
            {
                albumId = Convert.ToInt32(HttpContext.Session.GetString(nameof(albumId)));
                SetAlbumNameInSession((int)albumId);
            }
            else
            {
                return RedirectToAction("Index", "Album");
            }

            HttpContext.Session.SetString("isPrivateMode", "true");

            pictures = await _context.Picture.Where(i => i.OwnerId == _userManager.GetUserId(User) && i.AlbumId == albumId).ToListAsync();

            return View("Index", pictures.OrderByDescending(i => i.DateAdded));
        }

        [AllowAnonymous]
        // GET: Picture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Picture.Include(i => i.Album).FirstOrDefaultAsync(i => i.PictureId == id);

            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // GET: Picture/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Album.Where(a => a.OwnerId == _userManager.GetUserId(User)).ToList(), "AlbumId", "Name");
            return View();
        }

        // POST: Picture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// creates a new picture
        /// </summary>
        /// <param name="picture">picture object to be saved</param>
        /// <param name="image">data from the form</param>
        /// <returns>confirmation of the procedure</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PictureId,AlbumId,Name,Description,StoredPicture,DateAdded,DominantColor,IsPublic,IsHorizontal")] Picture picture, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    // Source code for fetching image: https://stackoverflow.com/questions/42741170/how-to-save-images-to-database-using-asp-net-core
                    byte[] pictureByteArr = null;
                    using (var fs = image.OpenReadStream())
                    {
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            pictureByteArr = ms.ToArray();
                        }

                        picture.StoredPicture = pictureByteArr;
                        picture.DominantColor = ColorCalculation.GetDominantColor((Bitmap)Bitmap.FromStream(fs));
                    }
                }

                picture.OwnerId = _userManager.GetUserId(User);

                _context.Add(picture);
                await _context.SaveChangesAsync();

                return await RedirectToIndex();
            }
            ViewData["AlbumId"] = new SelectList(_context.Album.Where(a => a.OwnerId == _userManager.GetUserId(User)).ToList(), "AlbumId", "Name", picture.AlbumId);
            return View(picture);
        }

        // GET: Picture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Picture.FindAsync(id);

            if (picture == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Album.Where(a => a.OwnerId == _userManager.GetUserId(User)).ToList(), "AlbumId", "Name", picture.AlbumId);
            return View(picture);
        }

        // POST: Picture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PictureId,AlbumId,Name,Description,StoredPicture,DateAdded,DominantColor,IsPublic,IsHorizontal")] Picture picture)
        {
            if (id != picture.PictureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    picture.OwnerId = _userManager.GetUserId(User);

                    _context.Update(picture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureExists(picture.PictureId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return await RedirectToIndex();
            }
            ViewData["AlbumId"] = new SelectList(_context.Album.Where(a => a.OwnerId == _userManager.GetUserId(User)).ToList(), "AlbumId", "Name", picture.AlbumId);
            return View(picture);
        }

        // GET: Picture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Picture.Include(i => i.Album).FirstOrDefaultAsync(m => m.PictureId == id);

            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // POST: Picture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var picture = await _context.Picture.FindAsync(id);
            _context.Picture.Remove(picture);
            await _context.SaveChangesAsync();
            return await RedirectToIndex();
        }

        private bool PictureExists(int id)
        {
            return _context.Picture.Any(e => e.PictureId == id);
        }

        private void SetAlbumNameInSession(int albumId)
        {
            var album = _context.Album.Find(albumId);
            HttpContext.Session.SetString("albumName", album.Name);
        }

        private async Task<IActionResult> RedirectToIndex()
        {
            bool isAlbumSpecified = false;
            string albumId = HttpContext.Session.GetString("albumId");

            if (!String.IsNullOrEmpty(albumId)) isAlbumSpecified = true;

            if (isAlbumSpecified) return RedirectToAction(nameof(BrowseAlbumImages));
            else return RedirectToAction(nameof(BrowsePrivateImages));
        }

        // POST: Picture/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string query)
        {
            var pictures = _context.Picture.Where(i => i.Name.Contains(query) || i.Description.Contains(query));

            bool isPrivateMode = Convert.ToBoolean(HttpContext.Session.GetString("isPrivateMode"));
            bool isAlbumSpecified = false;
            string albumId = HttpContext.Session.GetString("albumId");

            if (!String.IsNullOrEmpty(albumId))
                isAlbumSpecified = true;

            if (isPrivateMode)
            {
                pictures = pictures.Where(i => i.OwnerId == _userManager.GetUserId(User));
                if (isAlbumSpecified)
                {
                    pictures = pictures.Where(i => i.AlbumId == Convert.ToInt32(albumId));
                }
            }
            else
            {
                pictures = pictures.Where(i => i.IsPublic);
            }

            var results = await pictures.ToListAsync();
            return View("Index", results.OrderByDescending(i => i.DateAdded));
        }
    }
}
