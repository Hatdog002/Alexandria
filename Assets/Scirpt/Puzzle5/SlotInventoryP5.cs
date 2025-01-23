using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventoryP5 : MonoBehaviour, IDropHandler
{
    public SlotManager counter;
    public GameObject AnimActive1;

    public Puzzle5Man checker;
    public Puzzke6Man win;

    public bool level5;
    public bool level6;

    public GameObject error;
    public void Start()
    {
        counter = GetComponent<SlotManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (counter.Slot1 == true)
        {
            if (transform.childCount <= 7)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentsAfterDrag = transform;

                Image secondChildImage = dropped.GetComponent<Image>();

                secondChildImage.color = Color.white;
            }
        }
        else if (counter.Slot2 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP5 itemStatus = dropped.GetComponent<ItemP5>();
                draggableItem.parentsAfterDrag = transform;
                Image secondChildImage = dropped.GetComponent<Image>();

                if (itemStatus.correctAnswers[0] == true)
                {
                    if (level5)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        checker.Counter += 1;
                    }

                    if (level6)
                    {
                        win.counter();
                    }
                   
                    draggableItem.draggble = false;
                    secondChildImage.color = Color.green;
                    
                    Debug.Log("Correct");
                }
                else
                {
                    if (level5)
                    {
                        error.gameObject.SetActive(true);
                        checker.mistakeCounter += 1;
                        Invoke("DelayRed", 1f);
                    }

                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("DelayRed", 1f);
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
                ItemP5 itemStatus = dropped.GetComponent<ItemP5>();
                draggableItem.parentsAfterDrag = transform;
                Image secondChildImage = dropped.GetComponent<Image>();

                if (itemStatus.correctAnswers[1] == true)
                {
                    if (level5)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        checker.Counter += 1;
                    }

                    if (level6)
                    {
                        win.counter();
                    }

                    draggableItem.draggble = false;
                    secondChildImage.color = Color.green;

                    Debug.Log("Correct");
                }
                else
                {
                    if (level5)
                    {
                        error.gameObject.SetActive(true);
                        checker.mistakeCounter += 1;
                        Invoke("DelayRed", 1f);
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("DelayRed", 1f);
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
                ItemP5 itemStatus = dropped.GetComponent<ItemP5>();
                draggableItem.parentsAfterDrag = transform;
                Image secondChildImage = dropped.GetComponent<Image>();

                if (itemStatus.correctAnswers[2] == true)
                {
                    if (level5)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        checker.Counter += 1;
                    }

                    if (level6)
                    {
                        win.counter();
                    }

                    draggableItem.draggble = false;
                    secondChildImage.color = Color.green;

                    Debug.Log("Correct");
                }
                else
                {
                    if (level5)
                    {
                        error.gameObject.SetActive(true);
                        checker.mistakeCounter += 1;
                        Invoke("DelayRed", 1f);
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("DelayRed", 1f);
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
                ItemP5 itemStatus = dropped.GetComponent<ItemP5>();
                draggableItem.parentsAfterDrag = transform;
                Image secondChildImage = dropped.GetComponent<Image>();

                if (itemStatus.correctAnswers[3] == true)
                {
                    if (level5)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        checker.Counter += 1;
                    }

                    if (level6)
                    {
                        win.counter();
                    }

                    draggableItem.draggble = false;
                    secondChildImage.color = Color.green;

                    Debug.Log("Correct");
                }
                else
                {
                    if (level5)
                    {
                        error.gameObject.SetActive(true);
                        checker.mistakeCounter += 1;
                        Invoke("DelayRed", 1f);
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("DelayRed", 1f);
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
                ItemP5 itemStatus = dropped.GetComponent<ItemP5>();
                draggableItem.parentsAfterDrag = transform;
                Image secondChildImage = dropped.GetComponent<Image>();

                if (itemStatus.correctAnswers[4] == true)
                {
                    if (level5)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        checker.Counter += 1;
                    }

                    if (level6)
                    {
                        win.counter();
                    }

                    draggableItem.draggble = false;
                    secondChildImage.color = Color.green;

                    Debug.Log("Correct");
                }
                else
                {
                    if (level5)
                    {
                        error.gameObject.SetActive(true);
                        checker.mistakeCounter += 1;
                        Invoke("DelayRed", 1f);
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("DelayRed", 1f);
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
                ItemP5 itemStatus = dropped.GetComponent<ItemP5>();
                draggableItem.parentsAfterDrag = transform;
                Image secondChildImage = dropped.GetComponent<Image>();

                if (itemStatus.correctAnswers[5] == true)
                {
                    if (level5)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        checker.Counter += 1;
                    }

                    if (level6)
                    {
                        win.counter();
                    }

                    draggableItem.draggble = false;
                    secondChildImage.color = Color.green;

                    Debug.Log("Correct");
                }
                else
                {
                    if (level5)
                    {
                        error.gameObject.SetActive(true);
                        checker.mistakeCounter += 1;
                        Invoke("DelayRed", 1f);
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        win.Mistake();
                        Invoke("DelayRed", 1f);
                    }
                    secondChildImage.color = Color.red;
                    Debug.Log("Incorrect");
                }
            }

        }
    }

    public void DelayRed()
    {
        error.gameObject.SetActive(false);
    }
 }
