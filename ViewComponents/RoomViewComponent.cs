using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ChatApp.Data;
using ChatApp.Models;


namespace ChatApp.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private ApplicationDbContext _db;

        public RoomViewComponent(ApplicationDbContext db) {
            _db = db;
               
        }
        public IViewComponentResult Invoke()
        {
            var userId= HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _db.ChatUsers.Include(x => x.Chatss).Where(x => x.UserId == userId && x.Chatss.Type == ChatType.Room).Select(x=>x.Chatss)
                .ToList(); 
           
            return View(chats);
        }
        
    }
}
