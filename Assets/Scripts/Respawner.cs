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
   // public GameObject Thrust_Instantiate;
    public bool NeedToThrow;
    private LiftThrusters lifter;
    bool FirstLifting, firstExecution;
    public static Respawner respawner;
    public FuelManager fuelManager;
    public TouchEvent Touch;
   


    // Start is called before the first frame update
    void Start()
    {
        Thruster = this.gameObject;
        ThrusterStartPos = transform.position;
        Thruster_RB = GetComponent<Rigidbody2D>();
        ThrusterCurrentPos = ThrusterStartPos;
        ThrustCollider = Thruster.GetComponent<BoxCollider2D>();
    }
    private void Awake()
    {
        respawner = this;
    }

    // Update is called once per frame

    private void Update()
    {
       RaycastHit2D Box = Physics2D.BoxCast(ThrustCollider.bounds.center, ThrustCollider.bounds.size, 0, -Vector2.up, raysdistance,ColliderMask);
       
       RespawnObject(Box);
        Debug.DrawRay(ThrustCollider.bounds.center, -Vector2.up * (ThrustCollider.bounds.size.y + raysdistance));

        if (NeedToThrow)
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
    public void BackToPosition()
    {
        Touch.LeftThrusterParticle.Stop();
        Touch.RightThrusterParticle.Stop();
        Thruster_RB.velocity = Vector2.zero;
        Thruster_RB.angularVelocity = 0;
        transform.position = ThrusterCurrentPos;
    }
    void RespawnObject(RaycastHit2D Box)
    {
        if (Box.collider != null)
        {
            if (Box.collider.CompareTag("Lander"))
            {
                Vector2 r = Thruster_RB.GetPointVelocity(transform.TransformPoint(Box.point));
                if (r.magnitude < 9f)
                {
                    ThrusterCurrentPos = transform.position;
                    fuelManager.AddFuel();
                }
                if(r.magnitude>9f)
                {
                    BackToPosition();
                }
                
            }
            else if (Box.collider.CompareTag("Ground") || Box.collider.CompareTag("Obstacle"))
            {
              BackToPosition();
            }
        }
    }
    private void OnDrawGizmos()
    {
        BoxCollider2D T = GetComponent<BoxCollider2D>();
        Debug.DrawRay(transform.position, -Vector2.up * (T.bounds.center.y+raysdistance));
    }



}
