using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTowerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite tower1;
    public Sprite tower2;
    public Sprite tower3;
    public Sprite tower4;

    private float cooldownTime;
    private float waterFloodedCountdown;
    private bool isFlooded;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
    }
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tower1;
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
            StartCoroutine(wait());
            cooldownTime = Constants.WATER_TOWER_FLOODING_RATE;
            transform.GetChild(0).gameObject.SetActive(true);
            isFlooded = true;
            cooldownTime = Constants.WATER_TOWER_FLOODING_RATE;
        }
    }

    IEnumerator wait()
    {
        spriteRenderer.sprite = tower2;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = tower3;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = tower4;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sprite = tower3;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = tower2;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = tower1;
    }

    public bool canAttack
    {
        get
        {
            return cooldownTime <= 0f & waterFloodedCountdown > 0f;
        }
    }
}
