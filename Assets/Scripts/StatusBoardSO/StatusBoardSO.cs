using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StatusBoardSO : ScriptableObject
{
    [SerializeField]
    private int spawnedVehicles;
    [SerializeField]
    private int destroyedVehicles;
    [SerializeField]
    private int collectedScraps;
    [SerializeField]
    private int totalAmountOfVehiclesInWave;

    [SerializeField]
    private int fishAvailable;
    [SerializeField]
    private int fishEaten;

    public int GetSpawnedVehicles()
    { 
        return spawnedVehicles; 
    }
    public void SetSpawnedVehicles(int value)
    { 
        spawnedVehicles = value; 
    }
    public void ChangeSpawnedVehiclesBy(int value)
    {
        spawnedVehicles += value;
    }

    public int GetDestroyedVehicles()
    { 
        return destroyedVehicles; 
    }
    public void SetDestroyedVehicles(int value)
    { 
        destroyedVehicles = value; 
    }
    public void ChangeDestroyedVehiclesBy(int value)
    {
        destroyedVehicles += value;
    }

    public int GetCollectedScraps()
    { 
        return collectedScraps; 
    }
    public void SetCollectedScraps(int value)
    { 
        collectedScraps = value; 
    }
    public void ChangeCollectedScrapsBy(int value)
    {
        collectedScraps += value;
    }

    public int GetTotalAmountOfVehiclesInWave()
    {
        return totalAmountOfVehiclesInWave; 
    }
    public void SetTotalAmountOfVehiclesInWave(int value)
    { 
        totalAmountOfVehiclesInWave = value; 
    }

    public int GetFishAvailable()
    { 
        return fishAvailable; 
    }
    public void SetFishAvailable(int value)
    { 
        fishAvailable = value; 
    }
    public void ChangeFishAvailableBy(int value)
    {
        fishAvailable += value;
    }

    public int GetFishEaten()
    { 
        return fishEaten; 
    }
    public void SetFishEaten(int value)
    { 
        fishEaten = value; 
    }
    public void ChangeFishEatenBy(int value)
    {
        fishEaten += value;
    }
}