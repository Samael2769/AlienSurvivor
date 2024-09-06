using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{

    public GameObject player;
    public GameObject projectilePrefab;
    public float speed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float distance = 1.0f;

    public float attackDistance = 1.0f;
    public float attackSpeed = 1.0f;
    public float attackCooldown = 1.0f;
    public float attackTimer = 0.0f;


    public int health = 100;
    public int damage = 10;


    public bool canCharge = true;
    private Vector2 direction;
    private Vector2 target;


    public int attackType = 0;
    // 0 = Range
    // 1 = Follow
    // 2 = charge

    // Start is called before the first frame update
    void Start()
    {
        direction = player.transform.position - transform.position;
        target = (Vector2)player.transform.position + (Vector2)direction.normalized * distance;
        Debug.Log(target);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        

        if (attackType == 0)
        {
            followPlayerStayDistance();
            if (Vector2.Distance(player.transform.position, transform.position) < attackDistance)
            {
                if (attackTimer <= 0)
                {
                    shootProjectile();
                    attackTimer = attackCooldown;
                }
                else
                {
                    attackTimer -= Time.deltaTime;
                }
            }
        }
        else if (attackType == 1)
        {
            followPlayerAttack();
        }
        else if (attackType == 2)
        {
            charge();
        }
    }

    void followPlayerStayDistance()
    {
        if (Vector2.Distance(player.transform.position, transform.position) > distance)   
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
    }

    void followPlayerAttack()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void shootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<projectile>().direction = player.transform.position - transform.position;
    }

    void charge()
    {
        if (canCharge) {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target) < 0.1f)
                canCharge = false;
        }
        if (!canCharge && Vector2.Distance(transform.position, target) < 1f){
            direction = player.transform.position - transform.position;
            target = (Vector2)player.transform.position + (Vector2)direction.normalized * distance;
            canCharge = true;
        }
    }

    public void OnCollideEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            hitInfo.GetComponent<PlayerStats>().takeDamage(damage);
            Destroy(gameObject);
        }
        if (hitInfo.tag == "PlayerProjectile")
        {
            health -= player.GetComponent<PlayerStats>().damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            hitInfo.GetComponent<PlayerStats>().takeDamage(damage);
            Destroy(gameObject);
        }
        if (hitInfo.tag == "PlayerProjectile")
        {
            health -= player.GetComponent<PlayerStats>().damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
