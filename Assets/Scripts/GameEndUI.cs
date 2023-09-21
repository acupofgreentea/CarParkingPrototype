using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button exitButton;
    
    [SerializeField] private TMP_Text levelTimeText;

    private void Start()
    {
        nextButton.onClick.AddListener(HandleNextButtonPress);
        exitButton.onClick.AddListener(HandleExitButtonPress);

        panel.SetActive(false);
        
        GameManager.OnLevelCompleted += HandleLevelCompleted;
    }

    private void HandleLevelCompleted(string formattedTime)
    {
        levelTimeText.text = formattedTime;
        
        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.25f);
            panel.gameObject.SetActive(true);
        }
    }

    private void HandleExitButtonPress()
    {
        Application.Quit();
    }

    private void HandleNextButtonPress()
    {
        SceneManager.LoadScene(0);
    }

    void OnDestroy()
    {
        GameManager.OnLevelCompleted -= HandleLevelCompleted;
    }
}
