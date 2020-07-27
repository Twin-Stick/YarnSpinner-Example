using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : Singleton<DialogUI>
{
#pragma warning disable 0649
    [SerializeField] Image speakerPortrait;
    [SerializeField] TextMeshProUGUI txt_Dialog, txt_SpeakerName;
#pragma warning restore 0649

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
