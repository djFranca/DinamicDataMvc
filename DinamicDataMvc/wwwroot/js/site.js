// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ValidateSearch() {
    var nameReg = /^[A-Za-z][0-9]+$/;
    var versionReg = /^[0-9]+$/;

    var result = true;

    var name = document.forms["searchForm"]["Name"].value;
    var version = document.forms["searchForm"]["Version"].value;

    if (!nameReg.exec(name)) {
        if (name == null || name == "") {
            result = result & true;
        }
        else {
            alert("The input name value is not valid");
            result = result & false;
        }
    }

    if (!versionReg.exec(version)) {
        if (version == null || version == "") {
            result = result & true;
        }
        else {
            alert("The input version value is not valid");
            result = result & false;
        }
    }
}


function GoBack() {
    window.history.back();
}
