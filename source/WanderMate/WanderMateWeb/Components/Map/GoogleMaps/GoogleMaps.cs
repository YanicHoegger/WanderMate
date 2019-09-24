using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using WanderMateWeb.Components.Helpers;

namespace WanderMateWeb.Components.Map.GoogleMaps
{
    public class GoogleMaps : IMap
    {
        private readonly IJSRuntime _jSRuntime;

        public GoogleMaps(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public void Initialize(RenderTreeBuilder renderTreeBuilder)
        {
            var internalBuilder = new BlazorRendererTreeBuilder(renderTreeBuilder);

            internalBuilder
            .OpenElement("script")
            .AddAttribute("src", "GoogleMapInterop.js")
            .CloseElement()
            .OpenElement("div")
            .AddAttribute("id", "map")
            .AddAttribute("class", "map")
            .CloseElement()
            .OpenElement("script")
            .AddAttribute("async", "")
            .AddAttribute("defer", "")
            .AddAttribute("src", "https://maps.googleapis.com/maps/api/js?key=AIzaSyBvE0ow61-HN4JTLT1I1XJO-7UZo7Y-KMg&callback=blazorGoogleMap.initMapCallback")
            .CloseElement();
        }

        public async Task OnAfterRenderAsync(bool firstRender)
        {
            await _jSRuntime.InvokeAsync<object>("blazorGoogleMap.registerEventInvokers", DotNetObjectReference.Create(new InitMapCallback(MapInitialized)));
            await _jSRuntime.InvokeAsync<object>("blazorGoogleMap.initMap", new InitialMapOptions());

            await _jSRuntime.InvokeAsync<bool>("blazorGoogleMap.initMapCallback");
        }

        private void MapInitialized()
        {

        }
    }
}
