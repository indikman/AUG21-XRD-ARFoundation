using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // Check the collision and destroy the object as well as the robot
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RobotMovement>())
        {
            Manager.Instance.LoseLife();
            Destroy(collision.gameObject); // this will destroy the robot
            Destroy(gameObject); // this will destroy myself -> cannoball
        }
    }
}
