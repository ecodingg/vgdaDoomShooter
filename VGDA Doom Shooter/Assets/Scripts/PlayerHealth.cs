using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int healthP;
    public int maxHealth = 100;
    public GameObject shot, tom;
    public GunSystem shotgun, tommy;

    // Start is called before the first frame update
    void Start()
    {
        healthP = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Player took damage: " + amount);
        healthP -= amount;
        if(healthP <= 0)
        {
            Destroy(gameObject);
        }
    }

<<<<<<< Updated upstream
    public void IncreaseHealth(int amount)
    {
        healthP += amount;
        if(healthP > maxHealth)
        {
            healthP = maxHealth;
=======
    public void getAmmo(){
        if(shot.activeInHierarchy == true){
            shotgun.collectAmmo(26);
        }
        else if (tom.activeInHierarchy == true){
            tommy.collectAmmo(60);
>>>>>>> Stashed changes
        }
    }
}
