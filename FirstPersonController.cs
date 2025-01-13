using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float speedGround1 = 30f;
    [SerializeField] private float speedGround2 = 60f;
    [SerializeField] private float speed;

    [SerializeField] private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = speedGround1;
    }

    void Update()
    {
        CheckGroundTag();
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var direction = transform.forward*verticalInput + transform.right*horizontalInput;
        direction.Normalize();
        characterController.Move((direction * speed) * Time.deltaTime);
    }


    void CheckGroundTag()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            if (hit.collider.CompareTag("Ground1"))
            {
                speed = speedGround1;
            }
            else if (hit.collider.CompareTag("Ground2"))
            {
                speed = speedGround2;
            }
        }
        else
        {
            speed = 0;
        }
    }
}
