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

    [SerializeField]
    private StatusBoardSO statusBoardSO;
    
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
        if (statusBoardSO.GetCollectedScraps() < Constants.TOWER_BUILDING_SCRAPS_NUMBER && builtTower == null)
        {
            GameObject notEnoughScrapsView = Resources.LoadAll<GameObject>("Prefabs\\notEnoughScrapsText")[0];

            Instantiate(notEnoughScrapsView, (gameObject.transform.position + new Vector3(0, -0.4f, 0)), Quaternion.identity);
            return;
        }

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
        {
            statusBoardSO.ChangeCollectedScrapsBy(Constants.TOWER_BUILDING_SCRAPS_NUMBER);
            Destroy(builtTower);
        }

        builtTower = Instantiate(tower, transform.position +  new Vector3(0f,0.25f,0f), Quaternion.identity);
        statusBoardSO.ChangeCollectedScrapsBy(-Constants.TOWER_BUILDING_SCRAPS_NUMBER);
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
        if (statusBoardSO.GetCollectedScraps() < Constants.TOWER_BUILDING_SCRAPS_NUMBER && builtTower == null)
        {
            return;
        }

        sprite.color =  new Color( 0, 255,  0, 10);
    }

    public void OnMouseExit()
    {
        sprite.color = defaultColor;
    }

    public string getPlatformTag()
    {
        return tag;
    }
}
