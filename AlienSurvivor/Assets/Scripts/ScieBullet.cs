using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScieBullet : MonoBehaviour
{
    public GameObject player;
    public float speed = 100.0f;
    public int damage = 10;
    public float distance = 2.0f; // Ajuster la distance de rotation autour du joueur

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Calcule l'offset initial (la distance entre la boule et le joueur)
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Fais tourner la boule autour du joueur
        rotateAroundPlayer();

        // Met à jour l'offset pour que la boule suive les déplacements du joueur tout en restant à distance constante
        transform.position = player.transform.position + offset;
    }

    void rotateAroundPlayer()
    {
        // Effectue la rotation autour du joueur à partir de la position actuelle
        offset = Quaternion.Euler(0, 0, speed * Time.deltaTime) * offset;
    }
}