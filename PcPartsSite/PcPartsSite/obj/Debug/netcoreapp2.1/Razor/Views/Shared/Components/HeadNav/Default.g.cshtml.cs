#pragma checksum "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17d80ef37b8dcdf96738197f7d20331c1a8ee588"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HeadNav_Default), @"mvc.1.0.view", @"/Views/Shared/Components/HeadNav/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/HeadNav/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_HeadNav_Default))]
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
#line 1 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\_ViewImports.cshtml"
using PcPartsSite;

#line default
#line hidden
#line 2 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\_ViewImports.cshtml"
using PcPartsSite.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17d80ef37b8dcdf96738197f7d20331c1a8ee588", @"/Views/Shared/Components/HeadNav/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da520473fa904726a4bc0fe59546e3d91341e30b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_HeadNav_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PcPartsSite.Models.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 41, true);
            WriteLiteral("\r\n<ul class=\"nav navbar-nav\">\r\n    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 90, "\"", 129, 1);
#line 4 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
WriteAttributeValue("", 97, Url.Action("Categories","Home"), 97, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(130, 27, true);
            WriteLiteral(">View Categories</a></li>\r\n");
            EndContext();
#line 5 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
     foreach (Category cat in Model)
    {

#line default
#line hidden
            BeginContext(202, 87, true);
            WriteLiteral("    <li class=\"dropdown\">\r\n        <a data-target=\"nav-collapse\" data-toggle=\"collapse\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 289, "\"", 370, 1);
#line 8 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
WriteAttributeValue("", 296, Url.Action("ListProducts","Home", new {value = cat.Id, filter =  "Cat" }), 296, 74, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(371, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(373, 11, false);
#line 8 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
                                                                                                                                          Write(cat.CatName);

#line default
#line hidden
            EndContext();
            BeginContext(384, 60, true);
            WriteLiteral("</a>\r\n        <ul class=\"dropdown-menu collapse nav-dark\">\r\n");
            EndContext();
#line 10 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
             foreach (SubCategory sc in cat.SubCategories)
            {

#line default
#line hidden
            BeginContext(519, 22, true);
            WriteLiteral("                <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 541, "\"", 625, 1);
#line 12 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
WriteAttributeValue("", 548, Url.Action("ListProducts","Home", new { value = sc.Id, filter =  "SubCat" }), 548, 77, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(626, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(628, 13, false);
#line 12 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
                                                                                                       Write(sc.SubCatName);

#line default
#line hidden
            EndContext();
            BeginContext(641, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 13 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(667, 26, true);
            WriteLiteral("        </ul>\r\n    </li>\r\n");
            EndContext();
#line 16 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\HeadNav\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(700, 5, true);
            WriteLiteral("</ul>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PcPartsSite.Models.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
