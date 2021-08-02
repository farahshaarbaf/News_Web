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
        private IPageCommentRepository pageCommentRepository;


        public HomeController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);

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



        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);

            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();

            return View(news);
        }

        public ActionResult AddComment(int id, string name, string email, string website, string comment)
        {
            PageComment addcomment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Comment = comment,
                Email = email,
                Name = name,
                WebSite = website
            };
            pageCommentRepository.AddComment(addcomment);

            return PartialView("ShowComments", pageCommentRepository.GetCommentByNewsId(id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByNewsId(id));
        }

        public ActionResult EndBoxofmain()
        {
            return PartialView(pageRepository.ShowNewByPageIdFav(8,6));

        }











    }
}