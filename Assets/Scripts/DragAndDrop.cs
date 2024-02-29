using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DragAndDrop : MonoBehaviour
{
    public Canvas canvas;
    public GameObject btn;
    public GameObject drop;
    
    private float startPosX, startPosY;
    private GraphicRaycaster m_Raycaster;

    // Start is called before the first frame update
    void Start()
    {
        startPosX=transform.position.x;
        startPosY=transform.position.y;
        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnRectTransformDimensionsChange()
{
    // The RectTransform has changed!
    startPosX=transform.position.x;
    startPosY=transform.position.y;
}

    public void DragHandler(BaseEventData data){
        transform.SetAsLastSibling();
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,
                pointerData.position,
                canvas.worldCamera,
                out pos);

        transform.position=canvas.transform.TransformPoint(pos);
        
    }
    public void DropHandler(BaseEventData data){
        PointerEventData pointerData = (PointerEventData)data;
        transform.position= new Vector2(startPosX,startPosY);
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(pointerData, results);
        foreach (RaycastResult result in results)
        {
            if(result.gameObject.transform.parent.name == drop.name){
                gameObject.GetComponent<CanvasGroup>().alpha=0f;
                gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
                drop.GetComponentInChildren<TextMeshProUGUI>().enabled=true;
                btn.GetComponent<button_click>().setAnimatorClickTrigger(true);
                break;
            }
        }
        
    }

  
}
