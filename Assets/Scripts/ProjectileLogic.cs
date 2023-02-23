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
        // TODO DecreaseEnemyHealth 
        Destroy(gameObject);
    }
}
