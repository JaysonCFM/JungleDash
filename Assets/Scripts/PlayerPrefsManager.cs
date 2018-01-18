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
    const string DIFFICULTY_SETTING = "difficulty_setting";

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
    //Each difficulty increment doubles the amount of damage you take when playing.
    public static void DealDamage(int damageGiven)
    {
        if (!IsIndestructible)
        {
            if (GetDifficulty() == 0)
            {
                PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - damageGiven);
            }
            else if (GetDifficulty() == 1)
            {
                PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - (damageGiven * 2));
            }
            else if (GetDifficulty() == 2)
            {
                PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - (damageGiven * 4));
            }
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
		return (float)(PlayerPrefs.GetFloat(MASTER_VOLUME_KEY));
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

    //Sets the difficulty from the slider in the options
    public static void SetDifficulty(float Difficulty)
    {
        PlayerPrefs.SetFloat(DIFFICULTY_SETTING, Difficulty);
    }

    //Returns difficulty slider selection.
    public static float GetDifficulty()
    {
		return (float)(PlayerPrefs.GetFloat(DIFFICULTY_SETTING));
    }
}
