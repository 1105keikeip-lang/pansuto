using System.Collections;
using UnityEngine;

public class ItemUseSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public  PlayerStatus player;

    void Start()
    {
        if(player == null)
        {
            player = FindFirstObjectByType<PlayerStatus>();
        }
    }

    public void UseItem(ItemData item)
    {
        switch (item.itemType)
        {
            case ItemType.Heal:
                player.HP += item.healAmount;
                break;

            case ItemType.Buff:
                StartCoroutine(ApplyBuff(item));
                break;
        }
    }

    IEnumerator ApplyBuff(ItemData item)
    {
        player.attack *= item.buffValue;
        yield return new WaitForSeconds(item.duration);
        player.attack /= item.buffValue;
    }
}
