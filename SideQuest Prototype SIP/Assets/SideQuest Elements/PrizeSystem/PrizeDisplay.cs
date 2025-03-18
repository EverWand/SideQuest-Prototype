using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizeDisplay : MonoBehaviour
{
    [SerializeField] Image prizeImage;
    [SerializeField] TextMeshProUGUI countTxt;
    [SerializeField] Color darkenColor;
    [SerializeField] public Prize.PrizeDetails prizedetails { get; private set; }

    public void setPrize(Prize prize)
    {
        prizedetails = prize.Get_Details();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        prizeImage.sprite = prizedetails.icon;
        int count = Get_Count();
        countTxt.text = count.ToString();

        prizeImage.color = count <= 0 ? darkenColor : Color.white;
    }
    public int Get_Count()
    {
        if (prizedetails.name == "") { return -1; }

        int count = 0;

        foreach (string prizeName in GameManager.instance.GetComponent<PrizeManager>().Get_CollectedPrizes()) { 
            if (prizeName == prizedetails.name) { count++; }
        }

        return count;

    }
}
