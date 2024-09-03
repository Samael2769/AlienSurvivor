using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 10;
    public float lifeTime = 2.0f;
    public Rigidbody2D rb;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //abs value of player velocity
        speed = speed + player.GetComponent<PlayerMovement>().speed * player.GetComponent<PlayerStats>().speedMultiplier;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
