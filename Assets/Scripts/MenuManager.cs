using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image[] radioButtons;
    private int xOffsetMouse = 1000;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void VehicleSelection()
    {
        float mouseX = Input.mousePosition.x - xOffsetMouse;
        Debug.Log(Input.mousePosition.x + " " + Input.mousePosition.y + " " + Input.mousePosition.z);
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