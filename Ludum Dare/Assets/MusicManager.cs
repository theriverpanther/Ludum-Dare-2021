using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip neutralZoneStart;
    [SerializeField]
    AudioClip neutralZoneCont;

    private bool hasTriggered = false;
    public void OnCollisionEnter2D()
    {
        if(!hasTriggered)
        {
            source.clip = neutralZoneStart;
            hasTriggered = true;
            source.loop = false;
        }
    }

    public void Update()
    {
        if(!source.isPlaying)
        {
            source.loop = true;
            source.clip = neutralZoneCont;
        }
    }
}
