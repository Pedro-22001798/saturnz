using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float jetpackForce = 3f;
    [SerializeField]
    private int maxHealth = 200;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxFuel = 200;
    [SerializeField]
    private int currentFuel;

    private float hAxis;
    private bool isFlying = false;
    public HealthBar healthBar;
    public JetpackBar jetpackBar;
    private bool left, right;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        currentFuel = maxFuel;

        healthBar.SetMaxHealth(maxHealth);
        jetpackBar.SetMaxFuel(maxFuel);
    }

    void Update()
    {
        hAxis = Input.GetAxis("Horizontal");

        isFlying = Input.GetButton("Jump");

        if (hAxis < 0)
            TurnLeft();
        if (hAxis > 0)
            TurnRight();

        if(currentHealth <= 0)
        {
            Timer.reset_timer();
            Circle.timer_enabled = false;
            SceneManager.LoadScene("Death");
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(hAxis * moveSpeed, rigidbody.velocity.y);

        if(isFlying)
        {
            if(currentFuel > 0)
            {
                rigidbody.AddForce(Vector2.up * jetpackForce);
                currentFuel = currentFuel - 2;
                jetpackBar.SetFuel(currentFuel);
            }
        }
        if(Sun.inSun)
        {
            if (currentHealth > 0)
            {
                currentHealth--;
                currentFuel++;
            }
            healthBar.SetHealth(currentHealth);
            jetpackBar.SetFuel(currentFuel);
        }
        if(Shadow.inShadow)
        {
            if(currentHealth < 200)
            {
                currentHealth++;
            }
            healthBar.SetHealth(currentHealth);
        }

    }
    private void TurnLeft()
    {
        if (left)
            return;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        left = true;
        right = false;
    }
    private void TurnRight()
    {
        if (right)
            return;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        left = false;
        right = true;
    }

}
