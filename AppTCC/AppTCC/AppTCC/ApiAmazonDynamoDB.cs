using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC
{
    public class ApiAmazonDynamoDB : AmazonDynamoDBClient
    {
        public void CreateTable()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            string tableName = "ProductCatalog";

            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = new List<AttributeDefinition>()
                {
                    new AttributeDefinition
                    {
                      AttributeName = "Id",
                      AttributeType = "N"
                    }
                },
                KeySchema = new List<KeySchemaElement>()
                {
                    new KeySchemaElement
                    {
                        AttributeName = "Id",
                        KeyType = "HASH"  //Partition key
                    }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 10,
                    WriteCapacityUnits = 5
                }
            };

            var response = client.CreateTableAsync(request);
        }

        public void UpdateTable()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            string tableName = "ExampleTable";

            var request = new UpdateTableRequest()
            {
                TableName = tableName,
                ProvisionedThroughput = new ProvisionedThroughput()
                {
                    // Provide new values.
                    ReadCapacityUnits = 20,
                    WriteCapacityUnits = 10
                }
            };
            var response = client.UpdateTableAsync(request);
        }

        public void DeleteTable()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            string tableName = "ExampleTable";

            var request = new DeleteTableRequest { TableName = tableName };
            var response = client.DeleteTableAsync(request);
        }

        public void ListTables()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();

            // Initial value for the first page of table names.
            string lastEvaluatedTableName = null;
            do
            {
                // Create a request object to specify optional parameters.
                var request = new ListTablesRequest
                {
                    Limit = 10, // Page size.
                    ExclusiveStartTableName = lastEvaluatedTableName
                };

                var response = client.ListTablesAsync(request);
                /*ListTablesResult result = response.ListTablesResult;
                foreach (string name in result.TableNames)
                    Console.WriteLine(name);

                lastEvaluatedTableName = result.LastEvaluatedTableName;*/

            } while (lastEvaluatedTableName != null);
        }
    }
}
