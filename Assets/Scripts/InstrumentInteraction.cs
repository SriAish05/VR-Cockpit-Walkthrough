using UnityEngine;
using TMPro;

public class InstrumentInteraction : MonoBehaviour
{
    [Header("Instrument Info")]
    public string instrumentName = "Instrument";
    public string instrumentDescription = "Description.";

    [Header("UI References")]
    public GameObject infoPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    private bool isPanelVisible = false;

    public void TogglePanel()
    {
        if (isPanelVisible)
            HidePanel();
        else
            ShowPanel();
    }

    void ShowPanel()
{
    titleText.text = instrumentName.ToUpper();
    descriptionText.text = instrumentDescription;
    
    // Just show it — no position needed!
    // Screen Space Overlay handles position automatically
    infoPanel.SetActive(true);
    isPanelVisible = true;
}

    void HidePanel()
    {
        infoPanel.SetActive(false);
        isPanelVisible = false;
    }
}