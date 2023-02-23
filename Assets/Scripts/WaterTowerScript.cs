using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WaterTowerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] tower;

    private float cooldownTime;
    private float waterFloodedCountdown;
    private bool isFlooded;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tower[0];
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
                StartCoroutine(emptyWaterTower());
                isFlooded = false;
                waterFloodedCountdown = Constants.WATER_FLOODING_TIME;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canAttack && triggerIsEnemy(collision.tag))
        {
            cooldownTime = Constants.WATER_TOWER_FLOODING_RATE;
            StartCoroutine(fillWaterTower());
            StartCoroutine(spawnWater());
            isFlooded = true;
        }
    }

    IEnumerator spawnWater()
    {
        GameObject water = transform.GetChild(0).gameObject;
        water.SetActive(true);
        Vector3 pos = water.transform.position;
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
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

    IEnumerator fillWaterTower()
    {
        for (int i = 0; i < tower.Length; i++ )
        {
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.sprite = tower[i];
        }
    }

    IEnumerator emptyWaterTower()
    {
        for (int i = tower.Length - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.sprite = tower[i];
        }
    }

    public bool canAttack
    {
        get
        {
            return cooldownTime <= 0f && waterFloodedCountdown > 0f;
        }
    }

    public bool triggerIsEnemy(string tag)
    {
        return (tag == Constants.CRANE_TRUCK_ENEMY || tag == Constants.NORMAL_ENEMY || tag == Constants.TRUCK_ENEMY);
    }
}
