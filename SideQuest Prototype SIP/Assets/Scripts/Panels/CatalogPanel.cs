using TMPro;
using UnityEngine;

public class CatalogPanel : SQ_Panel
{
    /*====| References |====*/
    [SerializeField] TextMeshProUGUI currencyTxt;
    [SerializeField] TextMeshProUGUI packCostTxt;
    [SerializeField] TextMeshProUGUI scoreTxt;

    [SerializeField] Transform catalogContainer;
    [SerializeField] GameObject prizeEntryPrefab;

    [Header("Debug")]
    [SerializeField] int testEntries = -1; //-1 to set to no testing


    /*====| Events |====*/
    public delegate void PackBtnPressed_Call(PrizePack pack); //When Pack is Opened
    PackBtnPressed_Call OnPackBtnPressed;


    private void OnValidate()
    {
        if (testEntries != -1)
        {
            BuildCatalog();
        }
    }

    private void Awake()
    {
        BuildCatalog();
    }

    void BuildCatalog()
    {
        /* DEBUGGING LOGIC
        //Return if the contain doesn't exist
        if (!catalogContainer) { return; }

        Debug.Log("buildCatalog called");

        if (catalogContainer.childCount != testEntries)
        {
            ClearCatalogEntries();

            //CREATE ENTRIES
            for (int i = 0; i < testEntries; i++)
            {
                Debug.Log("Creating entry " + i);
                Instantiate(prizeEntryPrefab, catalogContainer);
            }
        }
        */

        ClearCatalogEntries();

        GameObject[] allPrizes = Resources.LoadAll<GameObject>("Prizes/Prizes");

        foreach (var prizeObj in allPrizes)
        {
            Prize prize = prizeObj.GetComponent<Prize>();

            //Get the Prize Display of a newly instantiated entry
            PrizeDisplay newEntry = Instantiate(prizeEntryPrefab, catalogContainer).GetComponent<PrizeDisplay>();
            //Set the entry's prize so it can display it's info
            newEntry.setPrize(prize);
        }
    }

    void ClearCatalogEntries()
    {
        int entryCount = catalogContainer.childCount - 1;

        Debug.Log("ClearCatalogEntries called, entryCount: " + entryCount);

        for (int i = entryCount; i >= 0; i--)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                Debug.Log("Destroying entry " + i + " immediately");
                DestroyImmediate(catalogContainer.GetChild(i).gameObject);
            }
            else
            {
#endif
                Debug.Log("Destroying entry " + i);
                Destroy(catalogContainer.GetChild(i).gameObject);
            }
        }
    }
}
