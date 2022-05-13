namespace WyrmChat.Models;
public class ChatLog{
   private List<UserMessage> userMessages=new();

   private List<User> userList=new();

   public List<UserMessage> GetChatLog=>userMessages;

   public bool IsPrivate{get;set;}

   public int ChatLogId{get;set;}

   public void AddMessage(UserMessage message){
      userMessages.Add(message);
   }

   public void AddUser(User user){
      if(user is not null)userList.Add(user);
   }

   public void RemoveUser(int id){
      var user=userList.Find(u=>u.UserID==id);
      if(user is null)return;
      userList.Remove(user);
   }

   public List<User> GetUserList(){
      return userList;
   }
}