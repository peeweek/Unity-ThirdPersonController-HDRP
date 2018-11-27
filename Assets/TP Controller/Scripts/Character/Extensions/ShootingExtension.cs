using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingExtension : CharacterExtension
{
    public enum InputMode
    {
        Button,
        Axis
    }

    public enum FireMode
    {
        Single,
        Rate
    }

    [Header("Input")]
    public InputMode mode = InputMode.Axis;
    public float AxisThreshold = 0.5f;
    public string FireInput = "Fire1";

    [Header("Fire")]
    public FireMode fireMode = FireMode.Rate;
    public float fireRate = 10.0f;
    public UnityEvent OnFire;


    // Private
    private Animator animator;
    private float ttl = 0.0f;

    public static readonly int SHOOTING = Animator.StringToHash("Shooting");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void UpdateExtension(Character character)
    {
        bool firing = false;
        if (mode == InputMode.Button)
            firing = Input.GetButton(FireInput);
        else
            firing = Input.GetAxis(FireInput) > AxisThreshold;

        // Checks if not sprinting or falling/jumping
        firing = firing && !character.IsSprinting && character.IsGrounded;

        // Sends state to animator
        animator.SetBool(SHOOTING, firing);

        if (!firing)
        {
            ttl = 0.0f;
        }
        else
        {
            if(ttl <= 0.0f)
            {
                // Shoot
                OnFire.Invoke();
                ttl = 1.0f / fireRate;
            }
            else
            {
                ttl -= Time.deltaTime;
            }
        }
    }
}
