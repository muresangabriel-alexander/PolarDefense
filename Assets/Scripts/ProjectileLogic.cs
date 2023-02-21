using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame+++
    void FixedUpdate()
    {
        // GameObject solarBeamPrefab = Resources.LoadAll<GameObject>("Prefabs\\SolarBeam")[0];
        // GameObject currentTargetEnemy = gameObject.GetComponent<SolarTowerDamage>().targetEnemy;
        GameObject currentTargetEnemy = SolarTowerDamage.targetEnemy;
        if (currentTargetEnemy != null && !currentTargetEnemy.CompareTag("SOLAR_PROJECTILE"))
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, currentTargetEnemy.transform.position, Constants.NORMAL_ENEMY_SPEED * 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO OnTrigger -> decrease enemy health respectively
        
        if (other.gameObject.CompareTag("NORMAL_ENEMY"))
        {
            Destroy(gameObject);
            Debug.Log("Collision with car");
        } else if (other.gameObject.CompareTag("CRANE_TRUCK_ENEMY"))
        {
            Destroy(gameObject);
            Debug.Log("Collision with crane");
        } else if (other.gameObject.CompareTag("TRUCK_ENEMY"))
        {
            Destroy(gameObject);
            Debug.Log("Collision with truck");
        }
    }
}
