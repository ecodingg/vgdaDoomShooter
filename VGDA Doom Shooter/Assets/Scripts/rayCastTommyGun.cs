using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastTommyGun : MonoBehaviour
{
    public float damage = 12.5f;
    public float range = 50f;

    public Camera fpsCam;

    private float maxBullets = 30;

    private float bullets;

    public ParticleSystem muzzleFlash;
    
    void Start()
    {
        bullets = maxBullets;
        //StartCoroutine(tommyGun());   
    }

    // Update is called once per frame
    //IEnumerator tommyGun()
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            if (bullets >= 1){
                Shoot();
                bullets -= 1;
                //yield return new WaitForSeconds(2);
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
