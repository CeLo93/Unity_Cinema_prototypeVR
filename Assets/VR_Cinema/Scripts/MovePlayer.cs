using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public Transform playerCamera;

    private Rigidbody rb;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Bloqueia e esconde o cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimento horizontal
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement) * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + transform.TransformDirection(movement));

        // Rotação da câmera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX);
        playerCamera.Rotate(Vector3.left * mouseY);

        // Pulo
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica se o jogador está no chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}