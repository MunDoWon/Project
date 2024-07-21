var WeatherslideIndex = 1;

var WeatherSlideTimer;

var slideshowContainer;

window.addEventListener("load", function () {
    WeathershowSlides(WeatherslideIndex);
    WeatherSlideTimer = setInterval(function () {
        WeatherPlusSlides(1)
    }, 2000);

    //화살표 부분을 마우스 멈춤/재개 부분으로 유지하려면 아래 줄을 주석 처리하세요
    slideshowContainer = document.getElementsByClassName('Weather-slideshow-inner')[0];

    //화살표 부분을 마우스 일시 중지/재개에 유지하려면 아래 줄의 주석 처리를 제거하세요
    // slideshowContainer = document.getElementsByClassName('Weather-slideshow-container')[0];

    slideshowContainer.addEventListener('mouseenter', pause)
    slideshowContainer.addEventListener('mouseleave', resume)
})

// 다음 그리고 이전 컨트롤
function WeatherPlusSlides(n) {
    clearInterval(WeatherSlideTimer);
    if (n < 0) {
        WeathershowSlides(WeatherslideIndex -= 1);
    } else {
        WeathershowSlides(WeatherslideIndex += 1);
    }

    //화살표 부분을 PAUSE/RESUME의 일부로 유지하려면 아래 줄을 주석 처리하세요

    if (n === -1) {
        WeatherSlideTimer = setInterval(function () {
            WeatherPlusSlides(n + 2)
        }, 2000);
    } else {
        WeatherSlideTimer = setInterval(function () {
            WeatherPlusSlides(n + 1)
        }, 2000);
    }
}

//현재 슬라이드를 제어하고 필요한 경우 간격을 재설정합니다
function WeatherCurrentSlide(n) {
    clearInterval(WeatherSlideTimer);
    WeatherSlideTimer = setInterval(function () {
        WeatherPlusSlides(n + 1)
    }, 2000);
    WeathershowSlides(WeatherslideIndex = n);
}

function WeathershowSlides(n) {
    var i;
    var slides = document.getElementsByClassName("Weather-Slides");
    var Weatherdots = document.getElementsByClassName("Weather-dot");
    if (n > slides.length) {
        WeatherslideIndex = 1
    }
    if (n < 1) {
        WeatherslideIndex = slides.length
    }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < Weatherdots.length; i++) {
        Weatherdots[i].className = Weatherdots[i].className.replace(" active", "");
    }
    slides[WeatherslideIndex - 1].style.display = "block";
    Weatherdots[WeatherslideIndex - 1].className += " active";
}

pause = () => {
    clearInterval(WeatherSlideTimer);
}

resume = () => {
    clearInterval(WeatherSlideTimer);
    WeatherSlideTimer = setInterval(function () {
        WeatherPlusSlides(WeatherslideIndex)
    }, 2000);
}
// 현재 선택된 도트의 인덱스를 저장하는 변수
var currentDotIndex = 1;

// 도트 클릭 이벤트 처리 함수
function WeatherCurrentSlide(dotIndex) {
    // 현재 선택된 도트의 색상을 원래 색상으로 복원
    var currentDot = document.querySelector('.Weather-dot:nth-child(' + currentDotIndex + ')');
    currentDot.style.backgroundColor = '';

    // 클릭한 도트의 색상을 검은색으로 변경
    var clickedDot = document.querySelector('.Weather-dot:nth-child(' + dotIndex + ')');
    clickedDot.style.backgroundColor = 'black';

    // 현재 선택된 도트 인덱스 갱신
    currentDotIndex = dotIndex;

    // 슬라이드 이동 로직을 호출 (WeatherPlusSlides 함수 내에서 슬라이드를 이동하도록 구현)
    WeatherPlusSlides(dotIndex - currentDotIndex);
}

// 슬라이드 이동 시 도트 색상 업데이트 함수
function UpdateDotColor(slideIndex) {
    // 현재 선택된 도트의 색상을 원래 색상으로 복원
    var currentDot = document.querySelector('.Weather-dot:nth-child(' + currentDotIndex + ')');
    currentDot.style.backgroundColor = '';

    // 해당 슬라이드에 해당하는 도트의 색상을 검은색으로 변경
    var targetDot = document.querySelector('.Weather-dot:nth-child(' + slideIndex + ')');
    targetDot.style.backgroundColor = 'black';

    // 현재 선택된 도트 인덱스 갱신
    currentDotIndex = slideIndex;
}