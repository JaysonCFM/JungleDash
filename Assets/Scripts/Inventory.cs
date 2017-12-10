using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    //Uses an array to determine which item is available, based off of the boolean currently set.
    public static bool[] Items = new bool[12];
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            //TODO: Inventory needs to be used, this just uses all items.
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = false;
            }
        }
	}

    public static void SetItem(int choice)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i] = false;
        }

        Items[choice] = true;
    }
}