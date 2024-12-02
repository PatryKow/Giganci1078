using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpIndicator;

    public void HpUpdate(string hpText)
    {
        hpIndicator.text = hpText;
    }
}
