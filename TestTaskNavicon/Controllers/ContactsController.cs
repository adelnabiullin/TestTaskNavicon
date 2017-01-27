using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestTaskNavicon.Models;
using PagedList;
using System.Collections.Generic;

namespace TestTaskNavicon.Controllers
{
    public class ContactsController : Controller
    {
        private ContactDBContext db = new ContactDBContext();

        // GET: Contacts
        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            // сортировка распространяется на все данные, а не только на текущую страницу пагинации
            // число контактов на страницу маленькое для наглядности
            int pageSize = 4;
            int pageIndex = page ?? 1;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "none" : sortOrder;
            CurrentSort = string.IsNullOrEmpty(CurrentSort) ? "none" : CurrentSort;
            ViewBag.CurrentPage = pageIndex;
            sortOrder = string.IsNullOrEmpty(sortOrder) ? "name" : sortOrder;
            IOrderedQueryable<Contact> contacts = null;
            switch(sortOrder)
            {
                case "name":
                    if (sortOrder.Equals(CurrentSort))
                    {
                        contacts = db.contacts.OrderByDescending(m => m.name);
                        ViewBag.CurrentSort = "none";
                    }
                    else
                        contacts = db.contacts.OrderBy(m => m.name);
                    break;
                case "surname":
                    if (sortOrder.Equals(CurrentSort))
                    {
                        contacts = db.contacts.OrderByDescending(m => m.surname);
                        ViewBag.CurrentSort = "none";
                    }
                    else
                        contacts = db.contacts.OrderBy(m => m.surname);
                    break;
                case "patronymic":
                    if (sortOrder.Equals(CurrentSort))
                    {
                        contacts = db.contacts.OrderByDescending(m => m.patronymic);
                        ViewBag.CurrentSort = "none";
                    }
                    else
                        contacts = db.contacts.OrderBy(m => m.patronymic);
                    break;
                case "birthday":
                    if (sortOrder.Equals(CurrentSort))
                    {
                        contacts = db.contacts.OrderByDescending(m => m.birthday);
                        ViewBag.CurrentSort = "none";
                    }
                    else
                        contacts = db.contacts.OrderBy(m => m.birthday);
                    break;
                case "sex":
                    if (sortOrder.Equals(CurrentSort))
                    {
                        contacts = db.contacts.OrderByDescending(m => m.sex);
                        ViewBag.CurrentSort = "none";
                    }
                    else
                        contacts = db.contacts.OrderBy(m => m.sex);
                    break;
                case "age":
                    if (sortOrder.Equals(CurrentSort))
                    {
                        contacts = db.contacts.OrderBy(m => m.birthday);
                        ViewBag.CurrentSort = "none";
                    }
                    else
                        contacts = db.contacts.OrderByDescending(m => m.birthday);
                    break;
                default:
                    contacts = db.contacts.OrderBy(m => m.name);
                    break;
            }
            return View(contacts.ToPagedList(pageIndex, pageSize));
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,surname,patronymic,birthday,sex")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,surname,patronymic,birthday,sex")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.contacts.Find(id);
            db.contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatchDelete(int[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                List<Contact> contactsToDelete = new List<Contact>();
                for (int i = 0; i < ids.Length; ++i)
                {
                    Contact contact = db.contacts.Find(ids[i]);
                    if (contact == null)
                    {
                        return HttpNotFound();
                    }
                    contactsToDelete.Add(contact);
                }
                foreach (Contact c in contactsToDelete)
                {
                    db.contacts.Remove(c);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
