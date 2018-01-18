using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour {

    public GameObject Torch, BloodCross, Bomb;

    // Update is called once per frame
    void Update() {
        //Decides which item in inventory to draw based on the item in the items array.
        if (Inventory.Items[0])
        {
            Torch.gameObject.SetActive(true);
            BloodCross.gameObject.SetActive(false);
            Bomb.gameObject.SetActive(false);
        }
        else if (Inventory.Items[1])
        {
            Torch.gameObject.SetActive(false);
            BloodCross.gameObject.SetActive(true);
            Bomb.gameObject.SetActive(false);
        }
        else if (Inventory.Items[2])
        {
            Torch.gameObject.SetActive(false);
            BloodCross.gameObject.SetActive(false);
            Bomb.gameObject.SetActive(true);
        }
        else if (Inventory.Items[3])
        {
            Torch.gameObject.SetActive(false);
            BloodCross.gameObject.SetActive(false);
            Bomb.gameObject.SetActive(false);
        }
        else
        {
            Torch.gameObject.SetActive(false);
            BloodCross.gameObject.SetActive(false);
            Bomb.gameObject.SetActive(false);
        }
    }
}
