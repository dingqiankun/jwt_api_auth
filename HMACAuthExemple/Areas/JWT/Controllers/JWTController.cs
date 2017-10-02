using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IdentityModel.Tokens.Jwt;
using HMACAuthExemple.Areas.JWT.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HMACAuthExemple.Areas.BearerAuth.Authorization;

namespace HMACAuthExemple.Areas.JWT.Controllers
{
    public class JWTController : Controller
    {
        #region Pregenerated
        // GET: JWT/JWT
        public ActionResult Index()
        {
            return View();
        }

        // GET: JWT/JWT/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JWT/JWT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JWT/JWT/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JWT/JWT/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JWT/JWT/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JWT/JWT/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JWT/JWT/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion Pregenerated

        [HttpPost]
        public string CreateTokenExemple(LoginModel jsonData)
        {
            try
            {
                return JwtManager.GenerateToken(jsonData.Username);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [TokenValidator]
        //[Authorize]
        public string ValidateToken()
        {
            return "value";
        }
    }
}
