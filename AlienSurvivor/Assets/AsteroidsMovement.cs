using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMovement : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public bool doMove = true;
    public float speed = 1.0f;
    public int distance = 10;
    private Vector2 initialPosition;
    private bool side = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        rotationSpeed = Random.Range(rotationSpeed - 50, rotationSpeed + 50);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        if (doMove)
        {
            Move();
        }
    }

    void Move()
    {
        if (side)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + distance, transform.position.y), speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, initialPosition) >= distance)
            {
                side = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - distance, transform.position.y), speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, initialPosition) <= 3)
            {
                side = true;
            }
        }
    }
}
