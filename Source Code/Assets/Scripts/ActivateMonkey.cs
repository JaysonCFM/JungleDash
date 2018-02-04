using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMonkey : MonoBehaviour {

    public GameObject monkey;

    private bool HasPlayerPassed;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (HasPlayerPassed == true && player.transform.position.x > transform.position.x)
        {
            monkey.GetComponent<Animator>().SetTrigger("PlayerNearby");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HasPlayerPassed = true;
        }
    }
}
