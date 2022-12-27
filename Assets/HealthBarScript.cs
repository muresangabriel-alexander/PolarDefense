using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth = 100;

    private Color orange = new Color32(252, 144, 3, 255);


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
    }

    void setColor(Color color)
    {
        healthBar.color = color;
    }

    void UpdateColor()
    {
        if(currentHealth > 75)
        {
            setColor(Color.green);
        }
        else if(currentHealth > 50)
        {
            setColor(Color.yellow);
        }
        else if(currentHealth > 25)
        {
            setColor(orange);
        }
        else
        {
            setColor(Color.red); 
        }
    }

    void updateCurrentHealth(float updateValue)
    {
        currentHealth += updateValue;
        healthBar.fillAmount = currentHealth / maxHealth;
        UpdateColor();
    }
}
