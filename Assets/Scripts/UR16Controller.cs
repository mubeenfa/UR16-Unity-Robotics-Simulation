using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UR16Controller : MonoBehaviour
{
    [Header("UR16 Joints")]
    public Transform baseJoint;
    public Transform shoulderJoint;
    public Transform elbowJoint;
    public Transform wrist1Joint;
    public Transform wrist2Joint;
    public Transform wrist3Joint;

    [Header("Joint Angles")]
    public float j1Angle = 0f;
    public float j2Angle = 0f;
    public float j3Angle = 0f;
    public float j4Angle = 0f;
    public float j5Angle = 0f;
    public float j6Angle = 0f;

    [Header("Joint Limits")]

    public float j1Min = -180f;
    public float j1Max = 180f;

    public float j2Min = 0f;
    public float j2Max = 180f;

    public float j3Min = -135f;
    public float j3Max = 135f;

    public float j4Min = -180f;
    public float j4Max = 180f;

    public float j5Min = -180f;
    public float j5Max = 180f;

    public float j6Min = -180f;
    public float j6Max = 180f;


    void Update()
    {
        //KeyboardControls();

        ClampJointAngles();
        ApplyJointRotations();
    }

    private void KeyboardControls()
    {
        if (Input.GetKey(KeyCode.A))
            j1Angle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            j2Angle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
            j3Angle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            j4Angle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.Z))
            j5Angle += 30f * Time.deltaTime;

        if (Input.GetKey(KeyCode.X))
            j6Angle += 30f * Time.deltaTime;
    }

    void ClampJointAngles()
    {
        j1Angle = Mathf.Clamp(j1Angle, j1Min, j1Max);
        j2Angle = Mathf.Clamp(j2Angle, j2Min, j2Max);
        j3Angle = Mathf.Clamp(j3Angle, j3Min, j3Max);
        j4Angle = Mathf.Clamp(j4Angle, j4Min, j4Max);
        j5Angle = Mathf.Clamp(j5Angle, j5Min, j5Max);
        j6Angle = Mathf.Clamp(j6Angle, j6Min, j6Max);
    }

    void ApplyJointRotations()
    {
        // J1 - Base
        baseJoint.localRotation =
            Quaternion.Euler(
                0f,
                0f,
                j1Angle
            );

        // J2 - Shoulder
        shoulderJoint.localRotation =
            Quaternion.Euler(
                -90f,
                j2Angle,
                0f
            );

        // J3 - Elbow
        elbowJoint.localRotation =
            Quaternion.Euler(
                0f,
                0f,
                j3Angle
            );

        // J4 - Wrist 1
        wrist1Joint.localRotation =
            Quaternion.Euler(
                0f,
                0f,
                j4Angle
            );

        // J5 - Wrist 2
        wrist2Joint.localRotation =
            Quaternion.Euler(
                -90f,
                0f,
                j5Angle
            );

        // J6 - Wrist 3
        wrist3Joint.localRotation =
            Quaternion.Euler(
                90f,
                0f,
                j6Angle
            );
    }
    
}