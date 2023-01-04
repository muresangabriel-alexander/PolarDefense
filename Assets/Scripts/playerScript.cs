using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int health = 100;
    public TMP_Text damageView; //  x = -0.2136841 y = 2.661896
    private int saved_health = health;
    void Start()
    {
        //damageView.enabled = false;
        //damageView.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (health <= 0)
            Destroy(gameObject);

    }



    private void FixedUpdate()
    {
        //if (saved_health > health)
        //{
        //    Debug.Log($"saved health > health {health - saved_health}");
        //    damageView.text = (health - saved_health).ToString();
        //    saved_health = health;
        //    damageView.enabled = true;
        //    damageView.GetComponent<Animator>().enabled = true;


        //    StartCoroutine(UtilityHelpers.waitSeconds(10));

        //    damageView.enabled = false;
        //    damageView.GetComponent<Animator>().enabled = false;
        //}
    }

    private void OnDestroy()
    {
        // TODO exit game here
    }
}
