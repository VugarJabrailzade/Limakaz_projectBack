var checkKargoTrue = document.querySelectorAll(".custom-control-input")
var priceInput = document.querySelector(".price-input")
var kargoPrice = document.getElementById("olke-daxili-kargo")


checkKargoTrue.forEach((radio)=>{
    radio.addEventListener("click", (e)=>{
        var targetValue = e.target.value
        if(targetValue == "true"){
            console.log("salam")
            kargoPrice.disabled = false
            console.log(priceInput)
        }
        else{
            kargoPrice.disabled = true
            console.log("sagol")
        }
    })
})


var newLinkBtn = document.querySelector(".link-button")
var cardBody = document.querySelector(".tab-content")
var fullCardBody = document.querySelector(".order-card-body");
var cardContaner = document.querySelector(".extraTabContent");
var trtapPane = document.getElementById("1")
console.log(trtapPane)
var tabpane = document.querySelectorAll(".tab-pane")




newLinkBtn.addEventListener("click", (e) => {
    e.preventDefault();
    
    tabpane.forEach((element) => {
        if (element.classList.contains("active")) {
            var tabContent = trtapPane.innerHTML;
            cardContaner.innerHTML = tabContent;
        }
    });
});


var paymentInputSidebar = document.querySelectorAll(".custom-payment-input")
var paymentBtn = document.querySelector(".payment-btn")

paymentInputSidebar.forEach((inputs) =>{
    inputs.addEventListener("click", (e)=>{
        var selectedValue = e.target.value
        if(selectedValue == 1 || selectedValue == 2 || selectedValue == 3){
            paymentBtn.disabled = false
            paymentBtn.classList.add('btnPointer')
        }
        else{
            paymentBtn.disabled = true
        }
    })
})

// TURKEY PRICE PERCENT CALCULATION
var productPriceTr = document.querySelector(".product-priceTr");
var pricePercentTr = document.querySelector(".product-price-percentTr")
var sideBarTotalPrice = document.querySelector(".payment-total-price");



productPriceTr.addEventListener("input", (e) => {
    e.preventDefault();

    // Input deyeri
    var inputValue = parseFloat(e.target.value);
    console.log(inputValue)

    if (isNaN(inputValue)) {
        inputValue = 0;
    }

    var values = inputValue;
    var percentPrice = (values * 5) / 100;
    var lastTotalTryPrice = values + percentPrice;
    console.log(lastTotalTryPrice)

    
    pricePercentTr.value = lastTotalTryPrice
    sideBarTotalPrice.innerHTML = lastTotalTryPrice + " TRY";
});

// AMERIKA PRICE PERCENT CALCULATION
var productPriceUsd = document.querySelector(".product-price-usd");
var pricePercentUsd = document.querySelector(".price-percent-usd")
var sideBarTotalPrice = document.querySelector(".payment-total-price");

productPriceUsd.addEventListener("input", (e) => {
    e.preventDefault();

    // Input deyeri
    var inputValue = parseFloat(e.target.value);
    console.log(inputValue)

    if (isNaN(inputValue)) {
        inputValue = 0;
    }

    var values = inputValue;
    var percentPrice = (values * 7) / 100;
    var lastTotalTryPrice = values + percentPrice;
    console.log(lastTotalTryPrice)

    
    pricePercentUsd.value = lastTotalTryPrice
    sideBarTotalPrice.innerHTML = lastTotalTryPrice + " USD";
});


var tabs= document.querySelector(".nav-tabs")
var liElements = tabs.querySelectorAll("li");
var sideBarpayment = document.querySelector(".payment-group")
var payments = sideBarpayment.querySelectorAll(".check-custom-payment")
var sidebarUsd = document.querySelectorAll(".check-payment-usd");


var tabLink = document.querySelectorAll(".tabs-head")

tabLink.forEach((tag)=>{
    tag.addEventListener("click", (e)=>{
        e.preventDefault();
        var selectedTag = e.target.text
        if(selectedTag === "Amerika"){
            sidebarUsd.forEach((element) =>{
                element.classList.add('sideBarUsd')
            })
        }
        if(selectedTag === "Türkiyə"){
            sidebarUsd.forEach((element) =>{
                element.classList.remove('sideBarUsd')
            })

        }
        

    })
})


// console.log(birinciLi)
// console.log(ikincili)
// if(birinciLi.classList.contains("active")){
//     console.log("dogru")
// }
// if(ikincili.classList.contains("active")){
//     console.log("heszad ")

// }

// liElements.forEach(function(li){
//     if(li.classList.contains("active")){
//         console.log("dogru")
//     }
//     else{
//         console.log("Bi siqeet")
//     }
// })