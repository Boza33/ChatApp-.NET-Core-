using ChatApp.Hubs;
using ChatApp.Infrastructure.Repository;
using ChatApp.Infrastructure;
using ChatApp.Models;
using ChatApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp_SignalR.Controllers
{
    [Authorize]
    [Route("controller")]
    public class ChatController : BaseController
    {
        private IHubContext<ChatHub> _chat;

        public ChatController(IHubContext<ChatHub> chat)
        {
            _chat = chat;
        }
        [HttpPost("[action]/{connectionId}/{roomName}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string roomName)
        {

            await _chat.Groups.AddToGroupAsync(connectionId, roomName);

            return Ok();
        }
        [HttpPost("[action]/{connectionId}/{roomName}")]

        public async Task<IActionResult> LeaveRoom(string connectionId, string roomName)
        {

            await _chat.Groups.AddToGroupAsync(connectionId, roomName);

            return Ok();
        }
        [HttpPost("action")]
        public async Task<IActionResult> SendMessaage(int chatId, string message, [FromServices] IChatRepository repo)
        {
            var Message = await repo.CreateMessage(chatId, message, User.Identity.Name);

            await _chat.Clients.Group(chatId.ToString())
                .SendAsync("ReciveMessage", new
                {
                    Text = Message.Text,
                    Name = Message.Name,
                    Timestamp = Message.Timestamp.ToString("dd/MM/yyyy hh:mm:ss")
                });

            return Ok();
        }
    }
}