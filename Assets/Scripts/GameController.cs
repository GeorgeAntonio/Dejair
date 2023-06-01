using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static bool isPuseed = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuCanvas;
    public GameObject eventSystem;
    public static GameController instance = null;
    public TextMeshProUGUI LevelTextMeshPro;
    public TextMeshProUGUI LifeTextMeshPro;
    public GameObject player;

    private int level = 1;
    private int life = 100;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseMenuCanvas);
        DontDestroyOnLoad(eventSystem);

        LevelTextMeshPro.text = "Level " + level;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPuseed)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPuseed = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPuseed = true;
    }

    public void GoToMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public int getLife()
    {
        return life;
    }

    public void setLife(int newLife)
    {
        life = newLife;
        LifeTextMeshPro.text = life.ToString();
    }

    public void GoToLevel(int newLevel)
    {
        level = newLevel;
        SceneManager.LoadScene(level, LoadSceneMode.Single);
        LevelTextMeshPro.text = "Level " + level;
    }
}
