#pragma checksum "C:\C#\E-Cars\E-cars\Views\Catalogue\Brand.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8e879ef966f1523302007a3329bf9e45940d6ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalogue_Brand), @"mvc.1.0.view", @"/Views/Catalogue/Brand.cshtml")]
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
#line 1 "C:\C#\E-Cars\E-cars\Views\_ViewImports.cshtml"
using E_cars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\C#\E-Cars\E-cars\Views\_ViewImports.cshtml"
using E_cars.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8e879ef966f1523302007a3329bf9e45940d6ac", @"/Views/Catalogue/Brand.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1705ae2f6e61ee2cc8452e071a7010a3dd63208c", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalogue_Brand : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\C#\E-Cars\E-cars\Views\Catalogue\Brand.cshtml"
  
    ViewData["Title"] = $"Каталог - {@ViewBag.selectedBrand}";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Selected brand is: ");
#nullable restore
#line 5 "C:\C#\E-Cars\E-cars\Views\Catalogue\Brand.cshtml"
                  Write(ViewBag.selectedBrand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
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