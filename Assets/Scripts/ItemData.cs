using UnityEngine;

public enum ItemType
{
    Heal,
    Buff,
    Debuff,
    Material,
    Important
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Game/Item")]


public class ItemData : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string itemName;
    public ItemType itemType;
    public Sprite icon;
    public string description;

    public int healAmount;  //回復量
    public float buffValue; //ステータス上昇値
    public float duration;  //効果時間
    // Update is called once per frame
    
}




