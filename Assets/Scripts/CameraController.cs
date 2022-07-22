using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField] private Transform _target;
    [SerializeField][Range(1, 10)] private float _mouseSensitivity;

    float _speedCoef = 50f;
    float _scrollCoef = 2;
    float cooldown = 3;

    private void Start()
    {
        //Set current instance to variable
        instance = this;
    }

    private void Update()
    {
        //If user uses mouse wheel, executes Zoom function.
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Zoom();
        }
        //If user clicks with LMB and the clicked object isn't any UI element, executes RotateWithHand function.
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.currentSelectedGameObject)
            {
                RotateWithHand();
                cooldown = 3;
            }
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        } 
        else
        {
            AutoCamera();
        }
    }

    private void RotateWithHand()
    {
        //Get mouse's value on X Axis.
        float mouseX = Input.GetAxis("Mouse X");

        //Rotate camera around the Sun on X axis when user drags with mouse.
        transform.RotateAround(_target.position, Vector3.up, mouseX * _mouseSensitivity);

        //Changes the camera's rotation through the Sun.
        transform.LookAt(_target.position);
    }

    private void AutoCamera()
    {
        //Orbits camera around the Sun.
        transform.RotateAround(_target.position, Vector3.up, _speedCoef * Time.deltaTime);

        //Changes the camera's rotation through the Sun.
        transform.LookAt(_target.transform);
    }
    private void Zoom()
    {
        //Set Mouse Wheel direction value to scrollInput
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        //Limit the zoom in-out and check if current value between 28 and 122
        if (GetComponent<Camera>().fieldOfView > 28 && GetComponent<Camera>().fieldOfView < 122)
        {
            //Check current FOV and mouse wheel scroll direction and zoom out
            if (scrollInput < 0 && GetComponent<Camera>().fieldOfView < 120)
            {
                GetComponent<Camera>().fieldOfView = GetComponent<Camera>().fieldOfView + _scrollCoef;
            }
            //Check current FOV and mouse wheel scroll direction and zoom in
            if (scrollInput > 0 && GetComponent<Camera>().fieldOfView > 30)
            {
                GetComponent<Camera>().fieldOfView = GetComponent<Camera>().fieldOfView - _scrollCoef;
            }
        }
    }
}