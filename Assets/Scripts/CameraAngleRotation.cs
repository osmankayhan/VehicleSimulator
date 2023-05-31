using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleRotation : MonoBehaviour
{
    public float maxAngleSpeedHorizontal = 300f;
    private float currentAngleSpeedHorizontal = 0f;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Cursor.visible = !Cursor.visible;
        }
    }

    void LateUpdate()
    {
        //Mouse X Movement
        currentAngleSpeedHorizontal = maxAngleSpeedHorizontal * Input.GetAxisRaw("Mouse X");
        transform.Rotate(new Vector3(0f, currentAngleSpeedHorizontal * Time.deltaTime, 0f));
    }
}