using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class LiftThrusters : MonoBehaviour
{
    public float thrsutForce;
    private Rigidbody2D Thruster_RigidBody;
    public float direction;
    Respawner respawner;
    public Button LeftButton;
    bool both=false;

    // Start is called before the first frame update
    void Start()
    {
        respawner = GetComponent<Respawner>();
        Thruster_RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  var val = Mathf.Clamp()
        if (!respawner.NeedToThrow)
        {
            if (Input.GetKey(KeyCode.Z)&&!both)
            {
                Thruster_RigidBody.velocity = new Vector2(3, 4f) * thrsutForce;
                if(Input.GetKeyDown(KeyCode.X))
                {
                    both = true;
                }

            }
            else if (Input.GetKey(KeyCode.X)&&!both)
            {
                Thruster_RigidBody.velocity = new Vector2(-3, 4f) * thrsutForce;
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    both = true;
                }
            }
            else if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.X))
            {
                Thruster_RigidBody.velocity = new Vector2(1f, 3f) * 1.2f;
            }
            else
            {
                both = false;
            }
        }
        //Debug.Log("Magnitude"+GetComponent<Rigidbody2D>().velocity.magnitude);
    }
   
    }
