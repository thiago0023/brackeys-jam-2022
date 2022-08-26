using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStorage : MonoBehaviour
{
    [System.Serializable]
    public class Storage{
        public string name = "Untitled";
        public AudioClip clip;
        // public AudioTypes type;
    }

    public List<Storage> audioList = new List<Storage>();

    public Storage GetAudio(string name)
    {
        var tempAudio = new Storage();
          for(int i=0; i<audioList.Count; i++){
            if(audioList[i].name == name) {
                tempAudio = audioList[i];
                break;
            }
        }
        return tempAudio;
    }
}
