using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.NonSerialized]
    public AudioSource sound = null;

    // Start is called before the first frame update
    void Awake(){
    }
    
    public void PlayAudio(string path){
        if(sound==null){
            sound = gameObject.AddComponent<AudioSource>();
            sound.clip=Resources.Load<AudioClip>(path);
        }
        sound.Play();
    }

     public void PauseAudio(){
        if(sound.isPlaying){
            sound.Pause();
        }
    }

    public void StopALLAudio(){
        if(sound!=null){
            if(sound.isPlaying){
                sound.Stop();
            }
        }
    }
}
