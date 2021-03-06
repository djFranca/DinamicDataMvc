﻿using DinamicDataMvc.Models.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Utils
{
    public class WebFormTemplate
    {
        private readonly List<WebFormModel> webFormModels;

        /*
         * Construtor recebe como argumento de entrada a lista de valores e tipo dos campos a renderizar;
         */
        public WebFormTemplate(List<WebFormModel> webFormModels)
        {
            this.webFormModels = webFormModels;
        }

        /*
         * Cria os fragmentos do webform template;
         */
        public List<string> Template()
        {
            List<string> htmlElements = new List<string>();


            for(int i = 0; i < webFormModels.Count(); i++)
            {
                if(webFormModels.ElementAt(i).Type.Equals("Text") || webFormModels.ElementAt(i).Type.Equals("Number") || webFormModels.ElementAt(i).Type.Equals("Password") || webFormModels.ElementAt(i).Type.Equals("Email"))
                {
                    string element = SetInputElement(webFormModels.ElementAt(i).Name, webFormModels.ElementAt(i).Type, webFormModels.ElementAt(i).Size, webFormModels.ElementAt(i).Maxlength, webFormModels.ElementAt(i).Value, webFormModels.ElementAt(i).Required, webFormModels.ElementAt(i).Readonly);
                    htmlElements.Add(element);
                }

                if (webFormModels.ElementAt(i).Type.Equals("TextArea"))
                {
                    string element = SetTextAreaElement(webFormModels.ElementAt(i).Size, webFormModels.ElementAt(i).Maxlength, webFormModels.ElementAt(i).Value, webFormModels.ElementAt(i).Readonly);
                    htmlElements.Add(element);
                }
            }

            return htmlElements;
        }

        /*
         * Cria um elemento do tipo input, considerando se é um elemento html reqired ou não;
         */
        private string SetInputElement(string name, string type, string size, string maxlength, string value, string required, bool readonlyValue)
        {
            if (Convert.ToBoolean(required) == true && readonlyValue)
            {
                return "<div class='form-group'><label><b>" + name + "</b></label><br /><input asp-for='Data' name='Data' type='" + type + "' size='" + size + "' maxlength='" + maxlength + "' value='" + value + "' required readonly class='form-control'/></div>";
            }
            if(Convert.ToBoolean(required) == true && !readonlyValue)
            {
                return "<div class='form-group'><label><b>" + name + "</b></label><br /><input asp-for='Data' name='Data' type='" + type + "' size='" + size + "' maxlength='" + maxlength + "' value='" + value + "' required class='form-control'/></div>";
            }
            if(Convert.ToBoolean(required) == false && !readonlyValue)
            {
                return "<div class='form-group'><label><b>" + name + "</b></label><br /><input asp-for='Data' name='Data' type='" + type + "' size='" + size + "' maxlength='" + maxlength + "' value='" + value + "' class='form-control'/></div>";
            }
            return "<div class='form-group'><label><b>" + name + "</b></label><br /><input asp-for='Data' name='Data' type='" + type + "' size='" + size + "' maxlength='" + maxlength + "' value='" + value + "' readonly class='form-control'/></div>";
        }

        /*
         * Cria um elemento html do tipo Text Area;
         */
        private string SetTextAreaElement(string size, string maxlength, string value, bool isReadonly)
        {
            if (!isReadonly)
            {
                return "<div class='form-group'><textarea name='Data' rows='" + size + "' cols='" + maxlength + "' asp-for='Data' class='form-control'>" + value + "</textarea></div>";
            }
            return "<div class='form-group'><textarea name='Data' rows='" + size + "' cols='" + maxlength + "' asp-for='Data' class='form-control' readonly>" + value + "</textarea></div>";
        }
    }
}
