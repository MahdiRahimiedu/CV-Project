using Microsoft.AspNetCore.Mvc;

namespace CV.Site.Controllers
{
    public class AdminController : Controller
    {
        [HttpPost]
        public IActionResult UploadImageWithId(IFormFile image)
        {
            try
            {
                string guid = Guid.NewGuid() + "_" + image.FileName;
                if (image != null && image.Length > 0)
                {
                    
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image");
                    var filePath = Path.Combine(uploads, guid);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    return Content(guid);
                }
                else
                {
                    return Content("");
                }
            }
            catch (Exception ex)
            {
                return Content("");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
