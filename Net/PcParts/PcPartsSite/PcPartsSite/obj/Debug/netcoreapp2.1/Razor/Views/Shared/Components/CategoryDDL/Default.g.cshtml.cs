#pragma checksum "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\CategoryDDL\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba39152d6c24da0f92517262881261ab9895c663"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CategoryDDL_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CategoryDDL/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CategoryDDL/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_CategoryDDL_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba39152d6c24da0f92517262881261ab9895c663", @"/Views/Shared/Components/CategoryDDL/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da520473fa904726a4bc0fe59546e3d91341e30b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CategoryDDL_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PcPartsSite.Models.Category>>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\CategoryDDL\Default.cshtml"
 foreach (Category cat in Model)
{
    if (ViewBag.id == cat.Id)
    {

#line default
#line hidden
            BeginContext(126, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(134, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "421a8c7d7f1e4b6dacddf1163c7613b1", async() => {
                BeginContext(165, 11, false);
#line 7 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\CategoryDDL\Default.cshtml"
                                 Write(cat.CatName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 7 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\CategoryDDL\Default.cshtml"
           WriteLiteral(cat);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(185, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\CategoryDDL\Default.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(211, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(219, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c442d3095f84107884d8b45b81c3188", async() => {
                BeginContext(241, 11, false);
#line 11 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\CategoryDDL\Default.cshtml"
                        Write(cat.CatName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 11 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\CategoryDDL\Default.cshtml"
           WriteLiteral(cat);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(261, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "C:\Users\Adrian\Desktop\InProgress\PcPartsSite\PcPartsSite\Views\Shared\Components\CategoryDDL\Default.cshtml"
    }

}

#line default
#line hidden
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
