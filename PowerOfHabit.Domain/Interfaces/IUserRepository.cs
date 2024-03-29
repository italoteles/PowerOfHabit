﻿using PowerOfHabit.Domain.Entities;

namespace PowerOfHabit.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetRoleUser(int id);
        Task<User> GetByIdAsync(int? id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(User user);

        Task<User> Authenticate(string userName, string password);
    }
}

