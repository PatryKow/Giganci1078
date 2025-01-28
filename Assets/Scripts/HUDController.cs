using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI hpIndicator; //zakomentowane warto�ci s�u�� do wy�wietlania �ycia w formie cyfr
    [SerializeField] Image hpBar; // te przedstawiaj� je jako cz�sciowo lub ca�kowicie widoczny pasek

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
