using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float YMin = -50.0f;
    [SerializeField] private float YMax = 50.0f;

    public Transform lookAt;

    public Transform Player;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        //Debug.Log(currentX);

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;
        //transform.rotation = rotation;

        transform.LookAt(lookAt.position);
    }

}
