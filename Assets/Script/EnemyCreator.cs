using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private List <EnemyController> enemy;
    [SerializeField] private Transform[] waypoints;

    private int timeBetweenWaves = 20;
    private int wave = 0;
    

    private void Start()
    {       
        StartCoroutine(CreateWaveEnemies(wave));
    }

    private IEnumerator CreateWaveEnemies (int wave)
    {       
        while (wave != 1)
        {
            int enemiesAmount = (wave + 1) * 5;
            for (int i = 0; i < enemiesAmount; i++)
            {
                CreateEnemy(wave);

                yield return new WaitForSeconds(1f);
            }
            wave++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void CreateEnemy (int wave)
    {
        Instantiate(enemy[wave], transform.position, Quaternion.identity).GetComponent<EnemyController>().waypoints = waypoints;        
    }

    
}
