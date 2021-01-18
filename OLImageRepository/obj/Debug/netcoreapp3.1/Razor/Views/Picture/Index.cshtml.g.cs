#pragma checksum "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0991fc91f1a36277000b1eb7b63f1e4c4e2b3588"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Picture_Index), @"mvc.1.0.view", @"/Views/Picture/Index.cshtml")]
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
#line 1 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\_ViewImports.cshtml"
using OLImageRepository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\_ViewImports.cshtml"
using OLImageRepository.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
using ImageRepositoryClassLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0991fc91f1a36277000b1eb7b63f1e4c4e2b3588", @"/Views/Picture/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbf53216a2c719471e06bab5a35a46159cd4c4b7", @"/Views/_ViewImports.cshtml")]
    public class Views_Picture_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OLImageRepository.Models.Picture>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
  
    bool isPrivateMode = Convert.ToBoolean(Context.Session.GetString("isPrivateMode"));
    bool isAlbumSpecified = false;
    string albumId = Context.Session.GetString("albumId");

    if (!String.IsNullOrEmpty(albumId))
        isAlbumSpecified = true;

    if (isPrivateMode)
    {
        if (!isAlbumSpecified) ViewData["Title"] = "My Images (your images only)";
        else ViewData["Title"] = $"Images in '{Context.Session.GetString("albumName")}' Album";
    }

    else ViewData["Title"] = "Browse Images (all with public access)";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"width:100%;\">\r\n    <h1 style=\"float:left;\">");
#nullable restore
#line 23 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0991fc91f1a36277000b1eb7b63f1e4c4e2b35886795", async() => {
                WriteLiteral("\r\n        <input name=\"query\" />\r\n        <input type=\"submit\" value=\"Search\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
#nullable restore
#line 30 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
 if (isPrivateMode)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0991fc91f1a36277000b1eb7b63f1e4c4e2b35888662", async() => {
                WriteLiteral("Add Image");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 35 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 41 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 44 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.StoredPicture));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 47 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
#nullable restore
#line 49 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
             if (isPrivateMode)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>\r\n                    ");
#nullable restore
#line 52 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.IsPublic));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n");
#nullable restore
#line 54 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 59 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 1854, "\"", 1926, 2);
            WriteAttributeValue("", 1860, "data:image/jpeg;base64,", 1860, 23, true);
#nullable restore
#line 66 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
WriteAttributeValue("", 1883, Convert.ToBase64String(item.StoredPicture), 1883, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 69 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 71 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                 if (isPrivateMode)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 74 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IsPublic));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 76 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n");
#nullable restore
#line 78 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                     if (isPrivateMode)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0991fc91f1a36277000b1eb7b63f1e4c4e2b358814664", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                                               WriteLiteral(item.PictureId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0991fc91f1a36277000b1eb7b63f1e4c4e2b358816861", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 81 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                                                 WriteLiteral(item.PictureId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 82 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0991fc91f1a36277000b1eb7b63f1e4c4e2b358819283", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
                                              WriteLiteral(item.PictureId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 86 "C:\Users\Oleksandr\Desktop\OLImageRepository\OLImageRepository\Views\Picture\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OLImageRepository.Models.Picture>> Html { get; private set; }
    }
}
#pragma warning restore 1591
