using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxThrows = 3;
    public int currentThrows;

    void Start()
    {
        currentThrows = maxThrows;
    }

    public bool CanThrow()
    {
        return currentThrows > 0;
    }

    public void UseThrow()
    {
        if (currentThrows <= 0) return;
        currentThrows--;
    }

    public void AddThrow(int value)
    {
        currentThrows = Mathf.Min(currentThrows + value, maxThrows);
    }
}
