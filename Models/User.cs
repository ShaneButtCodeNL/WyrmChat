namespace WyrmChat.Models;

public class User{
   public string? UserName{get;set;}
   private string? Password{get;set;}
   public int UserID{get;set;}

   public bool CheckPassword(string pass){
      return pass==Password;
   }

   public void UpdatePassword(string newPass,string? oldPass){
      if(Password is null||Password == ""||Password==oldPass){
         Password = newPass;
      }
   }
}

#line default
#line hidden
#nullable disable