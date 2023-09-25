using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shotgunToScreen : MonoBehaviour
{

    public rayCastShotgun shotgun;
    private float ammo;
    private int ammoInt;
    public TextMeshProUGUI ammoText;


    // Update is called once per frame
    void Update()
    {
        //Return current amount of bullets
        ammo = shotgun.bltCount();

        //Display Bullets to Screen
        int ammoInt = (int)ammo;
        ammoText.text = ammoInt.ToString() + "/13";

    }
}
