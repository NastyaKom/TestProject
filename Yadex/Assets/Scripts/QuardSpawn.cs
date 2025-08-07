using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuardSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _quard;
    [SerializeField] private GameObject _quardBonus; 
    public static QuardSpawn inststance { get; private set; }
    private float _bonusSpawnTimer = 3f;

    void Start()
    {
        if (inststance == null)
        {
            inststance = this; 
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(QuardSpawm());
        StartCoroutine(BonusSpawm()); 
    }

    //Рандомное появление препятствия
    public IEnumerator QuardSpawm()
    {

        while (true)
        {
            float randomSpawnTime = Random.Range(1f, 2f);
            float yQuardPosition = Random.Range(-3f, 3f);
            GameObject newQuard = Instantiate(_quard, new Vector3(transform.position.x, transform.position.y + yQuardPosition, transform.position.z), Quaternion.identity);
            newQuard.transform.parent = transform.parent;
            yield return new WaitForSeconds(randomSpawnTime);
        }
    }

    //Рандомное появление бонуса
    public IEnumerator BonusSpawm()
    {
        yield return new WaitForSeconds(_bonusSpawnTimer);
        while (true)
        {
            float randomSpawnBonusTime = Random.Range(5f, 8f);
            float yQuardPosition = Random.Range(-3f, 3f);
            GameObject newQuard = Instantiate(_quardBonus, new Vector2(transform.position.x, transform.position.y + yQuardPosition), Quaternion.identity);
            newQuard.transform.parent = transform.parent;
            yield return new WaitForSeconds(randomSpawnBonusTime);
        }
    }

}
