using UnityEngine;
using UnityEngine.Events;

public class PrizePack : MonoBehaviour
{
    [SerializeField] string packName = "Pack";   //The name of the pack
    [SerializeField] int packCost = 1;   //The cost of the pack

    [System.Serializable]
    public struct PrizeEntry
    {
        public Prize prize;
        public float chance;
    }

    [SerializeField] PrizeEntry[] prizePool;

    /*=====| Events |=====*/
    public UnityAction RolledPrize;

    /*Rolls for a random prize from the pack's prize pool*/
    public Prize RollPrize()
    {
        //GAURD: No entries within Prize Pool
        if (prizePool.Length == 0) { return null; }

        Prize prize = prizePool[Random.Range(0, prizePool.Length)].prize;
        Debug.Log("Rolling Pack for Prize: " + packName + " | ROLLED: " + prize.Get_Details().name);

        //Return a random prize from the prize pool
        return prize;
    }


    /*=====| Getters |=====*/
    public string Get_PackName() { return packName; }
    public int Get_PackCost() { return packCost; }
}
