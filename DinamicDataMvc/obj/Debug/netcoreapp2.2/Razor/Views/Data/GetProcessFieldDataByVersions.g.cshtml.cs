#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e7a58b65dd3d40cbec794929fcf98716faa2f55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Data_GetProcessFieldDataByVersions), @"mvc.1.0.view", @"/Views/Data/GetProcessFieldDataByVersions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Data/GetProcessFieldDataByVersions.cshtml", typeof(AspNetCore.Views_Data_GetProcessFieldDataByVersions))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e7a58b65dd3d40cbec794929fcf98716faa2f55", @"/Views/Data/GetProcessFieldDataByVersions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Data_GetProcessFieldDataByVersions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.Data.ViewDataModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/PageStyleFile.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:ghostwhite"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
  
    ViewData["Title"] = "GetProcessFieldDataByVersions";
    string ProcessName = ViewBag.ProcessName;

#line default
#line hidden
            BeginContext(174, 593, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e7a58b65dd3d40cbec794929fcf98716faa2f554957", async() => {
                BeginContext(180, 480, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
    ");
                EndContext();
                BeginContext(660, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e7a58b65dd3d40cbec794929fcf98716faa2f555835", async() => {
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
                BeginContext(696, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(702, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1e7a58b65dd3d40cbec794929fcf98716faa2f557088", async() => {
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
                BeginContext(758, 2, true);
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
            BeginContext(767, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(769, 2719, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e7a58b65dd3d40cbec794929fcf98716faa2f559217", async() => {
                BeginContext(811, 104, true);
                WriteLiteral("\r\n    <hr />\r\n    <div class=\"container\" id=\"subtitleDiv\">\r\n        <h2 id=\"ProcessDescription\">Process ");
                EndContext();
                BeginContext(916, 11, false);
#line 18 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                       Write(ProcessName);

#line default
#line hidden
                EndContext();
                BeginContext(927, 341, true);
                WriteLiteral(@"</h2>
    </div>
    <hr />
    <div class=""container"">
        <br />
        <div class=""table-responsive table-striped"">
            <table class=""table table-bordered"" border=""1"" id=""processResultTable"">
                <thead>
                    <tr id=""tableHeader"">
                        <th>
                            ");
                EndContext();
                BeginContext(1269, 62, false);
#line 28 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayNameFor(modelItem => Model.ElementAt(0).ProcessId));

#line default
#line hidden
                EndContext();
                BeginContext(1331, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1423, 67, false);
#line 31 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayNameFor(modelItem => Model.ElementAt(0).ProcessVersion));

#line default
#line hidden
                EndContext();
                BeginContext(1490, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1582, 66, false);
#line 34 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayNameFor(modelItem => Model.ElementAt(0).ProcessBranch));

#line default
#line hidden
                EndContext();
                BeginContext(1648, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1740, 65, false);
#line 37 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayNameFor(modelItem => Model.ElementAt(0).CreationDate));

#line default
#line hidden
                EndContext();
                BeginContext(1805, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(1897, 32, false);
#line 40 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                       Write(Html.DisplayName("Edit Webform"));

#line default
#line hidden
                EndContext();
                BeginContext(1929, 111, true);
                WriteLiteral("\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
                EndContext();
#line 45 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                     foreach (var model in Model)
                    {

#line default
#line hidden
                BeginContext(2114, 111, true);
                WriteLiteral("                        <tr id=\"tableBody\">\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2226, 45, false);
#line 49 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                           Write(Html.DisplayFor(modelItem => model.ProcessId));

#line default
#line hidden
                EndContext();
                BeginContext(2271, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2375, 50, false);
#line 52 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                           Write(Html.DisplayFor(modelItem => model.ProcessVersion));

#line default
#line hidden
                EndContext();
                BeginContext(2425, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2529, 49, false);
#line 55 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                           Write(Html.DisplayFor(modelItem => model.ProcessBranch));

#line default
#line hidden
                EndContext();
                BeginContext(2578, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2682, 48, false);
#line 58 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                           Write(Html.DisplayFor(modelItem => model.CreationDate));

#line default
#line hidden
                EndContext();
                BeginContext(2730, 71, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
                EndContext();
#line 61 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                 using (Html.BeginForm("GetStoredWebForm", "Data", new { ProcessId = model.ProcessId, ProcessBranch = model.ProcessBranch }, FormMethod.Post))
                                {

#line default
#line hidden
                BeginContext(3012, 97, true);
                WriteLiteral("                                    <button type=\"submit\"><i class=\"fa fa-pencil\"></i></button>\r\n");
                EndContext();
#line 64 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                                }

#line default
#line hidden
                BeginContext(3144, 66, true);
                WriteLiteral("                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 67 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Data\GetProcessFieldDataByVersions.cshtml"
                    }

#line default
#line hidden
                BeginContext(3233, 248, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n        <br />\r\n    </div>\r\n    <br />\r\n    <div class=\"container\">\r\n        <button type=\"button\" onclick=\"GoBack();\"><i class=\"fa fa-toggle-left\"> Go Back </i></button>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3488, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DinamicDataMvc.Models.Data.ViewDataModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
