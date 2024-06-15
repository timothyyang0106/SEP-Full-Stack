/* C# Assignment JS
    SEP Full Stack
    Timothy Yang
    June 15th, 2024
*/

// Create a function multiplyNumeric(obj) that multiplies all numeric properties of obj by 2

function multiplyNumeric(obj) {
    for (let key in obj) {
        if (typeof obj[key] === 'number') {
            obj[key] *= 2;
        }
    }
}

// Example usage:
let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

multiplyNumeric(menu);

console.log(menu);

// Expected Output:
// {
//     width: 400,
//     height: 600,
//     title: "My menu"
// }