using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    private float speedBonus = 6;
    private float distance = 2f;
    private GameObject ball;


    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
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
        if (Vector2.Distance(transform.position, ball.transform.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, ball.transform.position, 0.2f);
        }
        else
        {
            transform.position -= transform.right * Time.deltaTime * speedBonus;
        }
    }
}
