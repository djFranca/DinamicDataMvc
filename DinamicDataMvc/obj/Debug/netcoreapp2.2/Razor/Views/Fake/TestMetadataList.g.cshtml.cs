#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "106ae777fe513a2eee0bf55fe5c72564a41cae26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fake_TestMetadataList), @"mvc.1.0.view", @"/Views/Fake/TestMetadataList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Fake/TestMetadataList.cshtml", typeof(AspNetCore.Views_Fake_TestMetadataList))]
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
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
using PagedList.Mvc;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"106ae777fe513a2eee0bf55fe5c72564a41cae26", @"/Views/Fake/TestMetadataList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_Fake_TestMetadataList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.MetadataListModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/PagedList.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(84, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "106ae777fe513a2eee0bf55fe5c72564a41cae264390", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
            BeginContext(156, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
  
    ViewData["Title"] = "TestMetadataList";

#line default
#line hidden
            BeginContext(210, 78, true);
            WriteLiteral("<section>\r\n    <div class=\"text-body\">\r\n        <h4>Filters</h4>\r\n    </div>\r\n");
            EndContext();
#line 11 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
     using (Html.BeginForm("Fake", "TestMetadataList", FormMethod.Get))
    {
        

#line default
#line hidden
            BeginContext(377, 34, false);
#line 13 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
   Write(await Html.PartialAsync("_Filter"));

#line default
#line hidden
            EndContext();
#line 13 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                                           
    }

#line default
#line hidden
            BeginContext(420, 265, true);
            WriteLiteral(@"</section>
<br />
<section>
    <div class=""text-body"">
        <h4>Metadata</h4>
    </div>
    <div>
        <table class=""table"">
            <thead>
                <tr>
                    <th valign=""middle"" align=""center"">
                        ");
            EndContext();
            BeginContext(686, 40, false);
#line 26 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(726, 110, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th valign=\"middle\" align=\"center\">\r\n                        ");
            EndContext();
            BeginContext(837, 43, false);
#line 29 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                   Write(Html.DisplayNameFor(model => model.Version));

#line default
#line hidden
            EndContext();
            BeginContext(880, 110, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th valign=\"middle\" align=\"center\">\r\n                        ");
            EndContext();
            BeginContext(991, 40, false);
#line 32 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                   Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1031, 110, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th valign=\"middle\" align=\"center\">\r\n                        ");
            EndContext();
            BeginContext(1142, 42, false);
#line 35 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                   Write(Html.DisplayNameFor(model => model.Branch));

#line default
#line hidden
            EndContext();
            BeginContext(1184, 110, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th valign=\"middle\" align=\"center\">\r\n                        ");
            EndContext();
            BeginContext(1295, 41, false);
#line 38 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                   Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
            EndContext();
            BeginContext(1336, 112, true);
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody id=\"ProcessList\">\r\n");
            EndContext();
#line 43 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1513, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1598, 103, false);
#line 47 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                       Write(Html.ActionLink(@Html.DisplayTextFor(modelItem => item.Name), "ProcessDetails", new { ID = item.Name }));

#line default
#line hidden
            EndContext();
            BeginContext(1701, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1793, 46, false);
#line 50 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                       Write(Html.DisplayTextFor(modelItem => item.Version));

#line default
#line hidden
            EndContext();
            BeginContext(1839, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1931, 43, false);
#line 53 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                       Write(Html.DisplayTextFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1974, 63, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 56 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                             foreach (string branch in item.Branch)
                            {

#line default
#line hidden
            BeginContext(2137, 76, true);
            WriteLiteral("                                <span>\r\n                                    ");
            EndContext();
            BeginContext(2214, 32, false);
#line 59 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                               Write(Html.DisplayTextFor(s => branch));

#line default
#line hidden
            EndContext();
            BeginContext(2246, 43, true);
            WriteLiteral("\r\n                                </span>\r\n");
            EndContext();
#line 61 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                            }

#line default
#line hidden
            BeginContext(2320, 89, true);
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2410, 44, false);
#line 64 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                       Write(Html.DisplayTextFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(2454, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2546, 61, false);
#line 67 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { /*ID = item.Id*/ }));

#line default
#line hidden
            EndContext();
            BeginContext(2607, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 70 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Fake\TestMetadataList.cshtml"
                }

#line default
#line hidden
            BeginContext(2686, 95, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</section>\r\n<section>\r\n    \r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DinamicDataMvc.Models.MetadataListModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
