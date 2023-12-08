using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int healthP;
    public int maxHealth = 100;
    public CapsuleCollider collider;
    public GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        healthP = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentHealth();
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Player took damage: " + amount);
        healthP -= amount;
        if(healthP <= 0)
        {
            Debug.Log("player died");
            GetCurrentHealth();
            //Destroy(gameObject);
        }
    }

    //return player health for health bar UI
    public int GetCurrentHealth()
    {
        return healthP;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    //collider to detect getting hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) //so it only collides with enemy tags
        {
            InvokeRepeating("DelayHealth", 1f, 1f);
        }
    }

    //to stop the health depleting when enemy is not colliding
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            CancelInvoke("DelayHealth");
        }
    }

    private void DelayHealth()
    {
        //To call invoke method
        TakeDamage(10);
    }
}
