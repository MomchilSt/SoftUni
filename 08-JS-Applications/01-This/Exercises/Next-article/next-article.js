function getArticleGenerator(articles) {
    let inputArr = [...articles];
  
    return function() {
      if (inputArr.length > 0) {
        let div = document.querySelector("#content");
        let article = document.createElement("article");
  
        article.textContent = inputArr.shift();
  
        div.appendChild(article);
      }
    };
  }