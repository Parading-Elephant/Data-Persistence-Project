using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{

    public Text highScoreText;
    [SerializeField] private TextMeshProUGUI nameEntry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreText.text = PersistentManager.Instance.GetHighScoreString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNameEntryValueChanged(string _)
    {
        PersistentManager.Instance.currentName = nameEntry.text;
        Debug.Log("Updated name: " + PersistentManager.Instance.currentName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
