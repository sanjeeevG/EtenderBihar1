#pragma checksum "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Services\_BankDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2761a5d2a5b01842d2db9d434eb278134f83236"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Services__BankDetails), @"mvc.1.0.view", @"/Views/Services/_BankDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Services/_BankDetails.cshtml", typeof(AspNetCore.Views_Services__BankDetails))]
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
#line 1 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\_ViewImports.cshtml"
using ETB.WebApp;

#line default
#line hidden
#line 2 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\_ViewImports.cshtml"
using ETB.WebApp.Models;

#line default
#line hidden
#line 1 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Services\_BankDetails.cshtml"
using ETB.WebApp.Utilities;

#line default
#line hidden
#line 2 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Services\_BankDetails.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2761a5d2a5b01842d2db9d434eb278134f83236", @"/Views/Services/_BankDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc282d4421155e26141a0190875bd438aa5d8ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Services__BankDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(110, 314, true);
            WriteLiteral(@"
<div class=""col-md-6"">
    <div class=""h2 mt-2 text-muted"">For Payment (Bank Details)</div>
    <p>Please make the payment for your service to the below mentioned bank through the netbanking.</p>
    <dl class=""row pl-2"">
        <dt class=""col-sm-3 mb-0"">Bank Name: </dt>
        <dd class=""col-sm-9 mb-0"">");
            EndContext();
            BeginContext(425, 26, false);
#line 10 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Services\_BankDetails.cshtml"
                             Write(BankDetails.Value.BankName);

#line default
#line hidden
            EndContext();
            BeginContext(451, 95, true);
            WriteLiteral("</dd>\r\n        <dt class=\"col-sm-3 mb-0\">Bank Branch: </dt>\r\n        <dd class=\"col-sm-9 mb-0\">");
            EndContext();
            BeginContext(547, 28, false);
#line 12 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Services\_BankDetails.cshtml"
                             Write(BankDetails.Value.BankBranch);

#line default
#line hidden
            EndContext();
            BeginContext(575, 94, true);
            WriteLiteral("</dd>\r\n        <dt class=\"col-sm-3 mb-0\">Account No: </dt>\r\n        <dd class=\"col-sm-9 mb-0\">");
            EndContext();
            BeginContext(670, 27, false);
#line 14 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Services\_BankDetails.cshtml"
                             Write(BankDetails.Value.AccountNo);

#line default
#line hidden
            EndContext();
            BeginContext(697, 93, true);
            WriteLiteral("</dd>\r\n        <dt class=\"col-sm-3 mb-0\">IFSC Code: </dt>\r\n        <dd class=\"col-sm-9 mb-0\">");
            EndContext();
            BeginContext(791, 26, false);
#line 16 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Services\_BankDetails.cshtml"
                             Write(BankDetails.Value.IfscCode);

#line default
#line hidden
            EndContext();
            BeginContext(817, 24, true);
            WriteLiteral("</dd>\r\n    </dl>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptions<BankDetails> BankDetails { get; private set; }
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
