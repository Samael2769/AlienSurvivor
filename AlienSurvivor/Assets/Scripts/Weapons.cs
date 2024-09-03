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
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].GetComponent<Blaster>().player = player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
