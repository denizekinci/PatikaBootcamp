using System;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField] private Transform _target;
    [SerializeField][Range(1, 10)] private float _mouseSensitivity;


    public float _speedCoef = 50f;
    private float _scrollCoef = 2;
    float cooldown = 3;


    private void Start()
    {
        //Set current instance to variable
        instance = this;
    }

    private void Update()
    {
        //If user uses mouse wheel
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Zoom();
        }

        if (Input.GetMouseButton(0))
        {
            RotateWithHand();
            cooldown = 3;
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
        //Get mouses input value on X Axis.
        float mouseX = Input.GetAxis("Mouse X");

        //Rotate camera around the Sun on X axis with input direction.
        transform.RotateAround(_target.position, Vector3.up, mouseX * _mouseSensitivity);

        //Always looks through Sun.
        transform.LookAt(_target.position);
    }

    private void AutoCamera()
    {
        //Rotates camera around the Sun with given speed multiplier
        transform.RotateAround(_target.position, Vector3.up, _speedCoef * Time.deltaTime);

        //Always looks through Sun.
        transform.LookAt(_target.transform);
    }
    private void Zoom()
    {
        //Set Mouse Wheel value to variable.
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        //Check if current FOV greater than 28 and lesser than 122
        if (GetComponent<Camera>().fieldOfView > 28 && GetComponent<Camera>().fieldOfView < 122)
        {
            //Zoom out if current FOV lesser than 120
            if (scrollInput < 0 && GetComponent<Camera>().fieldOfView < 120)
            {
                GetComponent<Camera>().fieldOfView = GetComponent<Camera>().fieldOfView + _scrollCoef;
            }
            //Zoom in if current FOV greater than 30
            if (scrollInput > 0 && GetComponent<Camera>().fieldOfView > 30)
            {
                GetComponent<Camera>().fieldOfView = GetComponent<Camera>().fieldOfView - _scrollCoef;
            }
        }
    }
}