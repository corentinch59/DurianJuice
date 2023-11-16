using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public void AdjustHealth(int value)
    {
        Color currentColor = transform.GetChild(value).GetComponent<Image>().color;
        transform.GetChild(value).GetComponent<Image>().color =
            new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
    }
}
