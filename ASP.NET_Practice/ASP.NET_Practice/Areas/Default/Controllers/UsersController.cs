using ASP.NET_Practice.DataAccess.SingleEntityRepo;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using ASP.NET_Practice.Helpers;
using ASP.NET_Practice.Mappers;
using ASP.NET_Practice.Models;
using System;
using System.Drawing.Imaging;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET_Practice.Areas.Default.Controllers
{
    public class UsersController : Controller
    {
        private IGenericRepository<User> _usersRepo;
        private IMapper _mapper;


        public UsersController(IGenericRepository<User> usersRepo, IMapper mapper)
        {
            _usersRepo = usersRepo;
            _mapper = mapper;
        }

        // GET: SingleEntityRepo
        public ActionResult GetAll()
        {
            var users = _usersRepo.GetAll().IncludeMultiple(user => user.Role).ToList();
            return View(_usersRepo.GetAll().ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Title = "Добавление пользователя";
            return View(new UserView());
        }

        [HttpPost]
        public ActionResult Add(UserView newUser)
        {
            var existSameEmail = _usersRepo.GetAll().Any(u => u.Email == newUser.Email);
            
            if (existSameEmail)
            {
                ModelState.AddModelError("Email", "Пользователь с таким Email уже зарегистрирован");
            } 

            if (newUser.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
            }

            if (ModelState.IsValid)
            {
                var userModel = (User)_mapper.Map(newUser, typeof(UserView), typeof(User));
                userModel.AddAtDate = DateTime.UtcNow;
                userModel.RoleId = 1;//TODO: добавить в UI выбор роли
                _usersRepo.Add(userModel);
                return RedirectToAction("GetAll");
            }

            return View(newUser);
        }

        public ActionResult Captcha()
        {
            //храним ключ в сессии клиента. Оттуда его достанем при проверки перед добавлением пользователя в БД
            Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            var captchaImage = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Arial");
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";
            captchaImage.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            captchaImage.Dispose();
            return null;//потому что саму капчу записали в выходной поток респонза
        }
    }
}