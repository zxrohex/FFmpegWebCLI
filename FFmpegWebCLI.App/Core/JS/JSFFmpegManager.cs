using Microsoft.JSInterop;

namespace FFmpegWebCLI.App.Core.JS
{
    public class JSFFmpegManager
    {
        private IJSRuntime jsRuntime;

        private IJSObjectReference jsModule;

        private DotNetObjectReference<JSFFmpegManager> instanceObjRef;



        public JSFFmpegManager(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;

            this.instanceObjRef = DotNetObjectReference.Create(this);

            Initialize();
        }

        private async void Initialize()
        {
            jsModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/app-core.js");

            await jsModule.InvokeVoidAsync("init", instanceObjRef);
        }


        [JSInvokable]
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
