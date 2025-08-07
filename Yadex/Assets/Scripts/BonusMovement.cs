using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    private float _speedBonus = 6f;
    private float _distance = 2f;
    private float _towardSpeed = 8f;
    private GameObject _ball;


    private void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Score.instance.AddScore();
            Destroy(gameObject); 
        }
    }

    // Движение бонуса
    void Update()
    {
        if (Vector2.Distance(transform.position, _ball.transform.position) < _distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _ball.transform.position, _towardSpeed * Time.deltaTime);
        }
        else
        {
            transform.position -= transform.right * Time.deltaTime * _speedBonus;
        }
    }
}
