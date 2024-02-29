using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class SolveAll : MonoBehaviour, IPointerDownHandler
{
    public GameObject[] buttons;
    private GameObject[] drags;
    private GameObject[] drops;
    Animator m_animator = null;
    private bool animatorClickTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        setAnimatorClickTrigger(false);
        drags=new GameObject[buttons.Length];
        drops=new GameObject[buttons.Length];
        foreach(GameObject obj in buttons){
            string id = obj.GetComponent<button_click>().getId();
            Debug.Log(id);
            drags[int.Parse(id)]=GameObject.Find("drag_"+id);
            drops[int.Parse(id)]=GameObject.Find("drop_"+id);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnPointerDown(PointerEventData eventData)
    {
        if(animatorClickTrigger){
            setAnimatorClickTrigger(false);    
            foreach(GameObject obj in buttons){
                string id=obj.GetComponent<button_click>().getId();
                obj.GetComponent<button_click>().setAnimatorClickTrigger(false);    
                drags[int.Parse(id)].GetComponent<CanvasGroup>().alpha=1f;
                drags[int.Parse(id)].GetComponent<CanvasGroup>().blocksRaycasts = true;
                drops[int.Parse(id)].GetComponentInChildren<TextMeshProUGUI>().enabled=false;
            }
        }else{
            setAnimatorClickTrigger(true);    
           foreach(GameObject obj in buttons){
                string id=obj.GetComponent<button_click>().getId();
                obj.GetComponent<button_click>().setAnimatorClickTrigger(true);    
                drags[int.Parse(id)].GetComponent<CanvasGroup>().alpha=0f;
                drags[int.Parse(id)].GetComponent<CanvasGroup>().blocksRaycasts = false;
                drops[int.Parse(id)].GetComponentInChildren<TextMeshProUGUI>().enabled=true;
            }
        }  
    }

     public bool getAnimatorClickTrigger(){
        return animatorClickTrigger;
    }
    public void setAnimatorClickTrigger(bool mode){
        animatorClickTrigger = mode;
        m_animator.SetBool("clicked", animatorClickTrigger);
    }
}
