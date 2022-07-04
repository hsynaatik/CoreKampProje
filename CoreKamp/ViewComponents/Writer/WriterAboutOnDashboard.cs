using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using CoreKamp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.ViewComponents.Writer
{


    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
           
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where
                (x => x.WriterMail == userMail).Select
                (y => y.WriterID).FirstOrDefault();
            var values = writerManager.GetWriterById(writerID);
            return View(values);
        }

    }
}
