using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
  
    private float speedObstacle = 6f;
    private float speedObstacleUp = 2f;
    private Vector2 startPosition;
    private float movementRange = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        startPosition = transform.position; 
    }


    //Движение препятствий 
    void FixedUpdate()
    {
        transform.position -= new Vector3(1f,0f, 0f) * Time.deltaTime * speedObstacle;
        transform.position += transform.up * Time.deltaTime * speedObstacleUp;
        if ((transform.position.y >= startPosition.y + movementRange ) || (transform.position.y <= startPosition.y - movementRange))
        {
            transform.Rotate(new Vector3(0, 0, 180));
        }

    }
}
