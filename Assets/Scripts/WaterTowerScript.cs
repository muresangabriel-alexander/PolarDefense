using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTowerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float floodingRate = 2.0f;
    public float floodedRate = 1.0f;


    private float cooldownTime;
    private float floodedTime;
    private bool isFlooded;
    private Transform water;
    private void Awake()
    {
    }
    void Start()
    {
        isFlooded = false;
        cooldownTime = 0.0f;
        floodedTime = floodingRate;
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
            if (floodedTime > 0f)
            {
                floodedTime -= Time.deltaTime;
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                isFlooded = false;
                floodedTime = floodedRate;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canAttack)
        {
            cooldownTime = floodingRate;
            transform.GetChild(0).gameObject.SetActive(true);
            isFlooded = true;
            cooldownTime = floodingRate;
        }
    }

    public bool canAttack
    {
        get
        {
            return cooldownTime <= 0f & floodedTime > 0f;
        }
    }
}
