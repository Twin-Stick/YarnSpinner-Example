using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Speaker")]
public class SpeakerData : ScriptableObject
{
    public const string EMOTION_NEUTRAL = "neutral";
    public const string EMOTION_FOCUSED = "focused";
    public const string EMOTION_SHOCKED = "shocked";

    public string speakerName;
    public Sprite portraitNeutral, portraitFocused, portraitShocked;

    public Sprite GetEmotionPortrait(string emotion)
    {
        switch (emotion)
        {
            default:
            case EMOTION_NEUTRAL: return portraitNeutral;
            case EMOTION_FOCUSED: return portraitFocused;
            case EMOTION_SHOCKED: return portraitShocked;
        }
    }
}
