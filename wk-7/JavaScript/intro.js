 // now that I'm inside the script tags i am using javascript.
            // this is a comment.
            
            // JavaScript is UNRELATED TO JAVA!

            // JS is weakly typed, that allows us to declare a variable, and then change it's type later.
            // It's not as loosly typed as Bash, but not so strontly typed as C#.

            // In JS, we can use numbers!
            let x = 5; // remember in JS to use ; as your end-thought/section/action character.
            // let is one way that we can declare a variable

            var y = 6; // var is another way to declare a variable.
            let z = Infinity;
            x = 3 * 6;
            y = 1 / 0; // we can actually get infinity values from a calculation!
            z = NaN // this is a special value that represents a variable/object that is not a number.
            z = 'asdf' - 5; // this results in Nan.


            // Boolean operators : testing for a ture/false condition

            x = 3 == 3; // "==" is the equality operator, it checks if the values are equal.
            x = 3 != 2 // "!=" is the inequality operator, it checks if the values are not equal.
            x = 3 > 2 // ">" is the greater than operator, it checks if the value on the left is greater than the value on the right.
            x = 3 < 2 // ">" is the less than operator, it checks if the value on the left is less than the value on the right.
            x = 3 >= 2 // ">=" is the greater than or equal to operator, it checks if the value on the left is greater than or equal to the value on the right.
            x = 3 <= 2 // ">=" is the less than or equal to operator, it checks if the value on the left is less than or equal to the value on the right.
            //&& // "&&" is the logical AND operator, it checks if both values are true.
            //|| // "||" is the logical OR operator, it checks if either value is true.


            // Strings

            x = 'hello'; // this is a string.
            x = "hello"; // this is also a string.
            x = `as"df\'`;

            // JS can accept multip-line strings! use "back-tick" (under the ~ )
            x = `asf
            asdf
            asdf`;
           
            // JS can perform template literal (string interpolation)
            x = `3 + 3 == ${3 + 3}`;


            // Console.Log()
            // the console of your browser is where you can see the output of your code.

            console.log('Hello World!');
            console.log(x);


            // Objects in JS

            x = {}; // this is an object literal.
            console.log(x);
            x.name = 'Fred'; // this is how you add a property to an object.
            
            console.log(x);
            delete x.name; // this is how you delete a property from an object.
            console.log(x);

            x = {
                name: 'Fred',
                'properties can have spaces in their names': 5,
                3: 5
            };
            console.log(x);
            console.log(x.name);
            console.log(x[3]);
            console.log(x['properties can have spaces in their names']);
            x['name of'] = "Amin";
            console.log(x['name of']);
            x.newProperty = "Rich";
            console.log(x.newProperty);


            // Undefined 
            // special data type with only one posible value, undefined.
            // if you don't pass something for a fucntion parameter, it will be undefined.
            // if you don't return a value from a function, it will be undefined.

            x = undefined;


            // Null
            // special data type with only one posible value, null.
            // null represents missing data.
            // typeof says null is an object, wrongly.

            x = null;
            console.log(x);
            console.log(typeof x);


            // Functions
            // functions are of object type, but typeof calls them functions. (for historical reasons)
            x = function ()
            {
                console.log('hello');
            }
            x();
            // functions can accept and return data similar to how we are familiar in C#.

            // arrow functions are similar to lambda expressions in C#.
            x = () => {
                console.log('Hi there!');
            }
            x();

            x = a => a + a;

           console.log( x(2));
           console.log( x("hi"));








