using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHandler : MonoBehaviour
{
    public int missileType = 0;
    public GameObject player;
    public float speed = 5.0f;
    public int damage = 10;
    public float lifeTime = 2.0f;

    public Vector3 direction;

    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (missileType == 0)
        {
            //follow player
            direction = player.transform.position - transform.position;
        }
        //look at direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        rb.velocity = direction.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().takeDamage(damage);
        }
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().takeDamage(damage);
        }
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
