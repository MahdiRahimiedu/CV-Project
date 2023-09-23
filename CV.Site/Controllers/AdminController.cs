using CV.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CV.Site.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult UploadImageWithId(IFormFile image)
        {
            try
            {
                // یه جی یو ایدی به اول اسم اضافه میکنه تا شبیه نشه اسما
                string guid = Guid.NewGuid() + "_" + image.FileName;
                if (image != null && image.Length > 0)
                {
                    // واسه اپلود کردن عکس
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image");
                    // واسه ساخت مسیر فایل برای اپلود شدن تو روت
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

        [HttpDelete]
        public IActionResult DeleteImage(string id)
        {
            try
            {
                if(id == null)
                {
                    return Content("");
                }
                // Get the root path where the images are stored
                var webRootPath = _webHostEnvironment.WebRootPath + "//image//";

                // Combine the root path with the image name to get the full path
                var imagePath = Path.Combine(webRootPath, id);

                // Check if the file exists
                if (System.IO.File.Exists(imagePath))
                {
                    // Delete the file
                    System.IO.File.Delete(imagePath);
                    return Content("Image deleted successfully.");
                }
                else
                {
                    return Content("Image not found.");
                }
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAndSaveJson(AboutUs model) 
        {
            try
            {
                //  ابجکت به جیسان
                // Convert the object to JSON
                var json = JsonConvert.SerializeObject(model);

                // تبدیل جیسان به ابجکت
                //JsonConvert.DeserializeObject(json);

                // ادرس جایی که قراره ذخیره شه
                // Get the root path where the JSON file will be saved
                var webRootPath = _webHostEnvironment.WebRootPath + "\\js\\" ;

                // دادن اسم و پسوند فایل جیسان برای ذخیره سازی اطلاعات
                // Combine the root path with the file name to get the full path
                var jsonFilePath = Path.Combine(webRootPath, "jsonPop.json");

                // سیو کردن اطلاعات
                // Save the JSON data to the file
                System.IO.File.WriteAllText(jsonFilePath, json);

                return Content("JSON file created and saved successfully.");
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
        }
    }
    }

