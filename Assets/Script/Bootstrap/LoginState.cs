using CofyDev.AnimalDefender.UI;
using CofyEngine.Core;
using CofyEngine.UGS;
using CofyUI;

namespace CofyEngine
{
    public class LoginState : IPromiseState<BootStateId>
    {
        public BootStateId id => BootStateId.UGS;
        
        public void StartContext(IPromiseSM<BootStateId> sm, object param)
        {
            var initFuture = UGSController.InitService().executeInMainThread();

            initFuture.OnFailed(future =>
            {
            });
            
            initFuture.OnSucceed(_ =>
            {
                ConfirmationPopupPanel.instance.Show();
                sm.GoToState(BootStateId.Terminate);
            });
            
            LoadingScreen.instance.MonitorProgress(initFuture, "connecting to service");
        }

        public void OnEndContext() { }
    }
}