using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Camera cam;
    public LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = -100;
        Vector3 MouseP = cam.ScreenToWorldPoint((MousePos));
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(MouseP.x, MouseP.y,MouseP.z), Vector2.zero, 0f);

        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, MouseP);
        
    }
}
