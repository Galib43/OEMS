using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BLL
{
   public class UserAccountManager
    {
       UserAccountRepository _userAccountRepository=new UserAccountRepository();


       //login register Add
       public bool Add(UserAcount userAcount)
       {
           return _userAccountRepository.RegisterAdd(userAcount);
       }

       //login

       public UserAcount Login(UserAcount userAcount)
       {
           return _userAccountRepository.Login(userAcount);
       }

       //GetAll Register
       public List<UserAcount> GetAll()
       {
           return _userAccountRepository.GetAll();
       }

       ///for update 
       /// 
       public bool Update(UserAcount userAcount)
       {
           return _userAccountRepository.Update(userAcount);
       }

       //for delete
       public bool Delete(int id)
       {
         return _userAccountRepository.Delete(id);         
       }

       public UserAcount GetById(int id)
       {
           return _userAccountRepository.GetById(id);
       }
    }
}
