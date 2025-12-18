using System;
using MagicOnion;
using MagicOnion.Client;
using realtime_game.Shared;
using UnityEditor;
using UnityEngine;
using realtime_game.Shared.Interfaces.Services;

public class SampleScene : MonoBehaviour
{
    public string registname;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        try
        {
            registname = Guid.NewGuid().ToString();
            var channel = GrpcChannelx.ForAddress("http://localhost:5244");
            var client = MagicOnionClient.Create<IUserService>(channel);
            var result = await client.RegistUserAsync(registname);

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}