using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    [Header("Made by @petililfr on discord")]
    //variables
    public GameObject[] disableOnOpen;
    public GameObject menuUI;
    public Button resumeButton;
    public Movement movement;
    public Camera cam;

    private bool isPaused = false;

    //check for press
    void Start()
    {
        resumeButton.onClick.AddListener(Resume);
    }

    // Update is called once per frame
    //checks for pause key pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        movement.enabled = false;
        foreach (GameObject obj in disableOnOpen)
        {
            obj.SetActive(false);
        }
    }

    void Resume()
    {
        Time.timeScale = 1f;
        menuUI.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        movement.enabled = true;
        foreach (GameObject obj in disableOnOpen)
        {
            obj.SetActive(true);
        }
    }
}
