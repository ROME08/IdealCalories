// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const bmi_inputs = document.getElementsByClassName("numDecimal");
console.log(bmi_inputs);
bmi_inputs[0].addEventListener("keypress", numberHandler);



function numberHandler(e){

    if (e.keyCode >= 48 && e.keyCode <= 57) {
        return true;
    } else {
        e.stopPropagation();
        e.preventDefault();
        return true;
    }

}
