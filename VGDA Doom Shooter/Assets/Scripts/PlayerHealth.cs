using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int healthP;
    public int maxHealth = 100;
    public EnemyController enemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        healthP = maxHealth;
        enemyDamage = GetComponent<EnemyController>();
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
            Debug.Log("Player died lol");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            Debug.Log("Name of the object: " + other.gameObject.name);
            TakeDamage(enemyDamage);
        }
    }

}
