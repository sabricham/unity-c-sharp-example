using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Tweaking settings
    [Range(0f, 10f)]
    public float forward_starting_velocity;
    [Range(0f, 10f)]
    public float forward_acceleration;
    [Range(0f, 10f)]
    public float forward_starting_acceleration;
    [Range(0f, 2f)]
    public float forward_smoothness;
    [Range(0f, 10f)]
    public float jump_force;

    //Stats
    private bool fly = false;
    private bool jump = false;
    private bool fall = false;
    private float forward_velocity;

    //Various
    private float forward_currentVelocity;

    //Components
    private Rigidbody body;
    private Animator anim;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        forward_velocity = forward_starting_velocity;
    }

    private void AndroidCommands()
    {
        //input type working on android devices
        if (Input.touchCount > 0 && !jump && !fly)
        {
            body.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
            jump = true;
        }
        if (Input.touchCount == 0)
            jump = false;
    }

    private void TestCommands()
    {
        //input type working on development environment
        if (Input.GetKeyDown(KeyCode.Space) && !fly)
        {
            body.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
            jump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            jump = false;
    }

    private void Movement()
    {
        //update target velocity
        forward_velocity += forward_acceleration * Time.deltaTime;

        //smooth following the new target
        float x_velocity;
        x_velocity = Mathf.SmoothDamp(body.velocity.x, forward_velocity, ref forward_currentVelocity, forward_smoothness);

        //apply
        body.velocity = new Vector3(x_velocity, body.velocity.y, body.velocity.z);
    }

    private void Animation()
    {
        anim.SetBool("Jump", jump);

        anim.SetBool("Fly", fly);

        anim.SetBool("Fall", fall);
    }

    private void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
            AndroidCommands();
        else if(Application.platform == RuntimePlatform.WindowsEditor)
            TestCommands();        

        Movement();

        Animation();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FallTrigger") fall = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FallTrigger") fall = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Terrain") fly = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Terrain") fly = true;
    }
}
