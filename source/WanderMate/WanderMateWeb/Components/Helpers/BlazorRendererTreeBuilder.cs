using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using Utilities;

namespace WanderMateWeb.Components.Helpers
{
    public class BlazorRendererTreeBuilder
    {
        private readonly RenderTreeBuilder _renderTreeBuilder;
        private int sequence = 0;

        public BlazorRendererTreeBuilder(RenderTreeBuilder renderTreeBuilder)
        {
            renderTreeBuilder.CheckNotNull(nameof(renderTreeBuilder));
            _renderTreeBuilder = renderTreeBuilder;
        }

        public BlazorRendererTreeBuilder AddAttribute(string name, object value)
        {
            _renderTreeBuilder.AddAttribute(++sequence, name, value);

            return this;
        }

        public BlazorRendererTreeBuilder AddAttribute(string name, bool value)
        {
            _renderTreeBuilder.AddAttribute(++sequence, name, value);

            return this;
        }

        public BlazorRendererTreeBuilder AddAttribute(string name, string value)
        {
            _renderTreeBuilder.AddAttribute(++sequence, name, value);

            return this;
        }

        public BlazorRendererTreeBuilder AddAttribute(string name, MulticastDelegate value)
        {
            _renderTreeBuilder.AddAttribute(++sequence, name, value);

            return this;
        }

        public BlazorRendererTreeBuilder AddAttribute(string name, Action<EventArgs> value)
        {
            _renderTreeBuilder.AddAttribute(++sequence, name, value);

            return this;
        }

        public BlazorRendererTreeBuilder AddAttribute(string name, Func<MulticastDelegate> value)
        {
            _renderTreeBuilder.AddAttribute(++sequence, name, value);

            return this;
        }

        public BlazorRendererTreeBuilder AddContent(string textContent)
        {
            _renderTreeBuilder.AddContent(++sequence, textContent);

            return this;
        }

        public BlazorRendererTreeBuilder AddContent(RenderFragment fragment)
        {
            _renderTreeBuilder.AddContent(++sequence, fragment);

            return this;
        }

        public BlazorRendererTreeBuilder AddContent(MarkupString markupContent)
        {
            _renderTreeBuilder.AddContent(++sequence, markupContent);

            return this;
        }

        public BlazorRendererTreeBuilder CloseComponent()
        {
            _renderTreeBuilder.CloseComponent();

            return this;
        }

        public BlazorRendererTreeBuilder CloseElement()
        {
            _renderTreeBuilder.CloseElement();

            return this;
        }

        public BlazorRendererTreeBuilder OpenComponent(Type componentType)
        {
            _renderTreeBuilder.OpenComponent(++sequence, componentType);

            return this;
        }

        public BlazorRendererTreeBuilder OpenElement(string elementName)
        {
            _renderTreeBuilder.OpenElement(++sequence, elementName);

            return this;
        }
    }
}
