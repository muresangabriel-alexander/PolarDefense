using UnityEngine;

public class SolarTowerDamage : MonoBehaviour
{

    public GameObject targetEnemy = null;
    private float timer = 0.0f;

    void FixedUpdate()
    {
        if (targetEnemy != null)
        {
            if (timer > Constants.SOLAR_FIRE_FREQUENCY)
            {
                timer = 0.0f;
                // shooting projectile in ProjectileLogic.cs
                GameObject solarBeamPrefab = Resources.LoadAll<GameObject>("Prefabs\\SolarBeam")[0];
                
                GameObject solarBeamClone = Instantiate(solarBeamPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -2.0f), transform.rotation);
                solarBeamClone.GetComponent<ProjectileLogic>().solarTower = gameObject;
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == targetEnemy)
        {
            targetEnemy = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (targetEnemy == null && !other.CompareTag(Constants.SOLAR_PROJECTILE) && (other.gameObject.tag == Constants.NORMAL_ENEMY || other.gameObject.tag == Constants.TRUCK_ENEMY || other.gameObject.tag == Constants.CRANE_TRUCK_ENEMY))
        {
            targetEnemy = other.gameObject;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (targetEnemy == null && (other.gameObject.tag == Constants.NORMAL_ENEMY || other.gameObject.tag == Constants.TRUCK_ENEMY || other.gameObject.tag == Constants.CRANE_TRUCK_ENEMY))
        {
            targetEnemy = other.gameObject;
        }
        
    }
}    
