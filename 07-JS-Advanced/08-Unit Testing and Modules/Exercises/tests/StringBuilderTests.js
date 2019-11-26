const StringBuilder = require("../StringBuilder.js");
let expect = require("chai").expect;

describe("StringBuilder", function(){
    it("Can be instantiated with a passed in string argument or without anythin", function(){
        let expected = new StringBuilder();
        expect(expected).to.be.a("object");
    });

    it("Can be instantiated with a passed in string argument", function(){
        let expected = new StringBuilder("Test");
        expect(expected._stringArray).to.have.lengthOf(4);
    });

    it("append(string)", function(){
        let expected = new StringBuilder();
        expected.append("Demo");
        expect(expected._stringArray).to.have.lengthOf(4);
    });

    it("append(string) - test if appends at the end", function(){
        let expected = new StringBuilder("te");
        expected.append("Demo");
        let lastIndex = 
        expect(expected._stringArray[2]).to.equal("D");
    });

    it("prepend(string)", function(){
        let expected = new StringBuilder("Te");
        expected.prepend("Demo");
        expect(expected._stringArray).to.have.lengthOf(6);
    });

    it("prepend(string) - test if prepends at the start", function(){
        let expected = new StringBuilder("Te");
        expected.prepend("Demo");
        expect(expected._stringArray[0]).to.equal("D");
    });

    it("insertAt(string, index)", function(){
        let expected = new StringBuilder("Te");
        expected.insertAt("D", 1);
        expect(expected._stringArray[1]).to.equal("D");
    });

    it("insertAt(string, index)", function(){
        let expected = new StringBuilder("Te");
        expected.insertAt("D", 1);
        expect(expected._stringArray).to.equal(["T", "D", "e"]);
    });

    it("remove(startIndex, length)", function(){
        let expected = new StringBuilder("Test");
        expected.remove(1, 1);
        expect(expected._stringArray[1]).to.equal("s");
    });

    it("toString()", function(){
        let expected = new StringBuilder("Test");
        expect(expected.toString()).to.equal("Test");
    });

    it("Test for different type of arguments as input", function(){
        expect(() => new StringBuilder(1)).to.Throw("Argument must be string");
    });

    it("Test for different type of arguments as input", function(){
        expect(() => new StringBuilder(true)).to.Throw("Argument must be string");
    });

    it("Test for wrong argument in insertAt(string, index)", function(){
        let expected = new StringBuilder("Te");
        expect(() => expected.insertAt(1, 1)).to.throw("Argument must be string");
    });

    it("Test for wrong argument in append(string)", function(){
        let expected = new StringBuilder("Te");
        expect(() => expected.append(1)).to.throw("Argument must be string");
    });

    it("Test for wrong argument in prepend(string)", function(){
        let expected = new StringBuilder("Te");
        expect(() => expected.prepend(1)).to.throw("Argument must be string");
    });

    it('StringBuilder type', function () {
        expect(typeof StringBuilder).to.equal('function');
    });
    it('should have the correct function properties', function () {
        assert.isFunction(StringBuilder.prototype.append);
        assert.isFunction(StringBuilder.prototype.prepend);
        assert.isFunction(StringBuilder.prototype.insertAt);
        assert.isFunction(StringBuilder.prototype.remove);
        assert.isFunction(StringBuilder.prototype.toString);
    });
    it('full test', function () {
        let str = new StringBuilder('hello');
        str.append(', there');
        str.prepend('User, ');
        str.insertAt('woop', 5);
        str.remove(6, 3);
        expect(str.toString()).to.equal('User,w hello, there');
    });
});