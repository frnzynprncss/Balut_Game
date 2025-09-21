using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class GameController : MonoBehaviour
{
    [Header("Objects")]
    public TMP_Text scoreText;
    public TMP_Text gaemoverText;
    public TMP_Text timeText;
    public GameObject gameOverPanel;
    public GameObject Winning_Panel;
    public Balut_Attain balut_attainer;

    [Header("Values")]
    public int score = 0;
    public float gameTimer = 30f;
    private bool isGameOver = false;

    [Header("Sound Effects")]
    public AudioClip dingSound;
    public AudioClip timeSound;
    public AudioClip gameOverSound;
    public AudioClip backgroundMusic;

    [Header("Volume Settings")]
    public float dingVolume = 100f;
    public float timeVolume = 100f;
    public float gameOverVolume = 100f;
    public float musicVolume = 50f;

    private AudioSource audioSource;

    void Awake()
    {
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set audio source properties for better sound
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.volume = 2.0f;

        // Play background music
        if (backgroundMusic != null)
        {
            AudioSource.PlayClipAtPoint(backgroundMusic, transform.position, musicVolume);
            Debug.Log("Background music playing at volume: " + musicVolume);
        }
    }

    void Start()
    {
        UpdateScoreUI();
        gameOverPanel?.SetActive(false);
        Time.timeScale = 1f;
        Winning_Panel?.SetActive(false);
        isGameOver = false;

        EventManager.Instance.game_over.AddListener(GameOver);
        EventManager.Instance.add_time.AddListener(time => { gameTimer += time; });
        EventManager.Instance.add_score.AddListener(AddScore);
    }

    private void Update()
    {
        if (isGameOver) return;

        if (gameTimer > 0f)
        {
            gameTimer -= Time.deltaTime;
            timeText.text = "Time: " + gameTimer.ToString("F0");
        }
        else
        {
            GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;

        float length = 0;
        AudioSource audio_source_sfx = new AudioSource();
        Instantiate(audio_source_sfx, transform.position, Quaternion.identity); 

        if (collision.gameObject.CompareTag("Asin"))
        {
            // Play ding sound when touching asin
            if (dingSound != null)
            {
                audio_source_sfx.clip = dingSound;
                audio_source_sfx.volume = 1f;
                audio_source_sfx.Play();
                length = audio_source_sfx.clip.length;
                Debug.Log("Ding Sound!");
            }
        }
        else if (collision.gameObject.CompareTag("Suka"))
        {
            // Play time sound when touching suka
            if (timeSound != null)
            {
                audio_source_sfx.clip = timeSound;
                audio_source_sfx.volume = 1f;
                audio_source_sfx.Play();
                length = audio_source_sfx.clip.length;
                Debug.Log("Ding Sound!");
            }
        }

        Destroy(audio_source_sfx, length);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        // Play game over sound
        if (gameOverSound != null)
        {
            AudioSource.PlayClipAtPoint(gameOverSound, transform.position, gameOverVolume);
            Debug.Log("Game Over Sound! Volume: " + gameOverVolume);
        }
        else
        {
            Debug.LogWarning("Game over sound clip is not assigned!");
        }

        if (balut_attainer.GetBalut() > 100f)
        {
            Winning_Panel.SetActive(true);
        }
        else
        {
            if (gameOverPanel != null) gameOverPanel.SetActive(true);
            gaemoverText.text = $"You have attained {balut_attainer.GetBalut()}% Balut";
        }
    }

    public void Win()
    {
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoHome()
    {
        Time.timeScale = 1f;
        // load main menu if you have one
    }

    public void UseSukaPowerup()
    {
        // Example: slow time for 2 sec
        StartCoroutine(TemporarySlow());
    }

    System.Collections.IEnumerator TemporarySlow()
    {
        float prev = Time.timeScale;
        Time.timeScale = 0.6f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = prev;
    }
}