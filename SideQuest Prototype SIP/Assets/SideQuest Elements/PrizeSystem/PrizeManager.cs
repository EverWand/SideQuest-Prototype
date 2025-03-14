using UnityEngine;
using CustomUtil;

public class PrizeManager : MonoBehaviour, ISaveData
{
    
    [SerializeField] PrizePack[] packs;

    [Header("Debug")]
    
    [SerializeField] Prize[] collectedPrizes;
    public int currency { get; private set; }


    public void AddCurrency(int amount)
    {
        currency += amount;
    }
    public void OpenPack(PrizePack pack)
    {
        //GUARD: Insufficient currency for pack purchase
        if (currency < pack.packCost) { return; }

        /*Add the prize to the collected prizes*/
        Prize prize = pack.PullPrize();
        /*Remove the cost of the pack from the currency*/
        currency -= pack.packCost;
    }

    /*=====| SAVE DATA |=====*/
    public void SaveData(ref AppData data)
    {
        /*Save currency*/
        data.currency = this.currency;
        /*Save collected prizes*/
        data.collectedPrizes = this.collectedPrizes;
    }
    public void LoadData(AppData data)
    {
        /*Load saved collected prizes*/
        this.currency = data.currency;
        /*Load saved currency*/
        this.collectedPrizes = data.collectedPrizes;
    }
}
