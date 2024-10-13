using System.Linq.Expressions;
using AwardEntity;
using Dal;
using Utility.Security;

namespace AwardService
{
    public class UserService : BaseCrudDal<User>
    {
        public override void Add(User entity)
        {
            User? otherUser = GetAll(new List<Expression<Func<User, bool>>>
            {
                user => user.Email == entity.Email
            }).FirstOrDefault();

            if (otherUser != null)
            {
                //TODO Hata mesajını göndür
                return;
            }

            entity.Password = PasswordHash.Hash(entity.Password); 
            base.Add(entity);
        }

        public override void Update(User entity)
        {
            User userOld = GetById(entity.Id)!;

            if (entity.Email != userOld.Email)
            {
                User? otherUser = GetAll(new List<Expression<Func<User, bool>>>
                {
                    user => user.Id != entity.Id,
                    user => user.Email == entity.Email
                }).FirstOrDefault();

                if (otherUser != null)
                {
                    //TODO Hata mesajını göndür
                    return;
                }
            } 

            base.Update(entity);
        } 
    }
}
