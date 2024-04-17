using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int enemyCount;
    [SerializeField] private TMP_Text playerHealthText;
    [SerializeField] private GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        GamestateUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamestateUpdate()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            Win();
        }
    }

    private void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0.2f;
    }
}
