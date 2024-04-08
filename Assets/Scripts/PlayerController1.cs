using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    private Transform playerTransform;
    private Rigidbody playerRB;

    private bool isGrounded;
    private AudioSource audio;
    public AudioClip ping;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        playerRB = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionStay(Collision c)
    {
        if (c.collider.tag == "Ground")

        { 
            
            isGrounded = true;
            Debug.Log(c.GetContact(0));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            Debug.Log("Touch");
            GetComponent<TimeScore>().coins += 1;
            audio.clip = ping;
            audio.Play(0);
            GameObject.Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //playerTransform.Translate(Input.GetAxis("Horizontal")*speed*Vector3.right*Time.deltaTime);
        //playerTransform.Translate(Input.GetAxis("Vertical") * speed * Vector3.forward * Time.deltaTime);

        playerRB.AddForce((playerTransform.forward * Input.GetAxis("Vertical") + playerTransform.right * Input.GetAxis("Horizontal")) * speed );

        playerTransform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        
        if (isGrounded && Input.GetAxis("Jump") == 1)
        {
            playerRB.velocity =  playerRB.velocity + Vector3.up * jumpSpeed;
            isGrounded = false;
        }

        Debug.Log(isGrounded);
    }
}
