using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleY : MonoBehaviour
{
    public float SensivityY;
    public float minAngle;
    public float maxAngle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Rot = transform.localEulerAngles.x + -Time.deltaTime * SensivityY * Input.GetAxis("Mouse Y") * 1000;
        Rot = Mathf.Clamp(Rot, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(Rot, 0, 0);
    }
}
