using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class WSlider : MonoBehaviour
{
    private RaymarchCam cam;
    public Slider wSlider;

    void Start()
    {
        cam = GetComponent<RaymarchCam>();
    }

    void Update()
    {
        cam._wPosition = wSlider.value;
    }
}
