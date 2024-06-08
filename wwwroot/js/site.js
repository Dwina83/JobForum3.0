// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function displayText() {
    console.log("Button clicked!");
    var text = document.getElementById("textField");
    text.innerHTML = "Admin has been notified!";
    text.style.display = "block";

    setTimeout(function () {
        text.innerHTML = "";
    }, 7000)
}

function sendMessage() {
    var text1 = document.getElementById("textContent");
    text1.innerHTML = "Message was sent successfully!";
    text1.style.display = "block";

    setTimeout1(function () {
        text.innerHTML = "";
    }, 7000)
}

