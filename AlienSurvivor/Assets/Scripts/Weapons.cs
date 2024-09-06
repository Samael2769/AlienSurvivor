using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        weapons[0].GetComponent<Blaster>().player = player;
        weapons[1].GetComponent<Scie>().player = player;
        weapons[2].GetComponent<OrbitalStrike>().player = player;
        weapons[0].GetComponent<Blaster>().level = player.GetComponent<PlayerStats>().level;
        weapons[1].GetComponent<Scie>().level = player.GetComponent<PlayerStats>().level;
        weapons[2].GetComponent<OrbitalStrike>().level = player.GetComponent<PlayerStats>().level;
        weapons[3].GetComponent<Shield>().level = player.GetComponent<PlayerStats>().level;
    }

    // Update is called once per frame
    void Update()
    {
        weapons[0].GetComponent<Blaster>().level = player.GetComponent<PlayerStats>().level;
        weapons[1].GetComponent<Scie>().level = player.GetComponent<PlayerStats>().level;
        weapons[2].GetComponent<OrbitalStrike>().level = player.GetComponent<PlayerStats>().level;
        weapons[3].GetComponent<Shield>().level = player.GetComponent<PlayerStats>().level;
    }
}
