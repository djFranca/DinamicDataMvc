#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2195feb99fb01cf110160a342b8c07065089623c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Field_Read), @"mvc.1.0.view", @"/Views/Field/Read.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Field/Read.cshtml", typeof(AspNetCore.Views_Field_Read))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2195feb99fb01cf110160a342b8c07065089623c", @"/Views/Field/Read.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_Field_Read : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DinamicDataMvc.Models.Field.FieldModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ListPageStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
  
    ViewData["Title"] = "Read";

#line default
#line hidden
            BeginContext(102, 443, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2195feb99fb01cf110160a342b8c07065089623c4353", async() => {
                BeginContext(108, 277, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    ");
                EndContext();
                BeginContext(385, 54, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2195feb99fb01cf110160a342b8c07065089623c5022", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(439, 99, true);
                WriteLiteral("\r\n    <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js\"></script>\r\n");
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
            BeginContext(545, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(547, 2237, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2195feb99fb01cf110160a342b8c07065089623c7254", async() => {
                BeginContext(553, 38, true);
                WriteLiteral("\r\n    <h2>Field List</h2>\r\n    <div>\r\n");
                EndContext();
#line 16 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
         using (Html.BeginForm("Display", "Field", FormMethod.Get))
        {

#line default
#line hidden
                BeginContext(671, 76, true);
                WriteLiteral("            <button type=\"submit\"><i class=\"fa fa-file-text\"></i></button>\r\n");
                EndContext();
#line 19 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
        }

#line default
#line hidden
                BeginContext(758, 116, true);
                WriteLiteral("    </div>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(875, 38, false);
#line 25 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
               Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
                EndContext();
                BeginContext(913, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(981, 40, false);
#line 28 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
               Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
                EndContext();
                BeginContext(1021, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(1089, 40, false);
#line 31 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
                EndContext();
                BeginContext(1129, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(1197, 44, false);
#line 34 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
               Write(Html.DisplayNameFor(model => model.Required));

#line default
#line hidden
                EndContext();
                BeginContext(1241, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(1309, 40, false);
#line 37 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
               Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
                EndContext();
                BeginContext(1349, 106, true);
                WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
                EndContext();
#line 43 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
                BeginContext(1512, 72, true);
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(1585, 37, false);
#line 47 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
                EndContext();
                BeginContext(1622, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(1702, 39, false);
#line 50 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
                EndContext();
                BeginContext(1741, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(1821, 39, false);
#line 53 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
                EndContext();
                BeginContext(1860, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(1940, 43, false);
#line 56 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Required));

#line default
#line hidden
                EndContext();
                BeginContext(1983, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2063, 39, false);
#line 59 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
                EndContext();
                BeginContext(2102, 55, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
                EndContext();
#line 62 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                         using (Html.BeginForm("Details", "Field", item.Id, FormMethod.Get))
                        {

#line default
#line hidden
                BeginContext(2278, 87, true);
                WriteLiteral("                            <button type=\"submit\"><i class=\"fa fa-list\"></i></button>\r\n");
                EndContext();
#line 65 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                        }

#line default
#line hidden
                BeginContext(2392, 53, true);
                WriteLiteral("                    </td>\r\n                    <td>\r\n");
                EndContext();
#line 68 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                         using (Html.BeginForm("Delete", "Field", item.Id, FormMethod.Get))
                        {

#line default
#line hidden
                BeginContext(2565, 88, true);
                WriteLiteral("                            <button type=\"submit\"><i class=\"fa fa-trash\"></i></button>\r\n");
                EndContext();
#line 71 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
                        }

#line default
#line hidden
                BeginContext(2680, 50, true);
                WriteLiteral("                    </td>\r\n                </tr>\r\n");
                EndContext();
#line 74 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\Field\Read.cshtml"
            }

#line default
#line hidden
                BeginContext(2745, 32, true);
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
            BeginContext(2784, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DinamicDataMvc.Models.Field.FieldModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591