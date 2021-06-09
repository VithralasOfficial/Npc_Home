using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float distance = 4f;
   // public Text message;
    private Camera mainCam;
    private CharacterController controller;
    private float xRotation = 0f;
    private Vector3 velocity;
   // private AudioSource footSteps;
    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        controller = transform.GetComponent<CharacterController>();
        //footSteps = transform.GetComponent<AudioSource>();
        lastPos = transform.position;
    }

    //void checkInteraction()
    //{
    //    message.text = "";
    //    Vector3 origin = mainCam.transform.position;
    //    Vector3 direction = mainCam.transform.forward;
    //    RaycastHit hit;
    //    if (Physics.Raycast(origin, direction, out hit, distance))
    //    {
    //        if (hit.transform.tag == "bench")
    //        {
    //            message.text = "Press F to sit on bench";

    //            if (Input.GetKeyDown(KeyCode.F))
    //            {
    //                transform.position = new Vector3(hit.transform.position.x - 0.5f, transform.position.y + 1
    //                    , hit.transform.position.z);
    //                transform.Rotate(0, 180 - transform.rotation.y, 0, Space.World);
    //            }
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        mainCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //if (transform.position.x != lastPos.x || transform.position.z != lastPos.z)
        //{
        //    lastPos = transform.position;
        //    if (!footSteps.isPlaying)
        //        footSteps.Play();
        //}


        //checkInteraction();
    }
}
