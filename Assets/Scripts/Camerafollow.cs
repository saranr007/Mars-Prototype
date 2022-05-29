using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform Thruster;
    public Vector3 Offset;
    public float maxZoom=10f, minZoom=40f,zoomLimitor;
    private Vector3 speed;
    public float smoothtime = 0.5f;
    Vector3 thrusterdistance;
   
    void LateUpdate()
    {
        thrusterdistance = PlayerGroundDistance.Instance.EndPosition;
        Vector3 CenterPoint = GetCenterPoint();
        Vector3 TargetPos = new Vector3(Thruster.position.x,Thruster.position.y,Thruster.position.z) + Offset;
         var Smoothing = Vector3.Lerp(transform.position, TargetPos, 0.125f);
         transform.position = Smoothing;
         MoveCam(CenterPoint);
         Zoom_Effect();
    }
   
    void Zoom_Effect()
    {
        float Zoom = Mathf.Lerp(maxZoom, minZoom, GetHighestDistance()/zoomLimitor);
        gameObject.GetComponent<Camera>().fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, Zoom,Time.deltaTime*5);
    }
    void MoveCam(Vector3 CenterPoint)
    {
        Vector3 TargetPos = CenterPoint + Offset;
        var Smoothing = Vector3.SmoothDamp(transform.position, TargetPos, ref speed, smoothtime);
        transform.position = Smoothing;
    }
    private Vector3 GetCenterPoint()
    {
        var Bounds = new Bounds();
        Bounds.Encapsulate(thrusterdistance);
        Bounds.Encapsulate(PlayerGroundDistance.Instance.transform.position);
        return Bounds.center;
        
    }
    float GetHighestDistance()
    {
        var Bounds = new Bounds();
        Bounds.Encapsulate(thrusterdistance);
        Bounds.Encapsulate(PlayerGroundDistance.Instance.transform.position);
        return Bounds.size.y;
    }


}

