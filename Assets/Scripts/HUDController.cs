using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI hpIndicator; //zakomentowane wartoœci s³u¿¹ do wyœwietlania ¿ycia w formie cyfr
    [SerializeField] Image hpBar; // te przedstawiaj¹ je jako czêsciowo lub ca³kowicie widoczny pasek

    public void HpUpdate(float hp)
    {
        hpBar.fillAmount = hp;
    }

    /*
    public void HpUpdate(string hpText)
    {
        hpIndicator.text = hpText;

    }*/
}
