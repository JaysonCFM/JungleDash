using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    //Creates a key inside of the playerprefs (Storage for Unity).
    const string LEVEL_KEY = "level_unlocked_";
	//player health variable declaration
    const string PLAYER_HEALTH = "player_health_";
	//volume level variable declaration
    public const string MASTER_VOLUME_KEY = "master_volume";
	//weapon selection variable declaration
    const string WEAPON_SELECTED = "weapon_selected";
	//inventory selection variable declaration
    const string INVENTORY_ITEM = "inventory_item";
	//game difficulty level selection variable declaration
    const string DIFFICULTY_SETTING = "difficulty_setting";
	//player lives variable declaration
    const string PLAYER_LIVES = "player_lives";
	//rapid fire upgrade variable declaration (for bamboo blowgun weapon)
    const string IS_RAPID_FIRE = "is_rapid_fire";

    //Player X, Y, and Z saving for checkpoints.
    const string PLAYER_X = "player_x";
    const string PLAYER_Y = "player_y";
    const string PLAYER_Z = "player_z";

	//declare checker for player colliding with a checkpoint
    const string HAS_PASSED_CHECKPOINT = "has_passed_checkpoint";

	//declare booleans for invincibility (when blood cross item is active) and level 3 boss scene
    public static bool IsIndestructible, IsLevel3BossPlayer;

    //Can be called from another script to unlock a level by passing in a number.
    public static void UnlockLevel(int level)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, level);
    }

    //Returns the stored level unlock number, so that levels can be played from the map.
    public static int GetUnlockedLevel()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }
		
    //Each difficulty increment doubles the amount of damage you take when playing.
    public static void DealDamage(int damageGiven)
    {
		//checks for the blood cross being activated
        if (!IsIndestructible)
        {
            if (GetDifficulty() == 0f)
            {
				//easy (default damage)
                PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - damageGiven);
            }
            else if (GetDifficulty() == 1f)
            {
				//medium (double damage)
                PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - (damageGiven * 2));
            }
            else if (GetDifficulty() == 2f)
            {
				//hard (quadruple damage)
                PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - (damageGiven * 4));
            }
        } 
        else if (IsLevel3BossPlayer)
        {
            PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - damageGiven);
        }
		else
        {
            PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() - 0);
        }
    }

	//adds to health points
    public static void AddHealth(int health)
    {
        PlayerPrefs.SetInt(PLAYER_HEALTH, GetHealth() + health);
    }

	//sets # of health points
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

	//sets number of lives
    public static void SetLives(int Lives)
    {
        PlayerPrefs.SetInt(PLAYER_LIVES, Lives);
    }

	//takes away lives
    public static void SubtractLives(int SubtractBy)
    {
        PlayerPrefs.SetInt(PLAYER_LIVES, GetLives() - SubtractBy);
    }

	//adds to amount of lives
    public static void AddLives(int AddBy)
    {
        PlayerPrefs.SetInt(PLAYER_LIVES, GetLives() + AddBy);
    }

	//gets current number of lives
    public static int GetLives()
    {
        return PlayerPrefs.GetInt(PLAYER_LIVES);
    }

	//sets volume setting
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

	//gets volume setting
    public static float GetMasterVolume()
    {
		return (float)(PlayerPrefs.GetFloat(MASTER_VOLUME_KEY));
    }

	//sets weapon
    public static void SetWeapon(string Weapon)
    {
        PlayerPrefs.SetString(WEAPON_SELECTED, Weapon);
    }

	//gets current weapon
    public static string GetWeapon()
    {
        return PlayerPrefs.GetString(WEAPON_SELECTED);
    }

	//sets inventory item
    public static void SetInventory(string Item)
    {
        PlayerPrefs.SetString(INVENTORY_ITEM, Item);
    }

	//gets current inventory item
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

    //Input for the player's X, Y, and Z values for checkpoints etc.
    public static void SetLocation(float X, float Y, float Z)
    {
        PlayerPrefs.SetFloat(PLAYER_X, X);
        PlayerPrefs.SetFloat(PLAYER_Y, Y);
        PlayerPrefs.SetFloat(PLAYER_Z, Z);
    }

    //Returns current player location as a Vector3.
    public static Vector3 PlayerLocation()
    {
        Vector3 location = new Vector3(PlayerPrefs.GetFloat(PLAYER_X), PlayerPrefs.GetFloat(PLAYER_Y), PlayerPrefs.GetFloat(PLAYER_Z));

        return location;
    }

	//sets checkpoint
    public static void SetCheckpoint(string value)
    {
        PlayerPrefs.SetString(HAS_PASSED_CHECKPOINT, value);
    }

	//gets checkpoint
    public static string ReturnCheckpoint()
    {
        return PlayerPrefs.GetString(HAS_PASSED_CHECKPOINT);
    }

    //Enables rapid fire of the gun
    public static void SetRapidFire(string Value)
    {
        PlayerPrefs.SetString(IS_RAPID_FIRE, Value);
    }

	//returns rapid fire value
    public static string ReturnRapidFire()
    {
        return PlayerPrefs.GetString(IS_RAPID_FIRE);
    }
}
