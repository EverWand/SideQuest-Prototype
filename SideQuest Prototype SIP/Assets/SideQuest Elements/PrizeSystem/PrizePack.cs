using UnityEngine;

public class PrizePack : MonoBehaviour
{
    [SerializeField] string packName = "Pack";   //The name of the pack
    [SerializeField] int packCost = 1;   //The cost of the pack
    
    [System.Serializable]
    public struct PrizeEntry {
        public Prize prize;
        public float chance;
    }

    
    [SerializeField] PrizeEntry[] prizePool;

    /*Rolls for a random prize from the pack's prize pool*/
    public Prize RollPrize()
    {
        //GAURD: No entries within Prize Pool
        if (prizePool.Length == 0) { return null; }

        //Return a random prize from the prize pool
        return prizePool[Random.Range(0, prizePool.Length - 1)].prize;
    }


    /*=====| Getters |=====*/
    public string Get_PackName() { return packName; }   
    public int Get_PackCost() { return packCost; }
}
