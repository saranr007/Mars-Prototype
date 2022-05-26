using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TouchEvent : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject ThrusterObject;
    public float thrsutForce;
    private Rigidbody2D Thruster_RigidBody;
    public float direction;
    Respawner respawner;
    bool LeftDown;
    bool RightDown;
    bool bothButtonsClicked = false;
    RectTransform rect;
    public enum Buttns
    {
        left=-1,right=1
    }
    public Buttns bts;
    int ButtonDirection;
    // Start is called before the first frame update
    void Start()
    {
        ButtonDirection = Convert.ToInt32(bts);
        respawner = ThrusterObject.GetComponent<Respawner>();
        Thruster_RigidBody = ThrusterObject.GetComponent<Rigidbody2D>();
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(RightDown&&!bothButtonsClicked)
        {
            Thruster_RigidBody.velocity = new Vector2(3, 4f) * thrsutForce;
        }
        if(LeftDown&&!bothButtonsClicked)
        {
            Thruster_RigidBody.velocity = new Vector2(-3, 4f) * thrsutForce;
        }
        if (bothButtonsClicked)
        {
            Debug.Log("pressed");
            Thruster_RigidBody.velocity = new Vector2(1f, 3f) * 0.5f;
        }
        if(Input.touchCount>0)
        {
            Vector2 TouchPos;
            Vector2 MousePLeft = Input.GetTouch(0).position;
            Vector2 MousePRight = Input.GetTouch(1).position;
            if (MousePLeft.x < Screen.width / 2.2f && MousePRight.x > Screen.width / 2.2f)
            {
                Thruster_RigidBody.velocity = new Vector2(1f, 3f) * 0.5f;
            }
        }
        Debug.Log(Screen.width);

    }
    private void Update()
    {
        /*if(Input.touchCount>0)
        {
            Vector2 touchpos = Input.GetTouch(0).position;
            Vector3 tscreen = Camera.main.ScreenToWorldPoint(new Vector3(touchpos.x, touchpos.y, Camera.main.nearClipPlane));
            //Debug.Log("Touched "+touchpos+"Screened"+tscreen);
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect,tscreen,Camera.main,out Vector2 point))
            {
                //Debug.Log("it has a transdrom");
            }

        }
        if(RightDown&&LeftDown)
        {
            Debug.Log("bith");
        }*/
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        /*if(ButtonDirection  == -1)
        {
            LeftDown = true;
        }
        if(ButtonDirection==1)
        {
            RightDown = true;
        }*/
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Vector2 d = eventData.position;
        Debug.Log("eventData.position"+d);
        /*if (ButtonDirection == -1)
        {
            LeftDown = false;
        }
        if (ButtonDirection == 1)
        {
            RightDown =false;
        }
        Debug.LogError("Not Clockiing");*/
    }
    public void PointerDown()
    {
        if(ButtonDirection==-1)
        {
            LeftDown = true;
            if(RightDown)
            {
                bothButtonsClicked = true;
            }
        }
        if(ButtonDirection==1)
        {
            RightDown = true;
            if(LeftDown)
            {
                bothButtonsClicked = true;
            }
        }
    }
    public void PointerUp()
    {
        if (ButtonDirection == -1)
        {
            LeftDown = false;
        }
        if(ButtonDirection==1)
        {
            RightDown = false;
        }
    }
    public void Interrupt()
    {
        if(ButtonDirection==1)
        {
            if(LeftDown)
            {
                bothButtonsClicked = true;
            }
        }
        if (ButtonDirection == -1)
        {
            if (RightDown)
            {
                bothButtonsClicked = true;
            }
        }
    }
    
}
