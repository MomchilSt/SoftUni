let { expect } = require('chai');
let createCalculator = require("../AddSubtract");

describe("createCalculator()",() =>  {
    let calc;

    beforeEach(function () {
        calc = createCalculator();
    });

    it("should return 0 for get;",() =>  {
        let value = calc.get();
        expect(value).to.equal (0);
    });
    it("should return 5 after add(2); add(3);",() =>  {
        calc.add(2);
        calc.add(3);
        let value = calc.get();
        expect(value).to.equal (5);
    });
    it("shoul return -5 after subtract(3); subtract(2)",() =>  {
        calc.subtract(3);
        calc.subtract(2);
        let value = calc.get();
        expect(value).to.equal (-5);
    });
    it("should return 4.2 after add(5.3); subtract(1.1);",() =>  {
        calc.add(5.3);
        calc.subtract(1.1);
        let value = calc.get();
        expect(value).to.equal (5.3 - 1.1);
    });
    it("should return 2 after add(10); subtract('7'); add('-2'); subtract(-1)",() =>  {
        calc.add(10);
        calc.subtract('7');
        calc.add('-2');
        calc.subtract(-1);
        let value = calc.get();
        expect(value).to.equal (2);
    });
    it("should return NaN for add(string)",() =>  {
        calc.add('hello');
        let value = calc.get();
        expect(value).to.be.NaN;
    });
    it("should return NanN for subtarct(string)",() =>  {
        calc.subtract('hello');
        let value = calc.get();
        expect(value).to.be.NaN;
    });
});