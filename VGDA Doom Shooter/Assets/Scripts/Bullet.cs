using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 75;
    public Rigidbody bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb.velocity = transform.forward * speed;
    }

}
