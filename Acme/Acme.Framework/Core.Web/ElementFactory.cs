﻿namespace Acme.UI
{
    public static class ElementFactory
    {
        public static TElement Create<TElement>(Search search) where TElement : Element, new()
        {
            var element = new TElement
            {
                SearchWrapper = search
            };
            return element;
        }
    }
}
