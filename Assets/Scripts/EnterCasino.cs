using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCasino : MonoBehaviour {

    public static string PreviousLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene ShopName = SceneManager.GetActiveScene();

        PreviousLevel = ShopName.name;

        SceneManager.LoadScene("Casino");
    }
}
