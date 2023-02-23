using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public static int waveNum = 1;
    public static int enemiesInWave = 30;
    public Vector3 initSpawnPointNormal = new Vector3(-9.94f, -4.61f, 0);
    public Vector3 initSpawnPointTruck= new Vector3(-9.94f, -4.36f, 0);
    public Vector3 initSpawnPointCraneTruck= new Vector3(-9.94f, -4.384295f, 0);
    public List<Constants.EnemyType> enemySpawnProbabilty = new List<Constants.EnemyType>();
    private float timer = 15.0f;

    [SerializeField]
    private GameObject NormalEnemy;
    [SerializeField]
    private GameObject TruckEnemy;
    [SerializeField]
    private GameObject CraneTruckEnemy;

    void Start()
    {

        for(int i = 0; i < 7; i++)
            enemySpawnProbabilty.Add(Constants.EnemyType.NORMAL_ENEMY);

        for (int i = 0; i < 3; i++)
            enemySpawnProbabilty.Add(Constants.EnemyType.TRUCK_ENEMY);
        
        enemySpawnProbabilty.Add(Constants.EnemyType.CRANE_TRUCK_ENEMY);

        System.Random random = new System.Random();
        enemySpawnProbabilty = enemySpawnProbabilty.OrderBy(item => random.Next()).ToList();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (timer < Constants.ENEMY_SPAWN_RATE)
        {
            timer += Time.fixedDeltaTime;
        }
        else
        {
            timer = 0.0f;
            System.Random random = new System.Random();
            int rand_num = random.Next(0, enemySpawnProbabilty.Count);

            switch (enemySpawnProbabilty[rand_num])
            {
                case Constants.EnemyType.NORMAL_ENEMY:
                    Instantiate(NormalEnemy, initSpawnPointNormal, NormalEnemy.transform.rotation);
                    break;
                case Constants.EnemyType.TRUCK_ENEMY:
                    Instantiate(TruckEnemy, initSpawnPointTruck, TruckEnemy.transform.rotation);
                    break;
                case Constants.EnemyType.CRANE_TRUCK_ENEMY:
                    Instantiate(CraneTruckEnemy, initSpawnPointCraneTruck, CraneTruckEnemy.transform.rotation);
                    break;
            }
        }
    }
}
