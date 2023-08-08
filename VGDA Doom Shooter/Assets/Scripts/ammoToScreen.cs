using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ammoToScreen : MonoBehaviour
{

    public Pistol pistol;
    private float ammo;
    private int ammoInt;
    public TextMeshProUGUI ammoText;


    // Update is called once per frame
    void Update()
    {
        //Return current amount of bullets
        ammo = pistol.bulletCount();

        //Display Bullets to Screen
        int ammoInt = (int)ammo;
        ammoText.text = ammoInt.ToString() + "/6";

    }
}
