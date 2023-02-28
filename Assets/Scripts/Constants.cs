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
      public static readonly string WATER_TOWER = "WATER_TOWER"; 
      public static readonly string PLATFORM_WATER = "PLATFORM_WATER";
      public static readonly string WATER = "WATER";
      public static readonly string WIND = "WIND";
      public static readonly string SOLAR_PROJECTILE = "SOLAR_PROJECTILE";

    // SolarTower constants
    public static readonly float SOLAR_FIRE_FREQUENCY = 1.0f;

    public static readonly int NORMAL_SOLAR_DAMAGE = 1;
    public static readonly int TRUCK_SOLAR_DAMAGE = 2;
    public static readonly int CRANE_SOLAR_DAMAGE = 3;



    // Enemy constants
    public static float NORMAL_ENEMY_SPEED = 1.5f;
    public static readonly int NORMAL_ENEMY_DAMAGE = 3;
    public static int NORMAL_ENEMY_HEALTH = 10;
    public static readonly int NORMAL_ENEMY_POINTS = 1;
    public static readonly int NORMAL_ENEMY_SCRAPS = 2;

    public static float TRUCK_ENEMY_SPEED = 1.0f;
    public static readonly int TRUCK_ENEMY_DAMAGE = 6;
    public static int TRUCK_ENEMY_HEALTH = 20;
    public static readonly int TRUCK_ENEMY_POINTS = 2;
    public static readonly int TRUCK_ENEMY_SCRAPS = 3;

    public static float CRANE_TRUCK_ENEMY_SPEED = 0.5f;
    public static readonly int CRANE_TRUCK_ENEMY_DAMAGE = 10;
    public static int CRANE_TRUCK_ENEMY_HEALTH = 30;
    public static readonly int CRANE_TRUCK_ENEMY_POINTS = 3;
    public static readonly int CRANE_TRUCK_SCRAPS = 4;

    public static float ENEMY_SPAWN_RATE = 5.0f;
    public static float WAIT_AFTER_WAVE = 10.0f;

    public static readonly int FISH_HUNGER_FILL = 2;
    public static readonly float FISH_REFRESH_RATE = 15.0f;
    public static readonly int START_FISH_AVAILABLE = 15;
    public static readonly float EMOTION_CHANGE_TIME = 2.0f;

    public static readonly float HUNGER_INCREASE_TIME = 6.0f;

    public static int TOWER_BUILDING_SCRAPS_NUMBER = 10;
    

    public enum EnemyType
    {
        NORMAL_ENEMY,
        TRUCK_ENEMY,
        CRANE_TRUCK_ENEMY
    }


    // water tower constants
    public static readonly float WATER_TOWER_FLOODING_RATE = 5.0f;
    public static readonly float WATER_FLOODING_TIME = 2f;
    public static readonly float WATER_TOWER_DAMAGE_OVER_TIME_PERIOD = 0.8f;
    
    public static readonly float WIND_TOWER_BLOWING_RATE = 5.0f;
    public static readonly float WIND_BLOWING_TIME = 2.0f;
    public static readonly float WIND_TOWER_DAMAGE_OVER_TIME_PERIOD = 1.5f;


}
