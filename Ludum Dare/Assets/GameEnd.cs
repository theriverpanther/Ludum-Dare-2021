using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject endScreen;
    public void OnCollisionEnter2D()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().PlayerFinish();
        endScreen.SetActive(true);
    }
}
