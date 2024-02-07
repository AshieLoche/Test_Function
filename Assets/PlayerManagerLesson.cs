using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerLesson : MonoBehaviour
{
    public static PlayerManagerLesson Instance {  get; private set; }

    [Header("Movement Stats")]
    public float moveSpeed;
    public float rotSpeed;
    public float runSpeed;

    [Header("Script References")]
    public InputManager inputManager;
    public PlayerLocomotion playerLocomotion;

    [Header("Components")]
    public Rigidbody rigidBody;
    public Animator animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.HandleAllInput();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
