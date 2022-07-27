using DataLayer.Entities;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L0.Controllers
{
    public class UrunController : Controller
    {
        UrunRepository _repository;
        public UrunController(UrunRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View(_repository.ListUrun());
        }
        [HttpPost]
        public IActionResult Index(string aranacakUrun,DateTime? skt)
        {
            List<Urun> urun = _repository.Search(aranacakUrun,skt);
            return View(urun);
        }
        public ActionResult AktifUrunler()
        {
            return View(_repository.AktifUrunler());
        }

        public ActionResult Details(int id)
        {
            Urun urun = _repository.GetUrunById(id);
            return View(urun);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Urun urun )
        {
            if (ModelState.IsValid)
            {
                _repository.AddOrUpdateUrun(urun);
                return RedirectToAction("Index");
            }
            return View(urun);
        }

        public ActionResult Edit(int id)
        {
            Urun urun=_repository.GetUrunById(id);
            return View(urun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Urun urun)
        {
            if (ModelState.IsValid)
            {
                _repository.AddOrUpdateUrun(urun);
                return RedirectToAction("Index");
            }
            return View(urun);
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
