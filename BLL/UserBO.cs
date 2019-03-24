using DAL;
using DataStructure;
using System;
using System.Security.Cryptography;
using DAL.Utility;

namespace BLL
{
    public class UserBO : BusinessBase<User>
    {
        public User Loging(User user)
        {
            user.Password = StringUtils.HashPassword(user.Password);
            return base.FirstOrDefault(c => c.Username == user.Username && c.Password == user.Password);
        }

        public override void CheckConstraint(User obj)
        {
            User user = base.FirstOrDefault(c => c.Username == obj.Username);
            if (user != null)
            {
                throw new Exception("کاربر دیگری با این نام کاربری در سامانه وجود دارد");
            }

            if (string.IsNullOrEmpty(obj.FirstName))
            {
                throw new Exception("لطفا نام کاربر را وارد کنید");
            }

            if (string.IsNullOrEmpty(obj.LastName))
            {
                throw new Exception("لطفا نام خانوادگی کاربر را وارد کنید");
            }

            if (string.IsNullOrEmpty(obj.Password))
            {
                throw new Exception("لطفا رمز عبور کاربر را وارد کنید");
            }

            if (obj.Password != obj.ConfirmPassword)
            {
                throw new Exception("رمز عبور با تکرار رمز عبور مطابقت ندارد");
            }

            obj.Password = StringUtils.HashPassword(obj.Password);
        }

        public override bool Insert(User obj)
        {
            obj.Id = Guid.NewGuid();
            return base.Insert(obj);
        }
    }
}
