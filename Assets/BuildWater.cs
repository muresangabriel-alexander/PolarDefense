using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWater : MonoBehaviour
{
    public Sprite hoveredOver;
    SpriteRenderer sprite;
    Sprite defaultSprite;
    public GameObject towerObject;
    public GameObject platform;

    [SerializeField]
    private StatusBoardSO statusBoardSO;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultSprite = GetComponent<SpriteRenderer>().sprite;
    }

    public void OnMouseEnter()
    {
        if (PlatformLogic.existentMenuLocation.getPlatformTag() == Constants.PLATFORM_WATER)
        {
            if (statusBoardSO.GetCollectedScraps() >= Constants.TOWER_BUILDING_SCRAPS_NUMBER)
            {
                sprite.sprite = hoveredOver;
            }
        }   
    }

    public void OnMouseExit()
    {
        sprite.sprite = defaultSprite;
    }
    
    void OnMouseDown()
    {
        if (PlatformLogic.existentMenuLocation.getPlatformTag() == Constants.PLATFORM_WATER)
        {
            PlatformLogic.existentMenuLocation.BuildChosenTower(towerObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
