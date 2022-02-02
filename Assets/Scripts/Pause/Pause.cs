using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Pause : MonoBehaviour
{
    private bool IsPaused { get; set; }

    [SerializeField] private GameObject m_PausePanel;

    public void Show()
    {
        IsPaused = true;
        m_PausePanel.SetActive(IsPaused);
        Time.timeScale = 0.0f;
    }

    public void Hide()
    {
        m_PausePanel.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1.0f;
    }

    public void Toggle()
    {
        if (IsPaused)
            Hide();
        else 
            Show();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Toggle();
    }
}
