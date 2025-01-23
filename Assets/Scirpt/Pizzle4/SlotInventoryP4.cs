using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventoryP4 : MonoBehaviour, IDropHandler
{
    public SlotManager counter;
    public GameObject AnimActive1;
    //public GameObject AnimActive2;

    public GameObject parent;

    public Puzzle4Man checker;

    public Puzzke6Man win;

    public bool level4;
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
                Image dragItem = dropped.GetComponentInChildren<Image>();
                draggableItem.parentsAfterDrag = transform;
                dragItem.color = Color.white;
            }
        }
        else if (counter.Slot2 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                parent = dropped;

                Transform child = parent.transform.GetChild(0);

                Image colors = child.GetComponent<Image>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[0] == true)
                {
                    if (level4)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        
                        checker.Counter += 1;
                    }
                    if (level6)
                    {
                        win.counter();
                    }
                    draggableItem.draggble = false;
                    colors.color = Color.green;
                    Debug.Log("Correct");

                }
                else
                {
                    if (level4)
                    {
                        error.gameObject.SetActive(true);

                        checker.mistakeCounter += 1;
                        Invoke("delayRed", 1f);
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        win.Mistake();
                    }
                    colors.color = Color.red;
                    Debug.Log("Incorrect");
                    draggableItem.EndDrag = true;
                }
            }

        }

        else if (counter.Slot3 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;
                parent = dropped;

                Transform child = parent.transform.GetChild(0);

                Image colors = child.GetComponent<Image>();


                if (itemStatus.correctAnswers[1] == true)
                {
                    if (level4)
                    {
                        AnimActive1.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        checker.Counter += 1;
                    }
                    if (level6)
                    {
                        win.counter();
                    }
                    draggableItem.draggble = false;
                    colors.color = Color.green;
                    Debug.Log("Correct");
                }
                else
                {
                    if (level4)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        checker.mistakeCounter += 1;
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        win.Mistake();
                    }
                    colors.color = Color.red;
                    Debug.Log("Incorrect");
                    draggableItem.EndDrag = true;
                }
            }

        }
        else if (counter.Slot4 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;

                parent = dropped;

                Transform child = parent.transform.GetChild(0);

                Image colors = child.GetComponent<Image>();

                if (itemStatus.correctAnswers[2] == true)
                {
                    if (level4)
                    {
                        AnimActive1.gameObject.SetActive(true);

                        checker.Counter += 1;
                    }
                    if (level6)
                    {
                        win.counter();
                    }
                    draggableItem.draggble = false;
                    colors.color = Color.green;
                    Debug.Log("Correct");
                }
                else
                {
                    if (level4)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        checker.mistakeCounter += 1;
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        win.Mistake();
                    }
                    colors.color = Color.red;
                    Debug.Log("Incorrect");
                    draggableItem.EndDrag = true;
                }
            }

        }
        else if (counter.Slot5 == true)
        {
            if (transform.childCount == 0)
            {

                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                parent = dropped;

                Transform child = parent.transform.GetChild(0);

                Image colors = child.GetComponent<Image>();

                if (itemStatus.correctAnswers[3] == true)
                {
                    if (level4)
                    {
                        AnimActive1.gameObject.SetActive(true);

                        checker.Counter += 1;
                    }
                    if (level6)
                    {
                        win.counter();
                    }
                    draggableItem.draggble = false;
                    colors.color = Color.green;
                    Debug.Log("Correct");
                }
                else
                {
                    if (level4)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        checker.mistakeCounter += 1;
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        win.Mistake();
                    }
                    colors.color = Color.red;
                    Debug.Log("Incorrect");
                    draggableItem.EndDrag = true;
                }
            }

        }
        else if (counter.Slot6 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;

                parent = dropped;

                Transform child = parent.transform.GetChild(0);

                Image colors = child.GetComponent<Image>();

                if (itemStatus.correctAnswers[4] == true)
                {
                    if (level4)
                    {
                        AnimActive1.gameObject.SetActive(true);

                        checker.Counter += 1;
                    }
                    if (level6)
                    {
                        win.counter();
                    }
                    draggableItem.draggble = false;
                    colors.color = Color.green;
                    Debug.Log("Correct");
                }
                else
                {
                    if (level4)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        checker.mistakeCounter += 1;
                    }
                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        win.Mistake();
                    }
                    colors.color = Color.red;
                    Debug.Log("Incorrect");
                    draggableItem.EndDrag = true;
                }
            }

        }
        else if (counter.Slot7 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;

                parent = dropped;

                Transform child = parent.transform.GetChild(0);
                Image colors = child.GetComponent<Image>();

                if (itemStatus.correctAnswers[5] == true)
                {
                    if (level4)
                    {
                        AnimActive1.gameObject.SetActive(true);

                        checker.Counter += 1;
                    }

                    if (level6)
                    {
                        win.counter();
                    }
                    draggableItem.draggble = false;
                    colors.color = Color.green;
                    Debug.Log("Correct");
                }
                else
                {
                    if (level4)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        checker.mistakeCounter += 1;
                    }

                    if (level6)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        win.Mistake();
                    }
                    colors.color = Color.red;
                    Debug.Log("Incorrect");
                    draggableItem.EndDrag = true;
                }
            }

        }
        else if (counter.Slot8 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;

                parent = dropped;

                Transform child = parent.transform.GetChild(0);
                Image colors = child.GetComponent<Image>();

                if (itemStatus.correctAnswers[6] == true)
                {
                    if (level4)
                    {
                        checker.Counter += 1;
                    }
                    draggableItem.draggble = false;
                    colors.color = Color.green;
                    Debug.Log("Correct");
                }
                else
                {
                    if (level4)
                    {
                        error.gameObject.SetActive(true);
                        Invoke("delayRed", 1f);
                        checker.mistakeCounter += 1;
                    }
                    colors.color = Color.red;
                    Debug.Log("Incorrect");
                    draggableItem.EndDrag = true;
                }
            }

        }
        else if (counter.Slot9 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[7] == true)
                {
                    draggableItem.draggble = false;
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
            }

        }
        else if (counter.Slot10 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[8] == true)
                {
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
            }

        }
        else if (counter.Slot11 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[9] == true)
                {
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
            }

        }
        else if (counter.Slot12 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[10] == true)
                {
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
            }

        }
        else if (counter.Slot13 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[11] == true)
                {
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
            }

        }
        else if (counter.Slot14 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[12] == true)
                {
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
            }

        }
        else if (counter.Slot15 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[13] == true)
                {
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
            }

        }
        else if (counter.Slot16 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[14] == true)
                {
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
            }

        }
        else if (counter.Slot17 == true)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                ItemP4 itemStatus = dropped.GetComponent<ItemP4>();
                draggableItem.parentsAfterDrag = transform;


                if (itemStatus.correctAnswers[15] == true)
                {
                    checker.Counter += 1;
                    Debug.Log("Correct");
                }
                else
                {
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
