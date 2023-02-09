using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTowerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private float cooldownTime;
    private float waterFloodedCountdown;
    private bool isFlooded;
        private void Awake()
    {
    }
    void Start()
    {
        isFlooded = false;
        cooldownTime = 0.0f;
        waterFloodedCountdown = Constants.WATER_TOWER_FLOODING_RATE;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTime > 0f)
        {
            cooldownTime -= Time.deltaTime;
        }
        if (isFlooded)
        {
            if (waterFloodedCountdown > 0f)
            {
                waterFloodedCountdown -= Time.deltaTime;
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                isFlooded = false;
                waterFloodedCountdown = Constants.WATER_FLOODING_TIME;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canAttack)
        {
            cooldownTime = Constants.WATER_TOWER_FLOODING_RATE;
            transform.GetChild(0).gameObject.SetActive(true);
            isFlooded = true;
            cooldownTime = Constants.WATER_TOWER_FLOODING_RATE;
        }
    }

    public bool canAttack
    {
        get
        {
            return cooldownTime <= 0f & waterFloodedCountdown > 0f;
        }
    }
}
