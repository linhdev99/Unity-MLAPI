using System;
using System.Collections;
using System.Collections.Generic;
using MLAPI;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    CharacterController cc;

    public Transform cameraTrans;

    public float speed = 5f;

    float pitch = 0f;

    void Start()
    {
        if (!IsLocalPlayer)
        {
            cameraTrans.GetComponent<AudioListener>().enabled = false;
            cameraTrans.GetComponent<Camera>().enabled = false;
        }
        else
        {
            cc = GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            MovePlayer();
            Look();
        }
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * 3f;
        transform.Rotate(0, mouseX, 0);
        pitch -= Input.GetAxis("Mouse Y") * 3f;
        pitch = Mathf.Clamp(pitch, -45f, 45f);
        cameraTrans.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    private void MovePlayer()
    {
        Vector3 move =
            new Vector3(Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1f);
        move = transform.TransformDirection(move);
        cc.SimpleMove(move * speed);
    }
}
