#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5f42957de89f095fff7ca6a7c2a5d2ae4ca0d19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Metadata_GetDetailsByName), @"mvc.1.0.view", @"/Views/Metadata/GetDetailsByName.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Metadata/GetDetailsByName.cshtml", typeof(AspNetCore.Views_Metadata_GetDetailsByName))]
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
#line 1 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\_ViewImports.cshtml"
using DinamicDataMvc;

#line default
#line hidden
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\_ViewImports.cshtml"
using DinamicDataMvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5f42957de89f095fff7ca6a7c2a5d2ae4ca0d19", @"/Views/Metadata/GetDetailsByName.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_Metadata_GetDetailsByName : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.ViewMetadataModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/PageStyleFile.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
  
    ViewData["Title"] = "Details By Process Name";
    var pageNumber = ViewBag.NumberOfPages;

#line default
#line hidden
            BeginContext(165, 593, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5f42957de89f095fff7ca6a7c2a5d2ae4ca0d194786", async() => {
                BeginContext(171, 480, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
    ");
                EndContext();
                BeginContext(651, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5f42957de89f095fff7ca6a7c2a5d2ae4ca0d195664", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(687, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(693, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c5f42957de89f095fff7ca6a7c2a5d2ae4ca0d196917", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(749, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(758, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(760, 2760, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5f42957de89f095fff7ca6a7c2a5d2ae4ca0d199046", async() => {
                BeginContext(766, 104, true);
                WriteLiteral("\r\n    <hr />\r\n    <div class=\"container\" id=\"subtitleDiv\">\r\n        <h2 id=\"ProcessDescription\">Process ");
                EndContext();
                BeginContext(871, 17, false);
#line 18 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                                       Write(Html.ViewBag.Name);

#line default
#line hidden
                EndContext();
                BeginContext(888, 108, true);
                WriteLiteral(" Versions</h2>\r\n    </div>\r\n    <hr />\r\n    <div class=\"container\" id=\"linkDiv\">\r\n        <a id=\"updateLink\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 996, "\"", 1050, 2);
                WriteAttributeValue("", 1003, "/Metadata/Update?ProcessName=", 1003, 29, true);
#line 22 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
WriteAttributeValue("", 1032, Html.ViewBag.Name, 1032, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1051, 371, true);
                WriteLiteral(@"><i class=""fa fa-database""></i> Update Process </a>
    </div>
    <hr />
    <div class=""container"">
        <div class=""table-responsive table-striped"">
            <table class=""table table-bordered"" border=""1"" id=""processResultTable"">
                <thead>
                    <tr id=""tableHeader"">
                        <th>
                            ");
                EndContext();
                BeginContext(1423, 43, false);
#line 31 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                       Write(Html.DisplayNameFor(model => model.Version));

#line default
#line hidden
                EndContext();
                BeginContext(1466, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1558, 40, false);
#line 34 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
                EndContext();
                BeginContext(1598, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1690, 42, false);
#line 37 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                       Write(Html.DisplayNameFor(model => model.Branch));

#line default
#line hidden
                EndContext();
                BeginContext(1732, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1824, 41, false);
#line 40 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                       Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
                EndContext();
                BeginContext(1865, 111, true);
                WriteLiteral("\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
                EndContext();
#line 45 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
                BeginContext(2049, 111, true);
                WriteLiteral("                        <tr id=\"tableBody\">\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2161, 156, false);
#line 49 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.ActionLink(@Html.DisplayTextFor(modelItem => item.Version), "GetDetailsByVersion", "Metadata", new { ID = item.Id }, new { @class = "processDetails" }));

#line default
#line hidden
                EndContext();
                BeginContext(2317, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2421, 43, false);
#line 52 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.DisplayTextFor(modelItem => item.Date));

#line default
#line hidden
                EndContext();
                BeginContext(2464, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2568, 45, false);
#line 55 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.DisplayTextFor(modelItem => item.Branch));

#line default
#line hidden
                EndContext();
                BeginContext(2613, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2717, 44, false);
#line 58 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.DisplayTextFor(modelItem => item.State));

#line default
#line hidden
                EndContext();
                BeginContext(2761, 68, true);
                WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 61 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                    }

#line default
#line hidden
                BeginContext(2852, 152, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <div class=\"container\">\r\n        <ul class=\"pagination pagination-sm\">\r\n");
                EndContext();
#line 68 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
             for (int i = 1; i <= Convert.ToInt32(pageNumber); i++)
            {

#line default
#line hidden
                BeginContext(3088, 81, true);
                WriteLiteral("                <li class=\"page-item\"><a class=\"page-link\" style=\"color:#212529;\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3169, "\"", 3234, 4);
                WriteAttributeValue("", 3176, "/Metadata/GetDetailsByName?Name=", 3176, 32, true);
#line 70 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
WriteAttributeValue("", 3208, Html.ViewBag.Name, 3208, 18, false);

#line default
#line hidden
                WriteAttributeValue("", 3226, "&Page=", 3226, 6, true);
#line 70 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
WriteAttributeValue("", 3232, i, 3232, 2, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3235, 4, true);
                WriteLiteral("><b>");
                EndContext();
                BeginContext(3240, 1, false);
#line 70 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                                                                                                                                                  Write(i);

#line default
#line hidden
                EndContext();
                BeginContext(3241, 15, true);
                WriteLiteral("</b></a></li>\r\n");
                EndContext();
#line 71 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
            }

#line default
#line hidden
                BeginContext(3271, 68, true);
                WriteLiteral("        </ul>\r\n    </div>\r\n    <hr />\r\n    <div class=\"container\">\r\n");
                EndContext();
#line 76 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
         using (Html.BeginForm("Read", "Metadata", FormMethod.Get))
        {

#line default
#line hidden
                BeginContext(3419, 71, true);
                WriteLiteral("            <button><i class=\"fa fa-list\"></i> Back to List </button>\r\n");
                EndContext();
#line 79 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
        }

#line default
#line hidden
                BeginContext(3501, 12, true);
                WriteLiteral("    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DinamicDataMvc.Models.ViewMetadataModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
