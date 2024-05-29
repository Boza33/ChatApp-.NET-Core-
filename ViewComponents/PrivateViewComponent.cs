using Microsoft.AspNetCore.Mvc;
using ChatApp.Data;
using ChatApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;

namespace ChatApp.ViewComponents
{
    public class PrivateViewComponent : ViewComponent
    {
        private ApplicationDbContext _db;
        public PrivateViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _db.Chats
                .Include(x => x.ChatUser)
                .ThenInclude(x => x.User)
                .Where(x => x.Type == ChatType.Private && x.ChatUser
                .Any(y => y.UserId == userId))
                .ToList();
            return View(chats);
        }
    } 
}
