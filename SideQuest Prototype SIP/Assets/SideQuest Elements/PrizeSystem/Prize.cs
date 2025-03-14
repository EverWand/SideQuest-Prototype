using UnityEngine;

public abstract class Prize : MonoBehaviour
{
    [System.Serializable]
    public struct PrizeDetails
    {
        public string name { get; private set; }
        public Sprite icon { get; private set; }
        public int value { get; private set; }
    }
}
