using UnityEngine;

public abstract class PrizePack : MonoBehaviour
{
    [SerializeField] public string packName { get; private set; }   //The name of the pack
    [SerializeField] public int packCost    { get; private set; }   //The cost of the pack
    [SerializeField] Prize[] prizePool; //The pool of prizes that can be won from this pack

    /*Rolls for a random prize from the pack's prize pool*/
    public Prize PullPrize()
    {
        return prizePool[Random.Range(0, prizePool.Length)];
    }
}
