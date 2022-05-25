using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDistance : MonoBehaviour
{
    public LayerMask RayMask;
    public float MaxDistance;
    public Vector3 EndPosition;
    public static PlayerGroundDistance playerGroundDistance;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        player = gameObject.transform;
        playerGroundDistance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        float TargetDistance = MaxDistance;
        RaycastHit2D hit = CreateRay(TargetDistance);
        if (hit.collider != null)
        {
            EndPosition = hit.point;
            Debug.Log(hit.collider.name);
            Debug.DrawRay(transform.position, Vector2.down * TargetDistance);
        }
        else
        {
            EndPosition = transform.position + (Vector3.down * TargetDistance);
        }
        Debug.LogWarning("TargetDistance"+ TargetDistance);
    }
    public RaycastHit2D CreateRay(float maxd)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, maxd, RayMask);
        return ray;
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down*35f);
    }
}
