using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject endScreen;
    public void OnCollisionEnter2D()
    {
        endScreen.SetActive(true);
    }
}
