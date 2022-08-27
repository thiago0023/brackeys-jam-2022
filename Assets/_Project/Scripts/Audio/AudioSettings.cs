using System;

[Serializable]
public class AudioSettings
{
    public string audioName;
    public enAudioType audioType;
}

public enum enAudioType{ SFX, BGS, BGM };
