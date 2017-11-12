using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool grounded;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private int currentHealth;

    public float jumpPower;
    public float moveSpeed;
    public bool IsMapCharacter;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = PlayerPrefsManager.GetHealth();
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the input of the player, these are used in place of hard coding the keys, in case they are changed in the editor.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        currentHealth = PlayerPrefsManager.GetHealth();

        //If the MapCharacter boolean is false (Which in most cases it will be, it's just to change some movement on the map instead of creating a seperate class)
        if (!IsMapCharacter)
        {
            if (currentHealth <= 0)
            {
                levelManager.LoadLevel("Game Over Screen");
            }

            Movement(horizontalInput);

            //Allows the player to jump, AND prevents double jumping.
            if (verticalInput >= 1 && grounded)
            {
                grounded = false;
                rb.AddForce(Vector2.up * jumpPower);
            }
        }

        //Used only for the character on the map, instead of creating a seperate class.
        if (IsMapCharacter)
        {
            Movement(horizontalInput);

            //When it is a map character, the character will be able to move up on the map
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsWalking", true);
                transform.position += Vector3.up * Time.deltaTime * moveSpeed;
            }

            //When it is a map character, the character will be able to move down on the map
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("IsWalking", true);
                transform.position += Vector3.down * Time.deltaTime * moveSpeed;
            }
        }
    }

    private void Movement(float horizontalInput)
    {
        //When the key to move right is pressed, the player will move right
        if (horizontalInput >= 1f)
        {
            animator.SetBool("IsWalking", true);
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
            sr.flipX = false;
            if (audioSource.isPlaying == false && grounded)
            {
                audioSource.Play();
            }

        }
        //When the key to move left is pressed, the player will move left
        else if (horizontalInput <= -1f)
        {
            animator.SetBool("IsWalking", true);
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
            sr.flipX = true;
            if (audioSource.isPlaying == false && grounded)
            {
                audioSource.Play();
            }

        }

        //No movement will make the player go into an idle animation.
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    //Booleans to make sure the player is grounded and can't double jump.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            grounded = false;
        }
    }
}