using UnityEngine;
using UnityEngine.UI;

public class StoneInventory : MonoBehaviour
{
    public int maxStones = 3;
    public Image[] slots;

    int currentCount = 0;

    void Start()
    {
        UpdateUI();
    }

    public bool HasStone()
    {
        return currentCount > 0;
    }

    public bool CanAddStone()
    {
        return currentCount < maxStones;
    }

    public void AddStone()
    {
        if (!CanAddStone()) return;

        currentCount++;
        UpdateUI();
    }

    public void UseStone()
    {
        if (!HasStone()) return;

        currentCount--;
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].color = (i < currentCount) ? Color.white : Color.gray;
        }
    }
}