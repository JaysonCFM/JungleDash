using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Casino : MonoBehaviour {

    private Random rand;
    private int RandomNumber;
    public int CorrectBet = 7;
    public Text text;

    public void PlaceBet()
    {
        if (PlayerPrefsManager.GetHealth() >= 5)
        {
        text.text = "";

        //Unity uses Random.Range instead of Random.Next.
        RandomNumber = Random.Range(1, 5);

        if (RandomNumber == CorrectBet)
        {
            //displays won status and rewards player 10 health + the 5 they bet
            text.text = "Wow, you won! Want to try again?";
            if ((PlayerPrefsManager.GetHealth() + 15) <= 100)
            {
                PlayerPrefsManager.AddHealth(15);
            }
            else
            {
                PlayerPrefsManager.SetHealth(100);
            }
        }
        else
        {
            //displays loss status and deducts the 5 health the player bet
            text.text = "Better luck next time, but thanks for the health!";
            PlayerPrefsManager.DealDamage(5);
        }
    }
        else
        {
            text.text = "Health too low to gamble.";
        }
    }

    public void LeaveCasino()
    {
        SceneManager.LoadScene(EnterCasino.PreviousLevel);
    }
}
