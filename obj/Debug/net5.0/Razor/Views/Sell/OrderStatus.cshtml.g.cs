#pragma checksum "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Sell\OrderStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9dcacb62b53c4a2f3e5e81bdeb07ff54f364bb50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sell_OrderStatus), @"mvc.1.0.view", @"/Views/Sell/OrderStatus.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dcacb62b53c4a2f3e5e81bdeb07ff54f364bb50", @"/Views/Sell/OrderStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24ca819e875dda6b2e55247896ff0b35abcbde50", @"/Views/_ViewImports.cshtml")]
    public class Views_Sell_OrderStatus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Sell\OrderStatus.cshtml"
  
    Layout = "_mainLayout";
    ViewData["Title"] = "Order Status";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h2>Order Status:</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Sell\OrderStatus.cshtml"
 if (ViewBag.sellOrderId > 0)
{



#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Confirmed</p>\r\n");
#nullable restore
#line 14 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Sell\OrderStatus.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Failed to put Order</p>\r\n");
#nullable restore
#line 18 "C:\Users\ssaishanmukkha\source\repos\CloudCart\CloudCart\Views\Sell\OrderStatus.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
