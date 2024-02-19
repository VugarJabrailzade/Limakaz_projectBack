var showPaswordBtn = document.querySelector(".visibility-btn-password");
var passwordInput = document.getElementById("login-password");

showPaswordBtn.style.cursor = "pointer"

showPaswordBtn.addEventListener("click", (e)=>{
   e.preventDefault();
   var newPassValue = passwordInput.value.trim();
   if(newPassValue !== ""){
       if(passwordInput.type == "text"){
           passwordInput.type = "password"
       }
       else{
           passwordInput.type = "text"
    
       }
   }
})