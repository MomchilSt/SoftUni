function solve() {
  let points = 0;
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let index = 0;
  let questions = document.getElementsByTagName('section');

  Array.from(document.querySelectorAll('.quiz-answer'))
  .map(x => x.addEventListener('click', function nextQuestion(e){
      if (correctAnswers.includes(e.target.innerHTML)) {
        debugger;
        points++;
      }
      questions[index].style.display = 'none';
      index++;

      index !== 3
          ? questions[index].style.display = 'block'
          : showResult(points);
    })
  );

  function showResult(correctAnswers){
    document.querySelector("#results").style.display = 'block';
    let text = '';
    points === 3
        ? text = 'You are recognized as top JavaScript fan!'
        : text = `You have ${points} right answers`;
    document.querySelector("#results > li > h1").textContent = text;
  }
}
