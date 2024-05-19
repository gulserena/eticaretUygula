using eticaretUygulama.Dto;
using eticaretUygulama.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;

namespace eticaretUygulama.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
         
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegistorDto appUserRegistorDto)
        {
            Random random= new Random();
            int code = 0;
            code = random.Next(1000, 1000000);
            AppUser appUser = new AppUser()
            {
                FirstName= appUserRegistorDto.FirstName,
                LastName= appUserRegistorDto.LastName,
                City= appUserRegistorDto.City,
                UserName= appUserRegistorDto.UserName,
                Email= appUserRegistorDto.Email,
                ConfirmCode= code,

            };
            var result =await _userManager.CreateAsync(appUser, appUserRegistorDto.Password);
            if(result.Succeeded)
            {
                MimeMessage mimaMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Eticaret Uygulaması","gulserenakkus201@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                mimaMessage.From.Add(mailboxAddressFrom);
                mimaMessage.To.Add(mailboxAddressTo);
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Kaydınız Başarılı Şekilde Gerçekleşti."+code;
                mimaMessage.Body = bodyBuilder.ToMessageBody();
                mimaMessage.Subject = "E Ticaret Uygulaması";
                SmtpClient client = new SmtpClient();
                client.Connect("smpt.gmail.com",587,false);
                client.Authenticate("gulserenakkus201@gmail.com", "......");
                client.Send(mimaMessage);
                client.Disconnect(true);

                TempData["Mail"]=appUserRegistorDto.Email;
                return RedirectToAction("Index","ConfirmMail");



;            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
