using System;
using CofyUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CofyDev.AnimalDefender.UI
{
    public class ConfirmationPopupPanel: AnimatedPopupPanel<ConfirmationPopupPanel>
    {
        [Header("Buttons")]
        [SerializeField] private Button confirmButton;
        [SerializeField] private Button cancelButton;
        [SerializeField] private Button closeButton;

        [Header("Text")] 
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI contentText;

        private Promise<bool> confirmPromise;
        
        //TODO: need to resolve when animation end
        private void OnConfirm()
        {
            confirmPromise?.Resolve(true);
        }

        private void OnCancel()
        {
            confirmPromise?.Resolve(false);
        }

        public Future<bool> Inqiure()
        {
            confirmPromise = new Promise<bool>();
            
            confirmButton.onClick.AddListener(OnConfirm);
            cancelButton.onClick.AddListener(OnCancel);
            closeButton.onClick.AddListener(OnCancel);
            
            Show();
            confirmPromise.OnCompleted(v =>
            {
                confirmButton.onClick.RemoveListener(OnConfirm);
                cancelButton.onClick.RemoveListener(OnCancel);
                closeButton.onClick.RemoveListener(OnCancel);
                Hide();
            });
            
            return confirmPromise.future;
        }
    }
}