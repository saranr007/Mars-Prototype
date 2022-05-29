using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Camera cam;
    public LineRenderer line;
    // Strt is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            /*Touch T = Input.GetTouch(0);
            Vector3 MouseP = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(MouseP.x, MouseP.y), Vector2.zero, 0.5f);
            if(hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
            }*/
        }
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = -100;
        Vector3 MouseP = cam.ScreenToWorldPoint((MousePos));
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(MouseP.x, MouseP.y,MouseP.z), Vector2.zero, 0f);
        if (hit.collider)
        {
            Debug.LogWarning(hit.collider.gameObject.name);
        }
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, MouseP);
        /*if (MouseP.x>Screen.width/2f&&MouseP.x<Screen.width/0.5f)
        {
            Debug.Log("right");
        }
        else
        {
            Debug.Log("Out");
        }*/
    }
}
