const isOddOrEven = require("../EvenOrOdd.js");

let expect = require("chai").expect;
let assert = require("chai").assert;

describe("isOddOrEven function", function() {
    it("Pass number to return undefined.", function(){
        let actual = isOddOrEven(2); //undefined

        assert.equal(actual, undefined);
    })

    it("Pass object to return undefined.", function(){
        let actual = isOddOrEven({name: "pesho"}); //undefined

        assert.equal(actual, undefined);
    })

    it("Pass even string to return correct result.", function(){
        let actual = isOddOrEven("bird");

        assert.equal(actual, "even");
    })
    it("Pass odd string to return correct result.", function(){
        let actual = isOddOrEven("odd");

        assert.equal(actual, "odd");
    })
});