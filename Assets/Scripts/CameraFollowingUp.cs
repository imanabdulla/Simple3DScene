using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingUp : MonoBehaviour
{
    public Transform m_camTarget;
    public float m_walkDistance;
    public float m_runDistance;
    public float m_height;
    public float m_xSpeed;
    public float m_ySpeed;
    public float m_heightDamping = 2.0f;
    public float m_rotationDamping = 3.0f;


    private Transform camTransform;
    private float x, y;
    private bool isMouseDown = false;
    private Vector3 movingVelocity;

    private void Awake ()
    {
        camTransform = this.transform;
	}

    private void Start()
    {
        SetupCamera();
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(1))
    //        isMouseDown = true;
    //    if (Input.GetMouseButtonUp(1))
    //        isMouseDown = false;
    //}

    private void Update ()
    {
        //if (isMouseDown)
        //{
        //    x += Input.GetAxis("Mouse X") * m_xSpeed * 0.02f;
        //    y += Input.GetAxis("Mouse Y") * m_ySpeed * 0.02f;

        //    Quaternion rotation = Quaternion.Euler(y, x, 0);
        //    Vector3 position = rotation * new Vector3(0.0f, 0.0f, -m_walkDistance) + m_camTarget.position;

        //    camTransform.rotation = rotation;
        //    camTransform.position = position;
        //}
        //else
        //{
            camTransform.position = new Vector3(m_camTarget.position.x, m_camTarget.position.y + m_height, m_camTarget.position.z - m_walkDistance);
            //camTransform.position = Vector3.SmoothDamp(camTransform.position, m_camTarget.position, ref movingVelocity, Time.deltaTime);
            camTransform.LookAt(m_camTarget);

            x = 0;
            y = 0;

            ////get wanted postion and rotation of camera
            //float wantedHeight = m_camTarget.position.y + m_height;
            //float wantedRotationAngle = m_camTarget.eulerAngles.y;

            ////get current postion and rotation of camera
            //float currentHeight = camTransform.position.y;
            //float currentRotationAngle = camTransform.eulerAngles.y;

            ////lerp camera transform to target transform
            //currentHeight = Mathf.Lerp(currentHeight, wantedHeight, m_heightDamping * Time.deltaTime);
            //currentRotationAngle = Mathf.Lerp(currentRotationAngle, wantedRotationAngle, m_rotationDamping * Time.deltaTime);

            ////convert currentRotationAngle to Rotation;
            //Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            //camTransform.position = m_camTarget.position;
            //camTransform.position -= currentRotation * Vector3.forward * m_walkDistance;


            //camTransform.position = new Vector3(camTransform.position.x, currentHeight, camTransform.position.z);
            //camTransform.LookAt(m_camTarget);

        //}
    }

    private void SetupCamera()
    {
        camTransform.position = new Vector3(m_camTarget.position.x, m_camTarget.position.y + m_height, m_camTarget.position.z - m_walkDistance);
        camTransform.LookAt(m_camTarget);

    }
}
