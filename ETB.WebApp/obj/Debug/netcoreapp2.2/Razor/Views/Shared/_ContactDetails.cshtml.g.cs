#pragma checksum "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Shared\_ContactDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c74178901593e085dac31671578ee218303ee8b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ContactDetails), @"mvc.1.0.view", @"/Views/Shared/_ContactDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ContactDetails.cshtml", typeof(AspNetCore.Views_Shared__ContactDetails))]
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
#line 1 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Shared\_ContactDetails.cshtml"
using ETB.WebApp.Utilities;

#line default
#line hidden
#line 2 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Shared\_ContactDetails.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c74178901593e085dac31671578ee218303ee8b9", @"/Views/Shared/_ContactDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc282d4421155e26141a0190875bd438aa5d8ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ContactDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(116, 94, true);
            WriteLiteral("<div class=\"h2 mt-2 text-muted\">Support</div>\r\n<div>\r\n    <p><stronger>Contact No: </stronger>");
            EndContext();
            BeginContext(211, 28, false);
#line 6 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Shared\_ContactDetails.cshtml"
                                   Write(ContactDetails.Value.PhoneNo);

#line default
#line hidden
            EndContext();
            BeginContext(239, 49, true);
            WriteLiteral("</p>\r\n    <p><stronger>Email Adrress: </stronger>");
            EndContext();
            BeginContext(289, 33, false);
#line 7 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Shared\_ContactDetails.cshtml"
                                      Write(ContactDetails.Value.EmailAddress);

#line default
#line hidden
            EndContext();
            BeginContext(322, 12, true);
            WriteLiteral("</p>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptions<ContactDetails> ContactDetails { get; private set; }
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
