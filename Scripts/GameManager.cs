using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public float initialGameSpeed = 5f;
	public float gameSpeedIncrease = 0.1f;
	public float gameSpeed { get; private set; }

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public TextMeshProUGUI playText;

	public Button retryButton;
	public Button quitButton;


	private Player player;
	private Spawner spawner;

	private float score;
	private bool gameStarted = false;

	private void Awake()
	{
		if (Instance != null)
		{
			DestroyImmediate(gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Start()
	{
		player = FindObjectOfType<Player>();
		spawner = FindObjectOfType<Spawner>();

		NewGame();
	}

	public void NewGame()
	{
		Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

		foreach (var obstacle in obstacles)
		{
			Destroy(obstacle.gameObject);
		}

		score = 0f;
		gameSpeed = initialGameSpeed;
		enabled = true;

		player.gameObject.SetActive(true);
		spawner.gameObject.SetActive(true);
		gameOverText.gameObject.SetActive(false);
		retryButton.gameObject.SetActive(false);
		quitButton.gameObject.SetActive(false);
		playText.gameObject.SetActive(true);

		gameStarted = false;
	}

	public void GameOver()
	{
		gameSpeed = 0f;
		enabled = false;

		player.gameObject.SetActive(false);
		spawner.gameObject.SetActive(false);
		gameOverText.gameObject.SetActive(true);
		retryButton.gameObject.SetActive(true);
		quitButton.gameObject.SetActive(true);

	}

	private void Update()
	{
		if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
		{
			gameStarted = true;
			playText.gameObject.SetActive(false);
		}

		if (gameStarted)
		{
			gameSpeed += gameSpeedIncrease * Time.deltaTime;
			score += gameSpeed * Time.deltaTime;
			scoreText.text = Mathf.FloorToInt(score).ToString("D5");
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	public void QuitGame()
	{
		// Uygulamayý kapat
		Application.Quit();
	}
}


/*
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public float initialGameSpeed = 5f;
	public float gameSpeedIncrease = 0.1f;
	public float gameSpeed { get; private set; }

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public TextMeshProUGUI playText;

	public Button retryButton;


	private Player player;
	private Spawner spawner;

	private float score;

	private void Awake()
	{
		if (Instance != null)
		{
			DestroyImmediate(gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Start()
	{
		player = FindObjectOfType<Player>();
		spawner = FindObjectOfType<Spawner>();

		NewGame();
	}

	public void NewGame()
	{
		Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

		foreach (var obstacle in obstacles)
		{
			Destroy(obstacle.gameObject);
		}

		score = 0f;
		gameSpeed = initialGameSpeed;
		enabled = true;

		player.gameObject.SetActive(true);
		spawner.gameObject.SetActive(true);
		gameOverText.gameObject.SetActive(false);
		retryButton.gameObject.SetActive(false);
		playText.gameObject.SetActive(true);


	}

	public void GameOver()
	{
		gameSpeed = 0f;
		enabled = false;

		player.gameObject.SetActive(false);
		spawner.gameObject.SetActive(false);
		gameOverText.gameObject.SetActive(true);
		retryButton.gameObject.SetActive(true);

	}

	private void Update()
	{
		gameSpeed += gameSpeedIncrease * Time.deltaTime;
		score += gameSpeed * Time.deltaTime;
		scoreText.text = Mathf.FloorToInt(score).ToString("D5");
		if (Input.GetKeyDown(KeyCode.Space))
		{
			playText.gameObject.SetActive(false);
		}
	}

	

}
*/