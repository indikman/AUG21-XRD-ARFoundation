using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{

    public float moveSpeed = 30f;
    public float turnSpeed = 5f;
    public float deadZone = 0.2f;

    private Animator robotAnim;
    private Rigidbody robotBody;
    private Joystick joystick;



    // Start is called before the first frame update
    void OnEnable()
    {
        robotAnim = GetComponent<Animator>();
        robotBody = GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();

        robotAnim.SetBool("Open_Anim", true);

    }



    // Update is called once per frame
    void Update()
    {
        if(joystick.Direction.magnitude >= deadZone)
        {
            robotBody.AddForce(transform.forward * moveSpeed);
            robotAnim.SetBool("Walk_Anim", true);
        }
        else
        {
            robotAnim.SetBool("Walk_Anim", false);
        }

        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(direction);

    }
}
