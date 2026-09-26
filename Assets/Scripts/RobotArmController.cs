using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArmController : MonoBehaviour
{
    [Header("Robot Joints")]
    public Transform baseJoint;
    public Transform shoulderJoint;
    public Transform elbowJoint;
    public Transform wristJoint;

    [Header("Joint Angles")]
    public float baseAngle = 0f;
    public float shoulderAngle = 0f;
    public float elbowAngle = 0f;
    public float wristAngle = 0f;




    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            baseAngle -= 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            baseAngle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            shoulderAngle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            shoulderAngle -= 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
            elbowAngle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            elbowAngle -= 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.Z))
            wristAngle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.X))
            wristAngle -= 30f * Time.deltaTime;


        // Joint limits

        baseAngle = Mathf.Clamp(
            baseAngle,
            -180f,
            180f
        );

        shoulderAngle = Mathf.Clamp(
            shoulderAngle,
            -90f,
            90f
        );

        elbowAngle = Mathf.Clamp(
            elbowAngle,
            0f,
            135f
        );

        wristAngle = Mathf.Clamp(
            wristAngle,
            -90f,
            90f
        );


        // Apply joint rotations

        baseJoint.localRotation =
            Quaternion.Euler(0f, baseAngle, 0f);

        shoulderJoint.localRotation =
            Quaternion.Euler(shoulderAngle, 0f, 0f);

        elbowJoint.localRotation =
            Quaternion.Euler(elbowAngle, 0f, 0f);

        wristJoint.localRotation =
            Quaternion.Euler(wristAngle, 0f, 0f);
    }
}
