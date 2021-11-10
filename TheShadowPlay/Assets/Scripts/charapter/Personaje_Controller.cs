using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Personaje_Controller : MonoBehaviour
{
    float horizontalMove;
    private Vector3 playerInput;
    public CharacterController player;

  
    public float playerSpeed;
    public float gravity;
    public float fallVelocity;


    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;


    public float jumpForce = 8f;
    public bool isJumping = false;
    // Use this for initialization
    void Start()
    {
        player = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        PlayerMovement();
        SetGravity();
        PlayerSkills();
        player.Move(movePlayer);
    }
    //Funcion que obtiene el imnput de movimiento de nuestro jugador.
    public void PlayerInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        playerInput = new Vector3(horizontalMove, 0, 0);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
    }
    //Funcion para determinar la direccion a la que mira la camara. 
    
    public void PlayerMovement()
    {
        //movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = new Vector3(playerInput.x, 0, 0);
        movePlayer = new Vector3(movePlayer.x * playerSpeed * Time.deltaTime, 0, 0);
        player.transform.LookAt(player.transform.position + movePlayer);
    }
    public void PlayerSkills()
    {
        if (player.isGrounded)
        {
            isJumping = false;
        }
        //Jump                 
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            fallVelocity = jumpForce * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }
    //Funcion para la gravedad.
    public void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }
}