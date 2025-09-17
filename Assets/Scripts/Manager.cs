using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject SettingPanelPC;
    void Start()
    {
        SettingPanel.SetActive(false);
        SettingPanelPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SettingOn()
    {
        SettingPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void SettingOnPC()
    {
        SettingPanelPC.SetActive(true);
        Time.timeScale = 0;
    }
    public void Remuse ()
    {
        Time.timeScale = 1f;
        SettingPanel.SetActive(false );
    }
    public void RemusePC ()
    {
        Time.timeScale = 1f;
        SettingPanelPC.SetActive(false );
    }
    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        SceneManager.LoadScene("MenuGame");
    }
    public void plau()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }
    public void Quit() {
        Application.Quit();
    }
}
