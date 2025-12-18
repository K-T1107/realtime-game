using Cysharp.Threading.Tasks;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Client;
using realtime_game.Shared.Interfaces.Services;
using realtime_game.Shared.Model.Entities;
using UnityEngine;

public class UserModel : BaseModel
{
    User user;
    private int userId;

    public async UniTask<bool> RegistUserAsync(string name)
    {
        var channel = GrpcChannelx.ForAddress(ServerURL);
        var client = MagicOnionClient.Create<IUserService>(channel);

        try
        {
            userId = await client.RegistUserAsync(name);
            return true;
        }
        catch (RpcException e)
        {
            Debug.Log(e);
            return false;
        }
    }

    public async UniTask<User> GetUserByIdAsync(int id)
    {
        var channel = GrpcChannelx.ForAddress(ServerURL);
        var client = MagicOnionClient.Create<IUserService>(channel);

        try
        {
            user = await client.GetUserByIdAsync(id);
            return user;
        }
        catch (RpcException e)
        {
            Debug.Log(e);
            return null;
        }
    }
}