
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Reset_click : MonoBehaviour , IPointerDownHandler , IPointerUpHandler
{
    public Sprite normal_sprite;
    public Sprite hover_sprite;
    private Image Reset_button;

    private bool resetClicked=false;

    private void Awake(){
        Reset_button = GetComponent<Image>();
        Reset_button.sprite=normal_sprite;
    }
    

    void IPointerDownHandler.OnPointerDown(PointerEventData data){
        Reset_button.sprite=hover_sprite;
   }

    void IPointerUpHandler.OnPointerUp(PointerEventData data){
        Reset_button.sprite=normal_sprite;
        resetClicked=true;
   }

    public bool getResetClicked(){
        return resetClicked;
    }

    public void setResetClicked(bool mode){
        resetClicked = mode;
    }

}
