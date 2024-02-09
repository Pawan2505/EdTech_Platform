using Edtech.Data;
using Edtech.DTOs;
using Edtech.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace Edtech.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    public class StudentController : Controller
    {
        private AppDbContext _myApDbContext;
        private IWebHostEnvironment _webHostEnvironment;

        public StudentController(AppDbContext myApDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _myApDbContext = myApDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult Index()
        {
            var students = _myApDbContext.Students2.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentImage image)
        {
            string filename = Upload(image);


            if (image.ProfileImage.Length > 20)
            {
                // Do something with the image length if needed.
            }

            var student = new Student2()
            {
                CourseTitle = image.CourseTitle,
                InstructorName = image.InstructorName,
                Description = image.Description,
                Duration = image.Duration,
                Price = image.Price,
                ProfileImage = filename,
            };

            _myApDbContext.Add(student);
            _myApDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _myApDbContext.Students2.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _myApDbContext.Students2.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            // Delete the associated profile image file
            if (!string.IsNullOrEmpty(student.ProfileImage))
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", student.ProfileImage);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _myApDbContext.Students2.Remove(student);
            await _myApDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _myApDbContext.Students2 == null)
            {
                return NotFound();
            }

            var student2 = await _myApDbContext.Students2.FindAsync(id);
            if (student2 == null)
            {
                return NotFound();
            }
            return View(student2);
        }
        // GET: Student2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _myApDbContext.Students2 == null)
            {
                return NotFound();
            }

            var student2 = await _myApDbContext.Students2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student2 == null)
            {
                return NotFound();
            }

            return View(student2);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseTitle,InstructorName,Description,Duration,Price,ProfileImage")] Student2 student2, string originalProfileImage)
        {
            if (id != student2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // If the ProfileImage is not modified, use the original path
                    if (string.IsNullOrEmpty(student2.ProfileImage))
                    {
                        student2.ProfileImage = originalProfileImage;
                    }

                    _myApDbContext.Update(student2);
                    await _myApDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student2Exists(student2.Id))
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
            return View(student2);
        }


        private bool Student2Exists(int id)
        {
            return (_myApDbContext.Students2?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string Upload(StudentImage image)
        {
            string filename = null;
            if (image.ProfileImage != null)
            {
                string uploaddir = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                filename = Guid.NewGuid().ToString() + "-" + image.ProfileImage.FileName;
                string filepath = Path.Combine(uploaddir, filename);

                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    image.ProfileImage.CopyTo(filestream);
                }
            }
            return filename;
        }
    }
}
