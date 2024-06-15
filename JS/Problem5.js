/* 
    C# Assignment JS
    SEP Full Stack
    Timothy Yang
    June 15th, 2024
*/

/*
    Let’s try 5 array operations.
    Create an array styles with items “James” and “Brennie”.
    Append “Robert” to the end.

    Replace the value in the middle by “Calvin”. Your code for finding the middle value should work for any
    arrays with odd length.
    Remove the first value of the array and show it.
    Prepend Rose and Regal to the array.
    James, Brennie
    James, Brennie, Robert
    James, Calvin, Robert
    Calvin, Robert
    Rose, Regal, Calvin, Robert
*/


// Step 1: Create an array styles with items “James” and “Brennie”.
let styles = ["James", "Brennie"];
console.log(styles); // ["James", "Brennie"]

// Step 2: Append “Robert” to the end.
styles.push("Robert");
console.log(styles); // ["James", "Brennie", "Robert"]

// Step 3: Replace the value in the middle by “Calvin”.
let middleIndex = Math.floor(styles.length / 2);
styles[middleIndex] = "Calvin";
console.log(styles); // ["James", "Calvin", "Robert"]

// Step 4: Remove the first value of the array and show it.
let firstValue = styles.shift();
console.log(firstValue); // "James"
console.log(styles); // ["Calvin", "Robert"]

// Step 5: Prepend "Rose" and "Regal" to the array.
styles.unshift("Rose", "Regal");
console.log(styles); // ["Rose", "Regal", "Calvin", "Robert"]
