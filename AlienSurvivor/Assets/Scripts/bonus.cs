using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    public int type = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if (type == 0)
            {
                player.GetComponent<PlayerStats>().heal(10);
            }
            if (type == 1)
            {
                int randX = Random.Range(0, 5);
                switch (randX)
                {
                    case 0:
                        player.GetComponent<PlayerStats>().upgradeLife(10);
                        break;
                    case 1:
                        player.GetComponent<PlayerStats>().upgradeDamage(5);
                        break;
                    case 2:
                        player.GetComponent<PlayerStats>().upgradeSpeedMultiplier(0.1f);
                        break;
                    case 3:
                        player.GetComponent<PlayerStats>().upgradeDamageMultiplier(0.1f);
                        break;
                    case 4:
                        player.GetComponent<PlayerStats>().upgradeArmor(5);
                        break;
                }
            }
            else if (type == 2)
            {
                player.GetComponent<PlayerStats>().addExperience(10);
            }
        }
        Destroy(gameObject);
    }
}
