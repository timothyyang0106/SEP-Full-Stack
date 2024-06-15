/* 
    C# Assignment JS
    SEP Full Stack
    Timothy Yang
    June 15th, 2024
*/

/*
    Write a function checkEmailId(str) that returns true if str contains '@' and ‘.’, otherwise false. Make sure
    '@' must come before '.' and there must be some characters between '@' and '.'
    The function must be case-insensitive:
*/

function checkEmailId(str) {
    // Regular expression to check for the correct pattern
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/i;
    return regex.test(str);
}

// Example usage:
console.log(checkEmailId("example@example.com")); // true
console.log(checkEmailId("example.example.com")); // false
console.log(checkEmailId("example@com")); // false
console.log(checkEmailId("example@.com")); // false
console.log(checkEmailId("example@com.")); // false
console.log(checkEmailId("example@comcom")); // false
console.log(checkEmailId("example@com.com")); // true
console.log(checkEmailId("EXAMPLE@EXAMPLE.COM")); // true
