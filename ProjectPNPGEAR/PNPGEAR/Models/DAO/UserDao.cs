using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.UserID);
                user.LastName = entity.LastName;
                user.FirstName = entity.FirstName;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = entity.ModifiedBy;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
           
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page,int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString) || x.LastName.Contains(searchString) || x.FirstName.Contains(searchString));
            }
            //OrderbyDescending la danh sach xep theo thu tu giam dan dua vao ngay tao
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page,pageSize);
        }

        //GetbyId lay username khi user login ben client
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName,string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status==false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }

        }
    }
}
