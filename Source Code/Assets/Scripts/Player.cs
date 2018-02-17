using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//declare player sprite animator, renderer, and 2D rigidbody
    private Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
	//declare booleans for whether player is on the ground 
	//or in the air
    private bool grounded, jumping;
	//declare audiosource, levelmanager, and player inventory
    private AudioSource audioSource;
    private LevelManager levelManager;
    private Inventory inventory;
	//declare values for jump power, move & sprint speed
    public float jumpPower;
    public float moveSpeed;
	//declare booleans for whether the player is on the map
	//or level 3 boss screen
    public bool IsMapCharacter, IsLevel3BossPlayer;
    //declare input source for sprinting
    private float sprintInput;
	//declare audio clip array for sound fx
    public AudioClip[] Sounds = new AudioClip[2];

    // Use this for initialization
    void Start()
    {
		//assignments (see declarations above)
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();

		//puts player back where they were before entering the shop
        if (ExitShop.HasEnteredShopBefore == true)
        {
            transform.position = LoadShop.LocationToRespawn;
            ExitShop.HasEnteredShopBefore = false;
        }
		//puts the player back outside the arena in the main level 3 scene after they kill the griffin
		if (ExitArena.GriffinIsDead == true) {
			transform.position = LoadArena.LocationToReturn;
			//grounded = true;
			//transform.position += 2f;
		}
		//sends player back to last checkpoint
        if (PlayerPrefsManager.ReturnCheckpoint() == "true")
        {
            transform.position = PlayerPrefsManager.PlayerLocation();
            PlayerPrefsManager.SetCheckpoint("false");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the input of the player, these are used in place of hard coding the keys, in case they are changed in the editor.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        float jumpInput = Input.GetAxisRaw("Jump");
        sprintInput = Input.GetAxisRaw("Sprint");

        //If the MapCharacter boolean is false 
		//(Which in most cases it will be, it's just to change some movement on the map 
		//instead of creating a seperate class)
        if (!IsMapCharacter)
        {
			//if player loses all lives, they reset and get death screen
            if (PlayerPrefsManager.GetLives() < 0)
            {
                levelManager.LoadLevel("Game Over Screen");
                PlayerPrefsManager.SetLocation(0, 0, 0);
            }

			//if health points are depleted, a life is taken
			//and the player is respawned with full health
            if (PlayerPrefsManager.GetHealth() <= 0)
            {
				PlayerPrefsManager.SubtractLives(1);
                PlayerPrefsManager.SetHealth(100);
				//unless they are in the level 3 boss scene, they get
				//respawned at the last saved location. If they are at
				//the level 3 boss, they are sent to the custom arena vector
                if (!IsLevel3BossPlayer)
                {
                    transform.position = PlayerPrefsManager.PlayerLocation();
                }
                else if (IsLevel3BossPlayer)
                {
                    transform.position = new Vector3(-58.92968f, -49.7157f, 0f);
                }
            }

			//movement method called w input source
            Movement(horizontalInput);

            //Allows the player to jump
            if (jumpInput >= 1 && grounded)
            {
                grounded = false;
                jumping = true;
                rb.AddForce(Vector2.up * jumpPower);
            }
        }

        //Used only for the character on the map, instead of creating a seperate class.
        if (IsMapCharacter)
        {
			//binds player to map boundaries and activates movement system
            BindMapPlayer();
            Movement(horizontalInput);

            //When it is a map character, the character will be able to move up on the map
            if (verticalInput >= 1)
            {
                animator.SetBool("IsWalking", true);
                transform.position += Vector3.up * Time.deltaTime * moveSpeed;
				//reinforce playing of sound fx
                if (audioSource.isPlaying == false)
                {
                    audioSource.clip = Sounds[0];
                    audioSource.Play();
                }
            }

            //When it is a map character, the character will be able to move down on the map
            if (verticalInput <= -1)
            {
                animator.SetBool("IsWalking", true);
                transform.position += Vector3.down * Time.deltaTime * moveSpeed;
				//reinforce playing of sound fx
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
			//if the player's not airborne, the walking animation plays
            if (!jumping)
            {
                animator.SetBool("IsWalking", true);
            } else
            {
                animator.SetBool("IsWalking", false);
            }
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
            sr.flipX = false;
			//reinforce playing of sound fx
			if (audioSource.isPlaying == false && grounded | IsMapCharacter)
            {
                audioSource.clip = Sounds[0];
                audioSource.Play();
            }

        }
        //When the key to move left is pressed, the player will move left
        else if (horizontalInput <= -1f)
        {
			//if the player's not airborne, the walking animation plays
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
			//reinforce playing of sound fx
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
		//when sprint input is applied (shift key), move speed goes up
        if (sprintInput >= 1)
        {
            moveSpeed = 8;
        } else
        {
            moveSpeed = 5;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCanJump(collision);
    }

    //Boolean conditions to make sure the player is grounded
    private void PlayerCanJump(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            grounded = true;
            jumping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerCanJump(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            grounded = false;
        }
    }

	//binds player to boundaries on map screen
    private void BindMapPlayer()
    {
        int minX = -38;
        int maxX = -34;

        int minY = -1;
        int maxY = 1;

        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

	//method for taking damage and playing correlating sound effect
    public void TakeDamage(int DamageToTake)
    {
        PlayerPrefsManager.DealDamage(DamageToTake);
        audioSource.clip = Sounds[1];
        audioSource.Play();
    }
}