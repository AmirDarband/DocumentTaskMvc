using DocumentTaskMvc.Context;
using DocumentTaskMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentTaskMvc.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly AppDbContext _context;

        public DocumentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index(string searchString)
        {
            var documents = from d in _context.Documents.Include(d => d.User)
                            select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                documents = documents.Where(d => d.User.Username.Contains(searchString));
            }

            return View(await documents.ToListAsync());
        }

  

        // GET: Documents/Upload
        public IActionResult Upload()
        {
            return View();
        }

        // POST: Documents/Upload
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, string Title)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine("uploads", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                
                var document = new Document
                {
                    UserId = 1,
                    EntityId=1,
                    Title = Title,
                    CreatedDate = DateTime.Now,
                    FilePath = filePath
                };

                _context.Documents.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Documents/Download/5
        public async Task<IActionResult> Download(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            var filePath = document.FilePath;
            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "application/octet-stream", Path.GetFileName(filePath));
        }
    }
}
