using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingPanal : MonoBehaviour
{
    [SerializeField]private Canvas canvas;
    public Button SettingButton;
    // Start is called before the first frame update
    void Start()
    {
        SettingButton.onClick.AddListener(OnClickSetting);
    }

    private void OnClickSetting()
    {
        canvas.enabled = !canvas.enabled;
    }
}
