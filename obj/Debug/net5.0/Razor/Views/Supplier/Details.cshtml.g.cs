#pragma checksum "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b9d79a6a3d698248422d5c867b463526c60d0f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supplier_Details), @"mvc.1.0.view", @"/Views/Supplier/Details.cshtml")]
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
#line 1 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\_ViewImports.cshtml"
using CloudCart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\_ViewImports.cshtml"
using CloudCart.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b9d79a6a3d698248422d5c867b463526c60d0f0", @"/Views/Supplier/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24ca819e875dda6b2e55247896ff0b35abcbde50", @"/Views/_ViewImports.cshtml")]
    public class Views_Supplier_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CloudCart.Models.Supplier>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
  
    Layout = "_mainLayout";
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Supplier Details</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierIndustry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierIndustry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierJoinDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierJoinDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierRating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierRating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierCity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierCity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierProvince));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierProvince));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierCountry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierCountry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 81 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierPinCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 84 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierPinCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 87 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierDataLastUpdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierDataLastUpdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 95 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Supplier\Details.cshtml"
Write(Html.ActionLink("Edit", "Update", new { id = @Model.SupplierId }, new {@class="btn btn-info" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b9d79a6a3d698248422d5c867b463526c60d0f013209", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CloudCart.Models.Supplier> Html { get; private set; }
    }
}
#pragma warning restore 1591