using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Field
{
    public class FieldController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IFieldService _Field;
        private readonly IPropertyService _Properties;
        private readonly IKeyGenerates _ObjectId;

        public FieldController(IConnectionManagementService Connection, IFieldService Field, IPropertyService Properties, IKeyGenerates ObjectId)
        {
            _Connection = Connection;
            _Field = Field;
            _Properties = Properties;
            _ObjectId = ObjectId;
        }

        [HttpGet("/Field/Read/")]
        public async Task<ActionResult> Read()
        {
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            _Field.ReadFromDatabase();
            List<FieldModel> models = _Field.GetFields();

            return await Task.Run(() => View("Read", models));
        }

        [HttpPost("/Field/Create/")]
        public async Task<ActionResult> Create(string type)
        {
            ViewBag.Type = type;

            return await Task.Run(() => View("Create"));
        }

        [HttpGet]
        public async Task<ActionResult> Display()
        {
            return await Task.Run(() => View("Display"));
        }

        [HttpPost("/Field/Delete/")]
        public string Delete(string id)
        {
            if(id == null)
            {
                return NotFound().StatusCode.ToString();
            }
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            var message = _Field.Delete(id);

            return message;
        }

        [HttpPost("/Field/AddField/")]
        public async Task<ActionResult> AddField(ViewFieldModel model)
        {
            //Defines the properties model key
            _ObjectId.SetKey(); //Sets a new properties ObjectID collection;
            string propertiesId = _ObjectId.GetKey();

            //First must create properties model;
            PropertiesModel properties = new PropertiesModel()
            {
                ID = propertiesId,
                Size = Convert.ToInt32(model.Size),
                Value = model.Value,
                Maxlength = Convert.ToInt32(model.Maxlength),
                Required = Convert.ToBoolean(model.Required)
            };

            //Third creates field model
            FieldModel field = new FieldModel()
            {
                Name = model.Name,
                Type = model.Type,
                Properties = propertiesId,
                Date = Convert.ToDateTime(model.CreationDate)
            };

            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            _Field.CreateProperties(properties);
            _Field.CreateField(field);

            _Field.ReadFromDatabase();

            return await Task.Run(() => RedirectToAction("Read", "Field"));
        }

        [HttpPost("/Field/Update/")]
        public async Task<ActionResult> Update(string Id)
        {
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            FieldModel field = _Field.GetField(Id);
            PropertiesModel properties = _Field.GetProperties(field.Properties);

            ViewBag.FieldId = Id;
            ViewBag.PropertiesID = field.Properties;

            ViewFieldModel ViewModel = new ViewFieldModel()
            {
                Type = field.Type,
                Name = field.Name,
                Size = properties.Size.ToString(),
                Value = properties.Value,
                Maxlength = properties.Maxlength.ToString(),
                Required = properties.Required.ToString(),
                CreationDate = Convert.ToDateTime(field.Date).ToString().Substring(0, 10)
            };

            return await Task.Run(() => View("Update", ViewModel));
        }

        [HttpPost("/Field/SaveUpdate/")]
        public async Task<ActionResult> SaveUpdate(string fieldId, string propertiesId, ViewFieldModel model)
        {
            //string x = fieldId;
            //string y = propertiesId;

            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());

            _Field.UpdateField(fieldId, new FieldModel()
            {
                Id = fieldId,
                Type = model.Type,
                Name = model.Name,
                Properties = propertiesId,
                Date = Convert.ToDateTime(model.CreationDate)
            });

            _Field.UpdateProperties(propertiesId, new PropertiesModel()
            {
                ID = propertiesId,
                Size = Convert.ToInt32(model.Size),
                Value = model.Value,
                Maxlength = Convert.ToInt32(model.Maxlength),
                Required = Convert.ToBoolean(model.Required)
            });

            _Field.ReadFromDatabase();

            return await Task.Run(() => RedirectToAction("Read", "Field"));
        }
    }
}