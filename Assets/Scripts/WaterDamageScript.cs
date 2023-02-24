using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamageScript : MonoBehaviour
{
    private float damageOverTimePeriod = 0;

    // Start is called before the first frame update
    void Start()
    {
        damageOverTimePeriod = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (damageOverTimePeriod > 0f)
        {
            damageOverTimePeriod -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (triggerIsEnemy(collision.tag))
        {
            if (damageOverTimePeriod <= 0f)
            {
                UtilityHelpers.DecreaseEnemyhealth(collision.gameObject, 1);
                damageOverTimePeriod = Constants.WATER_TOWER_DAMAGE_OVER_TIME_PERIOD;
            }
        }
    }

    private bool triggerIsEnemy(string tag)
    {
        return (tag == Constants.CRANE_TRUCK_ENEMY || tag == Constants.NORMAL_ENEMY || tag == Constants.TRUCK_ENEMY);
    }
}
