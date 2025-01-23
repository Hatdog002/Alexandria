using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{

    public GameObject[] bookPages;

    public int pageAmmount;

    public int currentPage = 0;

    public GameObject nextButton;
    public GameObject prevButton;

    public GameObject BG;
    public GameObject Answer;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(currentPage == bookPages.Length - 1)
        {        
            nextButton.SetActive(false);            
            Debug.Log("Off");
        }
        else if(currentPage >= 1)
        {
            nextButton.SetActive(true);
        }
        if (currentPage == 0)
        {
            prevButton.SetActive(false);
        }
        else
        {
            Answer.gameObject.SetActive(true);
            BG.gameObject.SetActive(true);
            prevButton.SetActive(true);
        }


        if (currentPage < 0)
        {
            BG.gameObject.SetActive(true);
            Answer.gameObject.SetActive(true);
        }
        else if (currentPage == bookPages.Length - 1)
        {
            BG.gameObject.SetActive(false);
            Answer.gameObject.SetActive(false);
        }
        else if (currentPage == 0)
        {
            BG.gameObject.SetActive(false);
            Answer.gameObject.SetActive(false);
        }
    }

    public void NextPage()
    {
        bookPages[currentPage].SetActive(false);
        currentPage++;
        bookPages[currentPage].SetActive(true);
    }

    public void PrevPage()
    {
        bookPages[currentPage].SetActive(false);
        currentPage--;
        bookPages[currentPage].SetActive(true);
        Debug.Log("current page is: "+currentPage);
    }
}
