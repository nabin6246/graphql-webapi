using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using graphql_webapi.Graphql;

namespace graphql_webapi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphqlController:ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var myschema = new MySchema();
            var schema = myschema.GraphQLSchema;
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            return Ok(result);
        }
    }
}
