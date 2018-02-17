using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
	//declare boolean for player being near lever
    private bool OnTopOfLever;
	//declare int for array index of lever
    public int SpotInArray;
	//declare animator for lever
    private Animator animator;
	//declare input source
    private float selectInput;

    // Use this for initialization
    void Start () {
		//assign animator
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//assign and update input source
        selectInput = Input.GetAxisRaw("Submit");
		//spacebar input sets off animation and checks off
		//the level being activated in the array
        if (selectInput >= 1 && OnTopOfLever)
        {
            animator.SetTrigger("LeverActivate");
            Level2BossStart.LeversActivate[SpotInArray] = true;
        }
	}

	//bool is true when player is near lever, false when not
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTopOfLever = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTopOfLever = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTopOfLever = false;
    }
}
