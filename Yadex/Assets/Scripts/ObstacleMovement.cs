using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
  
    private float _speedObstacle = 6f;
    private float _speedObstacleUp = 2f;
    private Vector2 _startPosition;
    private float _movementRange = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        _startPosition = transform.position; 
    }


    //Движение препятствий 
    void FixedUpdate()
    {
        transform.position -= new Vector3(1f,0f, 0f) * Time.deltaTime * _speedObstacle;
        transform.position += transform.up * Time.deltaTime * _speedObstacleUp;
        if ((transform.position.y >= _startPosition.y + _movementRange ) || (transform.position.y <= _startPosition.y - _movementRange))
        {
            transform.Rotate(new Vector3(0, 0, 180));
        }

    }
}
