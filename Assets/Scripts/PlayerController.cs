using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float cameraRange = 90f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject gameController;
    [SerializeField] private TMP_Text playerHealthText;
    [SerializeField] private float damageCooldown = 1.0f;

    private float lastDamageTime = 0;
    private float gravity = -9.8f;
    private float vertVelocity = 0;
    private float cameraVertical = 0;
    private CharacterController characterController;
    private Player _player;

    private void Start()
    {
        _player = gameObject.AddComponent<Player>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        UpdateCamera();
        UpdateMovement();
        
    }

    private void UpdateCamera()
    {
        float cameraHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0, cameraHorizontal, 0);

        cameraVertical -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        cameraVertical = Mathf.Clamp(cameraVertical, -cameraRange, cameraRange);

        playerCam.transform.localRotation = Quaternion.Euler(cameraVertical, 0, 0);
    }

    private void UpdateMovement()
    {
        float vertSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float horSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                vertVelocity = Mathf.Sqrt(2 * -gravity * jumpHeight); 
            }
            else
            {
                vertVelocity = -2f; 
            }

        }
        else
        {
            vertVelocity += gravity * Time.deltaTime;
        }

        Vector3 speed = new Vector3(horSpeed, vertVelocity, vertSpeed);
        speed = transform.rotation * speed;

        characterController.Move(speed * Time.deltaTime);
    }

    public void UpdateUI()
    {
        playerHealthText.text = "Health: " + _player.Health;
        if (_player.Health <= 0)
        {
            gameController.GetComponent<GameController>().GameOver();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit by enemy");
            if (Time.time - lastDamageTime >= damageCooldown) //damage cooldown so the enemy jittering doesnt immediately kill me
            {
                _player.TakeDamage(10f);

                lastDamageTime = Time.time;
            }
        }
    }

}
