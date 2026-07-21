using UnityEngine;

public class ItemListUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform content;
    public GameObject itemPrefab;

     void OnEnable()
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);

        foreach (var pair in InventoryManager.Instance.items)
        {
            var item = pair.Key;
            var count = pair.Value;

            var obj = Instantiate(itemPrefab, content);
            obj.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>().text = item.itemName;
            obj.transform.Find("Count").GetComponent<TMPro.TextMeshProUGUI>().text = "Å~" + count;
            obj.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().sprite = item.icon;

            obj.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                InventoryManager.Instance.UseItem(item);
                OnEnable(); // çƒï`âÊ
            });
        }
    }
}
