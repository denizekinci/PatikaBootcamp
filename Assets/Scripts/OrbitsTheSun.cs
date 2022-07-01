using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitsTheSun : MonoBehaviour
{
    [SerializeField] Transform _target;
    Vector3 _startPosition;
    [SerializeField] float _speedCoef;
    float _distanceTravelled;
    float _totalDistance = 0f;
    int _tour = 0;

    void Start()
    {
        //Gets the position of object and calculates the distance between object and target.
        _startPosition = transform.position;
        _totalDistance = Vector3.Distance(_startPosition, _target.position);
    }

    void Update()
    {
        //Calculates the travelled distance by object with speed multiplier.
        _distanceTravelled += _speedCoef * Time.deltaTime;  

        if (_distanceTravelled > 360)
        {
            //If any object completed its tour, resets the distance travelled.
            _distanceTravelled = 0f;
            _tour++;
            Debug.Log(gameObject.name + " has completed its tour. Completed tours count: " + _tour);
        }
        //Object(planet) orbits the sun. Tour time can change with speed multiplier of the planet.
        transform.RotateAround(_target.position, Vector3.up, _speedCoef * Time.deltaTime); 
    }
}