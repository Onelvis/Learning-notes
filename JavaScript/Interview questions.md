# JavasScript interview questions answered

## 1. What is Event delegation?
> Event delagation occurs when you attach a **event listener** to a DOM element, and then all of it's decendants will fire that event.

```javascript
function handleChange(event){
    // track your change
    // this time on e.target
    console.log(event.target);
}

let el = document.getElementById('form');
el.addEventListener('change', handleChange);
```

## 2. What's the difference between `target` and  `currentTarget`?
>The `currentTarget` is the element in wich the **listener** was attached to, and `target` is the actual element that triggered the **event**. 
  
## 3. Explain why the  following doesn't work as an IIFE
  
```javascript
function foo(){
    // i'm not doing it...
}();
```

> Because the function declaration should be inside parenthesis:

```javascript
(function foo(){
    // Ok i will...
})();
```
  
## 4. Explain the difference on the usage of 
  
```javascript
function foo(){
    //i am a function definition
};

let foo = function() {
    // i am function expression
};
```
> MDN - An expression is any valid unit of code that resolves to a value.
  
## 5. Explaing hoisting
  
> All variables and function declarations are "Hoisted" or moved to the "Top" of the code at compile time. It actually means that they are **assigned in memory** first.

## What's the difference between a variable that is: `null`, `undefined` or `undeclared`?

>`undeclared`: a variable that was not declared.<br>`undefined` (`falsy`): Something that doesn't have a value. <br>`null` (`falsy`): has a value, the `null` value
```javascript
// undeclared
const bar = foo + 1; //foo is undeclared

// undefined
let foo; // foo is currently undefined
const ump; // Uncaught SyntaxError: Missing initializer in const declaration.

// null
let nothing = null; // There you go, a null thing
```
  
## 6. How would you go about checking for any of these states?

`undefined`
```javascript
let b;
(b === undefined); //true boolean;
```
  
`null`
```javascript
let b = null;
(b === null) // true boolean
```