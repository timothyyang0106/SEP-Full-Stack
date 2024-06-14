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

