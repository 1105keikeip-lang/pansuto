using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    public Button fullScreenButton;
    public string nextSceneName = "GameScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fullScreenButton.onClick.AddListener(OnStartClicked);
    }

    // Update is called once per frame
    void OnStartClicked()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
