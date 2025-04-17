using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//transporterY`nin x konumu deðiþip omuz kamerasý olabilir, sorun çýkarmaz.
public class TPSCamera : MonoBehaviour
{
    [SerializeField]
    private float followSpeed = 0.01f;
    [SerializeField]
    private float sensitivity = 5;
    private Transform transporterX;
    private Transform transporterY;
    public Transform character;
    void Start()
    {
        transporterX = transform.parent;
        transporterY = transform.parent.parent;
    }
    void Update()
    {
        transporterX.Rotate(Vector3.right * sensitivity * Input.GetAxis("Mouse Y") * 100 * Time.deltaTime);
        transporterY.Rotate(Vector3.up * sensitivity * Input.GetAxis("Mouse X") * 100 * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        transporterY.position = Vector3.Lerp(transporterY.position, character.position, followSpeed);//karakteri takip
    }
    private void LateUpdate()
    {
        transporterX.localEulerAngles = Vector3.right * transporterX.localEulerAngles.x;//bakýþ kilidi geçici
    }


}
