﻿using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    #region 변수

    private int m_screenSizeX = 0;
    private int m_screenSizeY = 0;

    [SerializeField, LabelName("화면 비율")] Vector2 m_aspect;

    #endregion

    #region 구현부

    private void RescaleCamera()
    {

        if (Screen.width == m_screenSizeX && Screen.height == m_screenSizeY) return;

        float targetaspect = m_aspect.x / m_aspect.y;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;
        Camera camera = Camera.main;

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        m_screenSizeX = Screen.width;
        m_screenSizeY = Screen.height;
    }

    #endregion

    #region 콜백 함수

    void OnPreCull()
    {
        if (Application.isEditor) return;
        Rect wp = Camera.main.rect;
        Rect nr = new Rect(0, 0, 1, 1);

        Camera.main.rect = nr;
        GL.Clear(true, true, Color.black);

        Camera.main.rect = wp;

    }

    #endregion

    #region 유니티 생명주기

    // Use this for initialization
    void Start()
    {
        RescaleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        RescaleCamera();
    }

    #endregion
}
