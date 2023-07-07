using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    private HingeJoint2D joint;
    [SerializeField] private float angle;
    [SerializeField] private float speed;
    private void Start()
    {
        joint = GetComponent<HingeJoint2D>();
        if (joint != null)
        {
            // Modify the lower angle limit
            joint.limits = new JointAngleLimits2D { min = angle, max = 0f };

            // Modify the motor speed
            joint.motor = new JointMotor2D { motorSpeed = speed, maxMotorTorque = 1000f };
        }

    }

    private void Update()
    {
        // 15 initial z rotation
        if (Mathf.Round(transform.eulerAngles.z) == (360-angle)+15)
        {

            joint.motor = new JointMotor2D { motorSpeed = -speed, maxMotorTorque = 1000f };
        }
        else if(Mathf.Round(transform.eulerAngles.z) == 15)
        {
            joint.motor = new JointMotor2D { motorSpeed = speed, maxMotorTorque = 1000f };
        }
    }
}
