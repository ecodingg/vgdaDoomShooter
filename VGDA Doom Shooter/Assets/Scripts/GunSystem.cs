using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;

    //Graphics
    //public ParticleSystem muzzleFlash;
    //public CamShake camShake;
    //public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;
    public AudioSource gunShot;//,reload
    public AudioClip impact, reload;
    public SpriteRenderer spriteRenderer;
    public Sprite hotGun, coolGun, midGun;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //SetText
        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading){
            Reload();
            gunShot.PlayOneShot(reload, 0.7f);
        } 

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = bulletsPerTap;
            Shoot();
            
        }

    }

    void hotSprite()
    {
        Debug.Log("Hot");
        spriteRenderer.sprite = hotGun;
    }

    void midSprite()
    {
        Debug.Log("Mid");
        spriteRenderer.sprite = midGun;
    }

    void coolSprite()
    {
        Debug.Log("Cool");
        spriteRenderer.sprite = coolGun;
        
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        hotSprite();
        

        //RayCast
        //muzzleFlash.Play();
        gunShot.PlayOneShot(impact, 0.7f);
        Debug.Log("Playing Gunshot");
        Invoke("midSprite",0.5f);
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);

            EnemyController target = rayHit.transform.GetComponent<EnemyController>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        Invoke("coolSprite",1f);

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0){
            Invoke("Shoot", timeBetweenShots);
            
        }
        
    }
    private void ResetShot()
    {
        readyToShoot = true;
        coolSprite();
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    public string bltCount(){
        return bulletsLeft + "/" + magazineSize;
    }
}
