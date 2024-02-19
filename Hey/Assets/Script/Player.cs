using UnityEngine;

public class Player : MonoBehaviour
{

    // Variable concernant les mouvements du joueurs
    private Rigidbody2D rb2D;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float sprint;

    //Variables concernant les points de vie du joueur
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        // TODO a supprimer une fois la création d'un système de dégat, juste la a titre de test
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }


    private void PlayerMovement()
    {
        // Movement in 8 direction 
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector2 movHorizontal = transform.right * xMov;
        Vector2 movVertical = transform.up * yMov;

        Vector2 velocity = (movHorizontal + movVertical).normalized * speed;

        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);

        // Player perform a Sprint 

        Vector2 dashVelocity = (movHorizontal + movVertical).normalized * sprint;

        if (Input.GetKey(KeyCode.Space))
        {
            rb2D.MovePosition(rb2D.position + dashVelocity * Time.fixedDeltaTime);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
