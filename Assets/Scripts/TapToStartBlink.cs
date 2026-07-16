using UnityEngine;
using TMPro;
public class TapToStartBlink : MonoBehaviour
{
    TMP_Text text;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.enabled = Mathf.FloorToInt(timer * 2) % 2 == 0;
    }
}
