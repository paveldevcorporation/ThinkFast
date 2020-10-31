﻿using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Resources
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "ThinkFast.Resources.AppResources";

        public TranslateExtension()
        {
            ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId,
                typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
                translation = Text;
            }
            return translation;
        }
    }
}