using UnityEngine;

/*
Each task item is a child of contentRect. 
Each task item is identified by its gameObject name.
Call AddItem to add a task to the list as well as give it a name.
The _text parameter in AddItem is the text that is displayed on screen.
Call RemoveItem to remove the item by giving it the name given to the idem when AddItem is called.
*/
public class TaskLog : MonoBehaviour
{
    [SerializeField] RectTransform contentRect;
    [SerializeField] GameObject taskPrefab;
    public bool isHidden;
    Vector2 startPosition;
    [SerializeField] Vector2 hiddenOffset;
    [SerializeField] float lerpFactor;

    void OnValidate()
    {
        ScaleContentRectToChildren();
    }

    void Start()
    {
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.H)) ShowHideLog();

        if (isHidden)
        {
            GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(GetComponent<RectTransform>().anchoredPosition, startPosition + hiddenOffset, lerpFactor * Time.deltaTime);
        }
        else
        {
            GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(GetComponent<RectTransform>().anchoredPosition, startPosition, lerpFactor * Time.deltaTime);
        }

        ScaleContentRectToChildren();
    }

    public void AddItem(string _itemName, string _text)
    {
        GameObject createdTask = Instantiate(taskPrefab, contentRect.transform);
        createdTask.name = _itemName;
        createdTask.transform.SetSiblingIndex(0);

        createdTask.GetComponent<TMPro.TextMeshProUGUI>().text = "- " + _text;
    }

    public void RemoveItem(string _itemName)
    {
        foreach (Transform child in contentRect)
            if (child.name == _itemName)
            {
                Destroy(child.gameObject);
                return;
            }
    }

    public void ShowHideLog()
    {
        isHidden = !isHidden;
    }   

    void ScaleContentRectToChildren()
    {
        UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup = contentRect.GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        verticalLayoutGroup.enabled = false;
        verticalLayoutGroup.enabled = true;

        float rectHeight = 0;
        foreach(RectTransform child in contentRect)
            rectHeight += child.rect.height + verticalLayoutGroup.spacing;

        float scrollRectHeight = contentRect.parent.GetComponent<RectTransform>().rect.height;
        if (rectHeight < scrollRectHeight) rectHeight = scrollRectHeight;
        
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, rectHeight);
    }
}
