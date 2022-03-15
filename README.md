# Coologs
A .NET Core library making it easier to write colorful prints !  

This library provides a single method, `Coologs.Print()`.  

### Usage
- Specify colors with color tags like so: `Coologs.Print("<blue>A blue line here...");`  
Note: the closure `</color>` tag is optionnal, as long as you don't want to reset the color.
- You can escape the tag, by doubling the first `<` tag character like so: `Coologs.Print("<<blue>This will appear normally");` -> "\<blue>This will appear normally"
- You don't need to close any tag before changing color: 
`Coologs.Print("<red>A red sentence but a <blue>blue<red> word."); // Writes the whole sentence in red, excepts the 'blue' word.`
- You can easily reset console's color to default with the closure tag `</color>` or simply `</>`.

About color's tag names:
- The colors' names are **case-insensitive**
- The colors' names available correspond to the vanilla `ConsoleColor` colors enum, *this means there's no need to update the library if new colors are added / removed*
- If an incorrect color's name is given, the library doesn't raise any error, and will just print the raw specified piece of input.
