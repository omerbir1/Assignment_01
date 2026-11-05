using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    public Vector2 movement;
    public int score = 0;
    
    public static string enemyTag = "Enemy";
    public static string coinTag = "Coin";
    
    public TextMeshProUGUI scoreText;
    public static int currCoins;
    private bool isGameOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        
        if (isGameOver && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
        movement = Vector2.zero;
        var dValue = Keyboard.current.dKey.value;
        var aValue = Keyboard.current.aKey.value;
        var wValue = Keyboard.current.wKey.value;
        var sValue = Keyboard.current.sKey.value;
        movement += dValue * Vector2.right;
        movement += aValue * Vector2.left;
        movement += wValue * Vector2.up;
        movement += sValue * Vector2.down;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Time.fixedDeltaTime * speed * movement); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            Debug.Log("You Lost");
            QuitGame(); 
        }
        if (other.CompareTag(coinTag))
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            score += coin.points;
            Destroy(other.gameObject);
            currCoins--;
            if (score >= 1000)
            {
                Debug.Log("You Won!!");
                QuitGame();
            }
        }
    }
    public void QuitGame()
    {
        Time.timeScale = 0f;
        isGameOver = true;
    }
}
