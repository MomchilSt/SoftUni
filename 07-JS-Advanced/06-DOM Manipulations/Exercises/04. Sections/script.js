function create(words) {

   for (let i = 0; i < words.length; i++) {
      let div = document.createElement('div');
      let paragraph = document.createElement('p');
      paragraph.textContent = words[i];
      paragraph.style.display = 'none';
      div.appendChild(paragraph);
      div.addEventListener('click', showText);

      document.getElementById('content').appendChild(div);
   }

   function showText(){
      if (this.getElementsByTagName('p')[0].style.display = 'none') {
         this.getElementsByTagName('p')[0].style.display = 'block'
      }
      else if (this.getElementsByTagName('p')[0].style.display = 'block') {
         this.getElementsByTagName('p')[0].style.display = 'none'
      }
   }
}