using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] PanelSwitcher panelSwitcher;
    public HUD hud;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (panelSwitcher == null) { panelSwitcher = GetComponent<PanelSwitcher>(); }
    }

    void Start()
    {
        panelSwitcher.FocusRootPanel();
    }
}
