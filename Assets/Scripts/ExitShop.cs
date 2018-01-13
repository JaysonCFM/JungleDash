using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitShop : MonoBehaviour {
    public static bool HasEnteredShopBefore;

    //Allows player to exit shop and return to position in level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HasEnteredShopBefore = true;

        SceneManager.LoadScene(LoadShop.PreviousLevel);

    }
}
