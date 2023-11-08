using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce, gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField] private AudioClip jumpSound, crashSound;
    private Animator playerAnimation;
    private AudioSource playerAudio;
    private Rigidbody playerRB;
    private bool isOnGround;
    public bool gameOver {get; private set;} 

    // Start is called before the first frame update
    private void Start()
    {
       playerRB = GetComponent<Rigidbody>();

        isOnGround = true;

        Physics.gravity *= gravityModifier;

        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnJump(InputValue input)
    {
        if (isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;

            playerAnimation.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isOnGround = true;
        }

        if(collision.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;

            playerAnimation.SetBool("Death_b", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
