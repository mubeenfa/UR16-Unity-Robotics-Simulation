using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UR16RobotArmController : MonoBehaviour
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

    [Header("Joint Sliders")]
    public Slider j1Slider;
    public Slider j2Slider;
    public Slider j3Slider;
    public Slider j4Slider;
    public Slider j5Slider;
    public Slider j6Slider;

    [Header("Joint Degree")]
    public TextMeshProUGUI txtJ1;
    public TextMeshProUGUI txtJ2;
    public TextMeshProUGUI txtJ3;
    public TextMeshProUGUI txtJ4;
    public TextMeshProUGUI txtJ5;
    public TextMeshProUGUI txtJ6;


    private float  a1, a2, a3, a4, a5, a6;

    void Start()
    {
        // Set slider limits
        j1Slider.minValue = -180f;
        j1Slider.maxValue = 180f;

        j2Slider.minValue = 0f;
        j2Slider.maxValue = 180f;

        j3Slider.minValue = -135f;
        j3Slider.maxValue = 135f;

        j4Slider.minValue = -180f;
        j4Slider.maxValue = 180f;

        j5Slider.minValue = -180f;
        j5Slider.maxValue = 180f;

        j6Slider.minValue = -180f;
        j6Slider.maxValue = 180f;

        // Initialize sliders from robot angles
        j1Slider.value = a1 = j1Angle;   // 0
        j2Slider.value = a2 = j2Angle;   // 62
        j3Slider.value = a3 = j3Angle;   // -111
        j4Slider.value = a4 = j4Angle;   // 172
        j5Slider.value = a5 = j5Angle;   // 87
        j6Slider.value = a6 = j6Angle;   // 100


    }

    void Update()
    {
        //KeyboardControls();

        UpdateJointAnglesWithSlider();

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

    private void UpdateJointAnglesWithSlider()
    {
        j1Angle = j1Slider.value;
        j2Angle = j2Slider.value;
        j3Angle = j3Slider.value;
        j4Angle = j4Slider.value;
        j5Angle = j5Slider.value;
        j6Angle = j6Slider.value;

        UpdateSliderText(j1Angle, j2Angle, j3Angle, j4Angle, j5Angle, j6Angle);
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

    public void Reset()
    {
        j1Slider.value = j1Angle = a1;   // 0
        j2Slider.value = j2Angle = a2;   // 62
        j3Slider.value = j3Angle = a3;   // -111
        j4Slider.value = j4Angle = a4;   // 172
        j5Slider.value = j5Angle = a5;   // 87
        j6Slider.value = j6Angle = a6;   // 100

        UpdateSliderText(a1, a2, a3, a4, a5, a6);
    }

    private void UpdateSliderText(float a1, float a2, float a3, float a4, float a5, float a6)
    {
        txtJ1.text = ((int)a1).ToString() + "°";
        txtJ2.text = ((int)a2).ToString() + "°";
        txtJ3.text = ((int)a3).ToString() + "°";
        txtJ4.text = ((int)a4).ToString() + "°";
        txtJ5.text = ((int)a5).ToString() + "°";
        txtJ6.text = ((int)a6).ToString() + "°";
    }
}