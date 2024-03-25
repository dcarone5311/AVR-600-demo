using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    private Transform playerTransform;
    private Rigidbody playerRB;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        playerRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        playerTransform.Translate(Input.GetAxis("Horizontal")*speed*Vector3.right*Time.deltaTime);
        playerTransform.Translate(Input.GetAxis("Vertical") * speed * Vector3.forward * Time.deltaTime);
        playerTransform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        
        if (isGrounded && Input.GetAxis("Jump") == 1)
        {
            playerRB.velocity =  playerRB.velocity + Vector3.up * jumpSpeed;
            isGrounded = false;
        }

        Debug.Log(isGrounded);
    }
}
