function createArticle() {
	let input = document.getElementById("createTitle");
	let textarea = document.getElementById("createContent");
	let articles = document.getElementById("articles");

	if (input === null || textarea === null || articles === null) {
		throw new Error("Something is wrong...");
	}

	let arcticle = document.createElement("article");
	let h3 = document.createElement("h3");
	let p = document.createElement("p");
	
	h3.innerHTML = input.value;
	p.innerHTML = textarea.value;
	
	article.appendChild(h3);
	article.appendChild(p);

	articles.appendChild(article);

	input.value = "";
	textarea.value = "";
}

const keyMap = {
	10: function(evt){
		createArticle();
	}
}

document.addEventListener('DOMContentLoaded', x => {
	document.querySelector("createArticleBtn").addEventListener('click', createArticle);
	document.addEventListener("keypress", function(evt){
		if (typeof keyMap[evt.keyCode] === "function") {
			keyMap[evt.keyCode](evt);
		}
	})
})