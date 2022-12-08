using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatStatusBoardObject : ScriptableObject
{
    [SerializeField]
    private int spawnedVehicles;
    [SerializeField]
    private int destroyedVehicles;
    [SerializeField]
    private int collectedShards;
    [SerializeField]
    private int totalAmountOfVehiclesInWave;

    [SerializeField]
    private int fishAvailable;
    [SerializeField]
    private int fishEaten;

    public int GetSpawnedVehicles()
    { return spawnedVehicles; }
    public void SetSpawnedVehicles(int value)
    { spawnedVehicles = value; }

    public int GetDestroyedVehicles()
    { return destroyedVehicles; }
    public void SetDestroyedVehicles(int value)
    { destroyedVehicles = value; }

    public int GetCollectedShards()
    { return collectedShards; }
    public void SetCollectedShards(int value)
    { collectedShards = value; }

    public int GetTotalAmountOfVehiclesInWave()
    { return totalAmountOfVehiclesInWave; }
    public void SetTotalAmountOfVehiclesInWave(int value)
    { totalAmountOfVehiclesInWave = value; }

    public int GetFishAvailable()
    { return fishAvailable; }
    public void SetFishAvailable(int value)
    { fishAvailable = value; }

    public int GetFishEaten()
    { return fishEaten; }
    public void SetFishEaten(int value)
    { fishEaten = value; }
}