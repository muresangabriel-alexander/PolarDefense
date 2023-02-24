using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UtilityHelpers : MonoBehaviour
{
    /// <summary>
    /// suspends execution of thread for seconds
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    public static IEnumerator waitSeconds(int seconds)
    {
        print("Begin wait() " + Time.time);
        yield return new WaitForSecondsRealtime(seconds);
        print("end wait() " + Time.time);
    }

    public static GameObject showDamage(GameObject damageView, int damagePoints)
    {
        GameObject view = Instantiate(damageView);
        GameObject dmgView = view.transform.GetChild(0).gameObject;
        dmgView.GetComponent<TMP_Text>().text = damagePoints.ToString();
        if (damagePoints < 0)
            dmgView.GetComponent<TMP_Text>().faceColor = new Color(229, 59, 59, 1);
        else
        {
            dmgView.GetComponent<TMP_Text>().faceColor = new Color(0, 255, 0, 1);
            dmgView.GetComponent<TMP_Text>().text = "+"+damagePoints.ToString();
        }

        return view;
    }

    public static void DecreaseEnemyhealth(GameObject enemy, int damage)
    {
        enemy.GetComponent<enemyLogic>().health -= damage;
        enemy.GetComponent<enemyLogic>().RunWait();
    }
}
