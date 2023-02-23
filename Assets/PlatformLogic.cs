using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformLogic : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject buildMenu;
    private Color defaultColor;
    private static bool isMenuUp = false;
    private static GameObject menuInstance;
    public static PlatformLogic existentMenuLocation = null;
    private GameObject builtTower = null;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
        defaultColor = sprite.color;
    }

    void Awake()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
    }


    void OnMouseDown()
    {
        if (!isMenuUp )
        {
            menuInstance = Instantiate(buildMenu, this.transform.position + new Vector3(-0.325f,-2.75f,0f), Quaternion.identity );
            existentMenuLocation = this;
            isMenuUp = true;
        }
        else if (isMenuUp && existentMenuLocation ==  this)
        {
            Destroy(menuInstance);
            menuInstance = null;
            isMenuUp = false;
            existentMenuLocation = null;
        }
        else if (isMenuUp && existentMenuLocation !=  this)
        {
            Destroy(menuInstance);
            menuInstance = null;
            isMenuUp = false;
            existentMenuLocation = null;
            
            menuInstance = Instantiate(buildMenu, this.transform.position + new Vector3(-0.325f,-2.75f,0f), Quaternion.identity );
            existentMenuLocation =  this;
            isMenuUp = true;
        }
    }
    
    public void BuildChosenTower(GameObject tower)
    {
        if (builtTower != null)
            Destroy(builtTower);
        
        
        builtTower = Instantiate(tower, transform.position +  new Vector3(0f,0.25f,0f), Quaternion.identity);
        if (isMenuUp && existentMenuLocation ==  this)
        {
            Destroy(menuInstance);
            menuInstance = null;
            isMenuUp = false;
            existentMenuLocation = null;
        }
        
    }
    
    public void OnMouseEnter()
    {
        sprite.color =  new Color( 0, 255,  0, 10);
    }

    public void OnMouseExit()
    {
        sprite.color = defaultColor;
    }
}
