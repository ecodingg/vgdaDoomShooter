using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int PacksCollected { get; private set; }

    public UnityEvent<PlayerInventory> OnHealthPCollected;

    public void ItemCollected()
    {
        PacksCollected++;
        OnHealthPCollected.Invoke(this);
    }
}
