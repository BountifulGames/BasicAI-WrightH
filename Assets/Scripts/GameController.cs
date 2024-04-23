using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int enemyCount;
    [SerializeField] private TMP_Text playerHealthText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMP_Text endText;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Time.timeScale = 1f;
        GamestateUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamestateUpdate()
    {
        if (enemyCount == 0)
        {
            Win();
        }
    }

    private void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endText.text = "YOU WIN!!!";
        playerHealthText.text = " ";
        endScreen.SetActive(true);
        Time.timeScale = 0f;

    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endText.text = "You Lose...";
        playerHealthText.text = " ";
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnRestartButtonPress()
    {
        Time.timeScale = 1f;  // Resume normal time
                              // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }
}
