<template>
  <div id="app">
      <div class="counter">
      <h1>
        {{countDown}}
      </h1>
    </div>
    <section class="memory-game">
      <div 
      v-bind:class="['memory-card', {flip: card.flipped}]"
      v-for="(card, index) in cards" 
      v-bind:key="card.key"  
      v-on:click="flipCard(index)"
      >
        <img class="front-face" 
        :src="card.imageUrl"
        :alt="card.type"
       
         />
        <img class="back-face" src="./assets/js-badge.svg" alt="JS Badge" />
      </div>
    </section>
  </div>
</template>

<script>

export default {
  data() {
    return {
      countDown: 60,
      guess: {},
      cards: [
            { type: "Aurelia", imageUrl: require('./assets/aurelia.svg'), flipped: false, key: 1 },
            { type: "Aurelia", imageUrl: require("./assets/aurelia.svg"), flipped: false, key: 2 },
            { type: "Vue", imageUrl: require("./assets/vue.svg"), flipped: false, key: 3 },
            { type: "Vue", imageUrl: require("./assets/vue.svg"), flipped: false, key: 4 },
            { type: "Angular", imageUrl: require("./assets/angular.svg"), flipped: false, key: 5 },
            { type: "Angular", imageUrl: require("./assets/angular.svg"), flipped: false, key: 6 },
            { type: "Ember", imageUrl: require("./assets/ember.svg"), flipped: false, key: 7 },
            { type: "Ember", imageUrl: require("./assets/ember.svg"), flipped: false, key: 8 },
            { type: "Backbone", imageUrl: require("./assets/backbone.svg"), flipped: false, key: 9 },
            { type: "Backbone", imageUrl: require("./assets/backbone.svg"), flipped: false, key: 10 },
            { type: "React", imageUrl: require("./assets/react.svg"), flipped: false, key: 11 },
            { type: "React", imageUrl: require("./assets/react.svg"), flipped: false, key: 12 },
        ]
    }
  },
  methods: {
    flipCard(index) { 
      let currentCard = this.cards[index];
      currentCard.flipped = !currentCard.flipped;
      if (this.guess.try !== 'first') {
        this.guess = { try: 'first', index}
      }
      else {
        this.guess = { try: 'second', index}
      }
     },
    flipNotMatchingCards(newIndex, oldIndex) {
      setTimeout(() => 
      this.cards[oldIndex].flipped = false, 600)

      setTimeout(() => 
      this.cards[newIndex].flipped = false, 600)
    }
  },
  created() {
    this.countDown;
    setInterval(() => {
      this.countDown--;
    }, 1000);

    this.cards.sort((a, b) => Math.random() - 0.5);
  },
  watch: {
    countDown(newValue) {
      if (newValue <= 0) {
        alert('Game over!');
      }
    },
    guess(newValue, oldValue) {
      if (newValue.try == 'second' && oldValue.try == "first") {
        if (this.cards[newValue.index].type != this.cards[oldValue.index].type) {
          this.flipNotMatchingCards(newValue.index, oldValue.index);
        }
      }
    }
  }
}
</script>

<style>
* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

body {
  height: 100vh;
  display: flex;
  background-image: linear-gradient(120deg, #d4fc79 0%, #96e6a1 100%);
}


#app {
  width: 100%;
  padding: 7%;
}
.memory-game {
  width: 640px;
  height: 640px;
  margin: auto;
  display: flex;
  flex-wrap: wrap;
  perspective: 1000px;
}

.memory-card {
  width: calc(25% - 10px);
  height: calc(33.333% - 10px);
  margin: 5px;
  position: relative;
  transform: scale(1);
  transform-style: preserve-3d;
  transition: transform .5s;
  box-shadow: 1px 1px 1px rgba(0,0,0,.3);
}

.disable-card {
  pointer-events: none;
}

.memory-card:active {
  transform: scale(0.97);
  transition: transform .2s;
}

.memory-card.flip {
  transform: rotateY(180deg);
}

.front-face,
.back-face {
  width: 100%;
  height: 100%;
  padding: 20px;
  position: absolute;
  border-radius: 5px;
  background: #FFF29E;
  backface-visibility: hidden;
}

.front-face {
  transform: rotateY(180deg);
}

.counter {
  position: absolute;
  top: 0px;
  right: 0px;
}
</style>
