using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject impactOnHit;
    public GameObject smokeOnHit;
    Rigidbody _rigidBody;
    [SerializeField] float _speedCoef;
    float _targetAngle = 35f;
    float _targetY = -20f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidBody.useGravity = true;
    }

    private void Update()
    {
        //Meteor goes through random generated position with force.
        Vector3 lookDirection = (TargetPositionGenerator() - transform.position).normalized;
        _rigidBody.AddForce(lookDirection * _speedCoef);


        //Destroys meteor when it's path ends.
        if (gameObject.transform.position.y <= _targetY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroys meteor when collisions with any GameObject and creates particles.
        Destroy(gameObject);
        ParticleSpawner();
    }

    void ParticleSpawner()
    {
        //Generates particles and destroys them after 2 sec
        GameObject _impactEffectOnHit = (GameObject)Instantiate(impactOnHit, transform.position, transform.rotation);
        GameObject _smokeEffectOnHit = (GameObject)Instantiate(smokeOnHit, transform.position, transform.rotation);
        Destroy(_impactEffectOnHit, 2f);
        Destroy(_smokeEffectOnHit, 2f);
    }

    //Generates random target position for meteors.
    public Vector3 TargetPositionGenerator()
    {
        float spawnPositionX = Random.Range(-_targetAngle, _targetAngle);

        float spawnPositionY = _targetY;

        float spawnPositionZ = Random.Range(-_targetAngle, _targetAngle);

        Vector3 _fallingPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
        return _fallingPosition;
    }
}
