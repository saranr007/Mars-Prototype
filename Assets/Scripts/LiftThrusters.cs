using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftThrusters : MonoBehaviour
{
    public float thrsutForce;
    private Rigidbody2D Thruster_RigidBody;
    public float direction;
    Respawner respawner;

    // Start is called before the first frame update
    void Start()
    {
        respawner = GetComponent<Respawner>();
        Thruster_RigidBody = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Thruster_RigidBody.velocity.magnitude);
        direction = Input.GetAxis("Horizontal");
        //  var val = Mathf.Clamp()
        if (!respawner.NeedToThrow)
        {
            if (direction > 0f)
            {
                Thruster_RigidBody.velocity = new Vector2(3, 4f) * thrsutForce;
            }
            else if (direction < 0f)
            {
                Thruster_RigidBody.velocity = new Vector2(-3, 4f) * thrsutForce;
            }
            else if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.X))
            {
                Thruster_RigidBody.velocity = new Vector2(1f, 3f) * 1.2f;
            }
        }
        //Debug.Log("Magnitude"+GetComponent<Rigidbody2D>().velocity.magnitude);
    }
}
