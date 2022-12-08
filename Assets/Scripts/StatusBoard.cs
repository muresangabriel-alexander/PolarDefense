using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusBoard : MonoBehaviour
{
    [SerializeField]
    private FloatStatusBoardObject statusBoardObject;

    [SerializeField]
    TextMeshProUGUI destroyedVehiclesTextField;
    [SerializeField]
    TextMeshProUGUI spawnedVehiclesTextField;
    [SerializeField]
    TextMeshProUGUI collectedShardsTextField;
    [SerializeField]
    TextMeshProUGUI fishAvailableTextField;
    [SerializeField]
    TextMeshProUGUI fishEatenTextField;

    // Start is called before the first frame update
    void Start()
    {
        statusBoardObject.SetSpawnedVehicles(0);
        statusBoardObject.SetCollectedShards(0);
        statusBoardObject.SetDestroyedVehicles(0);
        statusBoardObject.SetFishEaten(0);
        statusBoardObject.SetFishAvailable(0);
    }

    // Update is called once per frame
    void Update()
    {
        string destroyedVehiclesText = "Vehicles destroyed: " + statusBoardObject.GetDestroyedVehicles();
        destroyedVehiclesTextField.GetComponent<TMPro.TextMeshProUGUI>().text = destroyedVehiclesText;

        string spawnedVehiclesText = "Vehicles spawned: " + statusBoardObject.GetSpawnedVehicles() + "/" + statusBoardObject.GetTotalAmountOfVehiclesInWave();
        spawnedVehiclesTextField.GetComponent<TMPro.TextMeshProUGUI>().text = spawnedVehiclesText;

        string collectedShardsText = "Shards collected: " + statusBoardObject.GetCollectedShards();
        collectedShardsTextField.GetComponent<TMPro.TextMeshProUGUI>().text = collectedShardsText;

        string fishAvailableText = "Fish available: " + statusBoardObject.GetFishAvailable();
        fishAvailableTextField.GetComponent<TMPro.TextMeshProUGUI>().text = fishAvailableText;

        string fishEatenText = "Fish eaten: " + statusBoardObject.GetFishEaten();
        fishEatenTextField.GetComponent<TMPro.TextMeshProUGUI>().text = fishEatenText;
    }
}
