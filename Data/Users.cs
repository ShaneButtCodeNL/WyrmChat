/**
Mimics a database to store user credentials while server is running
**/

using WyrmChat.Models;

namespace WyrmChat.Data;

public class Users{
   private static int NextId=1;
   public static List<User> UserList=new ();
   private static User? MakeUser(string username,string password){
      if(username is not null && password is not null && username !="" && password!=""){
         var user= new User(){UserName=username,UserID=NextId};
         user.UpdatePassword(password,"");
         NextId++;
         return user;
      }
      return null;
   }
   public static User? AddUser(string username,string password){
      var user=MakeUser(username,password);
      if(user is not null){
         UserList.Add(user);
         return user;
      }
      return null;
   }

   public static User? Login(string username,string password){
      var details=UserList.Find(u=>u.UserName==username&&u.CheckPassword(password));
      return details is null?null:details;
   }
}