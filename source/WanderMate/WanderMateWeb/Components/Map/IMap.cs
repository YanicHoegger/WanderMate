using Microsoft.AspNetCore.Components.Rendering;
using System.Threading.Tasks;

namespace WanderMateWeb.Components.Map
{
    interface IMap
    {
        void Initialize(RenderTreeBuilder renderTreeBuilder);
        Task OnAfterRenderAsync(bool firstRender);
    }
}
