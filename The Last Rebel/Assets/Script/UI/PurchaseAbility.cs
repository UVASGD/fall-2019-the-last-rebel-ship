using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseAbility : MonoBehaviour
{
    
    public void SetText(string text)
    {
        Text t = transform.Find("Text").GetComponent<Text>();
        t.text = text;
    }

}
