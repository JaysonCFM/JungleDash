using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCasino : MonoBehaviour {
	//declare previous level name string
    public static string PreviousLevel;

    //Records which shop the player was in, then loads the casino.
    private void OnTriggerEnter2D(Collider2D collision)
    {
		//declare shopname scene
        Scene ShopName = SceneManager.GetActiveScene();
		//assign previouslevel (the shop)
        PreviousLevel = ShopName.name;
		//load casino
        SceneManager.LoadScene("Casino");
    }
}
