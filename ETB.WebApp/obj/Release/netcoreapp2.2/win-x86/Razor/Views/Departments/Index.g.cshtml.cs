#pragma checksum "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b9f76bc1e51a028e7e1b8edb7811f0858c3d79c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departments_Index), @"mvc.1.0.view", @"/Views/Departments/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Departments/Index.cshtml", typeof(AspNetCore.Views_Departments_Index))]
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
#line 1 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml"
using ETB.WebApp.Utilities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b9f76bc1e51a028e7e1b8edb7811f0858c3d79c", @"/Views/Departments/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc282d4421155e26141a0190875bd438aa5d8ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Departments_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ETB.WebApp.Models.DeptViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tenders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control d-inline btn-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("selNoOfRows"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline form-control dropdown"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml"
  
    Layout = "~/Views/Shared/_LayoutWithLogin.cshtml";

#line default
#line hidden
            BeginContext(132, 66, true);
            WriteLiteral("\r\n<div class=\"form-row\">\r\n    <div class=\"col-lg-7\">\r\n        <h2>");
            EndContext();
            BeginContext(199, 23, false);
#line 9 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml"
       Write(Subtitle.DepartmentList);

#line default
#line hidden
            EndContext();
            BeginContext(222, 55, true);
            WriteLiteral("</h2>\r\n    </div>\r\n    <div class=\"col-lg-5\">\r\n        ");
            EndContext();
            BeginContext(277, 115, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b9f76bc1e51a028e7e1b8edb7811f0858c3d79c5891", async() => {
                BeginContext(364, 24, true);
                WriteLiteral("Back to Tender Dashboard");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(392, 1343, true);
            WriteLiteral(@"
    </div>
</div>
<hr />
<div class=""form-row"">
    <div class=""col-lg-7"">
        <div class=""form-group row pl-3 pr-2"">
            <button class=""btn btn-dark"" id=""btnDelete""><i class=""fa fa-times""></i><span class=""d-none d-sm-inline-block ml-2"">Delete Selected Departments</span></button>
            <button id=""btnCreate"" class=""btn btn-primary d-inline ml-2""><i class=""fa fa-plus""></i><span class=""d-none d-sm-inline-block ml-2"" data-toggle=""modal"" data-target=""#deptModalCenter"">Add New Departments</span></button>
        </div>
    </div>
    <div class=""col-lg-7"">
        <input type=""hidden"" id=""selDeptId"" />
        <div class=""form-inline justify-content-start mr-2 mb-2"" style=""margin-left:0px;"">
            <div class=""d-inline pl-2 pb-2"">
                <label class=""d-inline control-label""><span class=""d-inline-block d-sm-none mr-1"">Total Recs:</span><span class=""d-none d-sm-inline-block mr-1"">Total Records:</span></label>
                <label class=""d-inline control-label"" id=""");
            WriteLiteral(@"lblTotalRecs""></label>
                <label class=""d-inline control-label""> | </label>
            </div>
            <div class=""d-inline form-group row pl-3 pr-2"">
                <label class=""d-inline control-label""><span class=""d-none d-sm-inline-block mr-1"">Rows to Display:</span></label>
                ");
            EndContext();
            BeginContext(1735, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b9f76bc1e51a028e7e1b8edb7811f0858c3d79c9001", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#line 33 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.NoOfRows;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1835, 87, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div id=\"jsGrid\"></div>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(1923, 142, false);
#line 38 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml"
Write(await Html.PartialAsync("_ModelDept", new DeptViewModel { States = Model.States, SelState = Model.SelState, Department1 = Model.Department1 }));

#line default
#line hidden
            EndContext();
            BeginContext(2065, 283, true);
            WriteLiteral(@"
</div>

<script type=""text/javascript"">
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }
    $(document).ready(function () {
        var selectedRow;
        function gettoken() {
            var token = '");
            EndContext();
            BeginContext(2349, 23, false);
#line 48 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml"
                    Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(2372, 762, true);
            WriteLiteral(@"';
            token = $(token).val();
            return token;
        }
        LoadList();
        function LoadList() {
             $(""#jsGrid"").jsGrid({
                height: ""500px"",
                width:""100%"",
                loadIndication: true,
                loadIndicationDelay: 5,
                loadShading: true,
                loadMessage: ""Please wait, Loading..."",
                selecting: true,
                paging: true,
                pageSize: 15,
                rowClass: ""rowCss"",
                autoload: true,
                controller: {
                    loadData: function () {
                        var d = $.Deferred();
                        $.ajax({
                            url: '");
            EndContext();
            BeginContext(3135, 43, false);
#line 70 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml"
                             Write(Url.Action("GetDepartments", "Departments"));

#line default
#line hidden
            EndContext();
            BeginContext(3178, 1947, true);
            WriteLiteral(@"',
                            dataType: ""json"",
                            contentType: ""application/json; charset=utf-8"",
                        }).done(function (result) {
                            $('#lblTotalRecs').text(result.tcount);
                            d.resolve(result.datas);
                        });
                        return d.promise();
                    }
                },
                 fields: [{ name: ""id"", title: ""Id"", width: 30, visible: true },
                     { name: ""deptartment"", title: ""Dept."", visible: true, width: 230 },
                    { name: ""deptBelongsTo"", title: ""State"", visible: true, width: 70 },
                 ],
                  rowClick: function (args) {
                    var id = args.item.id;
                      $('#selDeptId').val(id);
                    rowHighlight(args.item)
                }
            });
        }

        function rowHighlight(item) {
            if (selectedRow) { selectedRow.child");
            WriteLiteral(@"ren('.jsgrid-cell').css('background-color', ''); }
            var $row = $(""#jsGrid"").jsGrid(""rowByItem"", item);
            $row.children('.jsgrid-cell').css('background-color', '#F7B64B');
            selectedRow = $row;
        }

        $('#selNoOfRows').on('change', function (event) {
            $(""#jsGrid"").jsGrid(""option"", ""pageSize"", $(this).val());
        });


        $('#btnCreate').click(function () {
            clear();
        });

        $('#btnDelete').click(function () {
            if ($('#selDeptId').val() == """") {
                alert(""Please select a Department from department grid."");
                return false;
            }
            if (confirm(`Are you sure you want to Delete Department Id [${$('#selDeptId').val()}]?`) == true) {
                if (confirm(""Are you sure again?"") == true) {

                    $.ajax({
                        url: '");
            EndContext();
            BeginContext(5126, 45, false);
#line 117 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Departments\Index.cshtml"
                         Write(Url.Action("DeleteDepartment", "Departments"));

#line default
#line hidden
            EndContext();
            BeginContext(5171, 505, true);
            WriteLiteral(@"',
                        credentials: 'include',
                        dataType: ""json"",
                        type: 'POST',
                        data: { __RequestVerificationToken: gettoken(), id: $('#selDeptId').val() },
                        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                    }).done(function (result) {
                        LoadList();
                    });
                }
            }
        });
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ETB.WebApp.Models.DeptViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591