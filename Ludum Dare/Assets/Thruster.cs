using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool attached;
    [SerializeField] float forceDirection;
    [SerializeField] public ContactPoint2D[] points = new ContactPoint2D[30];

    GameObject player;
    GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<MainShip>().gameObject;
        particles = GetComponentInChildren<ParticleSystem>().gameObject;
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        forceDirection = Mathf.Deg2Rad * gameObject.transform.rotation.eulerAngles.z;

        if (attached)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector2(Mathf.Cos(forceDirection), Mathf.Sin(forceDirection)) * 0.5f);
                particles.SetActive(true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector2(Mathf.Cos(forceDirection), Mathf.Sin(forceDirection)) * -0.5f);
                particles.SetActive(false);
            }
            if(!Input.GetKey(KeyCode.W))
            {
                particles.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            if(!attached)
            {
                collision.GetContacts(points);
                for(int i = 0; i < points.Length; i++)
                {
                    //Debug.Log(points[i].point);
                }

                DistanceJoint2D joint = gameObject.GetComponent<DistanceJoint2D>();
                joint.connectedBody = player.GetComponent<Rigidbody2D>();

                //TRIG STUFF
                float myRadius = gameObject.GetComponent<CircleCollider2D>().radius;
                float shipRadius = collision.gameObject.GetComponent<CircleCollider2D>().radius;

                float jointAngle = Mathf.Atan2(collision.gameObject.transform.position.y - gameObject.transform.position.y, collision.gameObject.transform.position.x - gameObject.transform.position.x);
                float jointAngleShip = Mathf.Atan2(gameObject.transform.position.y - collision.gameObject.transform.position.y, gameObject.transform.position.x - collision.gameObject.transform.position.x);
                float myContactAngle = gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
                float shipContactAngle = collision.gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
                Debug.Log(shipContactAngle);

                joint.anchor = new Vector2(Mathf.Cos(jointAngle - myContactAngle) * myRadius, Mathf.Sin(jointAngle - myContactAngle) * myRadius);
                joint.connectedAnchor = new Vector2(Mathf.Cos(jointAngleShip - shipContactAngle) * shipRadius, Mathf.Sin(jointAngleShip - shipContactAngle) * shipRadius);
                
                attached = true;
            }
        }
    }

    private void OnJointBreak2D(Joint2D joint)
    {
        attached = false;
        StartCoroutine(JointAdd());
    }

    private IEnumerator JointAdd()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.AddComponent<DistanceJoint2D>();
        DistanceJoint2D newjoint = gameObject.GetComponent<DistanceJoint2D>();
        newjoint.enableCollision = true;
        newjoint.maxDistanceOnly = true;
    }
}
