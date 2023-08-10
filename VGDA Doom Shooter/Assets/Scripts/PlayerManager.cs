using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is supposed to go under a "game manager" - not sure where that goes in our case at this time

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this; 
    }

    #endregion

    public GameObject player;
}
