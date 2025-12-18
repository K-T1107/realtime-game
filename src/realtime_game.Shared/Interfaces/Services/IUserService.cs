using MagicOnion;
using realtime_game.Shared.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realtime_game.Shared.Interfaces.Services
{
    public interface IUserService : IService<IUserService>
    {
        UnaryResult<int> RegistUserAsync(string name);

        //id指定でユーザー情報を取得するAPI
        UnaryResult<User> GetUserByIdAsync(int id);

        ////ユーザー一覧を取得するAPI
        UnaryResult<List<User>> GetUsersAsync();

        //id指定でユーザー名を更新するAPI
        UnaryResult<bool> UpdateUserNameAsync(int id, string newName);
    }
}
