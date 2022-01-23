using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 4.0f;

    public ParticleSystem eatParticle;

    Rigidbody2D rigidbody2d;
    public Rigidbody2D rb;
    float horizontal;
    float vertical;
    
    public BoxCollider2D sharkBox;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public bool gameOver = false;

    AudioSource audioSource;
    public AudioClip eatClip;
    public AudioClip hungryClip;
    public AudioClip loseClip;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sharkBox = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(hungryClip);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (Score.State == true)
        {
            audioSource.PlayOneShot(loseClip);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            sharkBox.GetComponent<Collider2D>().enabled = false;
        }
        
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        if (Input.GetKey(KeyCode.R))
        {
            if (Score.State == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Fish controller = other.GetComponent<Fish>();
        Instantiate(eatParticle, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        audioSource.PlayOneShot(eatClip);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
