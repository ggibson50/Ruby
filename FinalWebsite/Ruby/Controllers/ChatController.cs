using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ruby.Models;
using Ruby.ViewModels;

namespace Ruby.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private RubyDBContext db = new RubyDBContext();

        // GET: Chat
        public ActionResult Index(Guid? serverId)
        {
            var userId = User.Identity.GetUserId();

            // Checks if current user is not in a server
            // Else redirects to action (Join Server)
            UserNotInServer(userId);

            if (serverId == null)
            {
                var defaultServer = (
                    from u in db.UserServers
                    where u.UserId == userId
                    orderby u.ServerId
                    select u
                ).FirstOrDefault();

                if (defaultServer != null)
                {
                    return RedirectToAction("Index", "Chat", new { defaultServer.ServerId });
                }
            }
            
            // Get list of members of current server
            var usersInServer = (
                from u in db.UserServers
                 where u.ServerId == serverId
                 select u
            ).ToList();

            // Get list of current user servers
            var userServers =
                from u in db.UserServers
                where u.UserId == userId
                select u.ServerId;

            // Show list of server's current user is in
            var userServerList = (
                from s in db.Servers
                where userServers.Contains(s.ServerId)
                select s
            ).ToList();
            
            var model = new ChatViewModel
            {
                CurrentServerId = serverId,
                Servers = userServerList,
                Chats = db.Chats.Where(x => x.ServerId == serverId).OrderBy(x => x.TimeSent).ToList(),
                //Friends = ,
                Members = usersInServer,
            };
            
            return View(model);
        }

        // NULL VALUE BUG - FIX LATER DATE
        public void UserNotInServer(string userId)
        {
            userId = User.Identity.GetUserId();

            var currentUser = (
                from u in db.Users
                join s in db.UserServers on u.UserId equals s.UserId
                where 
                u.UserId == userId /*&&*/
                //s.ServerId == null &&
                //s.UserId == null
                select s
            ).FirstOrDefault();

            if (currentUser.ServerId == null)
            {
                //return RedirectToAction("AddUserToServer", "Chat");
            }  
            else
            {
                //return View();
            }
        }

        [HttpPost]
        public JsonResult SendMessage(Guid? serverId, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return Json(false);
            }
            else
            {
                Chat msg = new Chat
                {
                    ChatId = Guid.NewGuid(),
                    Message = message,
                    TimeSent = DateTime.Now,
                    ServerId = serverId,
                    UserId = User.Identity.GetUserId(),
                };

                try
                {
                    db.Chats.Add(msg);
                    db.SaveChanges();
                    return Json(true);
                }
                catch (Exception)
                {
                    return Json(false);
                }
            }
        }

        [HttpPost]
        public ActionResult GetMessages(Guid? serverId)
        {
            var chats = (
                from c in db.Chats
                join u in db.Users on c.UserId equals u.UserId
                where c.ServerId == serverId
                orderby c.TimeSent
                select new { c.TimeSent, c.Message, u.UserName }
            );

            return Json(chats);
        }

        private void PopulateDropDowns()
        {
            var userId = User.Identity.GetUserId();

            var userServers =
                from u in db.UserServers
                where u.UserId == userId
                select u.ServerId;

            var servers =
                from s in db.Servers
                where !userServers.Contains(s.ServerId)
                orderby s.ServerName
                select s;

            ViewBag.Servers = servers.ToList();
        }

        [HttpGet]
        public ActionResult AddUserToServer()
        {
            PopulateDropDowns();
            return View();
        }

        [HttpPost]
        public ActionResult AddUserToServer(Guid serverId)
        {
            var userId = User.Identity.GetUserId();
            
            UserServer userServer = new UserServer
            {
                ServerId = serverId,
                UserId = userId
            };

            db.UserServers.Add(userServer);
            db.SaveChanges();
            return RedirectToAction("Index", routeValues: new { serverId = serverId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                db = null;
            }
            base.Dispose(disposing);
        }
    }
}