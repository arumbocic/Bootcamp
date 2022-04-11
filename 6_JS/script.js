// BACK TO THE TOP BUTTON IMPLEMENTATION //

const mybutton = document.getElementById("myBtn");

window.onscroll = function() {scrollFunction()};

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }
}

function topFunction() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0; 
}

////////////////////////////////////////////

// CHANGING BACKGROUND/BODY COLOR IMPLEMENTATION //

const input = document.querySelector('.color-input');
const bodyColor = document.querySelector('body');

input.addEventListener("change", function() {
    bodyColor.style.backgroundColor  = input.value;
});

////////////////////////////////////////////

// WELCOME SCREEN IMPLEMENTATION //
// JOŠ NIJE GOTOVO //

const splash = document.querySelector('.splash');

document.addEventListener('DOMContentLoaded', (e)=>{
    setTimeout(()=>{
        splash.classList.add('display-none');
    }, 2000);
});

////////////////////////////////////////////
