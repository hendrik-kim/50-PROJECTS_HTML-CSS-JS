using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Data;
using Talent.Data.Models;
using Talent.Services.Repository.IRepository;

namespace Talent.Services.Repository
{
    public class ApplicationUserRepository : IAppUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(ApplicationUser user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deactivate(ApplicationUser user)
        {
            user.IsActive = false;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public ApplicationUser GetByName(string name)
        {
            return _dbContext.ApplicationUsers.FirstOrDefault(user => user.UserName == name);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _dbContext.ApplicationUsers;
        }

        public ApplicationUser GetById(string userId)
        {
            return _dbContext.ApplicationUsers.FirstOrDefault(user => user.Id == userId);
        }

        public async Task UpdateUserRating(string userId, Type type)
        {
            var user = GetById(userId);
            user.Rating = CalculateUserRating(type, user.Rating);
            await _dbContext.SaveChangesAsync();
        }

        private int CalculateUserRating(Type type, int userRating)
        {
            var inc = 0;

            if (type == typeof(Post))
            {
                inc = 3;
            }
            if (type == typeof(PostReply))
            {
                inc = 1;
            }
            return userRating + inc;
        }

        public ServiceResponse<ApplicationUser> CreateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ApplicationUser> UpdateUser(string userId, Type type)
        {
            var user = GetById(userId);
            _dbContext.Update(user);
            _dbContext.SaveChangesAsync();
            throw new NotImplementedException();
        }

        ServiceResponse<ApplicationUser> IAppUserRepository.Deactivate(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        //public async Task SetProfileImage(string id, Uri uri)
        //{
        //    var user = GetById(id);
        //    user.ProfileImageUrl = uri.AbsoluteUri;
        //    _dbContext.Update(user);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task BumpRating(string userId, Type type)
        //{
        //    var user = GetById(userId);
        //    var increment = GetIncrement(type);
        //    user.Rating += increment;
        //    await _dbContext.SaveChangesAsync();
        //}
    }
}
