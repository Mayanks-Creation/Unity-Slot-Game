using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UILight : MonoBehaviour
{
    public Image image;

    public Sprite onSprite;
    public Sprite blinkSprite;
    public Sprite loseSprite;
    public Sprite winSprite;

    public void SetOn()
    {
        image.sprite = onSprite;
    }

    public void SetBlink()
    {
        image.sprite = blinkSprite;
    }

    public void SetLose()
    {
        image.sprite = loseSprite;
    }

    public void SetWin()
    {
        image.sprite = winSprite;
    }
}