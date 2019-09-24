using Microsoft.JSInterop;
using System;

namespace WanderMateWeb.Components.Map.GoogleMaps
{
    public class InitMapCallback
    {
        public Action AfterCallbackAction { get; }

        public InitMapCallback(Action afterCallbackAction)
        {
            AfterCallbackAction = afterCallbackAction;
        }

        [JSInvokable]
        public void OnInitFinished()
        {
            AfterCallbackAction.Invoke();
        }
    }
}
