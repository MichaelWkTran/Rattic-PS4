using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] Animator animator;
    [SerializeField]
    public PlayerInteractionArea playerScript;
    public bool canMove = true;

    private void Start()
    {
        if (!playerScript)
            playerScript = FindObjectOfType<PlayerInteractionArea>();
    }

    // bool isTalking = false;

    private void Awake()
    {
        //cameraTransform.parent = null;
    }
    void Update()
    {
        //if(playerScript.NPCColliding && playerScript.isTalking)
        //{
        //    isTalking = true;
        //}
        //else
        //{
        //    isTalking = false;
        //}
        //Debug.Log(playerScript.isTalking);

        if (!playerScript.isTalking && canMove)
        {
            float moveSpeed = Input.GetButton("Dash") ? sprintSpeed : walkSpeed;

            //Move
            rigidbody.velocity = moveSpeed * new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            //Animation
            if (rigidbody.velocity.magnitude > 0.1f)
            {
                animator.SetFloat("Last Move Input X", rigidbody.velocity.normalized.x);
                animator.SetFloat("Last Move Input Y", rigidbody.velocity.normalized.y);
            }
            animator.SetFloat("Speed", rigidbody.velocity.magnitude);
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
        }
      
    }
}
