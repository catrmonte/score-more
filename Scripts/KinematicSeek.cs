using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MonoBehaviour {

    public Transform target;
    public Transform character;
    public float maxSpeed;

    public class KinematicSteeringOutput {
        public Vector3 velocity;
        public Vector3 angularVelocity; 
    }

    void Update()
    {
        KinematicSteeringOutput newSteering = getSteering();

        character.position += newSteering.velocity * Time.deltaTime;

        character.eulerAngles = newSteering.angularVelocity;
    }    

    KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        float angle;

        // Getting the direction towards target by getting the difference between target & character
        result.velocity = target.position - character.position;

        // Normalize and set speed
        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        angle = newOrientation( character.transform.eulerAngles.y , result.velocity);
        angle *= Mathf.Rad2Deg;

        result.angularVelocity = new Vector3(0, angle, 0);

        return result;
    }

    // returns new orientation towards target in radians
    float newOrientation(float currentOrientation, Vector3 velocity)
    {
        if (velocity != Vector3.zero)
        {
            return Mathf.Atan2(velocity.x, velocity.z);
        }

        return currentOrientation;
    }
}
