using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public SoundManager audioManager;
    public GameObject reset;
    public Scrollbar scrollbar;

    void Start()
    {
        scrollbar.value=1;
    }

    // Update is called once per frame
    void Update()
    {
         if(reset.GetComponent<Reset_click>().getResetClicked()){
            initialise();
         }
    }
    public void initialise(){
        audioManager.StopALLAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
