using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 1.0f;
    public int damage = 10;
    public float lifeTime = 1.0f;
    public Vector2 direction;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            hitInfo.GetComponent<PlayerStats>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
