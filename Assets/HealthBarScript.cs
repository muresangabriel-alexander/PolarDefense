using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public static float maxHealth = 100;
    public static int currentHealth = 100;

    private Color orange = new Color(252, 144, 3, 255);
    private float timer = 7.0f;

    public HealthBarScript(Color orange, Image healthBar)
    {
        this.orange = orange;
        this.healthBar = healthBar;
    }

    [SerializeField]
    private Image healthBar; 

    // Start is called before the first frame update
    void Start()
    {
        healthBar.color = Color.green;
    }

    void Update()
    {
        // just to test the functionality
        //updateCurrentHealth(-0.05f);
        updateHealthAccordingToCurHealth();
    }

    private void FixedUpdate()
    {

        if (timer > Constants.HUNGER_INCREASE_TIME && HungerBarScript.currentHunger <= 0)
        {
            GameObject[] variableForPrefab = Resources.LoadAll<GameObject>("Prefabs\\damageText");
            currentHealth--;
            timer = 0.0f;
            UtilityHelpers.showDamage(variableForPrefab[0], -1);
        }
        else
        {
            timer += Time.fixedDeltaTime;
        }
    }

    void setColor(Color color)
    {
        healthBar.color = color;
    }

    void UpdateColor()
    {
        if(currentHealth > 70)
        {
            setColor(Color.green);
        }
        else if(currentHealth > 35)
        {
            setColor(Color.yellow);
        }
        else
        {
            setColor(Color.red); 
        }
    }

    public void updateCurrentHealth(int updateValue)
    {
        currentHealth += updateValue;
        healthBar.fillAmount = currentHealth / maxHealth;
        UpdateColor();
    }

    private void updateHealthAccordingToCurHealth()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        UpdateColor();
    }
}
