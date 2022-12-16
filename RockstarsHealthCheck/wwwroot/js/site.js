let slideIndex = 1;
let maxSlideIndex = 0;
let endX = 0;
let startX = 0;
const SlideMargin = 50;
let slides = document.getElementsByClassName("mySlides");
showSlides(slideIndex);


function touchStart(e) {
    startX += e.changedTouches[0].clientX;
}

function touchEnd(e) {
    endX += e.changedTouches[0].clientX;

    if (startX < endX - SlideMargin) {
        plusSlides(-2);
    } else if (startX > endX + SlideMargin) {
        plus2Slides(0);
    }

    startX = 0;
    endX = 0;
}


function StartUp() {
    GetGifs();
}

async function GetGifs() {
    let gifs = document.getElementsByName("gif");
    for (let i = 0; i < gifs.length; i++) {
        const response = await fetch("https://api.giphy.com/v1/gifs/random?api_key=AV3OpotCEox1VQQnKr44JSJDqitTMi7I&limit=1");
        var data = await response.json();
        gifs[i].src = data.data.images.original.url;
    }
}

async function GetEndGif() {
    let gifs = document.getElementsByName("gif");
    const response = await fetch("https://api.giphy.com/v1/gifs/search?q=party&api_key=AV3OpotCEox1VQQnKr44JSJDqitTMi7I&limit=1");
    var data = await response.json();
    gifs[0].src = data.data[0].images.original.url;
}

function plus2Slides(n) {
    if (slideIndex % 2 == 0) {
        let r = document.getElementById((slideIndex / 2) + "-div")
        if (r != null) {
            let i = r.querySelectorAll("input");
            if (i.length == 5) {
                if (i[1].checked || i[2].checked || i[3].checked) {
                    n += 2;
                } else if (i[0].checked || i[4].checked) {
                    n++;
                }
            } else if (i.length == 3) {
                console.log(i[0].checked + " | " + i[1].checked + " | " + i[2].checked);
                if (i[0].checked || i[1].checked || i[2].checked) {
                    n += 2;
                }
            }
        }
    } else {
        n += 1;
    }
    showSlides(slideIndex += n);
}

function plusSlides(n) {
    if (slideIndex == 1) {
        showSlides(slideIndex += 1);
    } else if (slideIndex == 2 && n < 0) {
    } else if (slideIndex % 2 != 0 && n < 0) {
    } else if (!slideIndex == slides.length && n > 0) {
    } else {
        showSlides(slideIndex += n);
    }
}

function showSlides(n) {
    if (n > slides.length) { slideIndex = 1; }
    if (n < 1) { slideIndex = slides.length; }
    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slides[slideIndex - 1].style.display = "flex";
    if (slideIndex > maxSlideIndex) {
        maxSlideIndex = slideIndex;
    }
    fixDots();
}

function showSlide(n) {
    if (n > maxSlideIndex) {
        alert("Please fill in the previous questions!");
    } else {
        showSlides(slideIndex = n);
    }
}

function doNothing() {
    console.log("doing nothing");
}

function fixDots() {
    let d = document.getElementsByName("dot");

    for (let i = 0; i < d.length; i++) {
        d[i].style.backgroundColor = "gray";
        d[i].style.borderColor = "gray";
        d[i].setAttribute("onClick", "javascript: showSlide(" + (i + 1) + "*2);");
        d[i].setAttribute("cursor", "pointer");
    }
    for (let i = d.length - 1; i >= (Math.floor(maxSlideIndex / 2)); i--) {
        d[i].style.backgroundColor = "#2d2e33";
        d[i].setAttribute("cursor", "default");
    }

    d[(Math.floor(slideIndex / 2) - 1)].style.backgroundColor = "white"
    d[(Math.floor(slideIndex / 2) - 1)].style.borderColor = "white"
}

function ShowHideDiv() {
    var r = document.getElementById((slideIndex/2) + "-div").querySelectorAll("input");
    var l = document.getElementById((slideIndex/2) + "-div").querySelectorAll("label");

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

    plus2Slides(0);
}

function ChangeArrowColor(trend) {
    let up = document.getElementById(slideIndex/2 + "-TrendUp");
    let equal = document.getElementById(slideIndex/2 + "-TrendEqual");
    let down = document.getElementById(slideIndex/2 + "-TrendDown");

    up.style.fill = "gray";
    equal.style.fill = "gray";
    down.style.fill = "gray";

    if (trend == "u")
    {
        up.style.fill = "green";
    }
    else if (trend == "d")
    {
        down.style.fill = "red";
    }
    else
    {
        equal.style.fill = "orange";
    }

    plus2Slides(0);
}