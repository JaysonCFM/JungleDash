﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOut : MonoBehaviour {

    public Camera mainCamera;

    private bool IsInBox;

    private void LateUpdate()
    {
        //When the player is not in the zoom out area, it will reset the camera back to default zoom with an animation
        if (!IsInBox)
        {
            if (mainCamera.orthographicSize > 5)
            {
                mainCamera.orthographicSize -= 0.25f;
            }
        }
    }

    //Animates a zoom out animation until the camera is zoomed out
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (mainCamera.orthographicSize < 10)
            {
                mainCamera.orthographicSize += 0.25f;
            }

            IsInBox = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (mainCamera.orthographicSize < 10)
            {
                mainCamera.orthographicSize += 0.25f;
            }

            IsInBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            IsInBox = false;
        }
    }
}
