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
        var currentTargetEnemy = SolarTowerDamage.targetEnemy;
        if (currentTargetEnemy != null)
        {
            Debug.Log("ProjectileLogic: " + currentTargetEnemy.name);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, currentTargetEnemy.transform.position, Constants.NORMAL_ENEMY_SPEED * 2 * Time.deltaTime);
        }
    }
    
    // TODO OnCollision -> destroy projectile and decrease enemy health
}
