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
                
                GameObject solarBeamClone = Instantiate(solarBeamPrefab, transform.position, transform.rotation);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetEnemy)
        {
            targetEnemy = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (targetEnemy == null && !other.CompareTag(Constants.SOLAR_PROJECTILE))
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
}    
