using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;

    //Collider Variables
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    public float speed;
    public float jump;
    private Rigidbody2D rd2d;

    private bool isJumping;

    private void Awake()
    {
        rd2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void KillPlayer()
    {
        Debug.Log("Player get hit");
        //scoreController.IncreaseScore(10);
        //Destroy(gameObject);
        ReloadLevel();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
       
    }

    public void PickUpKey()
    {
        Debug.Log("Player Picked the key");
        scoreController.IncreaseScore(10);
    }

    private void Start()
    {
        //Fetching initial collider properties
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float verticalJump = Input.GetAxisRaw("Jump");

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
        }

        playerNewAnimationHorizontal(horizontal, verticalJump);
        MoveCharater(horizontal, verticalJump);
    }

    private void playerNewAnimationHorizontal(float horizontal, float verticalJump)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
        //Flipping the player
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (verticalJump > 0)                                 //jump
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    private void MoveCharater(float horizontal, float verticalJump)
    {
        //Character movements horizontal
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Character movements vertical
        if (isJumping)
        {
            rd2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    public void Crouch(bool crouch)                //crouch
    {
        if (crouch == true)
        {
            // Values when player is crouching
            float offX = -0.11f;     //Offset X
            float offY = 0.6f;       //Offset Y

            float sizeX = 0.78f;     //Size X
            float sizeY = 1.29f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
        }
        else
        {
            // Values when player is idle
            float offX = 0.01690394f;     //Offset X
            float offY = 0.9858862f;      //Offset Y

            float sizeX = 0.6145657f;     //Size X
            float sizeY = 2.080524f;      //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
        }

        //Play Crouch animation
        playerAnimator.SetBool("Crouch", crouch);
    }
}