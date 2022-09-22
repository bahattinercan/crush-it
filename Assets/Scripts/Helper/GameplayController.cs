using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public GameObject[] obtaclePrefabs;
    public GameObject[] zombiePrefabs;
    public GameObject rocketPickup, shieldPickup, magnetizePickup;
    public Transform[] lanes;
    public float minObstacleDelay = 10f, maxObstacleDelay = 40f;
    private float halfGroundSize;
    private BaseController playerController;

    private Text scoreText;
    public int scoreApplier = 3;
    private int score;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private EndGamePanel endGamePanel;
    [SerializeField] private AudioSource musicAudioSource;

    public event Action OnGameFinished;

    private void Awake()
    {
        MakeInstance();
    }

    // Start is called before the first frame update
    private void Start()
    {
        halfGroundSize = GameObject.FindGameObjectWithTag("GroundBlock").GetComponent<GroundBlock>().halfLength;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseController>();
        StartCoroutine(GenerateObstacles());

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        StartCoroutine(AddScoreCo());
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator GenerateObstacles()
    {
        float timer = UnityEngine.Random.Range(minObstacleDelay, maxObstacleDelay) / playerController.speed.z;
        yield return new WaitForSeconds(timer);
        CreateObstacles(playerController.gameObject.transform.position.z + halfGroundSize);
        StartCoroutine(GenerateObstacles());
    }

    private void CreateObstacles(float zPos)
    {
        int r = UnityEngine.Random.Range(0, 10);

        if (0 <= r && r < 7)
        {
            int obtacleLane = UnityEngine.Random.Range(0, lanes.Length);
            AddObtacle(new Vector3(lanes[obtacleLane].transform.position.x, 0f, zPos), UnityEngine.Random.Range(0, obtaclePrefabs.Length));

            int zombieLane = 0;
            if (obtacleLane == 0)
            {
                zombieLane = UnityEngine.Random.Range(0, 2) == 1 ? 1 : 2;
            }
            else if (obtacleLane == 1)
            {
                zombieLane = UnityEngine.Random.Range(0, 2) == 1 ? 0 : 2;
            }
            else if (obtacleLane == 2)
            {
                zombieLane = UnityEngine.Random.Range(0, 2) == 1 ? 1 : 0;
            }
        }
    }

    private void AddObtacle(Vector3 position, int type)
    {
        GameObject obstacle = Instantiate(obtaclePrefabs[type], position, Quaternion.identity);
        bool mirror = UnityEngine.Random.Range(0, 2) == 1;
        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;

            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;

            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -1 : 1, 0f);
                break;

            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -170 : 170, 0f);
                break;
        }
        obstacle.transform.position = position;
    }

    private void AddZombies(Vector3 pos)
    {
        int count = UnityEngine.Random.Range(0, 3) + 1;

        for (int i = 0; i < count; i++)
        {
            Vector3 shift = new Vector3(UnityEngine.Random.Range(-.5f, .5f), 0f, UnityEngine.Random.Range(1f, 10f) * i);
            Instantiate(zombiePrefabs[UnityEngine.Random.Range(0, zombiePrefabs.Length)],
                pos + shift * i, Quaternion.identity);
        }
    }

    private void AddPowers(Vector3 position, int type)
    {
        /*
        Vector3 shift = new Vector3(Random.Range(-.5f, .5f), 0f, Random.Range(1f, 10f));
        Instantiate(powerPickupPrefabs[Random.Range(0, powerPickupPrefabs.Length)],
                position + shift, Quaternion.identity);
        */
    }

    public void IncreaseScore(int point = 5)
    {
        score += point;
        SetScore(score);
    }

    private IEnumerator AddScoreCo()
    {
        while (true)
        {
            score += UnityEngine.Random.Range(scoreApplier - 2, scoreApplier + 2);
            SetScore(score);
            yield return new WaitForSeconds(1);
        }
    }

    private void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        pausePanel.SetActive(false);
        endGamePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        endGamePanel.SetupPanel(false, score);
        AudioController.instance.StopAllAudio();
        musicAudioSource.Stop();
        OnGameFinished?.Invoke();
        AudioController.instance.PlayOneShot(AudioController.instance.loseClip);
    }

    public void WinTheGame()
    {
        pausePanel.SetActive(false);
        endGamePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        endGamePanel.SetupPanel(true, score);
        AudioController.instance.StopAllAudio();
        musicAudioSource.Stop();
        OnGameFinished?.Invoke();
        AudioController.instance.PlayOneShot(AudioController.instance.winClip);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}