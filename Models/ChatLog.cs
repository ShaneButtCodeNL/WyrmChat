namespace WyrmChat.Models;
public class ChatLog{
   private static List<UserMessage> userMessages=new();

   public static List<UserMessage> GetChatLog=>userMessages;

   public static void AddMessage(UserMessage message){
      userMessages.Add(message);
   }
}