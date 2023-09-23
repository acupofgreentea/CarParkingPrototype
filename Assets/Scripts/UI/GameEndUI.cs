using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private GameObject levelWinPanel;
    [SerializeField] private GameObject levelLosePanel;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button retryButton;
    
    [SerializeField] private TMP_Text levelTimeText;

    private void Start()
    {
        nextButton.onClick.AddListener(HandleNextButtonPress);
        exitButton.onClick.AddListener(HandleExitButtonPress);
        retryButton.onClick.AddListener(HandleRetryButtonPress);

        levelWinPanel.SetActive(false);
        levelLosePanel.SetActive(false);
        
        GameManager.OnLevelCompleted += HandleLevelCompleted;
    }

    private void HandleLevelCompleted(string time, bool isWin)
    {
        var panel = isWin ? levelWinPanel : levelLosePanel;
        if(isWin)
            levelTimeText.text = time;

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            panel.transform.localScale = Vector3.zero;
            yield return new WaitForSeconds(0.25f);
            panel.gameObject.SetActive(true);
            panel.transform.DOScale(1f, 0.65f).SetEase(Ease.OutBack);
        }
    }

    private void HandleExitButtonPress()
    {
        exitButton.interactable = false;
        Application.Quit();
    }

    private void HandleRetryButtonPress()
    {
        retryButton.interactable = false;
        SceneManagement.Instance.LoadSceneAsync(1);
    }

    private void HandleNextButtonPress()
    {
        nextButton.interactable = false;
        SceneManagement.Instance.LoadSceneAsync(1);
    }

    void OnDestroy()
    {
        GameManager.OnLevelCompleted -= HandleLevelCompleted;
    }
}
