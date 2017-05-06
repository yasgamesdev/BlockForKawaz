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

        CreateBlocks();
    }

    void CreateBlocks()
    {
        Transform parent = GameObject.Find("Blocks").transform;

        Vector3 start_pos = new Vector3(-4.0f, 0, 5.0f);
        for(int x=0; x<5; x++)
        {
            for (int z = 0; z < 5; z++)
            {
                GameObject block = (GameObject)Instantiate(Resources.Load("Block"), parent);
                block.transform.position = start_pos + new Vector3(2.0f * x, 0, 1.0f * z);
            }
        }
    }

    void FixedUpdate()
    {
        RaycastHit hitInfo;
        if(Physics.SphereCast(transform.position, 0.5f, velocity, out hitInfo, velocity.magnitude * Time.deltaTime, layerMask))
        {
            transform.position += (hitInfo.point - transform.position);
            velocity += -2.0f * Vector3.Dot(velocity, hitInfo.normal) * hitInfo.normal;

            CheckBlockDestroy(hitInfo);
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
        }
    }

    void CheckBlockDestroy(RaycastHit hitInfo)
    {
        if(hitInfo.collider.tag == "Block")
        {
            Destroy(hitInfo.collider.gameObject);
        }
    }
}
