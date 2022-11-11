
let slideIndex = 1;
let slides = document.getElementsByClassName("mySlides");
showSlides(slideIndex);

function plus2Slides(n, id) {
    let r = document.getElementById(id + "-div").querySelectorAll("input");
    if (r[1].checked || r[2].checked || r[3].checked) {
        n++;
    }
    showSlides(slideIndex += n);
    fixButtons(slideIndex + (n - 1));
}

function plusSlides(n) {
    showSlides(slideIndex += n);
    fixButtons(slideIndex + (n + 1));
}

function showSlides(n) {
    if (n > slides.length) { slideIndex = 1; }
    if (n < 1) { slideIndex = slides.length; }
    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slides[slideIndex - 1].style.display = "flex";
    fixDots();
}

function showSlide(n) {
    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex = n;
    slides[slideIndex - 1].style.display = "flex";
    fixDots();
}

function fixButtons(n) {
    let b = document.getElementsByName("button");
    let b2 = document.getElementsByName("button2");

    if (n == slides.length) {
        b.forEach(a => a.style.display = "flex");
        b2.forEach(a => a.style.display = "none");
    } else {
        b.forEach(a => a.style.display = "none");
        b2.forEach(a => a.style.display = "flex");
    }

    
}

function fixDots() {
    let d = document.getElementsByName("dot");

    for (let i = 0; i < d.length; i++) {
        d[i].style.backgroundColor = "gray";
    }
    d[(slideIndex/2)-1].style.backgroundColor = "white";
}

function ShowHideDiv(id) {
    var r = document.getElementById(id + "-div").querySelectorAll("input");
    var l = document.getElementById(id + "-div").querySelectorAll("label");

    var checked = -1;
    for (let i = 0; i < r.length; i++) {
        if (r[i].checked) {
            checked = i;
            break;
        }
    }
    for (let j = 0; j <= checked; j++) {
        l[j].innerHTML = "★";
    }
    for (let j = checked + 1; j < r.length; j++) {
        l[j].innerHTML = "☆";
    }

    fixButtons2(r)
}

function fixButtons2(r) {
    if (slideIndex == (slides.length - 1)) {
        for (let i = 0; i < r.length; i++) {
            if (r[i].checked) {
                checked = i;
                break;
            }
        }
        if (checked == 1 || checked == 2 || checked == 3) {
            fixButtons(slides.length)
        } else (
            fixButtons(slideIndex)
        )
    }
}