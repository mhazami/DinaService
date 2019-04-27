var myVar;
var myVar1;

function myFunction() {
    myVar = setTimeout(showPage, 2000);
    myVar = setTimeout(aos, 3000);

}

function showPage() {
    document.getElementById("atomo").style.display = "none";
    document.getElementById("myDiv").style.display = "block";

}   