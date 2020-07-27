using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

public class DialogUI : Singleton<DialogUI>
{
    public DialogueRunner Runner { get; private set; }

#pragma warning disable 0649
    [SerializeField] Image speakerPortrait;
    [SerializeField] TextMeshProUGUI txt_Dialog, txt_SpeakerName;
#pragma warning restore 0649

    public DialogueRunner dialogueRunner;
    Dictionary<string, SpeakerData> speakerDatabase = new Dictionary<string, SpeakerData>();

    private void Awake()
    {
        Runner = GetComponent<DialogueRunner>();
        Runner.AddCommandHandler("SetSpeaker", SetSpeakerInfo);
    }

    public void AddSpeaker(SpeakerData data)
    {
        if(speakerDatabase.ContainsKey(data.speakerName))
        {
            Debug.LogWarningFormat("Attempting to add {0} into speaker database, but it already exists!", data.speakerName);
            return;
        }
        // Add
        speakerDatabase.Add(data.speakerName, data);
    }

    void SetSpeakerInfo(string[] info)
    {
        string speaker = info[0];
        string emotion = info.Length > 1 ? info[1].ToLower() : SpeakerData.EMOTION_NEUTRAL;

        if(speakerDatabase.TryGetValue(speaker, out SpeakerData data))
        {
            speakerPortrait.sprite = data.GetEmotionPortrait(emotion);
            txt_SpeakerName.text = data.speakerName;
            return;
        }
        Debug.LogErrorFormat("Could not set speaker info for unknown speaker {0}", speaker);
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
