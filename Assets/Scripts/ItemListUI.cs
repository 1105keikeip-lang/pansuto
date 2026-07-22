using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemListUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform content;
    public GameObject itemPrefab;

     public void UpdateList()
    {
        

        Debug.Log("content = " + content);
        Debug.Log("itemPrefab = " + itemPrefab);
        Debug.Log("Inventory count = " + InventoryManager.Instance.items.Count);
        foreach (Transform child in content)
            Destroy(child.gameObject);

        foreach (var pair in InventoryManager.Instance.items)
        {
            var item = pair.Key;
            var count = pair.Value;

            var obj = Instantiate(itemPrefab, content);
            obj.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>().text = item.itemName;
            obj.transform.Find("Count").GetComponent<TMPro.TextMeshProUGUI>().text = "×" + count;
            obj.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().sprite = item.icon;
            

            obj.transform.Find("UseButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                InventoryManager.Instance.UseItem(item);
                UpdateList();//使用後に更新
            });
            Debug.Log("Name = " + obj.transform.Find("Name"));
            Debug.Log("Count = " + obj.transform.Find("Count"));
            Debug.Log("Icon = " + obj.transform.Find("Icon"));
            Debug.Log("UseButton = " + obj.transform.Find("UseButton"));
        }
    }

   
}
