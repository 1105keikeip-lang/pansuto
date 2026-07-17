using UnityEngine;

public class ItemPanelController : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject equipPanel;
    public GameObject itemListPanel;
    public GameObject forgePanel;

    public GameObject[] itemButtons;

    void HideAllButtons()
    {
        foreach(var btn in itemButtons)
        {
            btn.SetActive(false);
        }
    }
    public void ShowEquip()
    {

        equipPanel.SetActive(true);
        itemListPanel.SetActive(false);
        forgePanel.SetActive(false);
    }

    public void ShowItem()
    {
        equipPanel.SetActive(false);
        itemListPanel.SetActive(true);
        forgePanel.SetActive(false);
    }

    public void ShowForge()
    {
        equipPanel.SetActive(false);
        itemListPanel.SetActive(false);
        forgePanel.SetActive(true);
    }
}
