#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be36d8964faaf59edcd568e2fd23a60a58637415"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be36d8964faaf59edcd568e2fd23a60a58637415", @"/Views/Metadata/GetDetailsByName.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_Metadata_GetDetailsByName : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.ViewMetadataModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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

#line default
#line hidden
            BeginContext(120, 531, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be36d8964faaf59edcd568e2fd23a60a586374154031", async() => {
                BeginContext(126, 480, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
    ");
                EndContext();
                BeginContext(606, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be36d8964faaf59edcd568e2fd23a60a586374154909", async() => {
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
                BeginContext(642, 2, true);
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
            BeginContext(651, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(653, 2322, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be36d8964faaf59edcd568e2fd23a60a586374156959", async() => {
                BeginContext(659, 185, true);
                WriteLiteral("\r\n    <section id=\"ProcessNameTag\">\r\n        <hr />\r\n        <div class=\"container\" style=\"background-color:darkorange\">\r\n            <h2 style=\"color:white; text-align:right;\">Process ");
                EndContext();
                BeginContext(845, 17, false);
#line 17 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                                                          Write(Html.ViewBag.Name);

#line default
#line hidden
                EndContext();
                BeginContext(862, 456, true);
                WriteLiteral(@" Versions</h2>
        </div>
        <hr />
    </section>
    <section id=""ProcessVersions"">
        <div class=""container"">
            <div class=""table-responsive table-striped"">
                <table class=""table table-bordered"" border=""1"" style=""border-style:dotted"">
                    <thead>
                        <tr style=""background-color:#212529; color:white;"">
                            <th>
                                ");
                EndContext();
                BeginContext(1319, 43, false);
#line 28 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.DisplayNameFor(model => model.Version));

#line default
#line hidden
                EndContext();
                BeginContext(1362, 103, true);
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
                EndContext();
                BeginContext(1466, 40, false);
#line 31 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
                EndContext();
                BeginContext(1506, 103, true);
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
                EndContext();
                BeginContext(1610, 42, false);
#line 34 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.DisplayNameFor(model => model.Branch));

#line default
#line hidden
                EndContext();
                BeginContext(1652, 127, true);
                WriteLiteral("\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
                EndContext();
#line 39 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
                BeginContext(1860, 96, true);
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(1957, 121, false);
#line 43 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.ActionLink(@Html.DisplayTextFor(modelItem => item.Version), "GetDetailsByVersion", "Metadata", new { ID = item.Id }));

#line default
#line hidden
                EndContext();
                BeginContext(2078, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2182, 43, false);
#line 46 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.DisplayTextFor(modelItem => item.Date));

#line default
#line hidden
                EndContext();
                BeginContext(2225, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2329, 45, false);
#line 49 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                           Write(Html.DisplayTextFor(modelItem => item.Branch));

#line default
#line hidden
                EndContext();
                BeginContext(2374, 68, true);
                WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 52 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
                        }

#line default
#line hidden
                BeginContext(2469, 156, true);
                WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </section>\r\n    <section>\r\n        <div class=\"container\">\r\n");
                EndContext();
#line 60 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
             using (Html.BeginForm("Read", "Metadata", FormMethod.Get))
            {

#line default
#line hidden
                BeginContext(2713, 208, true);
                WriteLiteral("            <span>\r\n                <label class=\"form-group\" style=\"color:darkorange\"><strong>Back to List</strong></label>\r\n                <button><i class=\"fa fa-list\"></i></button>\r\n            </span>\r\n");
                EndContext();
#line 66 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Metadata\GetDetailsByName.cshtml"
            }

#line default
#line hidden
                BeginContext(2936, 32, true);
                WriteLiteral("        </div>\r\n    </section>\r\n");
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
