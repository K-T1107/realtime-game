using MagicOnion;
using MagicOnion.Server;
using realtime_game.Server.Models.Contexts;
using realtime_game.Shared.Interfaces.Services;
using realtime_game.Shared.Model.Entities;
using System;

namespace realtime_game.Server.Services
{
    public class UserService : ServiceBase<IUserService>, IUserService
    {
        public async UnaryResult<int> RegistUserAsync(string name)
        {
            using var context = new GameDbContext();
            //バリデーションチェック
            if (context.Users.Count() > 0 && context.Users.Where(user => user.Name == name).Count() > 0)
            {
                throw new ReturnStatusException(Grpc.Core.StatusCode.InvalidArgument, "");
            }


            //テーブルにレコードを追加
            User user = new User();
            user.Name = name;
            user.Token = Guid.NewGuid().ToString();
            user.Created_at = DateTime.Now;
            user.Updated_at = DateTime.Now;
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user.Id;
        }

        public async UnaryResult<List<User>> GetUsersAsync()
        {
            return new List<User>();
        }

        public UnaryResult<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public UnaryResult<bool> UpdateUserNameAsync(int id, string newName)
        {
            throw new NotImplementedException();
        }
    }

}
