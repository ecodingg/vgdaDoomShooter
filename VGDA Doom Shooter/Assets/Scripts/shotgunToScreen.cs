using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shotgunToScreen : MonoBehaviour
{

    public GunSystem shotgun;
    private string ammo;
    public TextMeshProUGUI ammoText;


    // Update is called once per frame
    void Update()
    {
        //Return current amount of bullets
        ammo = shotgun.bltCount();

        ammoText.text = ammo;


    }
}
