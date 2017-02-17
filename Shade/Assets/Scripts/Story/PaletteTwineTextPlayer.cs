using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteTwineTextPlayer : TwineTextPlayer
{
    private Canvas _canvas;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void hide()
    {
        _canvas.enabled = false;
    }

    public void show()
    {
        _canvas.enabled = true;
    }

    public void setVisible(bool visible)
    {
        if (visible) show();
        else hide();
    }
}
