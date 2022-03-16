string[] arrayName = { "Kevin", "Dan", "Anu", "Kelly", "Trygg" };

string Nametwo = arrayName[ 2 ];
arrayName[ 1 ] = "Cam";

Array.Sort(arrayName);
Array.Reverse(arrayName);

//Enumerables
foreach ( string name in arrayName )
{
	Console.WriteLine( name );
}

int[] myNumbers = {3,9,12,5,10,23,7,14};

Array.Sort(myNumbers);

foreach ( int i in myNumbers )
{
    Console.WriteLine(i);
}