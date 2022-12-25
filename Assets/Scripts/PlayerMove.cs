using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float SpeedMove = 5;
    public Rigidbody Rigidbody;
    public Animator Animator;
    public GameObject Player;

    private void FixedUpdate()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 speedVector = inputVector * SpeedMove;

        Vector3 speedVectorRelativeToPlayer = transform.TransformVector(speedVector);
        Rigidbody.velocity = new Vector3(speedVectorRelativeToPlayer.x, Rigidbody.velocity.y, speedVectorRelativeToPlayer.z);
        Animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));

        if (Rigidbody.velocity.x > 0)
        {
            Vector3 rotateRight = new Vector3(0, 30, 0);
            Player.transform.rotation = Quaternion.Euler(rotateRight);
        }
        else
        {
            Vector3 rotateLeft = new Vector3(0, 230, 0);
            Player.transform.rotation = Quaternion.Euler(rotateLeft);
        }
    }
}
