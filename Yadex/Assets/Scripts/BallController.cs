using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject ballParticle;
    [SerializeField] private float force;
    private Rigidbody2D rbBall;

    bool isStart = true; 

    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        rbBall.isKinematic = true;
        ballParticle.SetActive(false); 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Barrier")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //”правление м€чом 
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isStart)
            {
                startText.SetActive(false);
                ballParticle.SetActive(true);
                rbBall.isKinematic = false;
                isStart = false;
                QuardSpawn.inststance.StartSpawn(); 
            }
            rbBall.AddForce(gameObject.transform.up * force);
        } 
    }
}
