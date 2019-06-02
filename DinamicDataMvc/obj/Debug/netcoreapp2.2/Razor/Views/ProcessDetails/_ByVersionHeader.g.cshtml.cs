#pragma checksum "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c44fd09aeecd04ec5b4d55d2199657457f21fd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProcessDetails__ByVersionHeader), @"mvc.1.0.view", @"/Views/ProcessDetails/_ByVersionHeader.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ProcessDetails/_ByVersionHeader.cshtml", typeof(AspNetCore.Views_ProcessDetails__ByVersionHeader))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c44fd09aeecd04ec5b4d55d2199657457f21fd1", @"/Views/ProcessDetails/_ByVersionHeader.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b135ee1f7fb118fdd58813180c92355d712160c", @"/Views/_ViewImports.cshtml")]
    public class Views_ProcessDetails__ByVersionHeader : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DinamicDataMvc.Models.ProcessDetailsModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
   
    bool[] branchesState = new bool[3] { false, false, false};
    foreach(var description in Model.Branches)
    {
        if (description.Equals("Development")) {
            branchesState[0] = true;
        }
        else if (description.Equals("Quality"))
        {
            branchesState[1] = true;
        }
        else if (description.Equals("Production"))
        {
            branchesState[2] = true;
        }
    }

#line default
#line hidden
            BeginContext(505, 52, true);
            WriteLiteral("\r\n<section>\r\n    <div>\r\n        <span>\r\n            ");
            EndContext();
            BeginContext(558, 22, false);
#line 23 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
       Write(Html.Label("Version "));

#line default
#line hidden
            EndContext();
            BeginContext(580, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(595, 35, false);
#line 24 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
       Write(Html.DisplayTextFor(s => s.Version));

#line default
#line hidden
            EndContext();
            BeginContext(630, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(645, 28, false);
#line 25 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
       Write(Html.Label("Creation Date "));

#line default
#line hidden
            EndContext();
            BeginContext(673, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(688, 40, false);
#line 26 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
       Write(Html.DisplayTextFor(s => s.CreationDate));

#line default
#line hidden
            EndContext();
            BeginContext(728, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(743, 23, false);
#line 27 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
       Write(Html.Label("Branches "));

#line default
#line hidden
            EndContext();
            BeginContext(766, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(781, 47, false);
#line 28 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
       Write(Html.CheckBox("Development", @branchesState[0]));

#line default
#line hidden
            EndContext();
            BeginContext(828, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(843, 43, false);
#line 29 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
       Write(Html.CheckBox("Quality", @branchesState[1]));

#line default
#line hidden
            EndContext();
            BeginContext(886, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(901, 46, false);
#line 30 "C:\Projeto\localRepos\source\DinamicDataMvc\Views\ProcessDetails\_ByVersionHeader.cshtml"
       Write(Html.CheckBox("Production", @branchesState[2]));

#line default
#line hidden
            EndContext();
            BeginContext(947, 97, true);
            WriteLiteral("\r\n        </span>\r\n        <input type=\"submit\" value=\"Publish\"/>\r\n    </div>\r\n</section>\r\n    \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DinamicDataMvc.Models.ProcessDetailsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
