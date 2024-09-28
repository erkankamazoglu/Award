using AwardEntity;
using Dal;
using Utility.Security;

namespace AwardService
{
    public class UserService : BaseCrudDal<User>
    {
        public override void Add(User entity)
        {
            entity.Password = PasswordHash.Hash(entity.Password);

            base.Add(entity);
        }
    }
}
