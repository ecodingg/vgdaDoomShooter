using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastPistol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    private float maxBullets = 6;

    private float bullets;

    public ParticleSystem muzzleFlash;
    
    void Start()
    {
        bullets = maxBullets;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            if (bullets >= 1){
                Shoot();
                bullets -= 1;
            }
        }
         
        if (Input.GetKeyDown(KeyCode.R)){
            Reload();
        }
    }

    void Shoot()
    {
        Debug.Log("Fire");
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

        }
    }

    void Reload()
    {
        bullets = maxBullets;
    }

    public float bltCount()
    {
        return bullets;
    }
}
