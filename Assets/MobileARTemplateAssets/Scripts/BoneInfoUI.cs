using UnityEngine;
using UnityEngine.UI;

public class BoneInfoUI : MonoBehaviour
{
    public static BoneInfoUI Instance;

    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Text infoText;

    void Awake()
    {
        Instance = this;
        infoPanel.SetActive(false);
    }

    public void ShowInfo(string info)
    {
        infoText.text = info;
        infoPanel.SetActive(true);
    }

    public void Hide()
    {
        infoPanel.SetActive(false);
    }
}
