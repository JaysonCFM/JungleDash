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
        text.text = "";
        PlayerPrefsManager.DealDamage(5);

        //Unity uses Random.Range instead of Random.Next.
        RandomNumber = Random.Range(1, 5);

        //Gives player health or not.
        if (RandomNumber == CorrectBet)
        {
            if (PlayerPrefsManager.GetHealth() < 100)
            {
                PlayerPrefsManager.AddHealth(15);
                text.text = "Wow, you won! Want to try again?";
            }
        }
        else
        {
            text.text = "Better luck next time, but thanks for the health!";
        }
    }

    public void LeaveCasino()
    {
        SceneManager.LoadScene(EnterCasino.PreviousLevel);
    }
}
