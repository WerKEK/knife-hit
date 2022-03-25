using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text recordText;
    [SerializeField] private Text appleText;
    private void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    private void Update()
    {
        recordText.text = PlayerPrefs.GetInt("Record").ToString();
        appleText.text = PlayerPrefs.GetInt("Apple").ToString();
    }

    private void DelKeys()
    {
        PlayerPrefs.DeleteAll();
    }
}
