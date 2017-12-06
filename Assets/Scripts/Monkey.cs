using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour {

    public GameObject BarrierOne, BarrierTwo, BarrierThree;

    private void Update()
    {
        if (gameObject.GetComponent<Enemy>().Health <=0)
        {
            FreePlayer();
        }
    }

    //When monkey animation happens, the player will be trapped into a box and forced to fight the monkey.
    public void TrapPlayer()
    {
        BarrierOne.GetComponent<BoxCollider2D>().isTrigger = false;
        BarrierTwo.GetComponent<BoxCollider2D>().isTrigger = false;
        BarrierThree.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    //When triggered, the boxes will disable and the player can leave.
    public void FreePlayer()
    {
        BarrierOne.SetActive(false);
        BarrierTwo.SetActive(false);
        BarrierThree.SetActive(false);
    }
}
