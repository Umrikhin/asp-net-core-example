using Microsoft.AspNetCore.Mvc;

namespace BlazorCookieAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        // /api/User/GetUser
        [HttpGet("[action]")]
        public UserModel GetUser()
        {
            // Создание экземпляра модели пользователя
            var userModel = new UserModel
            {
                UserName = "[]",
                IsAuthenticated = false
            };
            // Определить, аутентифицирован ли пользователь
            if (User.Identity is not null)
            if (User.Identity.IsAuthenticated)
            {
                // Установите имя аутентифицированного пользователя
                userModel.UserName = User.Identity.Name;
                userModel.IsAuthenticated = User.Identity.IsAuthenticated;
            };
            return userModel;
        }
    }
    // Класс для хранения UserModel
    public class UserModel
    {
        public string? UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
