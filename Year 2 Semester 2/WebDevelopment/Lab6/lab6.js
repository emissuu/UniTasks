// === Task 1 ===
console.log("=== Task 1 ===");

let a = 10;
let b = 15;
console.log(`${a} + ${b} = ${a + b}`);
console.log(`${a} - ${b} = ${a - b}`);
console.log(`${a} * ${b} = ${a * b}`);
console.log(`${a} / ${b} = ${a / b}`);


// === Task 2 ===
console.log("\n=== Task 2 ===");

let firstName = "Soul",
    secondName = "Goodman";
let fullName = firstName + " " + secondName;
console.log("Hello, " + fullName + "!");


// === Task 3 ===
console.log("\n=== Task 3 ===");

let age = 18;
if (age >= 18)
    console.log("Access granted!");
else
    console.log("Access denied!");


// === Task 4 ===
console.log("\n=== Task 4 ===");

for (let i = 1; i < 11; i++)
    process.stdout.write(i + " ");


// === Task 5 ===
console.log("\n\n=== Task 5 ===");

function square(number) {
    return number * number;
}
console.log("Square of 5 is " + square(5));


// === Task 6 ===
console.log("\n=== Task 6 ===");

let fruits = ["apple", "pear", "orange"];
fruits.push("peach");
console.log(fruits);