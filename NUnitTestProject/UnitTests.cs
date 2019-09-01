using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Models.Metadata;
using DinamicDataMvc.Models.Properties;
using DinamicDataMvc.Services.Config;
using DinamicDataMvc.Services.Database;
using DinamicDataMvc.Services.Fields;
using DinamicDataMvc.Services.Metadata;
using DinamicDataMvc.Services.Properties;
using DinamicDataMvc.Services.Validation;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly string databaseName = "MetadataProcessesDb";

        private ConnectionManagementService manager;
        private MetadataService metadata;
        private BranchService branch;
        private StateService state;
        private FieldService field;
        private PropertyService property;
        private ValidationService validation;
        private KeyGenerates KeyId;

        [SetUp]
        public void Setup()
        {
            //Arrange
            manager = new ConnectionManagementService(connectionString, databaseName);
            metadata = new MetadataService(null, null);
            branch = new BranchService();
            state = new StateService();
            field = new FieldService();
            validation = new ValidationService();
            KeyId = new KeyGenerates(8);
            property = new PropertyService();
        }

        [Test]
        public void TestDatabaseConnection()
        {
            //Arrange
            manager.DatabaseConnection();
            string connString = manager.GetConnectionString();

            //Act
            IMongoDatabase conn = manager.GetDatabase();

            if(conn != null && connString.Equals(connectionString))
            {
                Assert.Pass("Result: Current database is " + conn.DatabaseNamespace.DatabaseName + "Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetBranchModels()
        {
            //Arrange
            manager.DatabaseConnection();
            branch.SetDatabase(manager.GetDatabase());

            //Act
            var models = branch.GetBranchModels();

            if(models.Count > 0)
            {
                Assert.Pass("Result: number of models = " + models.Count + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }

            Assert.Fail();
        }

        [Test]
        public void TestGetBranchId()
        {
            //Arrange
            manager.DatabaseConnection();
            branch.SetDatabase(manager.GetDatabase());
            string branchCode = "Qa";

            //Act
            var branchId = branch.GetBranchID(branchCode);

            if(!string.IsNullOrEmpty(branchId))
            {
                Assert.Pass("Result: Branch Id = " + branchId + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }

            Assert.Fail();
        }

        [Test]
        public void TestGetProcessBranches()
        {
            //Arrange
            manager.DatabaseConnection();
            branch.SetDatabase(manager.GetDatabase());
            List<string> branchIds = new List<string>() { "5ce95aab70eb31116c6ca8d6", "5ce95b7970eb31116c6ca8d7" };

            //Act
            branch.ReadFromDatabase(branchIds);
            string branches = branch.GetBranches();

            if (!string.IsNullOrEmpty(branches))
            {
                Assert.Pass("Result: Process branches = " + branches + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }

            Assert.Fail();
        }

        [Test]
        public void TestGetStateId()
        {
            //Arrange
            manager.DatabaseConnection();
            state.SetDatabase(manager.GetDatabase());
            string description = "Inactive";

            //Act 
            string stateId = state.GetStateID(description);

            if (!string.IsNullOrEmpty(stateId))
            {
                Assert.Pass("Result: State Id = " + stateId + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetStateProcess()
        {
            //Arrange
            manager.DatabaseConnection();
            state.SetDatabase(manager.GetDatabase());
            string stateId = "5ceac39b5cef382144c73570";

            //Act
            state.ReadFromDatabase(stateId);
            string description = state.GetStateDescription();

            if (!string.IsNullOrEmpty(description))
            {
                Assert.Pass("Result: State description = " + description + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }

            Assert.Fail();
        }

        [Test]
        public void TestGetStateModels()
        {
            //Arrange
            manager.DatabaseConnection();
            state.SetDatabase(manager.GetDatabase());

            //Act
            var models = state.GetStateModels();

            if(models.Count > 0)
            {
                Assert.Pass("Result: number of models = " + models.Count + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            Assert.Fail();
        }

        [Test]
        public void TestIfProcessExists()
        {
            //Arrange
            manager.DatabaseConnection();
            validation.SetDatabase(manager.GetDatabase());
            string processName = "P2";

            //Act
            bool exists = validation.ProcessExits(processName);

            if (exists)
            {
                Assert.Pass("Result: Process " + processName + " exists in database");
            }
            else if (!exists)
            {
                Assert.Pass("Result: Process " + processName + " do not exists in database");
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetProcessLastVersion()
        {
            //Arrange
            manager.DatabaseConnection();
            validation.SetDatabase(manager.GetDatabase());
            string processName = "P2";

            //Act
            int version = validation.GetProcessLastVersion(processName);

            Assert.Pass("Result: Process Version = " + version + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
        }


        [Test]
        public void TestCreateProperties()
        {
            //Arrange
            manager.DatabaseConnection();
            property.SetDatabase(manager.GetDatabase());
            string propertiesId = "7385f033377a07127da07385";

            PropertiesModel model1 = new PropertiesModel()
            {
                ID = propertiesId,
                Size = 40,
                Value = "Hello World",
                Maxlength = 50,
                Required = false
            };

            //PropertiesModel model2 = null;

            //Act
            string result = property.CreateProperties(model1);

            if(Convert.ToInt32(result) == 201)
            {
                Assert.Pass("Result: Properties Model with id = " + propertiesId + ", was created with success");
            }

            if(Convert.ToInt32(result) == 400)
            {
                Assert.Pass("Result: Properties Model with id = " + propertiesId + ", was not created");
            }

            Assert.Fail();
        }


        [Test]
        public void TestGetPropertyValue()
        {
            //Arrange
            manager.DatabaseConnection();
            property.SetDatabase(manager.GetDatabase());
            string propertyId = "18c8870a363bd02b32aa6677";

            //Act
            string result = property.GetPropertyValue(propertyId);

            if(!string.IsNullOrEmpty(result))
            {
                Assert.Pass("Result: " + result + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            else if (string.IsNullOrEmpty(result))
            {
                Assert.Pass("Result: Empty or null value, Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            Assert.Fail();
        }

        [Test]
        public void TestUpdatePropertyValue()
        {
            //Arrange
            manager.DatabaseConnection();
            property.SetDatabase(manager.GetDatabase());
            string propertiesId = "09a36f7f45683eba7e0e8dae";
            string value = "daniel.franca@mail.pt";

            //Act
            string result = property.UpdatePropertyValue(propertiesId, value);

            if(Convert.ToInt32(result) == 204)
            {
                Assert.Pass("Result: Properties Model with id = " + propertiesId + ", was updated with success");
            }
            else if(Convert.ToInt32(result) == 204)
            {
                Assert.Pass("Result: Properties Model with id = " + propertiesId + ", was not updated");
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetProperties()
        {
            //Arrange
            manager.DatabaseConnection();
            property.SetDatabase(manager.GetDatabase());
            string propertyId = "18c8870a363bd02b32aa6677";

            //Act
            PropertiesModel model = property.GetProperties(propertyId);

            if(model != null)
            {
                string result = "Model id " + model.ID + " with Size = " + model.Size + ", Value = " + model.Value + ", Maxlength = " + model.Maxlength + ", and Required = " + model.Required;
                Assert.Pass("Result: " + result + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            Assert.Fail();
        }

        //[Test]
        //public void TestUpdateProperties()
        //{
        //    //Arrange
        //    manager.DatabaseConnection();
        //    property.SetDatabase(manager.GetDatabase());
        //    string propertiesId = "18c8870a363bd02b32aa6677";
        //    PropertiesModel model = new PropertiesModel()
        //    {
        //        ID = propertiesId,
        //        Size = 60,
        //        Value = "daniel.isel.email@email.pt",
        //        Maxlength = 120,
        //        Required = false
        //    };

        //    //Act
        //    string result = property.UpdateProperties(propertiesId, model);

        //    if(Convert.ToInt32(result) == 204)
        //    {
        //        Assert.Pass("Result: Properties with id = " + propertiesId + " was updated with success");
        //    }
        //    if(Convert.ToInt32(result) == 400)
        //    {
        //        Assert.Pass("Result: Properties with id = " + propertiesId + " was not updated");
        //    }
        //    Assert.Fail();
        //}

        [Test]
        public void TestDeleteProperties()
        {
            //Arrange
            manager.DatabaseConnection();
            property.SetDatabase(manager.GetDatabase());
            string propertiesId = "7385f033377a07127da07385";

            //Act
            string result = property.DeleteProperties(propertiesId);

            if (Convert.ToInt32(result) == 204)
            {
                Assert.Pass("Result: Properties with id = " + propertiesId + " was deleted with success");
            }
            if (Convert.ToInt32(result) == 400)
            {
                Assert.Pass("Result: Properties with id = " + propertiesId + " was not deleted");
            }
            Assert.Fail();
        }

        [Test]
        public void TestCreateField()
        {
            //Arrange
            manager.DatabaseConnection();
            field.SetDatabase(manager.GetDatabase());
            string fieldId = "05afb3f91c73ee7b43ffb9fa";

            FieldModel model = new FieldModel()
            {
                Id = fieldId,
                Type = "Number",
                Name = "Number One",
                Date = DateTime.Now.ToLocalTime(),
                Properties = "7385f033377a07127da07385"
            };

            //Act
            string result = field.CreateField(model);

            if (Convert.ToInt32(result) == 201)
            {
                Assert.Pass("Result: Field model with id" + fieldId + ", was created with success");
            }
            if (Convert.ToInt32(result) == 400)
            {
                Assert.Pass("Result: Field model with id" + fieldId + ", was not created");
            }
            Assert.Fail();

        }

        [Test]
        public void TestGetField()
        {
            //Arrange
            manager.DatabaseConnection();
            field.SetDatabase(manager.GetDatabase());
            string fieldId = "05afb3f91c73ee7b43ffb9fa";

            //Act
            FieldModel model = field.GetField(fieldId);

            if(model != null)
            {
                string message = "Model Type " + model.Type + ", Name " + model.Name + ", Created in " + model.Date;
                Assert.Pass("Result: " + message + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            Assert.Fail();
        }

        [Test]
        public void TestDeleteField()
        {
            //Arrange
            manager.DatabaseConnection();
            field.SetDatabase(manager.GetDatabase());
            string fieldId = "05afb3f91c73ee7b43ffb9fa";

            //Act
            string result = field.DeleteField(fieldId);

            if (Convert.ToInt32(result) == 200)
            {
                Assert.Pass("Result: Field model with id" + fieldId + ", was deleted with success");
            }
            if (Convert.ToInt32(result) == 400)
            {
                Assert.Pass("Result: Field model with id" + fieldId + ", was not deleted");
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetProcessNames()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());

            //Act
            List<string> processNames = metadata.GetProcessNames(new List<MetadataModel>() { });

            if(processNames.Count >= 0)
            {
                Assert.Pass("Result: List have " + processNames.Count + " process names");
            }
            Assert.Fail();
        }

        [Test]
        public void TestReadFromDatabase()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());

            //Act
            metadata.ReadFromDatabase();
            List<MetadataModel> models = metadata.GetProcessesMetadataList();

            if(models.Count >= 0)
            {
                Assert.Pass("Result: List have " + models.Count + " metadata models");
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetMetadata()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());
            string processId = "70ae24df1b7c9faa4f77c332";

            //Act
            MetadataModel model = metadata.GetMetadata(processId);

            if(model != null)
            {
                string message = "Model Id " + model.Id + ", Name " + model.Name + ", Version " + model.Version + ",  Created in " + model.Date;
                Assert.Pass("Result: " + message + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            Assert.Fail();
        }

        [Test]
        public void TestCreateMetadata()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());
            KeyId.SetKey();
            string id = KeyId.GetKey();
            MetadataModel model = new MetadataModel()
            {
                Id = id,
                Name = "Processo Teste",
                Version = 1,
                Date = DateTime.Now.ToLocalTime(),
                Branch = new List<string>() { "5ce95aab70eb31116c6ca8d6" },
                State = "5ceac39b5cef382144c73570",
                Field = new List<string>() { "05afb3f91c73ee7b43ffb9fa" }
            };

            //Act
            string result = metadata.CreateMetadata(model);

            if(Convert.ToInt32(result) == 201)
            {
                Assert.Pass("Result: Metadata process with id = " + id + ", was created with success");
            }
            else if(Convert.ToInt32(result) == 400)
            {
                Assert.Pass("Result: Metadata process with id = " + id + ", was not created");
            }
            Assert.Fail();
        }

        [Test]
        public void TestDeleteMetadata()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());
            string processId = "6e4e20ee05cbf9481eb1a4fe";  //1C564AE540C3FDEF06571EDD

            //Act
            string result = metadata.DeleteMetadata(processId);

            if (Convert.ToInt32(result) == 204)
            {
                Assert.Pass("Result: Metadata process with id = " + processId + ", was deleted with success");
            }
            else if (Convert.ToInt32(result) == 400)
            {
                Assert.Pass("Result: Metadata process with id = " + processId + ", was not deleted");
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetProcessByName()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());
            string processName = "P2";

            //Act
            List<MetadataModel> models = metadata.GetProcessByName(processName);

            if(models.Count > 0)
            {
                Assert.Pass("Result: List have " + models.Count + " metadata models");
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetProcessByVersion()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());
            string processName = "P2";
            int processVersion = 1;

            //Act
            MetadataModel model = metadata.GetProcessByVersion(processName, processVersion);

            if(model != null)
            {
                string message = "Model Id " + model.Id + ", Name " + model.Name + ", Version " + model.Version + ",  Created in " + model.Date;
                Assert.Pass("Result: " + message + ", Status Code: " + ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString());
            }
            Assert.Fail();
        }

        [Test]
        public void TestAddFieldToProcess()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());
            string processId= "6e4e20ee05cbf9481eb1a4fe";
            string fieldId = "1C564AE540C3FDEF06571EAA";

            //Act
            string result = metadata.AddFieldToProcess(processId, fieldId);

            if (Convert.ToInt32(result) == 201)
            {
                Assert.Pass("Result: Field with id = " + fieldId + ", was added to process " + processId);
            }
            else if (Convert.ToInt32(result) == 404)
            {
                Assert.Pass("Result: Field with id = " + fieldId + ", was not added to process " + processId);
            }
            Assert.Fail();
        }

        [Test]
        public void TestGetProcessFieldsID()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());
            string processId = "6e4e20ee05cbf9481eb1a4fe";

            //Act
            List<string> fields = metadata.GetProcessFieldsID(processId);

            if(fields.Count > 0)
            {
                string message = string.Empty;
                for(int i = 0; i < fields.Count; i++)
                {
                    if(i < fields.Count - 1)
                    {
                        message += fields[i] + ", ";
                    }
                    else
                    {
                        message += fields[i] + "]";
                    }
                }

                Assert.Pass("Result: Process with id " + processId + ", have the follow fields [" + message);
            }
            Assert.Fail();
        }

        [Test]
        public void TestReplaceMetadata()
        {
            //Arrange
            manager.DatabaseConnection();
            metadata.SetDatabase(manager.GetDatabase());
            string processId = "6e4e20ee05cbf9481eb1a4fe";
            MetadataModel model = new MetadataModel()
            {
                Id = processId,
                Name = "Processo Teste",
                Version = 1,
                Date = DateTime.Now.ToLocalTime(),
                Branch = new List<string>() { "5ce95aab70eb31116c6ca8d6" },
                State = "5ceac39b5cef382144c73570",
                Field = new List<string>() { "5CFB840F7AA621021219548A" }
            };

            //Act
            string result = metadata.ReplaceMetadata(processId, model);

            if (Convert.ToInt32(result) == 204)
            {
                Assert.Pass("Result: Metadata process with id = " + processId + ", was updated with success");
            }
            else if (Convert.ToInt32(result) == 404)
            {
                Assert.Pass("Result: Metadata process with id = " + processId + ", was not updated");
            }
            Assert.Fail();
        }
    }
}