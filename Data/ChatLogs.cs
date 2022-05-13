/**
Mimics a database to store chatlogs while server is running
**/

using WyrmChat.Models;

namespace WyrmChat.Data;

public class ChatLogs{

   //Creates Very Simple Unique IDs
   private static int NextID=1;
   //List of ChatLogs
   private static List<ChatLog> ChatLogList=new List<ChatLog>(){};

   //Adds a public ChatLog to the chatlogList and updates nextId
   public static int  AddChatLog(){
      var CL=new ChatLog(){ChatLogId=NextID,IsPrivate=false};
      NextID++;
      ChatLogList.Add(CL);
      return NextID-1;
   }

   //Adds a private ChatLog to the chatlogList and updates nextId
   public static int AddPrivateChatLog(){
      var CL=new ChatLog(){ChatLogId=NextID,IsPrivate=true};
      NextID++;
      ChatLogList.Add(CL);
      return NextID-1;
   }

   //Retrives a ChatLog from list givenan ID return null if none found
   public static ChatLog? GetChatLog(int id){
      var CL= ChatLogList.Find(c=>c.ChatLogId==id);
      return CL;
   }

   //Adds a message to selected ChatLog if valid id and message
   public static void AddMessage(int id,UserMessage message){
      if(id < 0||message is null||message.Message=="")return;
      var CL=GetChatLog(id);
      if(CL is not null) CL.AddMessage(message);
   }

   //Get the list of ids for all active chatlogs
   public static List<int> GetListOfChatLogIDs(){
      List<int> res=new List<int>();
      foreach(var CL in ChatLogList) res.Add(CL.ChatLogId);
      return res;
   }

   //Returns if a list is empty
   public static bool IsEmpty()=>ChatLogList.Count==0;

}