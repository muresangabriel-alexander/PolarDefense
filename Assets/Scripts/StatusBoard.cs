using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusBoard : MonoBehaviour
{
    [SerializeField]
    private StatusBoardSO statusBoardObject;

    [SerializeField]
    TextMeshProUGUI destroyedVehiclesTextField;
    [SerializeField]
    TextMeshProUGUI spawnedVehiclesTextField;
    [SerializeField]
    TextMeshProUGUI collectedScrapsTextField;
    [SerializeField]
    TextMeshProUGUI fishAvailableTextField;
    [SerializeField]
    TextMeshProUGUI fishEatenTextField;

    // Start is called before the first frame update
    void Awake()
    {
        statusBoardObject.SetSpawnedVehicles(0);
        statusBoardObject.SetCollectedScraps(20);
        statusBoardObject.SetDestroyedVehicles(0);
        statusBoardObject.SetFishEaten(0);
        statusBoardObject.SetFishAvailable(Constants.START_FISH_AVAILABLE);
    }

    // Update is called once per frame
    void Update()
    {
        string destroyedVehiclesText = "Vehicles destroyed: " + statusBoardObject.GetDestroyedVehicles();
        destroyedVehiclesTextField.GetComponent<TMPro.TextMeshProUGUI>().text = destroyedVehiclesText;

        string spawnedVehiclesText = "Vehicles spawned: " + statusBoardObject.GetSpawnedVehicles();
        spawnedVehiclesTextField.GetComponent<TMPro.TextMeshProUGUI>().text = spawnedVehiclesText;

        string collectedScrapsText = "Scraps collected: " + statusBoardObject.GetCollectedScraps();
        collectedScrapsTextField.GetComponent<TMPro.TextMeshProUGUI>().text = collectedScrapsText;

        string fishAvailableText = "Fish available: " + statusBoardObject.GetFishAvailable();
        fishAvailableTextField.GetComponent<TMPro.TextMeshProUGUI>().text = fishAvailableText;

        string fishEatenText = "Fish eaten: " + statusBoardObject.GetFishEaten();
        fishEatenTextField.GetComponent<TMPro.TextMeshProUGUI>().text = fishEatenText;
    }
}
