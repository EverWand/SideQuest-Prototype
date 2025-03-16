using UnityEngine;

public class Prize : MonoBehaviour
{
    [System.Serializable]
    public struct PrizeDetails
    {
        public string name;
        public Sprite icon;
        public int value;
    }

    [SerializeField] PrizeDetails details;

    public PrizeDetails Get_Details() { return details; }
}
