using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using file_hosting.Models;
using System.IO;
using MimeKit;

namespace file_hosting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string fileForRename)
        { 
            return View(Utils.GetFilesUpload());
        }

        [HttpPost]
        [RequestSizeLimit(1048576)]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadedFile != null)
                    {
                        var fileName = System.IO.Path.GetFileName(uploadedFile.FileName);
                        FileInfo f = new System.IO.FileInfo(fileName);
                        using (var fileStream = new FileStream(Path.Combine(Utils.pathDir, f.Name), FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "No file selected!");
                        return View("Index", Utils.GetFilesUpload());
                    }
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View("Index", Utils.GetFilesUpload());
                }
            }
            else
            {
                ModelState.AddModelError("", "The file must be up to 1 MB.");
                return View("Index", Utils.GetFilesUpload());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFile(string FileName)
        {
            string webRootPath = Utils.pathDir;

            try
            {
                if (System.IO.File.Exists(Path.Combine(webRootPath, FileName)))
                {
                    System.IO.File.Delete(Path.Combine(webRootPath, FileName));

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "The file does not exist!");
                    return View("Index", Utils.GetFilesUpload());
                }
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", err.Message);
                return View("Index", Utils.GetFilesUpload());
            }
        }

        [HttpGet("download-file/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            string webRootPath = Utils.pathDir;
            var filePath = Path.Combine(webRootPath, fileName);
            if (filePath == null) return NotFound();

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }
    }
}
