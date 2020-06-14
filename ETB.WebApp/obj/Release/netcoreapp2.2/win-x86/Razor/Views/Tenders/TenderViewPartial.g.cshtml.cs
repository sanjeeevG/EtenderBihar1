#pragma checksum "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Tenders\TenderViewPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61aa4d4e3773234725f7050a6ea7ea6112e6a794"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tenders_TenderViewPartial), @"mvc.1.0.view", @"/Views/Tenders/TenderViewPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tenders/TenderViewPartial.cshtml", typeof(AspNetCore.Views_Tenders_TenderViewPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61aa4d4e3773234725f7050a6ea7ea6112e6a794", @"/Views/Tenders/TenderViewPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc282d4421155e26141a0190875bd438aa5d8ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Tenders_TenderViewPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 34, true);
            WriteLiteral("<div style=\"\" id=\"jsGrid\"></div>\r\n");
            EndContext();
            BeginContext(120, 2031, true);
            WriteLiteral(@"
<style>
    .show-eclipse {
        white-space: nowrap;
        overflow: hidden;
        width: 200px;
        text-overflow: ellipsis;
    }
</style>

<script type=""text/javascript"">

    $(document).ready(function () {
        $(""#jsGrid"").jsGrid(""option"", ""noDataContent"", """");
        function addCommas(nStr) {
            nStr += '';
            x = nStr.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            }
            return x1 + x2;
        }

        LoadPartialTender();
        //LoadPartialTender2();
        function LoadPartialTender2() {
            var columnDefs = [
                { headerName: ""District"", field: ""district"" },
                { headerName: ""Estimated Cost"", field: ""estimatedCost"" },
                { headerName: ""EMD"", field: ""emd"" },
                { headerName: ""BOQ"", f");
            WriteLiteral(@"ield: ""costOfBOQ"" },
                { headerName: ""Closing Date"", field: ""bidSubmissionEnDate"" },
                { headerName: ""Title"", field: ""tenderTitle"" }
            ];

            //var autoGroupColumnDef = {
            //    headerName: ""Model"",
            //    field: ""model"",
            //    cellRenderer: 'agGroupCellRenderer',
            //    cellRendererParams: {
            //        checkbox: true
            //    }
            //}

            // let the grid know which columns and what data to use
            var gridOptions = {
                columnDefs: columnDefs,
                rowSelection: 'single'
            };

            // lookup the container we want the Grid to use
            var eGridDiv = document.querySelector('#myGrid');

            // create the grid passing in the div to use together with the columns & data we want to use
            new agGrid.Grid(eGridDiv, gridOptions);

            agGrid.simpleHttpRequest({ url: '");
            EndContext();
            BeginContext(2152, 45, false);
#line 62 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Tenders\TenderViewPartial.cshtml"
                                        Write(Url.Action("GetTenderPartialData", "Tenders"));

#line default
#line hidden
            EndContext();
            BeginContext(2197, 1892, true);
            WriteLiteral(@"' }).then(function (data) {
                console.log('data', data.datas);
                gridOptions.api.setRowData(data.datas);
            });


        }


        function LoadPartialTender() {
            var dateField = function (config) {
                jsGrid.Field.call(this, config);
            };

            var numField = function (config) {
                jsGrid.Field.call(this, config);
            };

            dateField.prototype = new jsGrid.Field({
                sorter: function (date1, date2) {
                    return new Date(date1) - new Date(date2);
                },

                itemTemplate: function (value) {
                    return moment(value).format(""DD-MMM-YYYY hh:mm"");
                }
            });



            numField.prototype = new jsGrid.Field({
                itemTemplate: function (value) {
                    var val1 = value.toFixed(2);
                    return addCommas(val1);
                }
         ");
            WriteLiteral(@"   });

            jsGrid.fields.ClosingDate = dateField;
            jsGrid.fields.ECFormat = numField;
            jsGrid.fields.emdFormat = numField;
            jsGrid.fields.BOQFormat = numField;

            $(""#jsGrid"").jsGrid({
                height: ""200px"",
                width:""100%"",
                loadIndication: true,
                loadIndicationDelay: 5,
                loadShading: true,
                loadMessage: ""Please wait, Loading..."",
                noDataContent: """",
                selecting: true,
                paging: false,
                rowCSS: """",
                pageSize: 4,
                autoload: true,
                controller: {
                    loadData: function () {
                        var d = $.Deferred();
                        $.ajax({
                            url: '");
            EndContext();
            BeginContext(4090, 45, false);
#line 121 "E:\Sanjeev\EtenderBihar\Source\EtenderBihar\ETB.WebApp\Views\Tenders\TenderViewPartial.cshtml"
                             Write(Url.Action("GetTenderPartialData", "Tenders"));

#line default
#line hidden
            EndContext();
            BeginContext(4135, 2620, true);
            WriteLiteral(@"',
                            dataType: ""json"",
                            contentType: ""application/json; charset=utf-8"",
                        }).done(function (result) {
                            d.resolve(result.datas);
                        });
                        return d.promise();
                    }
                },
                fields: [{ name: ""Id"", title: ""Id"", visible: false, width: 40},
                    { name: ""district"", title: ""District"", visible: true, width: 100 },
                    { name: ""department"", css: ""show-eclipse"", title: ""Dept."", visible: true, width: 150 },
                    {
                        name: ""estimatedCost"",
                        align: ""right"",
                        type: ""ECFormat"",
                        visible: true,
                        width: 90,
                        headerTemplate: function (index, value) {
                            var span1 = $(""<span>"").text(""Esti. Cost"").attr(""class"", ""font-weig");
            WriteLiteral(@"ht-bold"");
                            var span2 = $(""<span>"").text(""(in Lakh)"").attr(""class"", ""font-weight-bold small"");
                            return $(""<div>"").append(span1).append(""</br>"").append(span2);
                        }
                    },
                    {
                        name: ""emd"", type: ""emdFormat"",
                        align: ""right"",
                        visible: true,
                        width: 90,
                        headerTemplate: function (index, value) {
                            var span1 = $(""<span>"").text(""EMD"").attr(""class"", ""font-weight-bold"");
                            var span2 = $(""<span>"").text(""(in Lakh)"").attr(""class"", ""font-weight-bold small"");
                            return $(""<div>"").append(span1).append(""</br>"").append(span2);
                        }
                    },
                    { name: ""costOfBOQ"", type: ""BOQFormat"", align: ""right"", title: ""BOQ"", visible: true, width: 100},
                   ");
            WriteLiteral(@" { name: ""bidSubmissionEnDate"", type: ""ClosingDate"", title: ""Closing Date"", visible: true,width: 125},
                    { name: ""tenderTitle"", css:""show-eclipse"", title: ""Title"", visible: true, width:150 },
                ]
            });
            $("".jsgrid-grid-header"").removeClass(""jsgrid-header-scrollbar"");
        }
    });
</script>
<style>
    .jsgrid-cell {
        padding: 0px;
        padding-left:.5em;
    }
    .jsgrid-grid-body{
        overflow-y:auto;
    }
    .jsgrid-grid-header {
        overflow-y: auto;
    }
</style>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
