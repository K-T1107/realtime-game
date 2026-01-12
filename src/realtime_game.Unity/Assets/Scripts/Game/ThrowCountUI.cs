using UnityEngine;
using UnityEngine.UI;

public class ThrowCountUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public Text throwCountText;

    void Update()
    {
        throwCountText.text =
            $"Throws: {inventory.currentThrows} / {inventory.maxThrows}";
    }
}