using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private GameObject Thruster;
    private Rigidbody2D Thruster_RB;
    private Vector2 ThrusterCurrentPos;
    private Vector2 ThrusterStartPos;
    private BoxCollider2D ThrustCollider;
    public float raysdistance;
    public LayerMask ColliderMask;
    public GameObject Thrust_Instantiate;
    public bool NeedToThrow;
    private LiftThrusters lifter;

    // Start is called before the first frame update
    void Start()
    {
        Thruster = this.gameObject;
        ThrusterStartPos = Thruster.transform.position;
        Thruster_RB = Thruster.GetComponent<Rigidbody2D>();
        ThrusterCurrentPos = ThrusterStartPos;
        ThrustCollider = Thruster.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    
    private void Update()
    {
      
       RaycastHit2D Box = Physics2D.BoxCast(ThrustCollider.bounds.center, ThrustCollider.bounds.size, 0, Vector2.down, raysdistance,ColliderMask);
        
        if (Box.collider != null)
        {
            
            if (Box.collider.CompareTag("Lander"))
            {
                Vector2 r = Thruster_RB.GetPointVelocity(transform.TransformPoint(Box.point));
                if (r.magnitude > 0)
                {
                    Debug.LogError("size" + r.magnitude);
                }
                if (r.magnitude<7f)
                {
                    ThrusterCurrentPos = transform.position;
                }
                else
                {
                    Thruster_RB.velocity = Vector2.zero;
                    Thruster_RB.angularVelocity = 0;
                    transform.position = ThrusterCurrentPos;
                }
            } else if (Box.collider.CompareTag("Ground")||Box.collider.CompareTag("Obstacle"))
            {
                Thruster_RB.velocity = Vector2.zero;
                Thruster_RB.angularVelocity = 0;
                transform.position = ThrusterCurrentPos;
            }
         }
        if(NeedToThrow)
        {
            Thruster_RB.velocity = Vector2.zero;
            transform.position = ThrusterCurrentPos;
            NeedToThrow = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("UpperBoundary"))
        {
            NeedToThrow = true;
        }
    }
    


}
