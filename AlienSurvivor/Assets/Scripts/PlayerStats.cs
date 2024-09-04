using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int life = 100;
    public int maxLife = 100;
    public int armor = 0;
    public float damageMultiplier = 1;
    public float speedMultiplier = 1;
    public int level = 1;

    public List<GameObject> shipsLevels = new List<GameObject>();
    public GameObject ship;


    // Start is called before the first frame update
    void Start()
    {
        ship = Instantiate(shipsLevels[level - 1], new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), transform.rotation);
        ship.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void upgradeLife(int amount)
    {
        life += amount;
        maxLife += amount;
    }

    void heal(int amount)
    {
        life += amount;
        if (life > maxLife)
        {
            life = maxLife;
        }
    }

    void upgradeArmor(int amount)
    {
        armor += amount;
    }

    void upgradeDamageMultiplier(float amount)
    {
        damageMultiplier += amount;
    }

    void upgradeSpeedMultiplier(float amount)
    {
        speedMultiplier += amount;
    }

    void takeDamage(int amount)
    {
        if (armor > 0)
        {
            armor -= amount;
            if (armor < 0)
            {
                life += armor;
                armor = 0;
            }
        }
        else
        {
            life -= amount;
        }
    }

    void levelUp()
    {
        upgradeLife(10);
        heal(maxLife);
        upgradeArmor(5);
        upgradeDamageMultiplier(0.5f);
        upgradeSpeedMultiplier(0.5f);
        level++;

        Destroy(ship);
        ship = Instantiate(shipsLevels[level - 1], new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), transform.rotation);
        ship.transform.parent = transform;
    }
}
