using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    [SerializeField] float thrustSpeed = 1000f ;
    [SerializeField] float rotateSpeed = 700 ;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrusting();
        Rotation();     
    }

    void Thrusting()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }
    }

    void Rotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-rotateSpeed);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotateSpeed);
        }
    }
    // testing testing 

    void ApplyRotation(float RotatePosNeg)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.right * RotatePosNeg * Time.deltaTime);
        rb.freezeRotation = false;
    }

    /* In Unity's Vector3 notation, along with Vector3.right and Vector3.up, the third commonly used vector is Vector3.forward.

    Vector3.right: Represents the positive X-axis direction (1, 0, 0).
    Vector3.up: Represents the positive Y-axis direction (0, 1, 0).
    Vector3.forward: Represents the positive Z-axis direction (0, 0, 1).

    These three vectors correspond to the primary axes in a 3D coordinate system, making them essential for various transformations and calculations in Unity's 3D space. */
}
