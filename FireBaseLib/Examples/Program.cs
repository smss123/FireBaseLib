using System;
using FireBaseLib.FireBase.DataBase;
namespace Examples
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Instanciating with base URL  
            FirebaseDB firebaseDB = new FirebaseDB("{URL OF DATABASE HERE}");
            // Referring to Node with name "Teams"  
            FirebaseDB users = firebaseDB.Node("Users");

            var data = @"{  
'UserName':'samer',
'Password':'mypassword',
'Type':'Admin'
                          }";

            FirebaseResponse getResponse = users.Get();

            WriteLine(getResponse.Success);
            if (getResponse.Success)
                WriteLine(getResponse.JSONContent);
            WriteLine();

            WriteLine("PUT Request");
            FirebaseResponse putResponse = users.Put(data);
            WriteLine(putResponse.Success);
            WriteLine();

            WriteLine("POST Request");
            FirebaseResponse postResponse = users.Post(data);
            WriteLine(postResponse.Success);
            WriteLine();

            WriteLine("PATCH Request");
            FirebaseResponse patchResponse = users
                // Use of NodePath to refer path lnager than a single Node  
                .NodePath("users/M1")
                .Patch("{\"Type\":\"admin\"}");
            WriteLine(patchResponse.Success);
            WriteLine();

            WriteLine("DELETE Request");
            FirebaseResponse deleteResponse = users.Delete();
            WriteLine(deleteResponse.Success);
            WriteLine();

            WriteLine(users.ToString());
            ReadLine();


        }
    }
}
