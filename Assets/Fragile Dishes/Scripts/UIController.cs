using UnityEngine;
using UnityEngine.UI;

namespace FragileDishes
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private GameObject uiPanel;
     
        void Start()
        {
            startButton.onClick.AddListener(CloseUI);
        }
        
        private void CloseUI()
        {
            uiPanel.SetActive(false);
        }
        
    }
}
