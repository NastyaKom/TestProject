using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    public static Score instance { get; private set; }
    private int _score = 0; 

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    //Изменение счётв
    public void AddScore()
    {
        _score++;
        textScore.text = _score + ""; 
    }

}
