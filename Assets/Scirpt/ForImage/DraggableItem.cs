using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public Transform parentsAfterDrag;
    public Image img;
    public Image img2;
    public bool Puzzle4;


    public bool EndDrag = false;
    public bool draggble = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (draggble)
        {
           
            //throw new System.NotImplementedException();
            Debug.Log("Begin");
            parentsAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            img.raycastTarget = false;
        }
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggble)
        {
            //throw new System.NotImplementedException();
            Debug.Log("Dragging");
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggble)
        {
            //throw new System.NotImplementedException();
            Debug.Log("End");
           
            img.raycastTarget = true;
        }
        transform.SetParent(parentsAfterDrag);
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(EndDrag == true)
        {
            Invoke("delay", 1f);
        }
        if (Puzzle4 && !EndDrag)
        {
            img2.color = Color.grey;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Puzzle4 && !EndDrag)
        {
            img2.color = Color.white;
        }
    }
    void delay()
    {
        EndDrag = false;
    }

}