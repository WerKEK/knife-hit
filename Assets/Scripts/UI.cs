using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject restartButtom;
    [SerializeField] private GameObject panelKnifes;
    [SerializeField] private GameObject iconKnife;
    [SerializeField] private Color knifeColor;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text appleText;
    [SerializeField] private Thrower thrower;
    [SerializeField] private GameController gameController;

    private void Update()
    {
        appleText.text = PlayerPrefs.GetInt("Apple").ToString();
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void ShowRestartButton()
    {
        restartButtom.SetActive(true);
    }

    public void SetInitialDisplayedKnifeCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconKnife, panelKnifes.transform);
    }

    private int knifeIconIndexToChange = 0;

    public void DecrementDisplayedKnifeCount()
    {
        panelKnifes.transform.GetChild(knifeIconIndexToChange++).GetComponent<Image>().color = knifeColor;
    }
}
