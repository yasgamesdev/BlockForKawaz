using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    float speed = 20.0f;
    int layerMask;

    Vector3 velocity;

    void Start()
    {
        layerMask = LayerMask.GetMask("Bound");
        velocity = (transform.forward + transform.right) * speed;
    }

    void FixedUpdate()
    {
        RaycastHit hitInfo;
        if(Physics.SphereCast(transform.position, 0.5f, velocity, out hitInfo, velocity.magnitude * Time.deltaTime, layerMask))
        {
            transform.position += (hitInfo.point - transform.position);
            velocity += -2.0f * Vector3.Dot(velocity, hitInfo.normal) * hitInfo.normal;
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
        }
    }

    void Update () {
	}
}
