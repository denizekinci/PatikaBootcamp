using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    [SerializeField] float _speedCoef;

    void Update()
    {
        //It makes the any given object to rotate around itself with given speed multiplier.
        transform.RotateAround(transform.position, Vector3.up, _speedCoef * Time.deltaTime);
    }
}