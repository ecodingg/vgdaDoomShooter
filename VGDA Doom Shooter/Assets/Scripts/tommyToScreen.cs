using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tommyToScreen : MonoBehaviour
{

    public rayCastTommyGun tommy;
    private float ammo;
    private int ammoInt;
    public TextMeshProUGUI ammoText;


    // Update is called once per frame
    void Update()
    {
        //Return current amount of bullets
        ammo = tommy.bltCount();

        //Display Bullets to Screen
        int ammoInt = (int)ammo;
        ammoText.text = ammoInt.ToString() + "/30";

    }
}
