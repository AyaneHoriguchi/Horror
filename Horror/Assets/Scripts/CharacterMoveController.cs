using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{

    public CharacterController CharacterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer = true;
    public float playerSpeed = 2.0f;
    public float jumppower = 1.0f;
    public Animator Animator;

   

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = CharacterController.isGrounded;
        if(groundedPlayer && playerVelocity.y< 0)
        {
            playerVelocity.y = 0;

        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        var movePower = Mathf.Abs(move.z) + Mathf.Abs(move.x);

        Animator.SetFloat("MovePower", movePower);


        CharacterController.Move(move * Time.deltaTime * playerSpeed);

        if(move != Vector3.zero)
        {
            gameObject.transform.forward = move;

        }

        
    }
}
