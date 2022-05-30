using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDistance : MonoBehaviour
{
    public LayerMask RayMask;
    public float MaxDistance;
    public Vector3 EndPosition;
    BoxCollider2D col;
    public static PlayerGroundDistance Instance;
    [HideInInspector]
    public Transform CurrenGround { private set; get; }
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    private void Update()
    {
        float TargetDistance = MaxDistance;
        RaycastHit2D hit = CreateRay(TargetDistance);
        
        if (hit.collider != null)
        {
            CurrenGround = hit.collider.transform;
            EndPosition = hit.point;  
        }
        else
        {
            EndPosition = Vector3.down * TargetDistance;
        }
        
      
    }
    public RaycastHit2D CreateRay(float MaxDis)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, -Vector2.up, MaxDis, RayMask);
        return ray;
    }
   


}
