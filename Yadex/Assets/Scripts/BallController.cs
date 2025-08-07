using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _ballParticle;
    private float _force = 1000f;
    private Rigidbody2D _rbBall;
    private bool _isStart = true; 

    void Start()
    {
        _rbBall = GetComponent<Rigidbody2D>();
        _rbBall.isKinematic = true;
        _ballParticle.SetActive(false); 
    }


    //Столкновения с барьером
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Barrier")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //Управление мячом 
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetBallForce(_isStart); 
        } 
    }

    //Толчок мяча
    private void SetBallForce(bool isStart)
    {
        if (isStart)
        {
            _startText.SetActive(false);
            _ballParticle.SetActive(true);
            _rbBall.isKinematic = false;
            _isStart = false;
            QuardSpawn.inststance.StartSpawn();
        }
        _rbBall.AddForce(gameObject.transform.up * _force * Time.deltaTime);
    }
}
