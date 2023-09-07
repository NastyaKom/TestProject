using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuardSpawn : MonoBehaviour
{
    [SerializeField] private GameObject quard;
    [SerializeField] private GameObject quardBonus; 


    public static QuardSpawn inststance { get; private set; }

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
            GameObject newQuard = Instantiate(quard, new Vector2(transform.position.x, transform.position.y + yQuardPosition), Quaternion.identity);
            newQuard.transform.parent = transform.parent;
            yield return new WaitForSeconds(randomSpawnTime);
        }
    }

    //Рандомное появление бонуса
    public IEnumerator BonusSpawm()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            float randomSpawnBonusTime = Random.Range(5f, 8f);
            float yQuardPosition = Random.Range(-3f, 3f);
            GameObject newQuard = Instantiate(quardBonus, new Vector2(transform.position.x, transform.position.y + yQuardPosition), Quaternion.identity);
            newQuard.transform.parent = transform.parent;
            yield return new WaitForSeconds(randomSpawnBonusTime);
        }
    }

}
