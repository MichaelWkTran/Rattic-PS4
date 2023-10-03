using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    GameObject screen;
    [SerializeField] GameObject winScreenItem;
    [SerializeField] GameObject winScreenItemDash;
    [SerializeField] Transform itemGroup;
    [SerializeField] int titleSceneIndex;
    [SerializeField] GameObject winFamily;
    [SerializeField] GameObject winCat;
    [SerializeField] GameObject winFake;

    void Start()
    {
        screen = transform.GetChild(0).gameObject;
        screen.SetActive(false);
    }

    public void AddItem(Sprite _itemSprite)
    {
        Instantiate(winScreenItemDash, itemGroup);
        Instantiate(winScreenItem, itemGroup).GetComponent<Image>().sprite = _itemSprite;
    }

    public void Win()
    {
        screen.SetActive(true);
        Time.timeScale = 0f;
        FindObjectOfType<PauseScreen>().Unpause();
    }

    public void EndCutscene(int type)
    {
        if (type == 0)
            winFamily.SetActive(true);
        if (type == 1)
            winCat.SetActive(true);
        if (type == 2)
            winFake.SetActive(true);
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(titleSceneIndex);
    }
}
