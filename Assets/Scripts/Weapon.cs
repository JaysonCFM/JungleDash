using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Player player;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
	}

    private void Attack()
    {

    }
}
