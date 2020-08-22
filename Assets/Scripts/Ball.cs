using UnityEngine;
using UnityEngine.InputSystem;


public class Ball : MonoBehaviour
{
    public InputAction launchAction;
    public float maxSpeedMaginitude = 300;
    private Vector2 dir;
    private Vector2 speed;
    private Vector2 vel;

    [SerializeField] private GameState GameState = null;

    void Start()
    {
        GameState.Playing = false;
        GameState.Player1Score = 0;
        GameState.Player2Score = 0;
        launchAction.performed += _ => Launch();
        speed = new Vector2(0, 0);
    }

    private void Launch()
    {
        if (!GameState.Playing)
        {
            dir = new Vector2(Random.value > .5 ? -1 : 1, 1);
            speed = new Vector2(100, Random.Range(-50.0f, 50.0f));
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            GameState.Playing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(
            GetComponent<Rigidbody2D>().velocity, maxSpeedMaginitude);
    }

    void FixedUpdate()
    {
        // GetComponent<Rigidbody2D>().MovePosition(vel * Time.deltaTime);
    }


    private void OnEnable()
    {
        launchAction.Enable();
    }

    private void OnDisable()
    {
        launchAction.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Left")
        {
            GameState.Player2Score += 1;
        }
        else
        {
            GameState.Player1Score += 1;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2();
        GetComponent<Rigidbody2D>().position = new Vector2();
        GameState.Playing = false;
        AudioManager.instance.Play("Score"); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Wall")
        {
            AudioManager.instance.Play("Wall");               
        }
    }
}
