#pragma checksum "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca355d912b4bee0a584e4c506b8281bb3414d854"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\_ViewImports.cshtml"
using FysioAvansWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\_ViewImports.cshtml"
using FysioAvansWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\_ViewImports.cshtml"
using FysioAvansWebApp.Domain;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca355d912b4bee0a584e4c506b8281bb3414d854", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"991bab02ad5e5e0fb311a8f224605b10b46aadce", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Fysio Avans</h1>
    <p>Welkom bij de website van Fysio Avans!</p>
    <p>Als je een afspraak wilt maken moet je eerst inloggen via login rechtsbovenin het scherm.</p>
    <p>Via onderstaande knop vind het de contactgegevens:</p>
    <div class=""row"">
        <div class=""col-lg-12 text-center"">
            ");
#nullable restore
#line 12 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Home\Index.cshtml"
       Write(Html.ActionLink("Contactgegevens", "Details", "Home", null, new { @class = "btn btn-success color-green text-dark" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
