using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;



namespace Repository
{
   public class UserAccountRepository
    {
       ExamManagementDbContext db=new ExamManagementDbContext();

       //Add Register
       public bool RegisterAdd(UserAcount userAcount)
       {
           db.UserAcounts.Add(userAcount);
           return db.SaveChanges()>0;
       }
       //login user
       public UserAcount Login(UserAcount user)
       {
           return db.UserAcounts.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            
       }

       public bool Update(UserAcount userAcount)
       {
           db.UserAcounts.Attach(userAcount);
           db.Entry(userAcount).State = EntityState.Modified;
           return db.SaveChanges() > 0;
       }
       public bool Delete(int id)
       {
           var userAcount = db.UserAcounts.FirstOrDefault(c => c.UserId == id);
           if (userAcount != null)
           {
               userAcount.isDelete = true;
               return Update(userAcount);
           }
           return false;
       }

       //getAll Useraccount
       public List<UserAcount> GetAll()
       {

           List<UserAcount> userAcounts = db.UserAcounts.Where(c=>c.isDelete==false).ToList();
           return userAcounts;
       }

       public UserAcount GetById(int id)
       {

           var userAcount = db.UserAcounts.FirstOrDefault(c => c.UserId == id);
           return userAcount;
       }

    }
}
