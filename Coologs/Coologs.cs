using System;
namespace Coologs;

public static class Coologs
{
    /// <summary>
    /// Prints a text and applies foreground changes with &lt;colors&gt; tags in it.
    /// </summary>
    /// <param name="text_code">Text desired with print styling code</param>
    /// <param name="endwith">Character at the end of the print -- default is a line break</param>
    /// <example>Coologs.Print("&lt;red&gt;Red text<blue> Blue text</blue> Normal text");</example>
    /// <remarks>You can escape the character '&lt;' with '&lt;' (Example: '&lt;&lt;test&gt;'</remarks>
    public static void Print(string text_code, string endwith = "\n")
    {
        bool parsing_tag = false;
        string tag = "";
        
        for (int i = 0; i < text_code.Length; i++){
            if (parsing_tag){

                if (text_code[i] == '>'){
                    parsing_tag = false;
                    tag = tag.ToLower();
                    tag = tag.Substring(1);
                    
                    //  Check for escape character '<'
                    if (tag[0] == '<'){
                        Console.Write(tag + '>');   //  We rebuild inital escaped tag because we previously remove the last '>'
                        tag = "";
                        continue;
                    }
                
                    //  A </> closure tag resets color
                    if (tag[0] == '/'){
                        Console.ResetColor();
                    }
                    //  Sets desired color
                    else{
                        //  If the color code is incorrect, we don't raise any error -- just let it go
                        int color = getColor(tag);

                        if (color != -1){
                            Console.ForegroundColor = (ConsoleColor)color;
                        }
                    }

                    tag = "";
                    continue;
                }
                
                tag += text_code[i];
                continue;
            }
            
            if (text_code[i] == '<'){
                parsing_tag = true;
                tag += "<";
                continue;
            }
            
            Console.Write(text_code[i]);
        }
        
        Console.Write(endwith);
        Console.ResetColor();
    }

    /// <summary>
    /// Returns color's int code based on its string representation
    /// </summary>
    /// <param name="code">Color's string code</param>
    /// <remarks>Returns -1 if the input doesn't match any color.</remarks>
    private static int getColor(string code)
    {
        foreach (int i in Enum.GetValues(typeof(ConsoleColor)))
        {
            if (((ConsoleColor)i).ToString().ToLower() == code){
                return i;
            }
        }

        return -1;
    }
}
