using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    //Creates a key inside of the playerprefs (Storage for Unity).
    const string LEVEL_KEY = "level_unlocked_";
    const string PLAYER_HEALTH = "player_health_";
    public const string MASTER_VOLUME_KEY = "master_volume";
    const string WEAPON_SELECTED = "weapon_selected";
    const string INVENTORY_ITEM = "inventory_item";

    public static bool IsIndestructible;

    //Can be called from another script to unlock a level by passing in a number.
    public static void UnlockLevel(int level)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, level);

    }

    //Returns the stored number, so that levels can be played from the map.
    public static int GetUnlockedLevel()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }

    //Health for the player, stored offline
    public static void DealDamage(int damageGiven)
    {
        if (!IsIndestructible)
        {
			PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - damageGiven);
        } else
        {
            PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - 0);
        }
    }

    public static void AddHealth(int health)
    {
        PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() + health);
    }

    public static void SetHealth(int health)
    {
        IsIndestructible = false;
        PlayerPrefs.SetInt(PLAYER_HEALTH, health);
    }

    //Returns the current health as an integer
    public static int GetHealth()
    {
        return PlayerPrefs.GetInt(PLAYER_HEALTH);
    }

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetWeapon(string Weapon)
    {
        PlayerPrefs.SetString(WEAPON_SELECTED, Weapon);
    }

    public static string GetWeapon()
    {
        return PlayerPrefs.GetString(WEAPON_SELECTED);
    }

    public static void SetInventory(string Item)
    {
        PlayerPrefs.SetString(INVENTORY_ITEM, Item);
    }

    public static string GetInventory()
    {
        return PlayerPrefs.GetString(INVENTORY_ITEM);
    }
}
