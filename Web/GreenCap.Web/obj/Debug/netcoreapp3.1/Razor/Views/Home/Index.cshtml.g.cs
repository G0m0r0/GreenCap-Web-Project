#pragma checksum "D:\Programming\SoftUni-Web-Project\Web\GreenCap.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84cb3d310900ae54315595edbedfa3c85dd1b0be"
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
#line 1 "D:\Programming\SoftUni-Web-Project\Web\GreenCap.Web\Views\_ViewImports.cshtml"
using GreenCap.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programming\SoftUni-Web-Project\Web\GreenCap.Web\Views\_ViewImports.cshtml"
using GreenCap.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Programming\SoftUni-Web-Project\Web\GreenCap.Web\Views\Home\Index.cshtml"
using GreenCap.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84cb3d310900ae54315595edbedfa3c85dd1b0be", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a348ebed1ce3b91827f1c76578237a82b58c6019", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Programming\SoftUni-Web-Project\Web\GreenCap.Web\Views\Home\Index.cshtml"
  
    this.ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"jumbotron\">\r\n    <h1 class=\"display-3\">Welcome to ");
#nullable restore
#line 7 "D:\Programming\SoftUni-Web-Project\Web\GreenCap.Web\Views\Home\Index.cshtml"
                                Write(GlobalConstants.SystemName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"!</h1>
    <p class=""text-muted"">Keep it green! </p>
    <hr class=""my-4"">
    <p class=""text-muted"">Prepare yourself to join our family and to become even more environmental friendly than before. You can share your creative ideas or to discuss a problem in the forum. It's up to you!</p>
    <p class=""lead"">
        <a class=""btn btn-info btn-lg"" href=""#"" role=""button"">Learn more</a>
    </p>
</div>");
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
