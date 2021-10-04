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

    private float timeElapsed = 0;

    private bool hasTriggered = false;
    public void OnCollisionEnter2D(Collision2D hit)
    {
        if(!hasTriggered)
        {
            source.Stop();
            source.clip = neutralZoneStart;
            hasTriggered = true;
            source.loop = false;
            source.Play();
        }
    }

    public void Update()
    {
        if(source.clip == neutralZoneStart)
        {
            timeElapsed += Time.deltaTime;
        }
        if(timeElapsed >= neutralZoneStart.length)
        {
            source.Stop();
            source.loop = true;
            source.clip = neutralZoneCont;
            source.Play();
        }
    }
}
