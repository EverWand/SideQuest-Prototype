using UnityEngine;
using CustomUtil;
using System;
using System.Collections.Generic;

public class PrizeManager : MonoBehaviour, ISaveData
{
    [SerializeField] List<PrizePack> packs;
    
    
    [Header("Debug")]

    [SerializeField] Prize[] collectedPrizes;
    [SerializeField] public int currency { get; private set; }

    


    public void AddCurrency(int amount)
    {
        currency += amount;
    }

    public void OpenPack<T>() where T : PrizePack
    {
        PrizePack pack = Activator.CreateInstance<T>();
        OpenPack(pack);
    }

    public void OpenPack(PrizePack pack)
    {
        //GUARD: Insufficient currency for pack purchase
        if (currency < pack.Get_PackCost()) { return; }

        /*Add the prize to the collected prizes*/
        Prize prize = pack.RollPrize();
        /*Remove the cost of the pack from the currency*/
        currency -= pack.Get_PackCost();
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
