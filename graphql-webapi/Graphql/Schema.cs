using GraphQL.Types;
using GraphQL;
using graphql_webapi.Database;

namespace graphql_webapi.Graphql
{
    public class MySchema
    {
        private ISchema _schema { get; set; }

        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }

        public MySchema()
        {
            this._schema = Schema.For(@"
                type Book   {
                    id: ID,
                    name: String,
                    published: Date,
                    Author: Author
                }

                type Author {
                    id: ID,
                    name: String,
                    books: [Book]
                }

                type Mutation {
                    addAuthor(name: String): Author
                }

                type Query {
                    books: [Book]
                    author(id: ID): Author,
                    authors: [Author]
                    hello: String
                }
            ", _ =>
             {
                _.Types.Include<Query>();
                _.Types.Include<Mutation>();
             });
            }
             
        }
    }

