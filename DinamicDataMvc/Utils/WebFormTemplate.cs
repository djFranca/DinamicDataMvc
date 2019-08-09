using DinamicDataMvc.Models.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Utils
{
    public class WebFormTemplate
    {
        private readonly List<WebFormModel> webFormModels;

        public WebFormTemplate(List<WebFormModel> webFormModels)
        {
            this.webFormModels = webFormModels;
        }

        public List<string> Template()
        {
            List<string> divs = new List<string>();


            for(int i = 0; i < webFormModels.Count(); i++)
            {
                if(webFormModels.ElementAt(i).Type.Equals("Text") || webFormModels.ElementAt(i).Type.Equals("Number") || webFormModels.ElementAt(i).Type.Equals("Password") || webFormModels.ElementAt(i).Type.Equals("Email"))
                {
                    string div = SetInputElement(webFormModels.ElementAt(i).Type, webFormModels.ElementAt(i).Name, webFormModels.ElementAt(i).Size, webFormModels.ElementAt(i).Maxlength, webFormModels.ElementAt(i).Value, webFormModels.ElementAt(i).Required);
                    divs.Add(div);
                }

                if(webFormModels.ElementAt(i).Type.Equals("Label"))
                {
                    string div = SetLabelElement(webFormModels.ElementAt(i).Value);
                    divs.Add(div);
                }
                if (webFormModels.ElementAt(i).Type.Equals("Button"))
                {
                    string div = SetButtonElement(webFormModels.ElementAt(i).Name, webFormModels.ElementAt(i).Value);
                    divs.Add(div);
                }
            }

            return divs;
        }

        private string SetInputElement(string type, string name, string size, string maxlength, string value, string required)
        {
            if (Convert.ToBoolean(required) == true)
            {
                return "<div class='container'><label><b>" + type + "</b></label><br /><input type='" + type + "' name='" + name + "' size='" + size + "' maxlength='" + maxlength + "' value='" + value + "' required /></div>";
            }
            return "<div class='container'><label><b>" + type + "</b></label><br /><input type='" + type + "' name='" + name + "' size='" + size + "' maxlength='" + maxlength + "' value='" + value + "' /></div>";
        }

        private string SetLabelElement(string value)
        {
            return "<div><label for='" + value + "'>" + value + "</label></div>";
        }

        private string SetButtonElement(string name, string value)
        {
            return "<button type='submit' name='" + name + "'><i class='fa fa-check'></i>" + value + "</button>";
        }
    }
}
