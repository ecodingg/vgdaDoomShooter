using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    private float maxBullets = 6;

    private float bullets;
    
    void Start()
    {
        bullets = maxBullets;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if (bullets >= 1){
                Instantiate(bullet, barrel.position, barrel.rotation);
                bullets -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)){
            bullets = maxBullets;
        }
    }

    public float bulletCount(){
        return bullets;
    }
}
