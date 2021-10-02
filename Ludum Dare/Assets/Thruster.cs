using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float forceDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        forceDirection = Mathf.Deg2Rad * gameObject.transform.rotation.eulerAngles.z;

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(Mathf.Cos(forceDirection), Mathf.Sin(forceDirection)) * 2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(Mathf.Cos(forceDirection), Mathf.Sin(forceDirection)) * -2);
        }
    }
}
