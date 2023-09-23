using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(HandlePlayButtonClick);
    }

    private void HandlePlayButtonClick()
    {
        SceneManagement.Instance.LoadSceneAsync(1);
        playButton.interactable = false;
    }
}
