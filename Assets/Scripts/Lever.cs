using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    private bool OnTopOfLever;

    public int SpotInArray;

    private Animator animator;

    private float selectInput;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        selectInput = Input.GetAxisRaw("Submit");

        if (selectInput >= 1 && OnTopOfLever)
        {
            animator.SetTrigger("LeverActivate");
            Level2BossStart.LeversActivate[SpotInArray] = true;
        }
	}

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
