using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public GameObject play_button;
    public GameObject pause_button;
    public Slider progress_bar;
    public Slider volume_bar;
    public Sprite pause_button_pressed;
    public Sprite pause_button_idle;
    public Sprite play_button_pressed;
    public Sprite play_button_idle;
    public SoundManager soundManager;

    private string path="Audios/audio";


    private bool play_button_clicked;
    private bool pause_button_clicked;

    // Start is called before the first frame update
    void Start()
    {
        play_button_clicked=false;
        pause_button_clicked=true;
        play_button.GetComponent<Image>().sprite=play_button_idle;
        pause_button.GetComponent<Image>().sprite=pause_button_pressed;
    }

    // Update is called once per frame
    void Update()
    {
        if(soundManager.sound!=null){
            progress_bar.maxValue = soundManager.sound.clip.length;
            progress_bar.value=soundManager.sound.time;
        }
    }

    public void Play(){
        if(!play_button_clicked){
            play_button_clicked=true;
            play_button.GetComponent<Image>().sprite=play_button_pressed;
            pause_button_clicked=false;
            pause_button.GetComponent<Image>().sprite=pause_button_idle;
            soundManager.PlayAudio(path);
        }
    }

    public void Pause(){
        if(!pause_button_clicked){
            play_button_clicked=false;
            play_button.GetComponent<Image>().sprite = play_button_idle;
            pause_button_clicked=true;
            pause_button.GetComponent<Image>().sprite=pause_button_pressed;
            soundManager.PauseAudio();
        }
    }

    public void setTime(float sliderValue){
        if(soundManager.sound!=null){
            soundManager.sound.time=sliderValue;
        }
    }

    public void setVolume(float sliderValue){
         if(soundManager.sound!=null){
            AudioListener.volume = sliderValue;
        }
    }
}
