using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eBodyColor
{
    Red,
    Green,
    Blue
}
public class RotationSample : MonoBehaviour
{
    public eBodyColor bodyColor = new eBodyColor();
    public Color Red, Green, Blue, currentColor;
    float x, y, z, t;
    public Vector3 currentEulerAngles;
    public Quaternion currentRotation;
    public float rotSpeed;

    public Transform targetA;
    public Transform targetB;

    float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Red = Color.red;
        Green = Color.green;
        Blue = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        RotateInput();
        //QuaternionRotateTowards();
        //SlerpExample();
        LookRotation();
    }

    private void OnMouseDown()
    {
        switch (bodyColor)
        {
            case eBodyColor.Red:
                currentColor = Color.red;
                
                break;
            case eBodyColor.Green:
                currentColor = Color.green;
                break;
            case eBodyColor.Blue:
                currentColor = Color.blue;
                break;
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new()
        {
            fontSize = 24
        };

        // Shows where our euler angles of the quaternion is stored
        GUI.Label(new Rect(10, 0, 0, 0), "Rotating on X: " + x + " Y: " + y + " Z: " + z, style);

        // Outputs the Quaternion.eulerAngles Value
        GUI.Label(new Rect(12, 30, 0, 0), "Current Euler Angles: " + currentEulerAngles, style);

        // Outputs the transform.eulerAngles Value
        GUI.Label(new Rect(12, 60, 0, 0), "World Euler Angles: " + transform.eulerAngles, style);
    }

    void RotateInput()
    {
        if (Input.GetKeyDown(KeyCode.X)) { x = 1 - x; }
        if (Input.GetKeyDown(KeyCode.Y)) { y = 1 - y; }
        if (Input.GetKeyDown(KeyCode.Z)) { z = 1 - z; }

        currentEulerAngles += rotSpeed * Time.deltaTime * new Vector3(x, y, z);
        currentRotation.eulerAngles = currentEulerAngles;
        transform.rotation = currentRotation;
    }

    void QuaternionRotateTowards()
    {
        if (Input.GetKeyDown(KeyCode.T)) { t = 1 - t; }
        Transform target = (t == 0) ? targetA : targetB;
        float step = rotSpeed * Time.time;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
    }

    void SlerpExample()
    {
        transform.rotation = Quaternion.Slerp(targetA.rotation, targetB.rotation, timeCount);
        timeCount += Time.deltaTime;
    }

    void LookRotation()
    {
        if (Input.GetKeyDown(KeyCode.T)) { t = 1 - t; }
        Transform target = (t == 0) ? targetA : targetB;
        float step = rotSpeed * Time.time;
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);
    }
}