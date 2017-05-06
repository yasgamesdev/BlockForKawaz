using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {
    [SerializeField]
    float accel = 1000.0f;
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigid.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * accel,ForceMode.Impulse);
    }
}
