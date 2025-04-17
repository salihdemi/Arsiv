using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSMovement : MonoBehaviour
{
    public float speed = 5;
    private float hori, vert;
    [SerializeField]
    private Transform cameraTransporter;
    [SerializeField]
    private Rigidbody rb;
    void Start()
    {

    }

    void Update()
    {
        hori = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 force = cameraTransporter.transform.forward * vert + cameraTransporter.transform.right * hori;
        //rb.AddForce(force.normalized * speed * Time.deltaTime, ForceMode.Force);//kayýyor
        rb.velocity = force.normalized * speed * 100 * Time.deltaTime;






        if (Input.GetKey(KeyCode.W))
        {
            Larb(cameraTransporter);
        }/*
        else if(Input.GetKey(KeyCode.A))
        {
            Larb(left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Larb(right);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Larb(back);
        }*/
    }
    private void Larb(Transform a)
    {
        Quaternion chrAngle = transform.rotation;
        Quaternion camTAngle = a.rotation;
        chrAngle = Quaternion.Lerp(chrAngle, camTAngle, 0.1f);
        transform.rotation = chrAngle;
    }
}
