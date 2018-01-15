using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool grounded, jumping;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private int currentHealth;
    private Inventory inventory;

    public float jumpPower;
    public float moveSpeed;
    public bool IsMapCharacter;
    public int sprintSpeed = 8;
    public AudioClip[] Sounds = new AudioClip[2];

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = PlayerPrefsManager.GetHealth();
        levelManager = FindObjectOfType<LevelManager>();

        if (ExitShop.HasEnteredShopBefore == true)
        {
            transform.position = LoadShop.LocationToRespawn;
            ExitShop.HasEnteredShopBefore = false;
        }
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
                PlayerPrefsManager.UnlockLevel(1);
                levelManager.LoadLevel("Game Over Screen");
            }

            Movement(horizontalInput);

            //Allows the player to jump, AND prevents double jumping.
            if (verticalInput >= 1 && grounded)
            {
                grounded = false;
                jumping = true;
                rb.AddForce(Vector2.up * jumpPower);
            }
        }

        //Used only for the character on the map, instead of creating a seperate class.
        if (IsMapCharacter)
        {
            BindMapPlayer();
            Movement(horizontalInput);

            //When it is a map character, the character will be able to move up on the map
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetBool("IsWalking", true);
                transform.position += Vector3.up * Time.deltaTime * moveSpeed;
                if (audioSource.isPlaying == false)
                {
                    audioSource.clip = Sounds[0];
                    audioSource.Play();
                }
            }

            //When it is a map character, the character will be able to move down on the map
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("IsWalking", true);
                transform.position += Vector3.down * Time.deltaTime * moveSpeed;
                if (audioSource.isPlaying == false)
                {
                    audioSource.clip = Sounds[0];
                    audioSource.Play();
                }
            }
        }
    }

    private void Movement(float horizontalInput)
    {
        //When the key to move right is pressed, the player will move right
        if (horizontalInput >= 1f)
        {
            if (!jumping)
            {
                animator.SetBool("IsWalking", true);
            } else
            {
                animator.SetBool("IsWalking", false);
            }
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
            sr.flipX = false;
            if (audioSource.isPlaying == false && grounded | IsMapCharacter)
            {
                audioSource.clip = Sounds[0];
                audioSource.Play();
            }

        }
        //When the key to move left is pressed, the player will move left
        else if (horizontalInput <= -1f)
        {
            if (!jumping)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
            sr.flipX = true;
            if (audioSource.isPlaying == false && grounded | IsMapCharacter)
            {
                audioSource.clip = Sounds[0];
                audioSource.Play();
            }
        }

        //No movement will make the player go into an idle animation.
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = sprintSpeed;
        } else
        {
            moveSpeed = 5;
        }

        //Suicide key
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefsManager.SetHealth(0);
        }
    }

    //Booleans to make sure the player is grounded and can't double jump.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            grounded = true;
            jumping = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            grounded = true;
            jumping = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            grounded = false;
        }
    }

    private void BindMapPlayer()
    {
        int minX = -44;
        int maxX = -27;

        int minY = -3;
        int maxY = 3;

        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    public void TakeDamage(int DamageToTake)
    {
        PlayerPrefsManager.DealDamage(DamageToTake);
        audioSource.clip = Sounds[1];
        audioSource.Play();
    }
}