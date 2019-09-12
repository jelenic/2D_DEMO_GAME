using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildProgressBar : MonoBehaviour
{
    [Header("Stuff")]
    public Image progressBar;

    private GameObject barCanvas;

    private Image currentBar;
    private float maxDuration;
    private float duration;

    // Start is called before the first frame update
    void Start()
    {
        barCanvas = GameObject.Find("BarsCanvas");
        maxDuration = 5f;
        duration = 5f;
        displayBar();

    }

    // Update is called once per frame
    void Update()
    {
        currentBar.transform.position = Camera.main.WorldToScreenPoint((Vector3.up * 0.3f) + transform.position);
        duration -= Time.deltaTime;
        setPorgressBar(duration / maxDuration);
        //Debug.Log("currentBar:");
    }

    void setPorgressBar(float value)
    {
        currentBar.fillAmount = value;
    }

    void displayBar()
    {
        currentBar = Instantiate(progressBar, transform.position, Quaternion.identity);
        currentBar.transform.SetParent(barCanvas.transform, false);
    }

    private void OnDestroy()
    {
        Destroy(currentBar);
    }
}
