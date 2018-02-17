using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitShop : MonoBehaviour {
	//boolean for whether or not player has been in the shop before
    public static bool HasEnteredShopBefore;

    //Allows player to exit shop and return to position in level
    private void OnTriggerEnter2D(Collider2D collision)
    {
		//becomes true after hitting the shop exit collider
        HasEnteredShopBefore = true;
		//loads previous scene prior to shop
        SceneManager.LoadScene(LoadShop.PreviousLevel);

    }
}
