
const usUnits = document.querySelector("#usUnits");
const metricUnits = document.querySelector("#metricUnits");

const heightUS = document.querySelector("#heightUS");
const heightMetric = document.querySelector("#heightMetric");

const weigthUS = document.querySelector("#weightUS");
const weigthKG = document.querySelector("#weightKG");



metricUnits.addEventListener("click", function(){
    heightUS.classList.add("inactive");
    heightMetric.classList.remove("inactive");

    weigthUS.classList.add("inactive");
    weigthKG.classList.remove("inactive");
});

usUnits.addEventListener("click", function(){
    heightUS.classList.remove("inactive");
    heightMetric.classList.add("inactive");

    weigthUS.classList.remove("inactive");
    weigthKG.classList.add("inactive");
});