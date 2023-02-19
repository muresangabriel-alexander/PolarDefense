using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursor;
    [SerializeField]
    private StatusBoardSO statusBoardObject;
    public static int hunger = 100;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite normalSprite;
    public Sprite sadSprite;

    private float timer = 15.0f;
    private float emotionTimer = 1.0f;
    void Start()
    {
    }


    public void ChangeSprite(string mode = "")
    {
        if (mode.Equals("happy"))
            spriteRenderer.sprite = newSprite;
        else if (mode.Equals("sad"))
            spriteRenderer.sprite = sadSprite;
        else
            spriteRenderer.sprite = normalSprite;
    }

    private void OnMouseOver()
    {
        //Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
    void OnMouseDown()
    {
        GameObject[] variableForPrefab = Resources.LoadAll<GameObject>("Prefabs\\damageText");

        if (statusBoardObject.GetFishAvailable() > 0)
        {
            GameObject[] variableForFish = Resources.LoadAll<GameObject>("Prefabs\\fish");
            if (hunger < 100)
                playerScript.hunger += Constants.FISH_HUNGER_FILL;

            Instantiate(variableForFish[0]);
            UtilityHelpers.showDamage(variableForPrefab[0], 1);

            statusBoardObject.SetFishEaten(statusBoardObject.GetFishEaten() + 1);
            statusBoardObject.SetFishAvailable(statusBoardObject.GetFishAvailable() - 1);
            if (HungerBarScript.currentHunger <= 98)
                HungerBarScript.currentHunger += 4;


            ChangeSprite("happy");
        }
        else
        {
            GameObject view = Instantiate(variableForPrefab[0]);
            GameObject dmgView = view.transform.GetChild(0).gameObject;
            dmgView.GetComponent<TMP_Text>().text = "0";
            ChangeSprite("sad");
        }
    }

     // Update is called once per frame
    void Update()
    {
        if (HealthBarScript.currentHealth <= 0)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (timer < Constants.FISH_REFRESH_RATE)
        {
            timer += Time.fixedDeltaTime;
        }
        else
        {
            timer = 0.0f;
            statusBoardObject.SetFishAvailable(statusBoardObject.GetFishAvailable() + 1);
        }

        if (emotionTimer < Constants.EMOTION_CHANGE_TIME)
        {
            emotionTimer += Time.fixedDeltaTime;
        }
        else
        {
            emotionTimer = 0.0f;
            ChangeSprite();
        }
    }

    private void OnDestroy()
    {
        // TODO exit game here
    }
}
