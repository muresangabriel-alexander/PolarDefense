using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    public GameObject solarTower;

    void FixedUpdate()
    {
        if (solarTower != null)
        {
            GameObject currentTargetEnemy = solarTower.GetComponent<SolarTowerDamage>().targetEnemy;
            if (currentTargetEnemy != null && !currentTargetEnemy.CompareTag(Constants.SOLAR_PROJECTILE))
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, currentTargetEnemy.transform.position, Constants.NORMAL_ENEMY_SPEED * 6 * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SUNBURN");
        if (other.gameObject.tag == Constants.NORMAL_ENEMY)
        {
            UtilityHelpers.DecreaseEnemyhealth(other.gameObject, Constants.NORMAL_SOLAR_DAMAGE);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == Constants.TRUCK_ENEMY)
        {
            UtilityHelpers.DecreaseEnemyhealth(other.gameObject, Constants.TRUCK_SOLAR_DAMAGE);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == Constants.CRANE_TRUCK_ENEMY)
        {
            UtilityHelpers.DecreaseEnemyhealth(other.gameObject, Constants.CRANE_SOLAR_DAMAGE);
            Destroy(gameObject);
        }
    }
}
