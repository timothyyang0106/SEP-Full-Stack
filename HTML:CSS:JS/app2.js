//Object Literals
// Useful for one-time use, fast and convenient. But not great for multiple ppl
var Person = {firstName: "Karim", lastName: "Elaagamy", Age: 24, Location: 'Washington'}
console.log(Person);

// Function Constructors
function Guy(first = "default", last = "default", Age = 0, Location = "default"){
    this.firstName = first;
    this.lastName = last;
    this.Age = age;
    this.Location = location;
}

const defaultGuy = new Guy();
const Karim = new Guy("Karim", "Elagamy", 24, "Washington");
console.log(defaultGuy);
console.log(Karim);

// Object.Create method
const newPerson = Object.create(defaultGuy);
console.log(newPerson);
newPerson.firstname = "New First Name";
newPerson.lastName = "New Last Name"
newPerson.Age = Karim.Age;
newPerson.Location = Karim.Location;
console.log(newPerson);

// Class
class Car {
    constructor(Make, Model){
        this.Make = Make;
        this.Model = Model;
    }
    intro(){
        console.log("Hi, I'm a " + this.Make + " of type " + this.Model);
    }
}

const newCar = new Car("Ford", "Focus");
console.log(newCar);
newCar.intro()

// these are all the ways you can create an object in javascript
// there are other similarities in javascript and C#

// like inheritance

class Engine extends Car {
    constructor(Make, Model, Size){
        super(Make,Model);
        this.Size = Size;
    }
}

const specificCar = new Engine("Ford", "Mustang", "V8");
console.log(specificCar);

//Arrays
let Products = [
    {Name: "Laptop", Cost: 1000},
    {Name: "Monitor", Cost: 400},
    {Name: "Keyboard", Cost: 100}
]

console.log(Products);

var sum = Products[0].Cost + Products[1].Cost + Products[2].Cost;
console.log(sum);

console.log(Products[0]);

let Salaries = [1000, 1500, 2000];
console.log(Salaries);

//Change the Value of an Array Item
Salaries[2] = 1500;
console.log(Salaries);

//Add Item to end of Array
Salaries.push(500);
console.log(Salaries);
// push - add an item at the end of the array
// pop - remove the last item of the array
// think of it as a stack
// shift - shift is the one that removes the first item of the array
// splice - removes from the middle

Salaries.pop();

Salaries.shift();
Salaries.push(600, 700, 800, 900, 1000);

// Removes elements from the middle of an array
Salaries.splice(1,2); // removes the second and third element
console.log();

// the other way we can do this is for loops
function exampleName(){
    for (var i = 0; i < Salaries.length; i++){
        Salaries[i] += 1;
    }
}

exampleName();
console.log(Salaries);

// Iterate through all elements in object
for (let element in Salaries){
    // Sample code here
    // if element.inventory < 5, then slice it to remove it... things like that
}

const myBtn = document.getElementById("bgColor");

myBtn.addEventListener("click", () => {
    document.body.style.backgroundColor = "Green";
});

const resetButton = document.getElementById("clearForm");

resetButton.addEventListener("click", ()=> {
    document.getElementById("Email").value = "22";
    document.getElementById("Password").value = "11";
});

resetButton.addEventListener("click", ()=> {
    document.getElementById("Email").value = "";
    document.getElementById("Password").value = "";
});

// Local storage

localStorage.clear();

localStorage.setItem('firstItem', 'Strawberry Pancake');
console.log(localStorage.getItem('firstItem'));
localStorage.removeItem('firstItem');
console.log(localStorage);

// session storage

sessionStorage.clear();

sessionStorage.setItem('firstItem', 'Chocolate Waffle');
console.log(sessionStorage.getItem('firstItem'));
let x = 'Super Secret User Info';
sessionStorage.setItem('userInfo', btoa(x));
// use btoa to encrypt, and atob to decrypt
console.log(sessionStorage.getItem('userInfo'));
let y = atob(sessionStorage.getItem('userInfo'));
console.log(y);

//Cookies
document.cookie = "new_Sample_Cookie=This_is_our_cookie; expires=Thu 5 Sep 2024 12:00:00 UTC; path=/";
console.log(document.cookie);

//Get Current Date
var currentDate = new Date();
console.log(currentDate);

//Add days to current Date and Time

function addDays(date, days){
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}

currentDate = addDays(currentDate, 7);
console.log(currentDate);

//XMLHTTPRequest Get Request
var gReq = new XMLHttpRequest();
gReq.addEventListener('load', reqListener);
gReq.open("GET", "https://jsonplaceholder.typicode.com/posts");
gReq.send();
function reqListener(){
    console.log(this.responseText);
}

//XMLHTTP Request Post Request
var pReq = new XMLHttpRequest();
pReq.addEventListener('load', reqListener);
pReq.open("POST", "https://jsonplaceholder.typicode.come/posts");
pReq.send("title=Example POST Request&Body=Antra.com&userID=100"); // the id is primary key of the table, it's automatically generated, will let sql server generate this on its own

//FETCH API is the new way of doing this, and much simpler
fetch("https://jsonplaceholder.typicode.come/posts/10") // default is get requests
.then((response) => response.json()) // only executes if it succeeds, what we got would be response
.then((json) => console.log(json)); // once that succeeds, it goes into this one, and we get the json file so we can output it

//Fetch API POST Request
var z = {title: "Example Post Request in Fetch", body: "Antra.com", userId: 55};
fetch("https://jsonplaceholder.typicode.com/posts", {
    method: 'POST',
    body: JSON.stringify(z),
    headers: {
        'Content-type': 'application/json; charset=UTF-8'
    },
}).then((response) => response.json())
.then((json) => console.log(json));

// regular expression = for patttern matching
// to validate input
// like pw: need one lower case, 1 symbol, 1 number
function ValidateEmail(){
    var mailFormat = /^\w+([\.-]?w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var inputText = myForm.Email.value;
    if (inputText.value.match(mailFormat)){
        alert("Valid Email Address!");
        document.myForm.Email.focus();
        return true;
    }
    else {
        alert("You have entered an invalid Email Address!");
        document.myForm.Email.focus();
        return false;
    }
}

//regex101
// (click)=validateEmail in the html thingy

// promises
// promise vs callback
// asynchronus programming

// callback hell - if u have enough callbacks chained to each other, the code grows exponentionally and makes it difficult to read
// solution to that: promises

// promises are very common for client interviews
// do readings over tonight, the weekend, etc
// some questions to ask about promises:
// there's a big document that would be given later


let promise = new Promise(function (resolve, reject){
    fetch("https://jsonplaceholder.typicode.com/posts/10")
    .then((resolve) => {if (response.ok){
        resolve();
    } else {
        reject();
    }
    })
});

// promise.
//     then(function () {
//         console.log('Success, The request succeeded');
//     }).
    // catch(funciton () {
    //     console.log('Same error has occured');
    // });