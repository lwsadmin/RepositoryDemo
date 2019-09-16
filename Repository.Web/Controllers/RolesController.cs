using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Data;
using Repository.Data.Data;
using Repository.DataAccess.UnitOfWork;

namespace Repository.Web.Controllers
{
    public class RolesController : Controller
    {

        //2019/09/16 --lws
        //http://www.360doc.com/userhome.aspx?userid=5397376&cid=3
        private UnitOfWork _unitWork;
        public RolesController()
        {
            this._unitWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var list = _unitWork.RoleRepository.GetList();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roles = _unitWork.RoleRepository.GetById(id.Value);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleName,Actions")] Roles roles)
        {
            if (ModelState.IsValid)
            {
                _unitWork.RoleRepository.Create(roles);
                return RedirectToAction("Index");
            }

            return View(roles);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roles roles = _unitWork.RoleRepository.GetById(id.Value);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: Roles/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleName,Actions")] Roles roles)
        {
            if (ModelState.IsValid)
            {
                _unitWork.RoleRepository.Edit(roles);
                return RedirectToAction("Index");
            }
            return View(roles);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roles = _unitWork.RoleRepository.GetById(id.Value);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitWork.RoleRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
