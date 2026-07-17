using UnityEngine;

public class HomeButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject homePanel;
    public GameObject ItemPanel;
    public GameObject MissionPanel;
    public GameObject BattlePanel;
    public GameObject MailPanel;
    public GameObject ShopPanel;
    public GameObject OptionPanel;

    public void OnItemButton()
    {
        homePanel.SetActive(false);
        ItemPanel.SetActive(true);
    }
    public void OnMissionButton()
    {
        homePanel.SetActive(false);
        MissionPanel.SetActive(true);
    }

    public void OnBattleButton()
    {
        homePanel.SetActive(false);
        BattlePanel.SetActive(true);
    }

    public void OnMailButton()
    {
        homePanel.SetActive(false);
        MailPanel.SetActive(true);
    }

    public void OnShopButton()
    {
        homePanel.SetActive(false);
        ShopPanel.SetActive(true);
    }

    public void OnOptionButton()
    {
        homePanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
        
        
        
        
        
    

    public void OnItemBackButton()
    {
        ItemPanel.SetActive(false);
        homePanel.SetActive(true);
       
    }
}
