using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventory : MonoBehaviour, IDropHandler
{
    public GameObject parentObject;
    public SlotManager counter;
    public GameObject AnimActive1;

    public Puzzle3Manager count;

    public CookBookManager Count;

    public Puzzke6Man win;

    public bool Level3;

    public bool Leve4;

    public bool Level6;

    public GameObject error;

    public void Start()
    {
        counter = GetComponent<SlotManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(counter.Slot1 == true)
        {
            if (transform.childCount <= 6)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                Image secondChildImage = dropped.GetComponent<Image>();
                draggableItem.parentsAfterDrag = transform;
                secondChildImage.color = Color.white;
            }
        }
        else if(counter.Slot2 == true)
        {
            if (transform.childCount == 0)
            {
                //
                //Transform secondChildTransform = parentObject.transform.GetChild(0);
                //Image secondChildImage = secondChildTransform.GetComponent<Image>();
                //
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                Image secondChildImage = dropped.GetComponent<Image>();
                Item itemStatus = dropped.GetComponent<Item>();
                draggableItem.parentsAfterDrag = transform;

                

                if (itemStatus.correctAnswer1 == true)
                {
                    if (Leve4)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        draggableItem.draggble = false;
                        Count.counter += 1;
                        secondChildImage.color = Color.white;
                    }
                    else
                    {
                        secondChildImage.color = Color.green;
                    }
                   
                    if (Level3)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        draggableItem.draggble = false;
                        count.correctCount += 1;
                    }
      
                    if (Level6)
                    {
                        secondChildImage.color = Color.green;
                        draggableItem.draggble = false;
                        win.counter();
                    }
                    
                   // AnimActive1.gameObject.SetActive(true);
                    Debug.Log("Correct");
                }
                else
                {
                    if (Level3)
                    {
                        error.gameObject.SetActive(true);
                        count.mistakeCounter += 1;
                        Invoke("delayRed", 1f);
                    }

                    if (Leve4)
                    {
                        error.gameObject.SetActive(true);
                        Count.mistakeCounter += 1;
                        Invoke("delayRed", 1f);
                    }

                    if (Level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("delayRed", 1f);
                    }

                    secondChildImage.color = Color.red;
                    Debug.Log("Incorrect");
                }
            }
           
        }
        
        else if (counter.Slot3 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                Image secondChildImage = dropped.GetComponent<Image>();
                Item itemStatus = dropped.GetComponent<Item>();
                draggableItem.parentsAfterDrag = transform;
                

                if (itemStatus.correctAnswer2 == true)
                {
                    if (Level3)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        draggableItem.draggble = false;
                        count.correctCount += 1;
                    }
                    if (Level6)
                    {
                       
                        draggableItem.draggble = false;
                        win.counter();
                    }
                    secondChildImage.color = Color.green;
                    //AnimActive1.gameObject.SetActive(true);
                    Debug.Log("Correct");
                }
                else
                {
                    if (Level3)
                    {
                        error.gameObject.SetActive(true);
                        count.mistakeCounter += 1;
                        Invoke("delayRed", 1f);
                    }
                    if (Level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("delayRed", 1f);
                    }
                    secondChildImage.color = Color.red;
                    Debug.Log("Incorrect");
                }
            }

        }

 

        else if (counter.Slot4 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                Image secondChildImage = dropped.GetComponent<Image>();
                Item itemStatus = dropped.GetComponent<Item>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswer3 == true)
                {
                    if (Level3)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        draggableItem.draggble = false;
                        count.correctCount += 1;
                    }
                    if (Level6)
                    {

                        draggableItem.draggble = false;
                        win.counter();
                    }
                    secondChildImage.color = Color.green;
                    //AnimActive1.gameObject.SetActive(true);
                    Debug.Log("Correct");
                }
                else
                {
                    if (Level3)
                    {
                        error.gameObject.SetActive(true);
                        count.mistakeCounter += 1;
                        Invoke("delayRed", 1f);
                    }
                    if (Level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("delayRed", 1f);
                    }
                    secondChildImage.color = Color.red;
                    Debug.Log("Incorrect");
                }
            }

        }

        else if (counter.Slot5 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                Image secondChildImage = dropped.GetComponent<Image>();
                Item itemStatus = dropped.GetComponent<Item>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswer4 == true)
                {
                    if (Level3)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        draggableItem.draggble = false;
                        count.correctCount += 1;
                    }
                    if (Level6)
                    {

                        draggableItem.draggble = false;
                        win.counter();
                    }
                    secondChildImage.color = Color.green;
                    //AnimActive1.gameObject.SetActive(true);
                    Debug.Log("Correct");
                }
                else
                {
                    if (Level3)
                    {
                        error.gameObject.SetActive(true);
                        count.mistakeCounter += 1;
                        Invoke("delayRed", 1f);
                    }
                    if (Level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("delayRed", 1f);
                    }
                    secondChildImage.color = Color.red;
                    Debug.Log("Incorrect");
                }
            }

        }

        else if (counter.Slot6 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                Image secondChildImage = dropped.GetComponent<Image>();
                Item itemStatus = dropped.GetComponent<Item>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswer5 == true)
                {
                    if (Level3)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        draggableItem.draggble = false;
                        count.correctCount += 1;
                    }
                    if (Level6)
                    {

                        draggableItem.draggble = false;
                        win.counter();
                    }
                    secondChildImage.color = Color.green;
                    //AnimActive1.gameObject.SetActive(true);
                    Debug.Log("Correct");
                }
                else
                {
                    if (Level3)
                    {
                        error.gameObject.SetActive(true);
                        count.mistakeCounter += 1;
                        Invoke("delayRed", 1f);
                    }
                    if (Level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("delayRed", 1f);
                    }
                    secondChildImage.color = Color.red;
                    Debug.Log("Incorrect");
                }
            }

        }

        else if (counter.Slot7 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                Image secondChildImage = dropped.GetComponent<Image>();
                Item itemStatus = dropped.GetComponent<Item>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswer6 == true)
                {
                    if (Level3)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        draggableItem.draggble = false;
                        count.correctCount += 1;
                    }
                    if (Level6)
                    {

                        draggableItem.draggble = false;
                        win.counter();
                    }
                    secondChildImage.color = Color.green;
                    //AnimActive1.gameObject.SetActive(true);
                    Debug.Log("Correct");
                }
                else
                {
                    if (Level3)
                    {
                        error.gameObject.SetActive(true);
                        count.mistakeCounter += 1;
                        Invoke("delayRed", 1f);
                    }
                    if (Level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("delayRed", 1f);
                    }
                    secondChildImage.color = Color.red;
                    Debug.Log("Incorrect");
                }
            }

        }
    }

    public void delayRed()
    {
        error.gameObject.SetActive(false);
    }

    
}
