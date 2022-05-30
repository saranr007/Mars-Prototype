using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TouchEvent : MonoBehaviour
{
    public GameObject ThrusterObject;
    public float thrsutForce;
    [HideInInspector]public Rigidbody2D Thruster_RigidBody;
    public float direction;
    Respawner respawner;
    bool LeftDown;
    bool RightDown;
    bool bothButtonsClicked = false;
    private float FuelRate=7;
    [HideInInspector]public bool IsMoving=false;
    public ParticleSystem LeftThrusterParticle;
    public ParticleSystem RightThrusterParticle;
    public MenuControls Menu;
    void Start()
    {
        respawner = ThrusterObject.GetComponent<Respawner>();
        Thruster_RigidBody = ThrusterObject.GetComponent<Rigidbody2D>();
        IsMoving = false;
    }
    void Update()
    {
        if (!Menu.isPaused)
        {
            MoveThruster();
            CheckForMovement();
        }
        
    }
   
    private void CheckForMovement()
    {
        if((RightDown||LeftDown||bothButtonsClicked)&&Thruster_RigidBody.velocity.magnitude>1)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }
    private void MoveThruster()
    {
        if (LeftDown)
        {
            Thruster_RigidBody.velocity = new Vector2(3, 4f) * thrsutForce;
            
            LeftThrusterParticle.Play();
        }
        else if (RightDown)
        {
            Thruster_RigidBody.velocity = new Vector2(-3, 4f) * thrsutForce;
            RightThrusterParticle.Play();
        }
        if (bothButtonsClicked)
        {
            Thruster_RigidBody.velocity = new Vector2(1f, 3f) * 0.5f;
            LeftThrusterParticle.Play();
            RightThrusterParticle.Play();
        }
        
        if (Input.touchCount >= 2)
        {
            Vector2 TouchPLeft = Input.GetTouch(0).position;
            Vector2 TouchPRight = Input.GetTouch(1).position;
            if ((TouchPLeft.x < Screen.width / 2f || TouchPRight.x < Screen.width / 2f)
                && (TouchPRight.x > Screen.width / 2f || TouchPLeft.x > Screen.width / 2f))
            {
                bothButtonsClicked = true;
            }

        }
        else
        {
            bothButtonsClicked = false;
        }

    }
    public void PointerDown(int direction)
    {   
        if(direction==-1)
        {
            LeftDown = true;
            
        }
        if(direction==1)
        {
            RightDown = true;
            
        }
    }
    public void PointerUp(int direction)
    {
        if (direction == -1)
        {
            LeftDown = false;
        }
        if(direction == 1)
        {
            RightDown = false;
        }
    }
    IEnumerator StoppingParticle(float duration)
    {
        yield return new WaitForSeconds(duration);
        LeftThrusterParticle.Stop();
        RightThrusterParticle.Stop();
    }
    
    
}
