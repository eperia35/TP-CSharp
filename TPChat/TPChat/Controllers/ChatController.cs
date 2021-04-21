using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPChat.Models;

namespace TPChat.Controllers
{
    public class ChatController : Controller
    {
        
        public static List<Chat> Chats = Chat.GetMeuteDeChats();


        // GET: Chat
        public ActionResult Index()
        {
            return View(Chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View(Chats.Where(c => c.Id == id).Single());
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Chats.Where(c => c.Id == id).Single());
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = Chats.FirstOrDefault(c => c.Id == id);
                if (chat != null)
                {
                    Chats.Remove(chat);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
