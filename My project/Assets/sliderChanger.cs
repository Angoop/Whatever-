using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class sliderChanger : MonoBehaviour
{
    public Slider changer;
    // Start is called before the first frame update
    void Start()
    {
        changer = GetComponent<Slider>();
    }

    // Update is called once per frame
    public void ChangeValue (float increment)
    {
        changer.value += increment;
    }
}
