using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tommyToScreen : MonoBehaviour
{

    public GunSystem tommy, shotgun;
    private string ammo;
    public TextMeshProUGUI ammoText;


    // Update is called once per frame
    void Update()
    {
        //Return current amount of bullets
        if (tommy.gameObject.activeInHierarchy){
            ammo = tommy.bltCount();
            ammoText.text = ammo;
        }
        else if(shotgun.gameObject.activeInHierarchy){
            ammo = shotgun.bltCount();
            ammoText.text = ammo;
        }


    }
}
