using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int knifeCount;
    [SerializeField] private Vector2 knifeSpawnPosition;
    [SerializeField] private GameObject knifeObject;
    public UI UI { get; private set; }
    public static GameController Instance { get; private set; }
    
    private Thrower thrower;

    private void Awake()
    {
        Instance = this;
        UI = GetComponent<UI>();
    }
    private void Start()
    {
        UI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife(); 
    }

    public void OnSuccsessKnifeHit()
    {
        if (knifeCount > 0)
        {
            if (PlayerPrefs.HasKey("Score"))
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("Score", 1);
            }
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }
    public void StartGameOverSequence(bool win)
    {
        StartCoroutine(nameof(GameOverSequenceCoroutine), win);
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
            Handheld.Vibrate();
            yield return new WaitForSecondsRealtime(0.6f);
            RestartGame();

        }
        else
        {
            PlayerPrefs.SetInt("Record", PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("Record") ? PlayerPrefs.GetInt("Score") : PlayerPrefs.GetInt("Record"));
            PlayerPrefs.SetInt("Score", 0);

            yield return new WaitForSecondsRealtime(0.3f);
            UI.ShowRestartButton();
        }
    }    

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    private void OpenMenu()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(0);
    }
}