let slideIndex = 1;
let slides = document.getElementsByClassName("mySlides");
showSlides(slideIndex);

var xDown = null;
var yDown = null;

function getTouches(evt) {
    return evt.touches ||             // browser API
        evt.originalEvent.touches; // jQuery
}

function handleTouchStart(evt) {
    const firstTouch = getTouches(evt)[0];
    xDown = firstTouch.clientX;
    yDown = firstTouch.clientY;
};

function handleTouchMove(evt) {
    if (!xDown || !yDown) {
        return;
    }

    var xUp = evt.touches[0].clientX;
    var yUp = evt.touches[0].clientY;

    var xDiff = xDown - xUp;
    var yDiff = yDown - yUp;

    if (Math.abs(xDiff) > Math.abs(yDiff)) {
        if (xDiff > 0) {
            if (slideIndex % 2 != 0) {
                plusSlides(1);
            }
        } else {
            if (slideIndex % 2 == 0) {
                plusSlides(-2);
            }
        }
    }

    xDown = null;
    yDown = null;
}

function StartUp() {
    GetGifs();
    SetUpDots();
}

async function GetGifs() {
    let gifs = document.getElementsByName("gif");
    for (let i = 0; i < gifs.length; i++) {
        const response = await fetch("https://api.giphy.com/v1/gifs/random?api_key=AV3OpotCEox1VQQnKr44JSJDqitTMi7I&limit=1");
        var data = await response.json();
        gifs[i].src = data.data.images.original.url;
    }
}

function SetUpDots() {
    let dots = document.getElementsByClassName("dot");

    for (i = 0; i < dots.length; i++) {
        dots[i].width = x;
        dots[i].height = x;
    }
}

async function GetEndGif() {
    let gifs = document.getElementsByName("gif");
    const response = await fetch("https://api.giphy.com/v1/gifs/search?q=party&api_key=AV3OpotCEox1VQQnKr44JSJDqitTMi7I&limit=1");
    var data = await response.json();
    gifs[0].src = data.data[0].images.original.url;
}

function plus2Slides(n, id) {
    let r = document.getElementById(id + "-div")
    if (r != null) {
        let i = r.querySelectorAll("input");
        if (i[1].checked || i[2].checked || i[3].checked) {
            n += 2;
        } else if (i[0].checked || i[4].checked) {
            n++;
        }
    }
    console.log(n);
    showSlides(slideIndex += n);
}

function plusSlides(n) {
    if (slideIndex == 1) {
        showSlides(slideIndex += 1);
    } else if (slideIndex == 2 && n < 0) {
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

function fixDots() {
    let d = document.getElementsByName("dot");

    for (let i = 0; i < d.length; i++) {
        d[i].style.backgroundColor = "gray";
    }
    d[(Math.floor(slideIndex / 2) - 1)].style.backgroundColor = "white";
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

    if (slideIndex % 2 == 0) {
        plus2Slides(0, id);
    }
}

function ChangeArrowColor(id, trend) {
    let up = document.getElementById(id + "-TrendUp");
    let equal = document.getElementById(id + "-TrendEqual");
    let down = document.getElementById(id + "-TrendDown");

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
}