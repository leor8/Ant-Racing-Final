using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    public KeyCode left, right, jump, powerup1, powerup2, powerup3;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public LayerMask thisLayer;
    private Inventory inventory;

    public  bool isGrounded;

    private Rigidbody2D rb;
    private PlayerController enemy;

    // powerup variables
    private bool speeded = false;
    private bool jumped = false;
    private bool slowed = false;
    private int speed_length = 300;
    private int jump_length = 300;
    private int slow_length = 300;

    // Snowflakes related
    private bool frozen = false;
    private int freeze_timer = 60;

    // Camera variables
    public GameObject target_cam;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
        if(this.tag == "Player"){
            enemy = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
        } else {
            enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }

    void Update () {


        // Check if player failed to catch up with the camera
         if(gameObject.tag == "Player2" && gameObject.transform.position.y < target_cam.transform.position.y - 20){
             SceneManager.LoadScene(5);
         }
         if(gameObject.tag == "Player" && gameObject.transform.position.y < target_cam.transform.position.y - 20){
             SceneManager.LoadScene(6);
         }


        // Checking if the player is on ground otherwise the player should not be able to jump mid-air
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        // Getting key inputs to move the player
        if(Input.GetKey(left)) {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } else if (Input.GetKey(right)) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // For jumping
        if(Input.GetKeyDown(jump) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(Input.GetKey(powerup1)){


            ///////////// This section is for code to Speed up //////
            if(inventory.isFull[0]) {
                inventory.isFull[0] = false;
                if(!speeded) { // Set a timer here and make sure it only runs for 1 frame per cast
                    speed += 10;
                    speeded = true;
                }
            }
        }

        if(Input.GetKey(powerup2)) {
            if(inventory.isFull[1]) {
                inventory.isFull[1] = false;
                if(!jumped) { // Set a timer here and make sure it only runs for 1 frame per cast
                    jumpForce += 15;
                    jumped = true;
                }
            }
        }

        if(Input.GetKey(powerup3)) {
            if(inventory.isFull[2]) {
                inventory.isFull[2] = false;
                if(!slowed) {
                    enemy.speed -= 10;
                    slowed = true;
                }
            }
        }

        if(speeded) {
            speed_length--;
            print("here");
            if(speed_length <= 0) {
                speed -= 10;
                speeded = false;
                speed_length = 300;
            }
        }

        if(jumped) {
            jump_length--;

            if(jump_length <= 0) {
                jumpForce -= 15;
                jumped = false;
                jump_length = 300;
            }
        }

        if(slowed) {
            slow_length--;
            if(slow_length <= 0) {
                enemy.speed += 10;
                slowed = false;
                slow_length = 300;
            }
        }


        // Snowflakes related
        if(frozen) {
            freeze_timer--;
            if(freeze_timer <= 0) {
                freeze_timer = 60;
                frozen = false;
                speed = 15;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.CompareTag("Collectables")){
            Destroy(coll.gameObject);
            // int curr_powerup = Random.Range(0, powerup_pool.Length);
            // inventory.Add(powerup_pool[curr_powerup]);
        }

        if(coll.CompareTag("Snowflake")) {
            Destroy(coll.gameObject);
            if(!frozen) {
                frozen = true;
                speed = 0;
            }
        }

    }
}
