using Microsoft.AspNetCore.Mvc;

namespace AzurePassword.Controllers
{
    public class PasswordController : Controller
    {
        [HttpGet("")]
        [HttpGet("generate/{len?}")]
        public JsonResult Generate(int len)
        {
            return Json(new { password = AzurePassword.Generate(len: len) });
        }

        [HttpGet("generate/{len}/{upper}/{lower}/{digits}/{symbols}")]
        public JsonResult Generate(int len, bool upper, bool lower, bool digits, string symbols)
        {
            return Json(new { password = AzurePassword.Generate(len, upper, lower, digits, symbols) });
        }

        [HttpGet("verify/{password}")]
        public JsonResult Verify(string password)
        {
            return Json(new { result = AzurePassword.Verify(password) });
        }
    }
}
