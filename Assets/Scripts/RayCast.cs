using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Vector2 MouseP = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(MouseP.x, MouseP.y), Vector2.zero, 0.5f);
        if (MouseP.x>Screen.width/2f&&MouseP.x<Screen.width/0.5f)
        {
            Debug.Log("right");
        }
        else
        {
            Debug.Log("Out");
        }
    }
}
