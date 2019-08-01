#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7870d46acca3061eb0768ddb7ac05f504c4ecff1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tools_PopulateStateCollection), @"mvc.1.0.view", @"/Views/Tools/PopulateStateCollection.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tools/PopulateStateCollection.cshtml", typeof(AspNetCore.Views_Tools_PopulateStateCollection))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7870d46acca3061eb0768ddb7ac05f504c4ecff1", @"/Views/Tools/PopulateStateCollection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_Tools_PopulateStateCollection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.StateModel>>
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
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
  
    ViewData["Title"] = "PopulateStateCollection";
    var message = ViewBag.Message;
    var collectionIsEmpty = ViewBag.EmptyCollection;

#line default
#line hidden
            BeginContext(203, 949, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7870d46acca3061eb0768ddb7ac05f504c4ecff14856", async() => {
                BeginContext(209, 480, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
    ");
                EndContext();
                BeginContext(689, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7870d46acca3061eb0768ddb7ac05f504c4ecff15734", async() => {
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
                BeginContext(725, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(731, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7870d46acca3061eb0768ddb7ac05f504c4ecff16987", async() => {
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
                BeginContext(787, 358, true);
                WriteLiteral(@"
    <style>
        #sucess {
            color: green;
            text-align: end;
        }

        #fail {
            color: red;
            text-align: end;
        }

        .infoMessage {
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
            font-display: auto;
        }
    </style>
");
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
            BeginContext(1152, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1154, 2024, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7870d46acca3061eb0768ddb7ac05f504c4ecff19475", async() => {
                BeginContext(1160, 144, true);
                WriteLiteral("\r\n    <div class=\"container\">\r\n        <div id=\"subtitleDiv\">\r\n            <h2 id=\"ProcessDescription\"> Operation Info </h2>\r\n        </div>\r\n\r\n");
                EndContext();
#line 39 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
         if (collectionIsEmpty.Equals("true"))
        {

#line default
#line hidden
                BeginContext(1363, 55, true);
                WriteLiteral("            <p class=\"infoMessage\" id=\"sucess\"><strong>");
                EndContext();
                BeginContext(1419, 7, false);
#line 41 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                                                  Write(message);

#line default
#line hidden
                EndContext();
                BeginContext(1426, 15, true);
                WriteLiteral("</strong></p>\r\n");
                EndContext();
#line 42 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
        }

#line default
#line hidden
                BeginContext(1452, 8, true);
                WriteLiteral("        ");
                EndContext();
#line 43 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
         if (collectionIsEmpty.Equals("false"))
        {

#line default
#line hidden
                BeginContext(1512, 53, true);
                WriteLiteral("            <p class=\"infoMessage\" id=\"fail\"><strong>");
                EndContext();
                BeginContext(1566, 7, false);
#line 45 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                                                Write(message);

#line default
#line hidden
                EndContext();
                BeginContext(1573, 15, true);
                WriteLiteral("</strong></p>\r\n");
                EndContext();
#line 46 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
        }

#line default
#line hidden
                BeginContext(1599, 306, true);
                WriteLiteral(@"    </div>
    <div class=""container"">
        <div class=""table-responsive table-striped"">
            <table class=""table table-bordered"" border=""1"" id=""processResultTable"">
                <thead>
                    <tr id=""tableHeader"">
                        <th>
                            ");
                EndContext();
                BeginContext(1906, 38, false);
#line 54 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                       Write(Html.DisplayName("State Order Number"));

#line default
#line hidden
                EndContext();
                BeginContext(1944, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2036, 41, false);
#line 57 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                       Write(Html.DisplayNameFor(model => model.Value));

#line default
#line hidden
                EndContext();
                BeginContext(2077, 91, true);
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
                EndContext();
                BeginContext(2169, 47, false);
#line 60 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
                EndContext();
                BeginContext(2216, 111, true);
                WriteLiteral("\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
                EndContext();
#line 65 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                     for (int i = 1; i <= Model.Count(); i++)
                    {

#line default
#line hidden
                BeginContext(2413, 113, true);
                WriteLiteral("                        <tr id=\"tableBody\">\r\n                            <td>\r\n                                #_");
                EndContext();
                BeginContext(2527, 1, false);
#line 69 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                             Write(i);

#line default
#line hidden
                EndContext();
                BeginContext(2528, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2632, 59, false);
#line 72 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                           Write(Html.DisplayFor(modelIndex => Model.ElementAt(i - 1).Value));

#line default
#line hidden
                EndContext();
                BeginContext(2691, 103, true);
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                EndContext();
                BeginContext(2795, 65, false);
#line 75 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                           Write(Html.DisplayFor(modelIndex => Model.ElementAt(i - 1).Description));

#line default
#line hidden
                EndContext();
                BeginContext(2860, 68, true);
                WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 78 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Tools\PopulateStateCollection.cshtml"
                    }

#line default
#line hidden
                BeginContext(2951, 220, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <div class=\"container\">\r\n        <button type=\"button\" onclick=\"GoBack();\"><i class=\"fa fa-toggle-left\"> Go Back </i></button>\r\n    </div>\r\n");
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
            BeginContext(3178, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DinamicDataMvc.Models.StateModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
