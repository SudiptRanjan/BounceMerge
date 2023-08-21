using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollImages : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] float x, y;

    // Update is called once per frame
    void Update()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(x, y) * Time.deltaTime, rawImage.uvRect.size);
    }
}
