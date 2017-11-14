using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMonkey : MonoBehaviour {

    public GameObject monkey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            monkey.GetComponent<Animator>().SetTrigger("PlayerNearby");
        }
    }
}
