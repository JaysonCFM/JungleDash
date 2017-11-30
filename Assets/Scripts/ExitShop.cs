using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitShop : MonoBehaviour {

    public bool Level1, Level2, Level3, Level4, Level5, Level6;
    public static bool HasEnteredShopBefore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HasEnteredShopBefore = true;
        if (Level1)
        {
            SceneManager.LoadScene("Level 1");
        }
        if (Level2)
        {
            SceneManager.LoadScene("Level 2");
        }
        if (Level3)
        {
            SceneManager.LoadScene("Level 3");
        }
        if (Level4)
        {
            SceneManager.LoadScene("Level 4");
        }
        if (Level5)
        {
            SceneManager.LoadScene("Level 5");
        }
        if (Level6)
        {
            SceneManager.LoadScene("Level 6");
        }

    }
}
