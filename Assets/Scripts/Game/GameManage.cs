using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManage : MonoBehaviour
{
    public GameObject player;
    public Transform startPoint;
    public GameObject firstLayout;
    public GameObject secondLayout;
    public GameObject pauseMenu;

    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void StartGame()
    {
        InstantiatePlayer();
    }
    
    private void InstantiatePlayer()
    {
        Instantiate(player, startPoint.position, startPoint.rotation);
    }

    public void ChangeLevelLayout()
    {
        firstLayout.SetActive(false);
        secondLayout.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
