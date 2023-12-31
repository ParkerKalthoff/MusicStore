﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class AdminArtistController : Controller
    {
        private readonly MusicStoreContext _context;

        public AdminArtistController(MusicStoreContext context)
        {
            _context = context;
        }

        // GET: AdminArtist
        public async Task<IActionResult> Index()
        {
              return _context.Artists != null ? 
                          View(await _context.Artists.ToListAsync()) :
                          Problem("Entity set 'MusicStoreContext.Artists'  is null.");
        }

        // GET: AdminArtist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artists = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistID == id);
            if (artists == null)
            {
                return NotFound();
            }

            return View(artists);
        }

        // GET: AdminArtist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminArtist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistID,ArtistName,GenreID")] Artists artists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artists);
        }

        // GET: AdminArtist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artists = await _context.Artists.FindAsync(id);
            if (artists == null)
            {
                return NotFound();
            }
            return View(artists);
        }

        // POST: AdminArtist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistID,ArtistName,GenreID")] Artists artists)
        {
            if (id != artists.ArtistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistsExists(artists.ArtistID))
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
            return View(artists);
        }

        // GET: AdminArtist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artists = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistID == id);
            if (artists == null)
            {
                return NotFound();
            }

            return View(artists);
        }

        // POST: AdminArtist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artists == null)
            {
                return Problem("Entity set 'MusicStoreContext.Artists'  is null.");
            }
            var artists = await _context.Artists.FindAsync(id);
            if (artists != null)
            {
                _context.Artists.Remove(artists);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistsExists(int id)
        {
          return (_context.Artists?.Any(e => e.ArtistID == id)).GetValueOrDefault();
        }
    }
}
