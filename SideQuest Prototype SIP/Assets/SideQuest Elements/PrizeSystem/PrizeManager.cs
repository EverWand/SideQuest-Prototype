using UnityEngine;
using CustomUtil;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class PrizeManager : MonoBehaviour, ISaveData
{
    [SerializeField] List<PrizePack> packs;

    
    [Header("Debug")]

    [SerializeField] List<string> collectedPrizes;
    [SerializeField] public int currency { get; private set; }


    /*====| Events |====*/
    public UnityAction PrizeRecieved;

    public List<string> Get_CollectedPrizes() { return collectedPrizes; }

    public void AddCurrency(int amount)
    {
        currency += amount;
    }

    public void OpenPack(string packName) {
        PrizePack foundPack = null;
        
        foreach (PrizePack pack in packs)
        {
            if (pack.Get_PackName() == packName) { foundPack = pack; }
        }

        if (foundPack == null) { return; }

        OpenPack(foundPack);
    }
    public void OpenPack(PrizePack pack)
    {
        //GUARD: Insufficient currency for pack purchase
        if (currency < pack.Get_PackCost()) { return; }

        pack.RolledPrize += PrizeRecieved;

        /*Add the prize to the collected prizes*/
        Prize prize = pack.RollPrize();
        /*Remove the cost of the pack from the currency*/
        currency -= pack.Get_PackCost();

        Debug.Log("Adding " + prize.Get_Details().name + " to Collection");

        collectedPrizes.Add(prize.Get_Details().name);
        PrizeRecieved.Invoke();


        pack.RolledPrize -= PrizeRecieved;
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
