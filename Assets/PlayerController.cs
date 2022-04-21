using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System;

public class PlayerController : MonoBehaviour
{
    public Transform trans;
    public KeyController keyController;
    public Rigidbody body;
    public Transform TransOfCamera;

    public float MaxSpeedOfFreeFall;
    public float SpeedOfRotation;

    public float Speed = 1;
    float x, y;

    KeyCode Up;
    KeyCode Rigth;
    KeyCode Down;
    KeyCode Left;
    public bool OnActiveComponent { get; private set; } = true;

    public void OnActivatorComponent(bool value)
    {
        OnActiveComponent = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        x = TransOfCamera.rotation.eulerAngles.y;
        y = TransOfCamera.rotation.eulerAngles.x;
        Up = keyController.GetKey(NameOfComand.Up);
        Rigth = keyController.GetKey(NameOfComand.Right);
        Down = keyController.GetKey(NameOfComand.Down);
        Left = keyController.GetKey(NameOfComand.Left);
    }

    // Update is called once per frame
    void Update()
    {
        if (OnActiveComponent == true)
        {
            if (Input.GetKey(Up)) Translate(trans.forward);
            if (Input.GetKey(Rigth)) Translate(trans.right);
            if (Input.GetKey(Down)) Translate(trans.forward * -1);
            if (Input.GetKey(Left)) Translate(trans.right * -1);
            if (Mathf.Abs(body.velocity.y) > Mathf.Abs(MaxSpeedOfFreeFall))
            {
                body.velocity = new Vector3(body.velocity.x,
                MaxSpeedOfFreeFall * Mathf.Sign(body.velocity.y), body.velocity.z);
            }
            x += Input.GetAxis("Mouse X") * Time.deltaTime * SpeedOfRotation;
            y -= Input.GetAxis("Mouse Y") * Time.deltaTime * SpeedOfRotation;
            Quaternion ratetion = Quaternion.Euler(y, x, 0);
            trans.rotation = ratetion;
            
        }
    }

    private void Translate(Vector3 delta)
    {
        trans.position += delta* Time.deltaTime * Speed;
    }
}
