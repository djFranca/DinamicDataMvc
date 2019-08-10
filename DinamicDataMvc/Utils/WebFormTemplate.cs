using DinamicDataMvc.Models.Tools;
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
                    string element = SetInputElement(webFormModels.ElementAt(i).Type, webFormModels.ElementAt(i).Name, webFormModels.ElementAt(i).Size, webFormModels.ElementAt(i).Maxlength, webFormModels.ElementAt(i).Value, webFormModels.ElementAt(i).Required);
                    htmlElements.Add(element);
                }

                if(webFormModels.ElementAt(i).Type.Equals("Label"))
                {
                    string element = SetLabelElement(webFormModels.ElementAt(i).Value);
                    htmlElements.Add(element);
                }
                if (webFormModels.ElementAt(i).Type.Equals("Button"))
                {
                    string element = SetButtonElement(webFormModels.ElementAt(i).Name, webFormModels.ElementAt(i).Value);
                    htmlElements.Add(element);
                }
            }

            return htmlElements;
        }

        /*
         * Cria um elemento do tipo input, considerando se é um elemento html reqired ou não;
         */
        private string SetInputElement(string type, string name, string size, string maxlength, string value, string required)
        {
            if (Convert.ToBoolean(required) == true)
            {
                return "<div class='container'><label><b>" + type + "</b></label><br /><input type='" + type + "' name='" + name + "' size='" + size + "' maxlength='" + maxlength + "' value='" + value + "' required /></div>";
            }
            return "<div class='container'><label><b>" + type + "</b></label><br /><input type='" + type + "' name='" + name + "' size='" + size + "' maxlength='" + maxlength + "' value='" + value + "' /></div>";
        }

        /*
         * Cria um elemento html do tipo label;
         */
        private string SetLabelElement(string value)
        {
            return "<div class='container'><label for='" + value + "'>" + value + "</label></div>";
        }

        /*
         * Cria um elemento html do tipo button;
         */
        private string SetButtonElement(string name, string value)
        {
            return "<div class='container'><div class='btn-group'><button type='submit' name='" + name + "'><i class='fa fa-check'></i>" + value + "</button></div></div>";
        }
    }
}
