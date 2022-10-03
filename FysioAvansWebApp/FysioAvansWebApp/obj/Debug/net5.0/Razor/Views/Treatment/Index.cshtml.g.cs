#pragma checksum "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39da1a27188b224d5846ec940e66e284705fbe37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Treatment_Index), @"mvc.1.0.view", @"/Views/Treatment/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39da1a27188b224d5846ec940e66e284705fbe37", @"/Views/Treatment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"991bab02ad5e5e0fb311a8f224605b10b46aadce", @"/Views/_ViewImports.cshtml")]
    public class Views_Treatment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TreatmentDetailsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        ");
#nullable restore
#line 8 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
   Write(Html.ActionLink("Voeg afspraak toe", "Create", "Treatment", null, new { @class = "btn btn-success color-green text-dark" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
</div>
<div class=""row"">
    <div class=""col-lg-12"">
        <table class=""table table-striped table-bordered"">
            <thead>
                <tr>
                    <td>Id</td>
                    <td>TypeId</td>
                    <td>Patient</td>
                    <td>Behandelaar</td>
                    <td>Behandeldatum</td>
                    <td></td>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 25 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                 if (Model.Count() > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                     foreach (var treatment in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 30 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                   Write(treatment.TreatmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                   Write(treatment.TypeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                   Write(treatment.PatientFullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                   Write(treatment.CaretakerFullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                   Write(treatment.TreatmentDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"text-center\">");
#nullable restore
#line 35 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                                       Write(Html.ActionLink("Edit", "Edit", "Treatment", new { Id = treatment.TreatmentId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 35 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                                                                                                                           Write(Html.ActionLink("Delete", "Delete", "Treatment", new { Id = treatment.TreatmentId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 37 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td colspan=\"5\" class=\"text-center\">\r\n                    No records found\r\n                </td>\r\n");
#nullable restore
#line 44 "D:\School\MVC\FysioAvansWebApp\FysioAvansWebApp\Views\Treatment\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TreatmentDetailsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591