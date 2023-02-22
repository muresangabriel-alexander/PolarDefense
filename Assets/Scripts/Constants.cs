using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static readonly string TUNNEL_ENTRY = "TUNNEL_ENTRY";
    public static readonly string TUNNEL_EXIT = "TUNNEL_EXIT";
    public static readonly string ICE_SHARDS = "ICE_SHARDS";
    public static readonly string WAYPOINT = "WAYPOINT";
    public static readonly string FINISH_LINE = "FINISH_LINE";
    public static readonly string PLATFORM = "PLATFORM";
    public static readonly string CURVE = "CURVE";
    public static readonly string CURVE_END = "CURVE_END";
    public static readonly string CURVE_MIDDLE = "CURVE_MIDDLE";
    public static readonly string NORMAL_ENEMY = "NORMAL_ENEMY";
    public static readonly string TRUCK_ENEMY = "TRUCK_ENEMY";
    public static readonly string CRANE_TRUCK_ENEMY = "CRANE_TRUCK_ENEMY"; 



    // Enemy constants
    public static readonly float NORMAL_ENEMY_SPEED = 2.0f;
    public static readonly int NORMAL_ENEMY_DAMAGE = 3;
    public static readonly int NORMAL_ENEMY_HEALTH = 10 + (5 * EnemySpawner.waveNum);
    public static readonly int NORMAL_ENEMY_POINTS = 1;

    public static readonly float TRUCK_ENEMY_SPEED = 1.0f + (0.05f * EnemySpawner.waveNum);
    public static readonly int TRUCK_ENEMY_DAMAGE = 6;
    public static readonly int TRUCK_ENEMY_HEALTH = 20 + (5 * EnemySpawner.waveNum);
    public static readonly int TRUCK_ENEMY_POINTS = 2;

    public static readonly float CRANE_TRUCK_ENEMY_SPEED = 0.5f + (0.05f * EnemySpawner.waveNum);
    public static readonly int CRANE_TRUCK_ENEMY_DAMAGE = 10;
    public static readonly int CRANE_TRUCK_ENEMY_HEALTH = 30 + (5*EnemySpawner.waveNum);
    public static readonly int CRANE_TRUCK_ENEMY_POINTS = 3;

    public static float ENEMY_SPAWN_RATE = 8.0f;
    public static float WAIT_AFTER_WAVE = 10.0f;

    public static readonly int FISH_HUNGER_FILL = 2;
    public static readonly float FISH_REFRESH_RATE = 15.0f;
    public static readonly int START_FISH_AVAILABLE = 30;
    public static readonly float EMOTION_CHANGE_TIME = 2.0f;

    public static readonly float HUNGER_INCREASE_TIME = 6.0f;

    public enum EnemyType
    {
        NORMAL_ENEMY,
        TRUCK_ENEMY,
        CRANE_TRUCK_ENEMY
    }


}
