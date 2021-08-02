using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Web.Controllers
{
    public class HomeController : Controller
    {
        MyCmsContext db = new MyCmsContext();
        private IPageRepository pageRepository;
        private IPageGroupRepository pageGroupRepository;


        public HomeController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
        }
        ///Home/Index
        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        ///Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/

        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return PartialView(pageRepository.GetPage(4));
        }


        public ActionResult Slider()
        {
            return PartialView(pageRepository.PagesInSlider());
        }
        public ActionResult Newsofslider()
        {
            return PartialView(pageRepository.Newsofslider());
        }
        public ActionResult FavoritePost()
        {
            return PartialView(pageRepository.GetGroups());
        }
        public ActionResult GroupsinFavorite()
        {
            return PartialView(pageGroupRepository.GetFavorite());
        }
        public ActionResult NewNews()
        {
            return PartialView(pageRepository.LastNews(6));
        }
        public ActionResult FavoriteColumn()
        {
            return PartialView(pageRepository.GetGroups(6));
        }
        public ActionResult NormalPost()
        {
            return PartialView(pageRepository.GetAllPage().Take(6));
        }
        [Route("News/{id}/{title}")]
        public ActionResult ShowPageByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }

        public ActionResult AllP()
        {
            return PartialView(pageRepository.GetAllPage().Take(6));

        }

        //ورزشی
        public ActionResult Sport()
        {
            return PartialView(pageRepository.ShowNewByPageIdFav(1,6));

        }

        //سیاسی
        public ActionResult syasi()
        {
            return PartialView(pageRepository.ShowNewByPageIdFav(2));

        }
        //اقتصادی
        public ActionResult eghtesad()
        {
            return PartialView(pageRepository.ShowNewByPageIdFav(3));

        }
        //هنری
        public ActionResult honari()
        {
            return PartialView(pageRepository.ShowNewByPageIdFav(4));

        }






        




    }
}