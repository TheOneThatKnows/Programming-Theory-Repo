using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image[] radioButtons;
    private int xOffsetMouse = 1000;

    private void Start()
    {
        Enabler(radioButtons, MainManager.Instance.VehicleType);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

    public void VehicleSelection()
    {
        float mouseX = Input.mousePosition.x - xOffsetMouse;

        int index = Mathf.RoundToInt(0.5f * (mouseX / Mathf.Abs(mouseX)) + 0.5f);
        
        MainManager.Instance.VehicleType = index;
        Enabler(radioButtons, index);
    }

    private void Enabler(Image[] images, int num)
    {
        bool tf = num == 0;

        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(tf);
            tf = !tf;
        }
    }
}