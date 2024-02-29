using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class button_click : MonoBehaviour, IPointerDownHandler
{
    private string id;
    Animator m_animator = null;
    private bool animatorClickTrigger;
    private GameObject drag;
    private GameObject drop;


    // Start is called before the first frame update
    void Awake()
    {
        string[] splitArray =  gameObject.name.Split(char.Parse("_"));
        id=splitArray[1];
        m_animator = GetComponent<Animator>();
        setAnimatorClickTrigger(false);
        drag= GameObject.Find("drag_"+id);
        drop = GameObject.Find("drop_"+id);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnPointerDown(PointerEventData eventData)
    {
        if(animatorClickTrigger){
            setAnimatorClickTrigger(false);    
            drag.GetComponent<CanvasGroup>().alpha=1f;
            drag.GetComponent<CanvasGroup>().blocksRaycasts = true;
            drop.GetComponentInChildren<TextMeshProUGUI>().enabled=false;
        }else{
            setAnimatorClickTrigger(true); 
            drag.GetComponent<CanvasGroup>().alpha=0f;
            drag.GetComponent<CanvasGroup>().blocksRaycasts = false; 
            drop.GetComponentInChildren<TextMeshProUGUI>().enabled=true;
        }  
    }
    public bool getAnimatorClickTrigger(){
        return animatorClickTrigger;
    }
    public void setAnimatorClickTrigger(bool mode){
        animatorClickTrigger = mode;
        m_animator.SetBool("clicked", animatorClickTrigger);
    }

    public string getId(){
        return id;
    }
    
}
