using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class enemyLogic : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    private int currentTargetCounter = 0;
    private bool targetFlipHandled = false;

    private Vector3 truckOffset = new Vector3(0.0f, 0.2f, 0.0f);

    private float speed = 0.0f;
    private int damage = 0;
    private int health = 0;
    private int enemypoints = 0;


    void Start()
    {
        initEnemyStats();
        // gameObject.GetComponent<enemyLogic>().health--;

    }
    private void initEnemyStats()
    {
        if (gameObject.tag == Constants.NORMAL_ENEMY)
        {
            speed = Constants.NORMAL_ENEMY_SPEED;
            damage = Constants.NORMAL_ENEMY_DAMAGE;
            health = Constants.NORMAL_ENEMY_HEALTH;
            enemypoints = Constants.NORMAL_ENEMY_POINTS;
        }
        else if (gameObject.tag == Constants.TRUCK_ENEMY)
        {
            speed = Constants.TRUCK_ENEMY_SPEED;
            damage = Constants.TRUCK_ENEMY_DAMAGE;
            health = Constants.TRUCK_ENEMY_HEALTH;
            enemypoints = Constants.TRUCK_ENEMY_POINTS;
        }
        else
        {
            speed = Constants.CRANE_TRUCK_ENEMY_SPEED;
            damage = Constants.CRANE_TRUCK_ENEMY_DAMAGE;
            health = Constants.CRANE_TRUCK_ENEMY_HEALTH;
            enemypoints = Constants.CRANE_TRUCK_ENEMY_POINTS;
        }
    }

    private float calculateDistance(Transform transformCar, Transform transformWaypoint)
    {
        float xDiff = Mathf.Pow(transformCar.position.x - transformWaypoint.position.x, 2);
        float yDiff = Mathf.Pow(transformCar.position.y - transformWaypoint.position.y, 2);
        float distance = Mathf.Sqrt(xDiff + yDiff);
        return distance;
    }

    private void calculateRotationinCurve(Transform target)
    {
        if (target.tag == Constants.CURVE_MIDDLE && !targetFlipHandled)
        {
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, 
                                                           gameObject.transform.localScale.y, 
                                                           gameObject.transform.localScale.z);
            targetFlipHandled = true;
        }
    }

    // disappear and appear again to show that damage was taken
    IEnumerator wait()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.enabled = !renderer.enabled;
        yield return new WaitForSeconds(0.2f);
        //renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a - 0.1f);
        renderer.enabled = !renderer.enabled;
    }

    private void FixedUpdate()
    {
        target = GameObject.Find($"waypoint ({currentTargetCounter})");

        if (gameObject.tag != Constants.NORMAL_ENEMY)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position + truckOffset, speed * Time.deltaTime);
        else
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
        calculateRotationinCurve(target.transform);

        if (calculateDistance(gameObject.transform, target.transform) < 0.3)
        {
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

            if (target.tag == Constants.TUNNEL_ENTRY)
                renderer.enabled = false;
            else if (target.tag == Constants.TUNNEL_EXIT)
                renderer.enabled = true;

            else if (target.tag == Constants.FINISH_LINE)
            {
                // TODO decrease player health once player scripts are there
                // player_health -= damage;
                GameObject[] variableForPrefab = Resources.LoadAll<GameObject>("Prefabs\\damageText");
                HealthBarScript.currentHealth -= damage;
                GameObject view = UtilityHelpers.showDamage(variableForPrefab[0], -damage);
                Destroy(gameObject);
                Debug.Log("Still running");
            }

            targetFlipHandled = false;
            currentTargetCounter++;
        }

        // TODO decrease enemy health once fire projectiles are here 
        // health -= towerdamage;
        // StartCoroutine(wait());
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // TODO increase status board counter of defeated enemies
            // statusboard_enemies_defeated += enemypoints;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        foreach(var enemy in EnemySpawner.allEnemies)
        {
            if (enemy == gameObject)
                EnemySpawner.allEnemies.Remove(enemy);
        }
    }
}
