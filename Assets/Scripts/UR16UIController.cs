using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UR16UIController : MonoBehaviour
{
    public UR16Controller robot;

    [Header("Joint Sliders")]
    public Slider j1Slider;
    public Slider j2Slider;
    public Slider j3Slider;
    public Slider j4Slider;
    public Slider j5Slider;
    public Slider j6Slider;

    [Header("Joint Degree Text")]
    public TextMeshProUGUI txtJ1;
    public TextMeshProUGUI txtJ2;
    public TextMeshProUGUI txtJ3;
    public TextMeshProUGUI txtJ4;
    public TextMeshProUGUI txtJ5;
    public TextMeshProUGUI txtJ6;

    private float a1, a2, a3, a4, a5, a6;

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
        j1Slider.value = a1 = robot.j1Angle;   // 0
        j2Slider.value = a2 = robot.j2Angle;   // 62
        j3Slider.value = a3 = robot.j3Angle;   // -111
        j4Slider.value = a4 = robot.j4Angle;   // 172
        j5Slider.value = a5 = robot.j5Angle;   // 87
        j6Slider.value = a6 = robot.j6Angle;   // 100

    }


    void Update()
    {
        UpdateJointAnglesWithSlider();
    }

    private void UpdateJointAnglesWithSlider()
    {
        robot.j1Angle = j1Slider.value;
        robot.j2Angle = j2Slider.value;
        robot.j3Angle = j3Slider.value;
        robot.j4Angle = j4Slider.value;
        robot.j5Angle = j5Slider.value;
        robot.j6Angle = j6Slider.value;

        UpdateSliderText(robot.j1Angle, robot.j2Angle, robot.j3Angle, robot.j4Angle, robot.j5Angle, robot.j6Angle);
    }

    public void Reset()
    {
        j1Slider.value = robot.j1Angle = a1;   // 0
        j2Slider.value = robot.j2Angle = a2;   // 62
        j3Slider.value = robot.j3Angle = a3;   // -111
        j4Slider.value = robot.j4Angle = a4;   // 172
        j5Slider.value = robot.j5Angle = a5;   // 87
        j6Slider.value = robot.j6Angle = a6;   // 100

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
