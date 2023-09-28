using Microsoft.Ajax.Utilities;
using Scarpe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scarpe.Controllers
{
    [Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View(DB.getAllScarpe());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Scarpa scarpa,HttpPostedFileBase CoverImg,HttpPostedFileBase Img1,HttpPostedFileBase Img2)
        {
            if(ModelState.IsValid)
            {
                if (CoverImg.ContentLength > 0)
                {
                    string nomeFile = CoverImg.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets"), nomeFile);
                    CoverImg.SaveAs(path);
                    scarpa.CoverImg = nomeFile;
                }
                else scarpa.CoverImg = "";
                 if (Img1.ContentLength > 0)
                {
                    string nomeFile = Img1.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets"), nomeFile);
                    Img1.SaveAs(path);
                    scarpa.Img1 = nomeFile;
                }
                else scarpa.Img1 = "";
                if (Img2.ContentLength > 0)
                {
                    string nomeFile = Img2.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets"), nomeFile);
                    Img2.SaveAs(path);
                    scarpa.Img2 = nomeFile;
                }
                else scarpa.Img2 = "";

                DB.AddScarpa(scarpa.Name,scarpa.Price, scarpa.Description, scarpa.CoverImg, scarpa.Img1, scarpa.Img2, scarpa.Quantity, scarpa.Production, scarpa.Visible);
                return RedirectToAction("Index");
            } else return View();
        }

        public ActionResult Edit(int id)
        {
            Scarpa scarpa = DB.getScarpaById(id);
            return View(scarpa);
        }

        [HttpPost]
        public ActionResult Edit(Scarpa changedScarpa, HttpPostedFileBase CoverImg, HttpPostedFileBase Img1, HttpPostedFileBase Img2)
        {
            if(ModelState.IsValid)
            {
                if (CoverImg.ContentLength > 0)
                {
                    string nomeFile = CoverImg.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets"), nomeFile);
                    CoverImg.SaveAs(path);
                    changedScarpa.CoverImg = nomeFile;
                }
                else changedScarpa.CoverImg = "";
                if (Img1.ContentLength > 0)
                {
                    string nomeFile = Img1.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets"), nomeFile);
                    Img1.SaveAs(path);
                    changedScarpa.Img1 = nomeFile;
                }
                else changedScarpa.Img1 = "";
                if (Img2.ContentLength > 0)
                {
                    string nomeFile = Img2.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets"), nomeFile);
                    Img2.SaveAs(path);
                    changedScarpa.Img2 = nomeFile;
                }
                else changedScarpa.Img2 = "";
                DB.UpdateScarpa(changedScarpa.Id, changedScarpa.Name, changedScarpa.Price, changedScarpa.Description, changedScarpa.CoverImg, changedScarpa.Img1, changedScarpa.Img2, changedScarpa.Quantity, changedScarpa.Production, changedScarpa.Visible);
                return RedirectToAction("Index");
            } else return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Scarpa scarpa = DB.getScarpaById(id);
            return View(scarpa);
        }

        [HttpPost]
        public ActionResult Delete(Scarpa scarpa)
        {
            DB.Remove(scarpa.Id);
            return RedirectToAction("Index");
        }
    }
}