// GUID - Globally Unique Identifier (UUID - Universal Unique Identifer)

Guid id = Guid.NewGuid();
string userId = Guid.NewGuid().ToString();

Console.WriteLine(id);
Console.WriteLine(userId);
Console.ReadKey();