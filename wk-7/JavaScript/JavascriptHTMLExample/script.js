function myFunction() 
{
    console.log("myFunction is running");

    let testDiv = document.getElementById("testdiv"); 
    // get the div and creating an object in JS for us to interact with

    let newParagraph = document.createElement('p');
    // create a new object, that is a paragraph element.

    newParagraph.textContent = "this is a new paragraph";
    // set the context of the paragraph, giving it some data

    testDiv.append(newParagraph);
    // append the paragraph to the div
}

let counter = 0;
function countFunction()
{
    ++counter;
    console.log(counter);
}

// document.addEventListener("DOMContentLoaded", countFunction());

// DOMContentLoaded event fires as soon as all the elements are created on the page.
// even if they haven't fulluly loaded yet.
// When we use this, it doesn't really matter where you put the script in your HTML.
// Often it's put at the end of the HEAD.


document.addEventListener('DOMContentLoaded', function () { 
    //when the DOM loads, do this thing...
    
    let somethingAmazing = document.getElementById('button2'); 
    // create an object based on the button2 element

    somethingAmazing.addEventListener('click', () => { 
        // when the button is clicked...

        location.href = 'https://www.google.com/'; 
        // send a GET request to google.com, display the response in the current window/tab
    });


    let somethingLessAmazing = document.getElementById('button3'); 
    // create an object based on the button2 element

    somethingLessAmazing.addEventListener('click', () => { 
        // when the button is clicked...

        location.href = 'https://www.github.com/'; 
        // send a GET request to google.com, display the response in the current window/tab
    });
});