using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    public Transform spawnPoint;

    public float shootingForce = 40f;
    public float turnSpeed = 20f;


    
    void OnEnable()
    {
        // Start shooting in intervals
        InvokeRepeating("ShootAtPlayer", 3f, 3f);
    }


    void Update()
    {
        if (!Robot())
        {
            return;
        }
        else
        {
            // Rotate the cannon towards the player / robot

            Vector3 targetDirection = Robot().transform.position - transform.position; // Direction towards the player w.r.t cannon
            Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }


    private void ShootAtPlayer()
    {
        if (Robot())
        {
            GameObject newCannonBall = Instantiate(cannonBall, spawnPoint.position, spawnPoint.rotation);
            newCannonBall.GetComponent<Rigidbody>().AddForce(shootingForce * cannonBall.transform.forward);

            // Destroy the cannon ball aftrer 2 seconds
            Destroy(newCannonBall, 2f);

            //Invoke("destroyCannon", 2f);
        }
    }

   


    private GameObject Robot()
    {
        RobotMovement robot = FindObjectOfType<RobotMovement>();

        if (robot)
        {
            return robot.gameObject;
        }

        return default;
    }
}
