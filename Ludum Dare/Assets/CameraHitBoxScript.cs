using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHitBoxScript : MonoBehaviour
{
    [SerializeField]
    int newCameraScale;

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MainCamera>().SetScale(newCameraScale);
        }
    }
}
