// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
import MyThing from './modules/moduleOne.js';

console.log("Continueing the js file");
if (MyThing === "This is a thing and its going to be exported!") {
    console.log("It matches");
}
else {
    console.log("It don't match hun");
}