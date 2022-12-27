using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float SpeedMove = 5;
    public Rigidbody Rigidbody;
    public Animator Animator;
    public GameObject PlayerChildObject;

    public Vector2 InputValue;
    [SerializeField] private FixedJoystick _fixedJoystick;

    private void FixedUpdate()
    {
        //Keyboard control:
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 speedVector = inputVector * SpeedMove;
        Vector3 speedVectorRelativeToPlayer = transform.TransformVector(speedVector);
        Rigidbody.velocity = new Vector3(speedVectorRelativeToPlayer.x, Rigidbody.velocity.y, speedVectorRelativeToPlayer.z);
        Animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));

        if (Rigidbody.velocity.x > 0)
        {
            Vector3 rotateRight = new Vector3(0, 30, 0);
            PlayerChildObject.transform.rotation = Quaternion.Euler(rotateRight);
        }
        else
        {
            Vector3 rotateLeft = new Vector3(0, 230, 0);
            PlayerChildObject.transform.rotation = Quaternion.Euler(rotateLeft);
        }

        //Mouse control (Joystick):
        if (Input.GetMouseButton(0))
        {
            Vector3 inputMouseVector = new Vector3(_fixedJoystick.Horizontal, Rigidbody.velocity.y, _fixedJoystick.Vertical);
            Vector3 speedMouseVector = inputMouseVector * SpeedMove;
            Vector3 speedMouseVectorRelativeToPlayer = transform.TransformVector(speedMouseVector);
            Rigidbody.velocity = new Vector3(speedMouseVectorRelativeToPlayer.x,
            Rigidbody.velocity.y,
            speedMouseVectorRelativeToPlayer.z);

            Animator.SetFloat("Speed", Mathf.Abs(Rigidbody.velocity.x + Rigidbody.velocity.z));

            if (Rigidbody.velocity.x > 0)
            {
                Vector3 rotateRight = new Vector3(0, 30, 0);
                PlayerChildObject.transform.rotation = Quaternion.Euler(rotateRight);
            }
            else
            {
                Vector3 rotateLeft = new Vector3(0, 230, 0);
                PlayerChildObject.transform.rotation = Quaternion.Euler(rotateLeft);
            }
        }
    }
}
