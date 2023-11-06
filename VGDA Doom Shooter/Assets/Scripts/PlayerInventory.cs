using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberCollected { get; private set; }

    public UnityEvent<PlayerInventory> OnGemCollected;

    public void ItemCollected()
    {
        NumberCollected++;
        OnGemCollected.Invoke(this);
    }
}
