using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class SolarTowerDamage : MonoBehaviour
{

    public static GameObject targetEnemy = null;
    private float timer = 0.0f;

    void Start()
    {
        // _waypoints = GameObject.Find("waypoints");
        // foreach (Transform currentChild in _waypoints.transform.GetComponentsInChildren<Transform>())
        // {
        //     if (null == currentChild.gameObject) continue;
        //     
        //     waypointChildren.Add(currentChild);
        // }
    }

    void FixedUpdate()
    {
        if (targetEnemy != null)
        {
            if (timer > Constants.SOLAR_FIRE_FREQUENCY)
            {
                timer = 0.0f;
                // shooting projectile in ProjectileLogic.cs
                var currentSolarTower = gameObject;
                GameObject solarBeamPrefab = Resources.LoadAll<GameObject>("Prefabs\\SolarBeam")[0];
                Instantiate(solarBeamPrefab);
                
                // TODO projectile should start from right position (currentSolarTower)
            }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }
        else
        {
            timer = 0.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetEnemy)
        {
            targetEnemy = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (targetEnemy == null)
        {
            targetEnemy = other.gameObject;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (targetEnemy == null)
        {
            targetEnemy = other.gameObject;
        }
        
    }

    // void findNearestWaypoint()
    // {
    //     List<Double> eucDistances = new List<Double>();
    //
    //
    //     foreach (Transform currentWP in waypointChildren)
    //     {
    //
    //         Vector3 enemyPosition = gameObject.transform.position;
    //         Vector3 currentWPPosition = currentWP.transform.position;
    //
    //         float xDif = enemyPosition.x - currentWPPosition.x;
    //         float yDif = enemyPosition.y - currentWPPosition.y;
    //
    //         float currentEucDis = (float)Math.Sqrt(xDif * xDif - yDif * yDif);
    //         if (!float.IsNaN(currentEucDis)) eucDistances.Add(currentEucDis);
    //     }
    //     
    //
    //     Double minDistance = eucDistances.Min();
    //     int wpIndex = eucDistances.FindIndex(minDistance1 => (minDistance1 == minDistance));
    //
    //     if (wpIndex != -1)
    //     {
    //         Transform nearestWP = waypointChildren[wpIndex - 1];
    //         Vector3 flattened = new Vector3(0, 0, nearestWP.rotation.z);
    //
    //         Vector2 directionVec = nearestWP.position - transform.position;
    //
    //         eucDistances.Clear();
    //         directionTriangle.transform.rotation = Quaternion.FromToRotation(Vector3.up, directionVec);
    //         directionTriangle.transform.position = transform.position;
    //         // directionTriangle.transform.LookAt(flattened);
    //         // directionTriangle.transform.rotation = Quaternion.Euler(new Vector3(directionTriangle.transform.rotation.x, directionTriangle.transform.rotation.y, 0));
    //     }
    // }
    
    
}    
