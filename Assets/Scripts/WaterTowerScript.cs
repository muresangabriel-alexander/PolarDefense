using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
        waterFloodedCountdown = Constants.WATER_FLOODING_TIME;
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
                StartCoroutine(removeWater());
                //transform.GetChild(0).gameObject.SetActive(false);
                isFlooded = false;
                waterFloodedCountdown = Constants.WATER_FLOODING_TIME;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canAttack && collision.tag != Constants.WATER)
        {
            cooldownTime = Constants.WATER_TOWER_FLOODING_RATE;
            StartCoroutine(spawnWater());
            isFlooded = true;
            //cooldownTime = Constants.WATER_TOWER_FLOODING_RATE;
        }
    }

    IEnumerator spawnWater()
    {
        GameObject water = transform.GetChild(0).gameObject;
        water.SetActive(true);
        Vector3 pos = water.transform.position;
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.03f);
            water.transform.position -= new Vector3(0, 0.15f, 0);
            water.transform.localScale += new Vector3(1, 1, 0);
        }

    }

    IEnumerator removeWater()
    {
        GameObject water = transform.GetChild(0).gameObject;
        Vector3 pos = water.transform.position;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.03f);
            water.transform.position += new Vector3(0, 0.15f, 0);
            water.transform.localScale -= new Vector3(1, 1, 0);
        }
        yield return new WaitForSeconds(0.03f);
        water.SetActive(false);
    }


    public bool canAttack
    {
        get
        {
            return cooldownTime <= 0f && waterFloodedCountdown > 0f;
        }
    }
}
