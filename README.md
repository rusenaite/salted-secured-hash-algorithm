# Salted Hash Algorithm

### How does it work?

Situation: in a database of users, only hashed passwords (without salt) makes it easier for hackers to guess the password from hashed value. If the same password occurs between 2 or more users, their hashed password will be the same:


| Username | String to be hashed | Hashed value = SHA256 |
| --- | --- | --- |
| user1 | password123 | 57DB1253B68B6802B59A969F750FA32B60CB5CC8A3CB19B87DAC28F541DC4E2A |
| user2 | password123 | 57DB1253B68B6802B59A969F750FA32B60CB5CC8A3CB19B87DAC28F541DC4E2A |


Now, we can avoid this situation by using salt strings: for each password we can generate a unique random string of any length and add it to the existing password's end - like an extention. After that, the process is the same as before - hash the given string and store the value - just this time duplicate passwords won't be the same:


| Username | Salt value | String to be hashed | Hashed value = SHA256 (Password + Salt value) |
| --- | --- | --- | --- |
| user1 | E1F53135E559C253 | password123E1F53135E559C253 | 72AE25495A7981C40622D49F9A52E4F1565C90F048F59027BD9C8C8900D5C3D8 |
| user2 | 84B03D034B409D4E | password12384B03D034B409D4E | B4B6603ABC670967E99C7E7F1389E40CD16E78AD38EB1468EC2AA1E62B8BED3A |


Example tables from [wikipedia.org](https://en.wikipedia.org/wiki/Salt_(cryptography)).


### Built With
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [.NET 5](https://docs.microsoft.com/en-gb/dotnet/)
* MSTest

### Usage
To the downloaded repository add .TXT format file of username-password pairs. Each pair is in a new line and whitespace in between pair's items. Look at .TXT file example below:

```
newUser1 VerySafePassword123
IAmAnotherUser I1Have2A3Password4Too5
user111 qwerty987654321
```

After adding the data file, run the program and the result file named `hashed_log_info.txt` will be created in your program's main folder.

### More about Salted Hash Algorithm

* [Salt in cryptography](https://en.wikipedia.org/wiki/Salt_(cryptography))
* [Hashing Algorithms and Security](https://www.youtube.com/watch?v=b4b8ktEV4Bg)

### Acknowledgments
* [Cryptographic hash functions](https://stackoverflow.com/questions/800685/which-cryptographic-hash-function-should-i-choose)
* [String Hash Functions](https://www.godo.dev/tutorials/csharp-string-hash/)
