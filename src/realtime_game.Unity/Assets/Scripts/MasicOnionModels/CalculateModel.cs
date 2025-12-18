using Cysharp.Threading.Tasks;
using MagicOnion.Client;
using MagicOnion;
using UnityEngine;
using realtime_game.Shared.Interfaces.Services;

public class CalculateModel : MonoBehaviour
{
    const string ServerURL = "http://localhost:5244";

    async void Start()
    {
        // 接続
        var channel = GrpcChannelx.ForAddress(ServerURL);
        var client = MagicOnionClient.Create<ICalculateService>(channel);

        // 乗算
        int mulResult = await client.MulAsync(100, 323);
        Debug.Log($"[MulAsync] 100 × 323 = {mulResult}");

        // 配列の合計
        int sumResult = await client.SumAllAsync(new int[] { 10, 20, 30, 40 });
        Debug.Log($"[SumAllAsync] 合計 = {sumResult}");

        // 四則演算
        int[] calcResults = await client.CalcForOperationAsync(50, 10);
        Debug.Log($"[CalcForOperationAsync] +:{calcResults[0]}, -:{calcResults[1]}, *:{calcResults[2]}, /:{calcResults[3]}");

        // Numberの合計
        var num = new Number { x = 1.5f, y = 2.5f, z = 3.5f };
        float numSum = await client.SumAllNumberAsync(num);
        Debug.Log($"[SumAllNumberAsync] x+y+z = {numSum}");
    }
}