using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthP;
    public int maxHealth = 100;

    void Start()
    {
        healthP = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Player took damage: " + amount);
        healthP -= amount;
        if (healthP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Player died lol");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Name of the object: " + other.gameObject.name);

       
            //Using damageP from Enemy Controller
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                TakeDamage(enemyController.damageP);
            }
            else
            {
                Debug.LogError("EnemyController component not found on collided object!");
            }
        }
    }
}

