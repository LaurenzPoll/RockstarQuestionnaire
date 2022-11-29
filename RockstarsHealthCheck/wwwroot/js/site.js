
let slideIndex = 1;
let slides = document.getElementsByClassName("mySlides");
showSlides(slideIndex);

$(document).ready(function () {
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});

async function GetGifs() {
    let gifs = document.getElementsByName("gif");
    for (let i = 0; i < gifs.length; i++) {
        const response = await fetch("https://api.giphy.com/v1/gifs/random?api_key=AV3OpotCEox1VQQnKr44JSJDqitTMi7I&limit=1");
        var data = await response.json();
        console.log(data);
        gifs[i].src = data.data.images.original.url;
    }
}

async function GetEndGif() {
    let gifs = document.getElementsByName("gif");
    console.log(gifs);
    const response = await fetch("https://api.giphy.com/v1/gifs/search?q=party&api_key=AV3OpotCEox1VQQnKr44JSJDqitTMi7I&limit=1");
    /*const response = await fetch("https://api.giphy.com/v1/gifs/random?api_key=AV3OpotCEox1VQQnKr44JSJDqitTMi7I&limit=1");*/
    var data = await response.json();
    console.log(data);
    gifs[0].src = data.data.url;
}

function plus2Slides(n, id) {
    let r = document.getElementById(id + "-div")
    if (r != null) {
        let i = r.querySelectorAll("input");
        if (i[1].checked || i[2].checked || i[3].checked) {
            n++;
        }
    } else {
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

function ChangeArrowColor(id, trend) {
    let up = document.getElementById(id + "-TrendUp");
    let equal = document.getElementById(id + "-TrendEqual");
    let down = document.getElementById(id + "-TrendDown");

    console.log(trend);

    up.style.fill = "gray";
    equal.style.fill = "gray";
    down.style.fill = "gray";

    if (trend == "u")
    {
        console.log("changed up to green");
        up.style.fill = "green";
    }
    else if (trend == "d")
    {
        console.log("changed down to red");
        down.style.fill = "red";
    }
    else
    {
        console.log("changed equal to orange");
        equal.style.fill = "orange";
    }
}