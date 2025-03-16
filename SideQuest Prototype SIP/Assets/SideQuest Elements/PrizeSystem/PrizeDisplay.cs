using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizeDisplay : MonoBehaviour
{
    [SerializeField] Image prizeImage;
    [SerializeField] public TextMeshProUGUI Count { get; private set; }
    [SerializeField] Prize.PrizeDetails prizedetails;


    public void setPrize(Prize prize)
    {
        prizedetails = prize.Get_Details();
        UpdateDisplay();
    }



    private void Start()
    {
        prizeImage.sprite = prizedetails.icon;
        UpdateCount();
    }

    void UpdateDisplay()
    {
        prizeImage.sprite = prizedetails.icon;
        UpdateCount();
    }
    void UpdateCount()
    {
        //Count.text = Wherever I put the count;
    }
}
