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
    public bool gameOver { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();

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
        if (isOnGround && !GameManager.gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;

            playerAnimation.SetTrigger("Jump_trig");

            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground" && !GameManager.gameOver)
        {
            isOnGround = true;

            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            GameManager.gameOver = true;

            playerAnimation.SetBool("Death_b", true);

            playerAudio.PlayOneShot(crashSound, 5.0f);

            transform.Translate(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));

            explosionParticle.Play();

            dirtParticle.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Scoreable"))
        {
            GameManager.ChangeScore(1);
        }
    }
}