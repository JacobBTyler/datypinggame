using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{

    public GameObject charTyped;

    public GameObject correctTyped;

    public GameObject used;

    public GameObject accuracy;
    // Start is called before the first frame update
    void Start()
    {
        charTyped.GetComponent<TMPro.TextMeshProUGUI>().text = "Characters Typed: " + (tracker.charsTyped).ToString();
        correctTyped.GetComponent<TMPro.TextMeshProUGUI>().text = "Correct Characters Typed: " + (tracker.correctlyTyped).ToString();
        used.GetComponent<TMPro.TextMeshProUGUI>().text = "Words Used: " + (tracker.wordsUsed).ToString();
        accuracy.GetComponent<TMPro.TextMeshProUGUI>().text = "Accuracy: " + (tracker.correctlyTyped/tracker.charsTyped).ToString() + "%";

    }

  
}
