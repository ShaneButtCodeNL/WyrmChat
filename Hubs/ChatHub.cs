using Microsoft.AspNetCore.SignalR;
using WyrmChat.Models;

namespace WyrmChat.Hubs;
public class ChatHub : Hub{
   public async Task SendMessage(string user,string message){
      await Clients.All.SendAsync("RecieveMessage",user,message);
   }

   public async Task AddToChat(int chatID){
      await Groups.AddToGroupAsync(Context.ConnectionId,chatID.ToString());
      await Clients.Caller.SendAsync("UpdateListForClient",chatID);
      await Clients.All.SendAsync("UpdateChatRoomList");
   }

   public async Task RemoveFromChat(int chatID){
      await Groups.RemoveFromGroupAsync(Context.ConnectionId,chatID.ToString());
   }

   public async Task SendMessageToGroup(User user,string message,int chatID){
      await Clients.Group(chatID.ToString()).SendAsync("RecieveMessageToGroup",user.UserName,message,chatID);
   }
}