// See https://aka.ms/new-console-template for more information
using Mapper;

string name = "Tom";
int age = 18;
dynamic variable1 = new { name,age };
MapperBase mapper = new Mapper.Mapper();
Person []people = mapper.ConvertArray<dynamic,Person>(new[] { variable1},parser
    => parser.FromPropertyManualy((dynamic from, Person to) => 
    {
    to.Age = variable1.age;
    to.Name = variable1.name;
    }));
Console.WriteLine("Hello mapper {0}!", people[0].Name);
