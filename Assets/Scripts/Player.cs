using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public AudioSource pointAudio;
    public AudioSource hitAudio;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float upStrength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating("AnimateSprite", 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * upStrength;
            GetComponent<AudioSource>().Play();
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex= 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            hitAudio.Play();
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.tag == "Gap")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            pointAudio.Play();
        }
    }
}