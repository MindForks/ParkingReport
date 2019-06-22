
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using PR.Entities;
using PR.Interfaces;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;

using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PR.Data.Repositories
{
    public class UserRepository : IRepositoryAsync<User>
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public System.Threading.Tasks.Task CreateAsync(User item)
        {
            return _userManager.CreateAsync(item);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }

        public System.Threading.Tasks.Task UpdateAsync(User item)
        {
            return _userManager.UpdateAsync(item);
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return await _userManager.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public Task<User> GetItemAsync(string id)
        {

            return  _userManager.FindByIdAsync(id);

            return _userManager.FindByIdAsync(id);

        }

        public System.Threading.Tasks.Task SaveChangesAsync()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}
