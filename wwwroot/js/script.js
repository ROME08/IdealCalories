
const usUnits = document.querySelector("#usUnits");
const metricUnits = document.querySelector("#metricUnits");

const heightUS = document.querySelector("#heightUS");
const heightMetric = document.querySelector("#heightMetric");

const weigthSpan = document.querySelector("#weightUnits");

metricUnits.addEventListener("click", function(){
    heightUS.classList.add("inactive");
    heightMetric.classList.remove("inactive");
    weigthSpan.textContent = "kg";
});

usUnits.addEventListener("click", function(){
    heightUS.classList.remove("inactive");
    heightMetric.classList.add("inactive");
    weigthSpan.textContent = "lbs";
});