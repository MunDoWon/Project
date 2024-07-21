// Radio.js

// Symptom 라디오 버튼 변경 이벤트 핸들러
$("input[type='radio'][name='Symptom']").change(function () {
    var selectedSymptom = $("input[type='radio'][name='Symptom']:checked").val();
    var InCntInput = $("input[name='InCnt']");
    var OutCntInput = $("input[name='OutCnt']");

    // Symptom 값에 따라 InCnt와 OutCnt 변경
    if (selectedSymptom === "복통" || selectedSymptom === "두통" || selectedSymptom === "고열") {
        InCntInput.val(1);
        OutCntInput.val(0);
    } else {
        InCntInput.val(0);
        OutCntInput.val(1);
    }
});

//<script>
//                // 복통 라디오 버튼 클릭 이벤트 리스너 추가
//    document.getElementById("radio1").addEventListener("click", function () {
//        // 복통 라디오 버튼이 클릭되었을 때 실행할 코드 작성
//        console.log("복통 라디오 버튼이 클릭되었습니다.");

//    // InCnt를 1로, OutCnt를 0으로 설정
//    document.getElementById("InCnt").value = 1;
//    document.getElementById("OutCnt").value = 0;
//                });

//    // 두통 라디오 버튼 클릭 이벤트 리스너 추가
//    document.getElementById("radio2").addEventListener("click", function () {
//        // 두통 라디오 버튼이 클릭되었을 때 실행할 코드 작성
//        console.log("두통 라디오 버튼이 클릭되었습니다.");

//    // InCnt를 1로, OutCnt를 0으로 설정
//    document.getElementById("InCnt").value = 1;
//    document.getElementById("OutCnt").value = 0;
//                });

//    // 고열 라디오 버튼 클릭 이벤트 리스너 추가
//    document.getElementById("radio3").addEventListener("click", function () {
//        // 고열 라디오 버튼이 클릭되었을 때 실행할 코드 작성
//        console.log("고열 라디오 버튼이 클릭되었습니다.");

//    // InCnt를 1로, OutCnt를 0으로 설정
//    document.getElementById("InCnt").value = 1;
//    document.getElementById("OutCnt").value = 0;
//                });
//</script>