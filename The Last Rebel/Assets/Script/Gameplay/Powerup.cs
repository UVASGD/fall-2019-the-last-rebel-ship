using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public float[] powerarray;
    public int[] costarray;
    public int currentPower = 0;
    public string name = "";

    public GameObject label;
    public GameObject costLabel;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        (label.GetComponent<Text>()).text = name;
        (costLabel.GetComponent<Text>()).text = costarray[0] + " gb";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Upgrade()
    {
        if (currentPower + 1 < powerarray.Length)
        {
            currentPower++;
        }
    }

    public float GetValue()
    {
        return powerarray[currentPower];
    }

    public float GetCost()
    {
        return costarray[currentPower];
    }
}
