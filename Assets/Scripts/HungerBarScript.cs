using UnityEngine;
using UnityEngine.UI;

public class HungerBarScript : MonoBehaviour
{
    public static float maxHunger = 100;
    public static int currentHunger = 100;

    private Color StartColor = new Color32(250, 128, 114, 255);
    private Color middleColor = new Color32(253, 103, 85, 255);
    private Color endColor = new Color32(253, 89, 69, 255);
    private float timer = 0.0f;

    [SerializeField]
    private Image hungerbar; 

    // Start is called before the first frame update
    void Start()
    {
        currentHunger = 100;
        hungerbar.color = StartColor;
    }

    void Update()
    {
        // just to test the functionality
        updateHealthAccordingToCurHunger();
        //updateCurrentHealth(-0.05f);
    }

    private void FixedUpdate()
    {
        if (timer > Constants.HUNGER_INCREASE_TIME)
        {
            currentHunger-= 2;
            timer = 0.0f;
        }
        else
        {
            timer += Time.fixedDeltaTime;
        }
    }

    void setColor(Color color)
    {
        hungerbar.color = color;
    }

    void UpdateColor()
    {
        if(currentHunger > 75)
        {
            setColor(StartColor);
        }
        else if(currentHunger > 50)
        {
            setColor(middleColor);
        }
        else if(currentHunger > 25)
        {
            setColor(endColor);
        }
        else
        {
            setColor(Color.red); 
        }
    }

    public void updateCurrentHealth(int updateValue)
    {
        currentHunger += updateValue;
        hungerbar.fillAmount = currentHunger / maxHunger;
        UpdateColor();
    }

    private void updateHealthAccordingToCurHunger()
    {
        hungerbar.fillAmount = currentHunger / maxHunger;
        //UpdateColor();
    }
}
