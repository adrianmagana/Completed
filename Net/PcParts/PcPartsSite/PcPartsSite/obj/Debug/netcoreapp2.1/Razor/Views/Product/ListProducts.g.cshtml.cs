#pragma checksum "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b25651751a817fe6a60fec82471fba7b90d41e71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ListProducts), @"mvc.1.0.view", @"/Views/Product/ListProducts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/ListProducts.cshtml", typeof(AspNetCore.Views_Product_ListProducts))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b25651751a817fe6a60fec82471fba7b90d41e71", @"/Views/Product/ListProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da520473fa904726a4bc0fe59546e3d91341e30b", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ListProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PcPartsSite.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
  
    ViewData["Title"] = "Products";
    Layout = "~/Views/Shared/_Admin.cshtml";

#line default
#line hidden
            BeginContext(140, 57, true);
            WriteLiteral("<div class=\"flex marginV-20\">\r\n    <h2 class=\"no-margin\">");
            EndContext();
            BeginContext(198, 13, false);
#line 8 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
                     Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(211, 50, true);
            WriteLiteral("</h2>\r\n    <button class=\"marginL-1\" type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 261, "\"", 312, 3);
            WriteAttributeValue("", 271, "location.href=\'", 271, 15, true);
#line 9 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
WriteAttributeValue("", 286, Url.Action("AddProduct"), 286, 25, false);

#line default
#line hidden
            WriteAttributeValue("", 311, "\'", 311, 1, true);
            EndWriteAttribute();
            BeginContext(313, 56, true);
            WriteLiteral(" style=\"margin-left:1em;\">Add Product</button>\r\n</div>\r\n");
            EndContext();
#line 11 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
  
    PcPartsSite.Models.Product demoProd = new Product();

#line default
#line hidden
            BeginContext(434, 82, true);
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th>");
            EndContext();
            BeginContext(517, 39, false);
#line 18 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
           Write(Html.DisplayNameFor(p => demoProd.Name));

#line default
#line hidden
            EndContext();
            BeginContext(556, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(580, 40, false);
#line 19 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
           Write(Html.DisplayNameFor(p => demoProd.Price));

#line default
#line hidden
            EndContext();
            BeginContext(620, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(644, 43, false);
#line 20 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
           Write(Html.DisplayNameFor(p => demoProd.Discount));

#line default
#line hidden
            EndContext();
            BeginContext(687, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(711, 46, false);
#line 21 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
           Write(Html.DisplayNameFor(p => demoProd.Description));

#line default
#line hidden
            EndContext();
            BeginContext(757, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(781, 63, false);
#line 22 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
           Write(Html.DisplayNameFor(p => demoProd.SubCategory.Category.CatName));

#line default
#line hidden
            EndContext();
            BeginContext(844, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(868, 57, false);
#line 23 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
           Write(Html.DisplayNameFor(p => demoProd.SubCategory.SubCatName));

#line default
#line hidden
            EndContext();
            BeginContext(925, 112, true);
            WriteLiteral("</th>\r\n            <th style=\"text-align:end;\">Edit / Delete</th>\r\n        </tr>\r\n    </thead> \r\n\r\n    <tbody>\r\n");
            EndContext();
#line 29 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
         foreach (PcPartsSite.Models.Product product in Model)
        {

#line default
#line hidden
            BeginContext(1112, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(1151, 34, false);
#line 32 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
               Write(Html.DisplayFor(x => product.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1185, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1213, 35, false);
#line 33 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
               Write(Html.DisplayFor(x => product.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1248, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1276, 38, false);
#line 34 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
               Write(Html.DisplayFor(x => product.Discount));

#line default
#line hidden
            EndContext();
            BeginContext(1314, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1342, 41, false);
#line 35 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
               Write(Html.DisplayFor(x => product.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1383, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1411, 58, false);
#line 36 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
               Write(Html.DisplayFor(x => product.SubCategory.Category.CatName));

#line default
#line hidden
            EndContext();
            BeginContext(1469, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1497, 52, false);
#line 37 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
               Write(Html.DisplayFor(x => product.SubCategory.SubCatName));

#line default
#line hidden
            EndContext();
            BeginContext(1549, 75, true);
            WriteLiteral("</td>\r\n                <td style=\"text-align:end;\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1624, "\"", 1684, 1);
#line 39 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
WriteAttributeValue("", 1631, Url.Action("UpdateProduct", new { id = product.Id }), 1631, 53, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1685, 79, true);
            WriteLiteral("><span class=\"glyphicon glyphicon-pencil\"></span></a> |\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1764, "\"", 1824, 1);
#line 40 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
WriteAttributeValue("", 1771, Url.Action("DeleteProduct", new { id = product.Id }), 1771, 53, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1825, 97, true);
            WriteLiteral("><span class=\"glyphicon glyphicon-remove\"></span></a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 43 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Product\ListProducts.cshtml"
        }

#line default
#line hidden
            BeginContext(1933, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PcPartsSite.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
