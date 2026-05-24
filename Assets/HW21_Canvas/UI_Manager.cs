using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject[] canvases;

    // 모든 Canvas 끄기
    private void HideAllCanvases()
    {
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }
    }

    // 원하는 Canvas만 켜기
    public void ShowCanvas(GameObject targetCanvas)
    {
        HideAllCanvases();

        targetCanvas.SetActive(true);
    }
}